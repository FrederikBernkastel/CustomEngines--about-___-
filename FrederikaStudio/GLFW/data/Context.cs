namespace FrederikaStudio.GLFW;

public static class Context
{
    public static void Initialization(string path)
    {
        Library = new(path);
        NativeGLFW.Init();
    }
    public static _nGLFW.INative NativeGLFW => Library!.NativeGLFW;
    private static _nGLFW.Library? Library { get; set; }
    public static Func<string, IntPtr> GetProcAddress => Library!.NativeGLFW.GetProcAddress;
    public static void Dispose() => Library!.Dispose();
}
