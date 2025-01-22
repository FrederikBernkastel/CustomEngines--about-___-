using System.Runtime.InteropServices;
using System.Reflection;
using System.Reflection.Emit;

namespace FrederikaStudio.LibLoader;

public sealed class Library
{
    private IntPtr Handle { get; }

    public Library(string path) => Handle = WinLoader.LoadLibrary(path);
    ~Library() => Dispose();

    public T Load<T>(Func<string, string> converterName) where T : class
    {
        if (!typeof(T).IsInterface)
            throw new Exception($"Type T must be an interface. {typeof(T)} is not an interface.");
        var typeBuilder =
            AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Assembly.GetCallingAssembly().GetName().Name!), AssemblyBuilderAccess.Run)
            .DefineDynamicModule(Assembly.GetCallingAssembly().GetName().Name!)
            .DefineType("Native", TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public);
        var methodAttributes = 
            MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
        typeBuilder.AddInterfaceImplementation(typeof(T));
        typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
        foreach (MethodInfo method in typeof(T).GetMethods().Where(u => !u.IsStatic))
        {
            var parameters = method.GetParameters();
            var types = parameters.Select(p => p.ParameterType).ToArray();
            var methodBuilder = typeBuilder.DefineMethod(
                method.Name,
                methodAttributes,
                CallingConventions.HasThis,
                method.ReturnType,
                method.ReturnParameter.GetRequiredCustomModifiers(),
                method.ReturnParameter.GetOptionalCustomModifiers(),
                types,
                parameters.Select(p => p.GetRequiredCustomModifiers()).ToArray(),
                parameters.Select(p => p.GetOptionalCustomModifiers()).ToArray());
            typeBuilder.DefineMethodOverride(methodBuilder, method);
            var procAddress = WinLoader.GetProcAddress(Handle, converterName(method.Name));
            if (procAddress == IntPtr.Zero)
                throw new Exception("Unable to load function " + method.Name);
            var generator = methodBuilder.GetILGenerator();
            for (int i = 0; i < parameters.Length; ++i)
                generator.Emit(OpCodes.Ldarg, i + 1);
            generator.Emit(OpCodes.Ldc_I8, procAddress.ToInt64());
            var returnsString = method.ReturnType == typeof(string);
            generator.EmitCalli(
                OpCodes.Calli,
                CallingConvention.Cdecl,
                returnsString ? typeof(IntPtr) : method.ReturnType,
                types);
            if (returnsString)
                generator.Emit(OpCodes.Call, typeof(Library).GetMethod(nameof(GetString))!);
            generator.Emit(OpCodes.Ret);
        }
        return (T)Activator.CreateInstance(typeBuilder.CreateType()!)!;
    }

    public void Dispose() => WinLoader.FreeLibrary(Handle);
    public static string GetString(IntPtr str) => str == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(str)!;
}
internal static class WinLoader
{
    [DllImport("kernel32", CharSet = CharSet.Ansi)]
    public static extern IntPtr LoadLibrary(string dllToLoad);
    [DllImport("kernel32", CharSet = CharSet.Ansi)]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
    [DllImport("kernel32")]
    public static extern bool FreeLibrary(IntPtr hModule);
}
