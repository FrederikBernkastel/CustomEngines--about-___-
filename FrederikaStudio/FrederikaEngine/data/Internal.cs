namespace FrederikaStudio.FrederikaEngine;

internal static class Librarys
{
    private static _nGLFW.IGLFW NativeGLFW { get; set; }
    private static _nGLFW.Window Window { get; set; }

    public static _nGLFW.INativeGLFW GLFW { get; private set; }
    public static _nOpenGL.IOpenGL_4_5 OpenGL { get; private set; }

    public static void Initialization()
    {
        NativeGLFW = _nGLFW.IGLFW.CreateGLFW(@"D:\code\resources\lib\glfw_native.dll");

        GLFW = NativeGLFW.GLFW;
        GLFW.Init();

        GLFW.WindowHint(_nGLFW.WindowHintInt.VersionMajor, 4);
        GLFW.WindowHint(_nGLFW.WindowHintInt.VersionMinor, 5);

        GLFW.WindowHint(_nGLFW.WindowHintBool.Visible, false);
        Window = GLFW.CreateWindow(1, 1, "", default, default);
        GLFW.MakeContextCurrent(Window);
        OpenGL = _nOpenGL.IOpenGL_4_5.CreateOpenGL_4_5(GLFW.GetProcAddress);
        GLFW.WindowHint(_nGLFW.WindowHintBool.Visible, true);
    }
    public static void Dispose()
    {
        GLFW.DestroyWindow(Window);
        NativeGLFW.Dispose();
    }
}
