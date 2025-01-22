namespace FrederikaStudio.GLFW.Native;

public static class ENGLFW
{
    [Flags]
    public enum ModsGLFW
    {
        Shift = 0x0001,
        Control = 0x0002,
        Alt = 0x0004,
        Super = 0x0008,
        CapsLock = 0x0010,
        NumLock = 0x0020,
    }
    public enum ErrorsGLFW
    {
        NoError = 0,
        NoCurrentContext = 0x00010002,
        InvalidValue = 0x00010004,
        OutOfMemory = 0x00010005,
        ApiUnavailable = 0x00010006,
        VersionUnavailable = 0x00010007,
        PlatformError = 0x00010008,
        FormatUnavailable = 0x00010009,
        NoWindowContext = 0x0001000A,
        ContextNoError = 0x0002200A,
    }
    public enum ConnectionStatusGLFW
    {
        Connected = 0x00040001,
        Disconnected = 0x00040002,
    }
    public enum WindowAttribSetGLFW
    {
        Resizable = 0x00020003,
        Decorate = 0x00020005,
        AutoIconify = 0x00020006,
        Floating = 0x00020007,
        FocusOnShow = 0x0002000C,
    }
    public enum WindowAttribGetIntGLFW
    {
        VersionMajor = 0x00022002,
        VersionMinor = 0x00022003,
        Revision = 0x00022004,
    }
    public enum WindowAttribGetBoolGLFW
    {
        Focus = 0x00020001,
        Iconify = 0x00020002,
        Resizable = 0x00020003,
        Visible = 0x00020004,
        Decorate = 0x00020005,
        AutoIconify = 0x00020006,
        Floating = 0x00020007,
        Maximized = 0x00020008,
        TransparentFrameBuffer = 0x0002000A,
        Hover = 0x0002000B,
        FocusOnShow = 0x0002000C,
        ForwardCompat = 0x00022006,
        OpenglDebug = 0x00022007,
    }
    public enum WindowHintIntGLFW
    {
        VersionMajor = 0x00022002,
        VersionMinor = 0x00022003,
        RefreshRate = 0x0002100F,
        RedBits = 0x00021001,
        GreenBits = 0x00021002,
        BlueBits = 0x00021003,
        AlphaBits = 0x00021004,
        DepthBits = 0x00021005,
        StencilBits = 0x00021006,
        AccumRedBits = 0x00021007,
        AccumGreenBits = 0x00021008,
        AccumBlueBits = 0x00021009,
        AccumAlphaBits = 0x0002100A,
        AuxBuffers = 0x0002100B,
        Samples = 0x0002100D,
    }
    public enum WindowHintBoolGLFW
    {
        ForwardCompat = 0x00022006,
        OpenglDebug = 0x00022007,
        Focus = 0x00020001,
        Maximized = 0x00020008,
        Resizable = 0x00020003,
        Visible = 0x00020004,
        Decorate = 0x00020005,
        AutoIconify = 0x00020006,
        Floating = 0x00020007,
        CenterCursor = 0x00020009,
        TransparentFrameBuffer = 0x0002000A,
        FocusOnShow = 0x0002000C,
        ScaleToMonitor = 0x0002200C,
        Stereo = 0x0002100C,
        SrgbCapable = 0x0002100E,
        DoubleBuffer = 0x00021010,
    }
    public enum WindowHintRobustnessGLFW { Robustness = 0x00022005 }
    public enum WindowHintReleaseBehaviorGLFW { ReleaseBehavior = 0x00022009 }
    public enum WindowHintOpenGLProfileGLFW { OpenGLProfile = 0x00022008 }
    public enum WindowHintRobustnessValueGLFW
    {
        None = 0,
        NoResetNotification = 0x00031001,
        LoseContextOnReset = 0x00031002
    }
    public enum WindowHintReleaseBehaviorValueGLFW
    {
        Any = 0,
        Flush = 0x00035001,
        None = 0x00035002
    }
    public enum WindowHintOpenGLProfileValueGLFW
    {
        Any = 0,
        Core = 0x00032001,
        Compatibility = 0x00032002
    }
    public enum CursorModeGLFW { CursorMode = 0x00033001 }
    public enum InputModeGLFW
    {
        StickyKeys = 0x00033002,
        LockKeyMods = 0x00033004,
        RawMouseMotion = 0x00033005,
    }
    public enum CursorModeValueGLFW
    {
        Normal = 0x00034001,
        Hidden = 0x00034002,
        Disabled = 0x00034003
    }
    public enum MouseButtonGLFW
    {
        Left = 0,
        Right = 1,
        Middle = 2,
    }
    public enum InputStateGLFW
    {
        Release = 0,
        Press = 1,
        Repeat = 2,
    }
    public enum KeysGLFW
    {
        Space = 32,
        Apostrophe = 39,
        Comma = 44,
        Minus = 45,
        Period = 46,
        Slash = 47,
        Alpha0 = 48,
        Alpha1 = 49,
        Alpha2 = 50,
        Alpha3 = 51,
        Alpha4 = 52,
        Alpha5 = 53,
        Alpha6 = 54,
        Alpha7 = 55,
        Alpha8 = 56,
        Alpha9 = 57,
        SemiColon = 59,
        Equal = 61,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LeftBracket = 91,
        Backslash = 92,
        RightBracket = 93,
        GraveAccent = 96,
        World1 = 161,
        World2 = 162,
        Escape = 256,
        Enter = 257,
        Tab = 258,
        Backspace = 259,
        Insert = 260,
        Delete = 261,
        Right = 262,
        Left = 263,
        Down = 264,
        Up = 265,
        PageUp = 266,
        PageDown = 267,
        Home = 268,
        End = 269,
        CapsLock = 280,
        ScrollLock = 281,
        NumLock = 282,
        PrintScreen = 283,
        Pause = 284,
        F1 = 290,
        F2 = 291,
        F3 = 292,
        F4 = 293,
        F5 = 294,
        F6 = 295,
        F7 = 296,
        F8 = 297,
        F9 = 298,
        F10 = 299,
        F11 = 300,
        F12 = 301,
        F13 = 302,
        F14 = 303,
        F15 = 304,
        F16 = 305,
        F17 = 306,
        F18 = 307,
        F19 = 308,
        F20 = 309,
        F21 = 310,
        F22 = 311,
        F23 = 312,
        F24 = 313,
        F25 = 314,
        Numpad0 = 320,
        Numpad1 = 321,
        Numpad2 = 322,
        Numpad3 = 323,
        Numpad4 = 324,
        Numpad5 = 325,
        Numpad6 = 326,
        Numpad7 = 327,
        Numpad8 = 328,
        Numpad9 = 329,
        NumpadDecimal = 330,
        NumpadDivide = 331,
        NumpadMultiply = 332,
        NumpadSubtract = 333,
        NumpadAdd = 334,
        NumpadEnter = 335,
        NumpadEqual = 336,
        LeftShift = 340,
        LeftControl = 341,
        LeftAlt = 342,
        LeftSuper = 343,
        RightShift = 344,
        RightControl = 345,
        RightAlt = 346,
        RightSuper = 347,
        Menu = 348,
    }
    public enum CursorTypeGLFW
    {
        Arrow = 0x00036001,
        Ibeam = 0x00036002,
        Crosshair = 0x00036003,
        Hand = 0x00036004,
        ResizeHorizontal = 0x00036005,
        ResizeVertical = 0x00036006,
    }
}
