namespace FrederikaStudio.GLFW;

internal static class FactoryHint
{
    public static IHintContext CreateHintContext()
    {
        HintContext context_hint = new();
        context_hint.DefaultHint();
        return context_hint;
    }
    public static IHintWindow CreateHintWindow()
    {
        HintWindow window_hint = new();
        window_hint.DefaultHint();
        return window_hint;
    }
    public static IHintMonitor CreateHintMonitor()
    {
        HintMonitor monitor_hint = new();
        monitor_hint.DefaultHint();
        return monitor_hint;
    }
    public static IHintFrameBuffer CreateHintFrameBuffer()
    {
        HintFrameBuffer framebuffer_hint = new();
        framebuffer_hint.DefaultHint();
        return framebuffer_hint;
    }
}
public interface IHintContext
{
    public int VersionMajor { get; set; }
    public int VersionMinor { get; set; }
    public bool IsForwardCompat { get; set; }
    public bool IsDebug { get; set; }
    public _nGLFW.WindowHintRobustnessValue Robustness { get; set; }
    public _nGLFW.WindowHintOpenGLProfileValue OpenGLProfile { get; set; }
    public _nGLFW.WindowHintReleaseBehaviorValue ReleaseBehavior { get; set; }
    public void DefaultHint();
}
public interface IHintWindow
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
    public void DefaultHint();
}
public interface IHintMonitor
{
    public int RefreshRate { get; set; }
    public void DefaultHint();
}
public interface IHintFrameBuffer
{
    public int RedBits { get; set; }
    public int GreenBits { get; set; }
    public int BlueBits { get; set; }
    public int AlphaBits { get; set; }
    public int DepthBits { get; set; }
    public int StencilBits { get; set; }
    public int AccumRedBits { get; set; }
    public int AccumGreenBits { get; set; }
    public int AccumBlueBits { get; set; }
    public int AccumAlphaBits { get; set; }
    public int AuxBuffers { get; set; }
    public int Samples { get; set; }
    public bool Stereo { get; set; }
    public bool SrgbCapable { get; set; }
    public bool DoubleBuffer { get; set; }
    public void DefaultHint();
}
internal sealed class HintContext : IHintContext
{
    private int[] WindowHintInt { get; } = new int[5];
    private bool[] WindowHintBool { get; } = new bool[2];

    public int VersionMajor
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.VersionMajor, value); WindowHintInt[0] = value; }
        get => WindowHintInt[0];
    }
    public int VersionMinor
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.VersionMinor, value); WindowHintInt[1] = value; }
        get => WindowHintInt[1];
    }
    public bool IsForwardCompat
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.ForwardCompat, value); WindowHintBool[0] = value; }
        get => WindowHintBool[0];
    }
    public bool IsDebug
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.OpenglDebug, value); WindowHintBool[1] = value; }
        get => WindowHintBool[1];
    }
    public _nGLFW.WindowHintRobustnessValue Robustness
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintRobustness.Robustness, value); WindowHintInt[2] = (int)value; }
        get => (_nGLFW.WindowHintRobustnessValue)WindowHintInt[2];
    }
    public _nGLFW.WindowHintOpenGLProfileValue OpenGLProfile
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintOpenGLProfile.OpenGLProfile, value); WindowHintInt[3] = (int)value; }
        get => (_nGLFW.WindowHintOpenGLProfileValue)WindowHintInt[3];
    }
    public _nGLFW.WindowHintReleaseBehaviorValue ReleaseBehavior
    {
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintReleaseBehavior.ReleaseBehavior, value); WindowHintInt[4] = (int)value; }
        get => (_nGLFW.WindowHintReleaseBehaviorValue)WindowHintInt[4];
    }
    public void DefaultHint()
    {
        VersionMajor = 1;
        VersionMinor = 0;
        Robustness = _nGLFW.WindowHintRobustnessValue.None;
        OpenGLProfile = _nGLFW.WindowHintOpenGLProfileValue.Any;
        ReleaseBehavior = _nGLFW.WindowHintReleaseBehaviorValue.Any;
        IsForwardCompat = false;
        IsDebug = false;
    }
}
internal sealed class HintWindow : IHintWindow
{
    private bool[] WindowHintBool { get; } = new bool[11];

