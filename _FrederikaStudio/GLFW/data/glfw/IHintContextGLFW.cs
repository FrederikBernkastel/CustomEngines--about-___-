namespace FrederikaStudio.GLFW;

public interface IHintContextGLFW
{
    public int VersionMajor { get; set; }
    public int VersionMinor { get; set; }
    public bool IsForwardCompat { get; set; }
    public bool IsDebug { get; set; }
    public ENGLFW.WindowHintRobustnessValueGLFW Robustness { get; set; }
    public ENGLFW.WindowHintOpenGLProfileValueGLFW OpenGLProfile { get; set; }
    public ENGLFW.WindowHintReleaseBehaviorValueGLFW ReleaseBehavior { get; set; }
}
