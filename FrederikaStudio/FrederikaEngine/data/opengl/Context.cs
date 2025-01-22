namespace FrederikaStudio.OpenGL;

public static class Context
{
    public static void Initialization(Func<string, IntPtr> func)
    {
        OpenGL = _nOpenGL.IOpenGL_4_5.CreateOpenGL_4_5(func);
    }
    private static _nOpenGL.IOpenGL_4_5? OpenGL { get; set; }
    public static _nOpenGL.IOpenGL_4_5 NativeOpenGL => OpenGL!;
}