    public bool Focus 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Focus, value); WindowHintBool[2] = value; } 
        get => WindowHintBool[2]; 
    }
    public bool Resizable 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Resizable, value); WindowHintBool[3] = value; } 
        get => WindowHintBool[3]; 
    }
    public bool Visible 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Visible, value); WindowHintBool[4] = value; } 
        get => WindowHintBool[4]; 
    }
    public bool Decorate 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Decorate, value); WindowHintBool[5] = value; } 
        get => WindowHintBool[5]; 
    }
    public bool AutoIconify 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.AutoIconify, value); WindowHintBool[6] = value; } 
        get => WindowHintBool[6]; 
    }
    public bool Floating 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Floating, value); WindowHintBool[7] = value; } 
        get => WindowHintBool[7]; 
    }
    public bool Maximize 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Maximized, value); WindowHintBool[8] = value; } 
        get => WindowHintBool[8]; 
    }
    public bool CenterCursor 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.CenterCursor, value); WindowHintBool[9] = value; } 
        get => WindowHintBool[9]; 
    }
    public bool TransparentFrameBuffer 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.TransparentFrameBuffer, value); WindowHintBool[10] = value; } 
        get => WindowHintBool[10]; 
    }
    public bool FocusOnShow 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.FocusOnShow, value); WindowHintBool[11] = value; } 
        get => WindowHintBool[11]; 
    }
    public bool ScaleToMonitor 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.ScaleToMonitor, value); WindowHintBool[12] = value; } 
        get => WindowHintBool[12]; 
    }
    public void DefaultHint()
    {
        Focus = true;
        Resizable = true;
        Visible = true;
        Decorate = true;
        AutoIconify = true;
        CenterCursor = true;
        FocusOnShow = true;
        Floating = false;
        Maximize = false;
        TransparentFrameBuffer = false;
        ScaleToMonitor = false;
    }
}
internal sealed class HintMonitor : IHintMonitor
{
    private int WindowHintInt { get; set; }

    public int RefreshRate 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.RefreshRate, value); WindowHintInt = value; } 
        get => WindowHintInt; 
    }
    public void DefaultHint()
    {
        RefreshRate = -1;
    }
}
internal sealed class HintFrameBuffer : IHintFrameBuffer
{
    private int[] WindowHintInt { get; } = new int[12];
    private bool[] WindowHintBool { get; set; } = new bool[3];

    public int RedBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.RedBits, value); WindowHintInt[6] = value; } 
        get => WindowHintInt[6]; 
    }
    public int GreenBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.GreenBits, value); WindowHintInt[7] = value; } 
        get => WindowHintInt[7]; 
    }
    public int BlueBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.BlueBits, value); WindowHintInt[8] = value; } 
        get => WindowHintInt[8]; 
    }
    public int AlphaBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.AlphaBits, value); WindowHintInt[9] = value; } 
        get => WindowHintInt[9]; 
    }
    public int DepthBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.DepthBits, value); WindowHintInt[10] = value; } 
        get => WindowHintInt[10]; 
    }
    public int StencilBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.StencilBits, value); WindowHintInt[11] = value; } 
        get => WindowHintInt[11]; 
    }
    public int AccumRedBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.AccumRedBits, value); WindowHintInt[12] = value; } 
        get => WindowHintInt[12]; 
    }
    public int AccumGreenBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.AccumGreenBits, value); WindowHintInt[13] = value; } 
        get => WindowHintInt[13]; 
    }
    public int AccumBlueBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.AccumBlueBits, value); WindowHintInt[14] = value; } 
        get => WindowHintInt[14]; 
    }
    public int AccumAlphaBits 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.AccumAlphaBits, value); WindowHintInt[15] = value; }
        get => WindowHintInt[15]; 
    }
    public int AuxBuffers 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.AuxBuffers, value); WindowHintInt[16] = value; } 
        get => WindowHintInt[16]; 
    }
    public int Samples 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintInt.Samples, value); WindowHintInt[17] = value; } 
        get => WindowHintInt[17]; 
    }
    public bool Stereo 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.Stereo, value); WindowHintBool[13] = value; } 
        get => WindowHintBool[13]; 
    }
    public bool SrgbCapable 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.SrgbCapable, value); WindowHintBool[14] = value; } 
        get => WindowHintBool[14]; 
    }
    public bool DoubleBuffer 
    { 
        set { Library.GLFW.WindowHint(_nGLFW.WindowHintBool.DoubleBuffer, value); WindowHintBool[15] = value; } 
        get => WindowHintBool[15]; 
    }
    public void DefaultHint()
    {
        RedBits = 8;
        GreenBits = 8;
        BlueBits = 8;
        AlphaBits = 8;
        DepthBits = 24;
        StencilBits = 8;
        AccumRedBits = 0;
        AccumGreenBits = 0;
        AccumBlueBits = 0;
        AccumAlphaBits = 0;
        AuxBuffers = 0;
        Samples = 0;
        Stereo = false;
        SrgbCapable = false;
        DoubleBuffer = true;
    }
}
