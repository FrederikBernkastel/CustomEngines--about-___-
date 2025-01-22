namespace FrederikaStudio.GLFW;

public static class Debuging
{
    private static bool Flag { get; set; }
    
    public static void Initialization()
    {
        if (Flag)
            return;
        Library.GLFW.SetErrorCallback(ErrorCallback);
        Flag = true;
        static void ErrorCallback(_nGLFW.Errors error, string description)
        {
            string source_str = error switch
            {
                _nGLFW.Errors.ApiUnavailable => "ApiUnavailable",
                _nGLFW.Errors.ContextNoError => "ContextNoError",
                _nGLFW.Errors.FormatUnavailable => "FormatUnavailable",
                _nGLFW.Errors.InvalidValue => "InvalidValue",
                _nGLFW.Errors.NoCurrentContext => "NoCurrentContext",
                _nGLFW.Errors.NoWindowContext => "NoWindowContext",
                _nGLFW.Errors.OutOfMemory => "OutOfMemory",
                _nGLFW.Errors.PlatformError => "PlatformError",
                _nGLFW.Errors.VersionUnavailable => "VersionUnavailable",
                _ => "UNKNOWN",
            };
            Console.WriteLine($"Debug message: {source_str} || {description}");
            throw new Exception("<See console error message>");
        }
    }
}
