namespace FrederikaStudio.GLFW;

public sealed class WindowHintGLFW : IHintContextGLFW, IHintWindowGLFW, IHintMonitorGLFW, IHintFrameBufferGLFW
{
    private int[] WindowHintInt { get; } = new int[18];
    private bool[] WindowHintBool { get; } = new bool[16];

    internal WindowHintGLFW() => Default();

    #region HintContext

    public int VersionMajor { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.VersionMajor, value); WindowHintInt[0] = value; } get => WindowHintInt[0]; }
    public int VersionMinor { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.VersionMinor, value); WindowHintInt[1] = value; } get => WindowHintInt[1]; }
    public bool IsForwardCompat { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.ForwardCompat, value); WindowHintBool[0] = value; } get => WindowHintBool[0]; }
    public bool IsDebug { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.OpenglDebug, value); WindowHintBool[1] = value; } get => WindowHintBool[1]; }
    public ENGLFW.WindowHintRobustnessValueGLFW Robustness { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintRobustnessGLFW.Robustness, value); WindowHintInt[2] = (int)value; } get => (ENGLFW.WindowHintRobustnessValueGLFW)WindowHintInt[2]; }
    public ENGLFW.WindowHintOpenGLProfileValueGLFW OpenGLProfile { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintOpenGLProfileGLFW.OpenGLProfile, value); WindowHintInt[3] = (int)value; } get => (ENGLFW.WindowHintOpenGLProfileValueGLFW)WindowHintInt[3]; }
    public ENGLFW.WindowHintReleaseBehaviorValueGLFW ReleaseBehavior { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintReleaseBehaviorGLFW.ReleaseBehavior, value); WindowHintInt[4] = (int)value; } get => (ENGLFW.WindowHintReleaseBehaviorValueGLFW)WindowHintInt[4]; }

    #endregion

    #region HintWindow

    public bool Focus { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Focus, value); WindowHintBool[2] = value; } get => WindowHintBool[2]; }
    public bool Resizable { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Resizable, value); WindowHintBool[3] = value; } get => WindowHintBool[3]; }
    public bool Visible { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Visible, value); WindowHintBool[4] = value; } get => WindowHintBool[4]; }
    public bool Decorate { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Decorate, value); WindowHintBool[5] = value; } get => WindowHintBool[5]; }
    public bool AutoIconify { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.AutoIconify, value); WindowHintBool[6] = value; } get => WindowHintBool[6]; }
    public bool Floating { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Floating, value); WindowHintBool[7] = value; } get => WindowHintBool[7]; }
    public bool Maximize { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Maximized, value); WindowHintBool[8] = value; } get => WindowHintBool[8]; }
    public bool CenterCursor { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.CenterCursor, value); WindowHintBool[9] = value; } get => WindowHintBool[9]; }
    public bool TransparentFrameBuffer { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.TransparentFrameBuffer, value); WindowHintBool[10] = value; } get => WindowHintBool[10]; }
    public bool FocusOnShow { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.FocusOnShow, value); WindowHintBool[11] = value; } get => WindowHintBool[11]; }
    public bool ScaleToMonitor { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.ScaleToMonitor, value); WindowHintBool[12] = value; } get => WindowHintBool[12]; }

    #endregion

    #region HintMonitor

    public int RefreshRate { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.RefreshRate, value); WindowHintInt[5] = value; } get => WindowHintInt[5]; }

    #endregion

    #region HintFrameBuffer

    public int RedBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.RedBits, value); WindowHintInt[6] = value; } get => WindowHintInt[6]; }
    public int GreenBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.GreenBits, value); WindowHintInt[7] = value; } get => WindowHintInt[7]; }
    public int BlueBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.BlueBits, value); WindowHintInt[8] = value; } get => WindowHintInt[8]; }
    public int AlphaBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.AlphaBits, value); WindowHintInt[9] = value; } get => WindowHintInt[9]; }
    public int DepthBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.DepthBits, value); WindowHintInt[10] = value; } get => WindowHintInt[10]; }
    public int StencilBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.StencilBits, value); WindowHintInt[11] = value; } get => WindowHintInt[11]; }
    public int AccumRedBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.AccumRedBits, value); WindowHintInt[12] = value; } get => WindowHintInt[12]; }
    public int AccumGreenBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.AccumGreenBits, value); WindowHintInt[13] = value; } get => WindowHintInt[13]; }
    public int AccumBlueBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.AccumBlueBits, value); WindowHintInt[14] = value; } get => WindowHintInt[14]; }
    public int AccumAlphaBits { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.AccumAlphaBits, value); WindowHintInt[15] = value; } get => WindowHintInt[15]; }
    public int AuxBuffers { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.AuxBuffers, value); WindowHintInt[16] = value; } get => WindowHintInt[16]; }
    public int Samples { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintIntGLFW.Samples, value); WindowHintInt[17] = value; } get => WindowHintInt[17]; }
    public bool Stereo { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.Stereo, value); WindowHintBool[13] = value; } get => WindowHintBool[13]; }
    public bool SrgbCapable { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.SrgbCapable, value); WindowHintBool[14] = value; } get => WindowHintBool[14]; }
    public bool DoubleBuffer { set { LibraryGLFW.GLFW.WindowHint(ENGLFW.WindowHintBoolGLFW.DoubleBuffer, value); WindowHintBool[15] = value; } get => WindowHintBool[15]; }

    #endregion


    public IHintFrameBufferGLFW FrameBuffer => this;
    public IHintMonitorGLFW Monitor => this;
    public IHintWindowGLFW Window => this;
    public IHintContextGLFW Context => this;
    public void Default()
    {
        LibraryGLFW.GLFW.DefaultWindowHints();

        WindowHintInt[0] = 1;
        WindowHintInt[1] = 0;
        WindowHintInt[2] = (int)ENGLFW.WindowHintRobustnessValueGLFW.None;
        WindowHintInt[3] = (int)ENGLFW.WindowHintReleaseBehaviorValueGLFW.Any;
        WindowHintInt[4] = (int)ENGLFW.WindowHintOpenGLProfileValueGLFW.Any;
        WindowHintBool[0] = false;
        WindowHintBool[1] = false;

        WindowHintBool[2] = true;
        WindowHintBool[3] = true;
        WindowHintBool[4] = true;
        WindowHintBool[5] = true;
        WindowHintBool[6] = true;
        WindowHintBool[7] = false;
        WindowHintBool[8] = false;
        WindowHintBool[9] = true;
        WindowHintBool[10] = false;
        WindowHintBool[11] = true;
        WindowHintBool[12] = false;

        WindowHintInt[5] = -1;

        WindowHintInt[6] = 8;
        WindowHintInt[7] = 8;
        WindowHintInt[8] = 8;
        WindowHintInt[9] = 8;
        WindowHintInt[10] = 24;
        WindowHintInt[11] = 8;
        WindowHintInt[12] = 0;
        WindowHintInt[13] = 0;
        WindowHintInt[14] = 0;
        WindowHintInt[15] = 0;
        WindowHintInt[16] = 0;
        WindowHintInt[17] = 0;
        WindowHintBool[13] = false;
        WindowHintBool[14] = false;
        WindowHintBool[15] = true;
    }
}
