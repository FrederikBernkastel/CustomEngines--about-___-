namespace FrederikaStudio.RenderEngine;

public sealed class RenderEngine
{
    public _GLFW.Window MainFramebuffer { get; }
    
    public RenderEngine()
    {
        _GLFW.Library.Initialization();
        _GLFW.Debuging.Initialization();
        _GLFW.Monitor.Initialization();

        _GLFW.Hint.DefaultHint();
        _GLFW.Hint.VersionMajor = 4;
        _GLFW.Hint.VersionMinor = 5;
        _GLFW.Hint.Visible = false;

        MainFramebuffer = new(700, 700, "HelloWorld");
        MainFramebuffer.MakeContextCurrent();

        _Veldrid.Library.Initialization(_GLFW.Library.GetProcAddress);
        _Veldrid.Debuging.Initialization();
    }

    public void Dispose()
    {
        MainFramebuffer.Dispose();
        _GLFW.Library.Dispose();
    }
}
