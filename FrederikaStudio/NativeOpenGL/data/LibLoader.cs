namespace FrederikaStudio.OpenGL.Native;

public static class LibLoader
{
    internal static T Load<T>(Func<string, IntPtr> GetProcAddress, Func<string, string> MethodNameToFunctionName) where T : class
    {
        if (!typeof(T).IsInterface)
            throw new Exception($"Type T must be an interface. {typeof(T)} is not an interface.");
        var typeBuilder =
            AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Assembly.GetCallingAssembly().GetName().Name!), AssemblyBuilderAccess.Run)
            .DefineDynamicModule(Assembly.GetCallingAssembly().GetName().Name!)
            .DefineType("Native", TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public);
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
            var procAddress = GetProcAddress(MethodNameToFunctionName(method.Name));
            if (procAddress == IntPtr.Zero || 
                procAddress == new IntPtr(0x1) || 
                procAddress == new IntPtr(0x2) || 
                procAddress == new IntPtr(0x3) || 
                procAddress == new IntPtr(-1))
                throw new Exception("Unable to load function " + method.Name);
            var generator = methodBuilder.GetILGenerator();
            for (int i = 0; i < parameters.Length; ++i)
                generator.Emit(OpCodes.Ldarg, i + 1);
            generator.Emit(OpCodes.Ldc_I8, procAddress.ToInt64());
            var returnsString = method.ReturnType == typeof(string);
            generator.EmitCalli(
                OpCodes.Calli,
                CallingConvention.Cdecl,
                method.ReturnType == typeof(string) ? typeof(IntPtr) : method.ReturnType,
                types);
            if (returnsString)
                generator.Emit(OpCodes.Call, typeof(LibLoader).GetMethod(nameof(GetString))!);
            generator.Emit(OpCodes.Ret);
        }
        return (T)Activator.CreateInstance(typeBuilder.CreateType()!)!;
    }
    public static string GetString(IntPtr str) => str == IntPtr.Zero ? string.Empty : Marshal.PtrToStringUTF8(str)!;
}