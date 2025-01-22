namespace FrederikaStudio.GLFW;

public interface IHintWindowGLFW
{
    public bool Focus { get; set; }
    public bool Resizable { get; set; }
    public bool Visible { get; set; }
    public bool Decorate { get; set; }
    public bool AutoIconify { get; set; }
    public bool Floating { get; set; }
    public bool Maximize { get; set; }
    public bool CenterCursor { get; set; }
    public bool TransparentFrameBuffer { get; set; }
    public bool FocusOnShow { get; set; }
    public bool ScaleToMonitor { get; set; }
}
