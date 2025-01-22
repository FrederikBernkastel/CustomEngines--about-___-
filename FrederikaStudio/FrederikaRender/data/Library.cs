#define GLFW_DEBUG
#define OPENGL_DEBUG

namespace FrederikaStudio;

[_Core.InvokeStaticCtor]
public static class Library
{
    private static _nGLFW.IGLFW Lib { get; }
    internal static _nOpenGL.IOpenGL_4_5 OpenGL { get; }
    internal static _nGLFW.INativeGLFW GLFW { get; }

    static Library()
    {
        #region Initialization GLFW

        Lib = _nGLFW.IGLFW.CreateGLFW(@"D:\code\resources\lib\glfw_native.dll");
        GLFW = Lib.GLFW;
        GLFW.Init();

#if GLFW_DEBUG
        _GLFW.Debuging.Initialization();
#endif

        _GLFW.IWindow.DefaultWindow = _GLFW.FactoryWindow.CreateDefaultWindow();

        #endregion

        #region Initialization OpenGL

        OpenGL = _nOpenGL.IOpenGL_4_5.CreateOpenGL_4_5(GLFW.GetProcAddress);

#if OPENGL_DEBUG
        _OpenGL.Debuging.Initialization();
#endif

        #endregion
    }

    public static void Dispose()
    {
        Lib.Dispose();
    }
}
