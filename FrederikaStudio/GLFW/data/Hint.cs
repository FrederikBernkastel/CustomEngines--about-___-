namespace FrederikaStudio.GLFW;

public enum OptionContext
{
    IsForwardCompat = 2,
    IsDebug = 4,
    None = 8,
}
public enum OptionWindow
{
    Focus = 2,
    Resizable = 4,
    Visible = 8,
    Decorate = 16,
    AutoIconify = 32,
    Floating = 64,
    Maximize = 128,
    CenterCursor = 256,
    TransparentFrameBuffer = 512,
    FocusOnShow = 1024,
    ScaleToMonitor = 2048,
    None = 4096,
}
public enum OptionFramebuffer
{
    Stereo = 2,
    SrgbCapable = 4,
    DoubleBuffer = 8,
    None = 16,
}
public record StyleHintContext
{
    public _Math.Vector2D<int> VersionOpenGL { get; set; } = new(1, 0);
    public OptionContext ContextH { get; set; } = OptionContext.None;
    public _nGLFW.WindowHintRobustnessValue Robustness { get; set; } = (int)_nGLFW.WindowHintRobustnessValue.None;
    public _nGLFW.WindowHintOpenGLProfileValue OpenGLProfile { get; set; } = (int)_nGLFW.WindowHintOpenGLProfileValue.Any;
    public _nGLFW.WindowHintReleaseBehaviorValue ReleaseBehavior { get; set; } = (int)_nGLFW.WindowHintReleaseBehaviorValue.Any;

    internal void Update()
    {
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.VersionMajor, VersionOpenGL.X);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.VersionMinor, VersionOpenGL.Y);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.ForwardCompat,
            ContextH.HasFlag(OptionContext.IsForwardCompat));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.OpenglDebug,
            ContextH.HasFlag(OptionContext.IsDebug));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintRobustness.Robustness, Robustness);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintOpenGLProfile.OpenGLProfile, OpenGLProfile);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintReleaseBehavior.ReleaseBehavior, ReleaseBehavior);
    }
}
public record StyleHintWindow
{
    public OptionWindow WindowH { get; set; } =
        OptionWindow.Focus | OptionWindow.Resizable | OptionWindow.Visible | OptionWindow.Decorate | 
        OptionWindow.AutoIconify | OptionWindow.CenterCursor | OptionWindow.FocusOnShow;

    internal void Update()
    {
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Focus,
            WindowH.HasFlag(OptionWindow.Focus));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Resizable,
            WindowH.HasFlag(OptionWindow.Resizable));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Visible,
            WindowH.HasFlag(OptionWindow.Visible));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Decorate,
            WindowH.HasFlag(OptionWindow.Decorate));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.AutoIconify,
            WindowH.HasFlag(OptionWindow.AutoIconify));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Floating,
            WindowH.HasFlag(OptionWindow.Floating));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Maximized,
            WindowH.HasFlag(OptionWindow.Maximize));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.CenterCursor,
            WindowH.HasFlag(OptionWindow.CenterCursor));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.TransparentFrameBuffer,
            WindowH.HasFlag(OptionWindow.TransparentFrameBuffer));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.FocusOnShow,
            WindowH.HasFlag(OptionWindow.FocusOnShow));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.ScaleToMonitor,
            WindowH.HasFlag(OptionWindow.ScaleToMonitor));
    }
}
public record StyleHintMonitor
{
    public int RefreshRate { get; set; } = -1;

    internal void Update()
    {
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.RefreshRate, RefreshRate);
    }
}
public record StyleHintFrameBuffer
{
    public int RedBits { get; set; } = 8;
    public int GreenBits { get; set; } = 8;
    public int BlueBits { get; set; } = 8;
    public int AlphaBits { get; set; } = 8;
    public int DepthBits { get; set; } = 24;
    public int StencilBits { get; set; } = 8;
    public int AccumRedBits { get; set; } = 0;
    public int AccumGreenBits { get; set; } = 0;
    public int AccumBlueBits { get; set; } = 0;
    public int AccumAlphaBits { get; set; } = 0;
    public int AuxBuffers { get; set; } = 0;
    public int Samples { get; set; } = 0;
    public OptionFramebuffer Framebuffer { get; set; } = OptionFramebuffer.DoubleBuffer;

    internal void Update()
    {
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.RedBits, RedBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.GreenBits, GreenBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.BlueBits, BlueBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.AlphaBits, AlphaBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.DepthBits, DepthBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.StencilBits, StencilBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.AccumRedBits, AccumRedBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.AccumGreenBits, AccumGreenBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.AccumBlueBits, AccumBlueBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.AccumAlphaBits, AccumAlphaBits);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.AuxBuffers, AuxBuffers);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintInt.Samples, Samples);
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.Stereo, 
            Framebuffer.HasFlag(OptionFramebuffer.Stereo));
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.SrgbCapable,
            Framebuffer.HasFlag(OptionFramebuffer.SrgbCapable)); 
        Context.NativeGLFW.WindowHint(_nGLFW.WindowHintBool.DoubleBuffer,
            Framebuffer.HasFlag(OptionFramebuffer.DoubleBuffer));
    }
}