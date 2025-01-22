namespace FrederikaStudio.OpenGL;

public static class Debuging
{
    private static bool Flag { get; set; }

    public static void Initialization(bool OUTPUT_SYNCHRONOUS = true, IntPtr useParam = default)
    {
        if (Flag)
            return;
        Context.NativeOpenGL.Enable(_nOpenGL.EnableCap.DebugOutput);
        if (OUTPUT_SYNCHRONOUS)
            Context.NativeOpenGL.Enable(_nOpenGL.EnableCap.DebugOutputSynchronous);
        Context.NativeOpenGL.DebugMessageCallback(MessageCallback, useParam);
        Flag = true;
        static void MessageCallback(
            _nOpenGL.DebugSource source, _nOpenGL.DebugType type, uint id,
            _nOpenGL.DebugSeverity severity, uint length, _UnsafeWork.PointerArray<byte> message, IntPtr userParam)
        {
            if (id == 131169 || id == 131185 || id == 131218 || id == 131204)
                return;

            string source_str = source switch
            {
                _nOpenGL.DebugSource.DebugSourceApi => "API",
                _nOpenGL.DebugSource.DebugSourceWindowSystem => "WINDOW SYSTEM",
                _nOpenGL.DebugSource.DebugSourceShaderCompiler => "SHADER COMPILER",
                _nOpenGL.DebugSource.DebugSourceThirdParty => "THIRD PARTY",
                _nOpenGL.DebugSource.DebugSourceApplication => "APPLICATION",
                _nOpenGL.DebugSource.DebugSourceOther => "OTHER",
                _ => "UNKNOWN",
            };
            string type_str = type switch
            {
                _nOpenGL.DebugType.DebugTypeError => "ERROR",
                _nOpenGL.DebugType.DebugTypeDeprecatedBehavior => "DEPRECATED_BEHAVIOR",
                _nOpenGL.DebugType.DebugTypeUndefinedBehavior => "UNDEFINED_BEHAVIOR",
                _nOpenGL.DebugType.DebugTypePortability => "PORTABILITY",
                _nOpenGL.DebugType.DebugTypePerformance => "PERFORMANCE",
                _nOpenGL.DebugType.DebugTypeMarker => "MARKER",
                _nOpenGL.DebugType.DebugTypeOther => "OTHER",
                _nOpenGL.DebugType.DebugTypePopGroup => "POP_GROUP",
                _nOpenGL.DebugType.DebugTypePushGroup => "PUSH_GROUP",
                _ => "UNKNOWN",
            };
            string severity_str = severity switch
            {
                _nOpenGL.DebugSeverity.DebugSeverityNotification => "NOTIFICATION",
                _nOpenGL.DebugSeverity.DebugSeverityLow => "LOW",
                _nOpenGL.DebugSeverity.DebugSeverityMedium => "MEDIUM",
                _nOpenGL.DebugSeverity.DebugSeverityHigh => "HIGH",
                _ => "UNKNOWN",
            };
            Console.WriteLine(
                $"Debug message ({id}): {_UnsafeWork.ExtensionUnsafe.GetString(message, (int)length)}\nSource: " +
                $"{source_str}\nType: {type_str}\nSeverity: {severity_str}");
            throw new Exception("<See console error message>");
        }
    }
}
