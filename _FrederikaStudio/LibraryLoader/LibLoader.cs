using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace FrederikaStudio.LibraryLoader;

public static class SLL
{
    public readonly record struct ContextThread(Func<string, IntPtr> GetProcAddress, Func<string, string> MethodNameToFunctionName);
    public readonly record struct LibraryThread(string LibraryName, Func<string, string> MethodNameToFunctionName);
}
public static class WinLoaderLL
{
    [DllImport("kernel32", CharSet = CharSet.Ansi)]
    public static extern IntPtr LoadLibrary(string dllToLoad);
    [DllImport("kernel32", CharSet = CharSet.Ansi)]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
    [DllImport("kernel32")]
    public static extern bool FreeLibrary(IntPtr hModule);
}
public static class LibLoader
{
    public static T Load<T>(SLL.LibraryThread libraryThread, bool ispublic) where T : class, IDisposable
    {
        if (!typeof(T).IsInterface)
            throw new Exception($"Type T must be an interface. {typeof(T)} is not an interface.");
        var libraryHandle = WinLoaderLL.LoadLibrary(libraryThread.LibraryName);
        var typeBuilder =
            AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Assembly.GetCallingAssembly().GetName().Name!), AssemblyBuilderAccess.Run)
            .DefineDynamicModule(Assembly.GetCallingAssembly().GetName().Name!)
            .DefineType("Native",
            ispublic ? TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public :
            TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.NotPublic);
        var methodAttributes = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
        CreateDisposeMethod(typeBuilder, libraryHandle, methodAttributes);
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
            var procAddress = WinLoaderLL.GetProcAddress(libraryHandle, libraryThread.MethodNameToFunctionName(method.Name));
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
                generator.Emit(OpCodes.Call, typeof(LibLoader).GetMethod(nameof(GetString))!);
            generator.Emit(OpCodes.Ret);
        }
        return (T)Activator.CreateInstance(typeBuilder.CreateType()!)!;
    }
    public static T Load<T>(SLL.ContextThread contextThread, bool ispublic) where T : class
    {
        if (!typeof(T).IsInterface)
            throw new Exception($"Type T must be an interface. {typeof(T)} is not an interface.");
        var typeBuilder =
            AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Assembly.GetCallingAssembly().GetName().Name!), AssemblyBuilderAccess.Run)
            .DefineDynamicModule(Assembly.GetCallingAssembly().GetName().Name!)
            .DefineType("Native",
            ispublic ? TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public :
            TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.NotPublic);
        var methodAttributes = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
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
            var procAddress = contextThread.GetProcAddress(contextThread.MethodNameToFunctionName(method.Name));
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
                generator.Emit(OpCodes.Call, typeof(LibLoader).GetMethod(nameof(GetString))!);
            generator.Emit(OpCodes.Ret);
        }
        return (T)Activator.CreateInstance(typeBuilder.CreateType()!)!;
    }
    public static T Load<T>(SLL.ContextThread contextThread, SLL.LibraryThread libraryThread, bool ispublic) where T : class
    {
        if (!typeof(T).IsInterface)
            throw new Exception($"Type T must be an interface. {typeof(T)} is not an interface.");
        var libraryHandle = WinLoaderLL.LoadLibrary(libraryThread.LibraryName);
        var typeBuilder =
            AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Assembly.GetCallingAssembly().GetName().Name!), AssemblyBuilderAccess.Run)
            .DefineDynamicModule(Assembly.GetCallingAssembly().GetName().Name!)
            .DefineType("Native",
            ispublic ? TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public :
            TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.NotPublic);
        var methodAttributes = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
        CreateDisposeMethod(typeBuilder, libraryHandle, methodAttributes);
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
            var procAddress = contextThread.GetProcAddress(contextThread.MethodNameToFunctionName(method.Name));
            if (procAddress == IntPtr.Zero)
            {
                procAddress = WinLoaderLL.GetProcAddress(libraryHandle, libraryThread.MethodNameToFunctionName(method.Name));
                if (procAddress == IntPtr.Zero)
                    throw new Exception("Unable to load function " + method.Name);
            }
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
                generator.Emit(OpCodes.Call, typeof(LibLoader).GetMethod(nameof(GetString))!);
            generator.Emit(OpCodes.Ret);
        }
        return WinLoaderLL.FreeLibrary(libraryHandle) ? (T)Activator.CreateInstance(typeBuilder.CreateType()!)! : throw new Exception();
    }
    public static string GetString(IntPtr str) => str == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(str)!;
    private static void CreateDisposeMethod(TypeBuilder typeBuilder, IntPtr libraryHandle, MethodAttributes methodAttributes)
    {
        var methodBuilder = typeBuilder.DefineMethod(nameof(IDisposable.Dispose), methodAttributes);
        typeBuilder.DefineMethodOverride(methodBuilder, typeof(IDisposable).GetMethod(nameof(IDisposable.Dispose))!);
        var generator = methodBuilder.GetILGenerator();
        generator.Emit(OpCodes.Ldc_I8, libraryHandle.ToInt64());
        generator.Emit(OpCodes.Newobj, typeof(IntPtr).GetConstructor(new Type[] { typeof(long) })!);
        generator.Emit(OpCodes.Call, typeof(WinLoaderLL).GetMethod(nameof(WinLoaderLL.FreeLibrary))!);
        generator.Emit(OpCodes.Pop);
        generator.Emit(OpCodes.Ret);
    }
}