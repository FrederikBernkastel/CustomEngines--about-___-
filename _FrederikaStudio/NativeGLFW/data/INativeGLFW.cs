namespace FrederikaStudio.GLFW.Native;

public interface INativeGLFW : IDisposable
{
    public static INativeGLFW CreateGLFW(string path) => LibLoader.Load<INativeGLFW>(new SLL.LibraryThread(path, u => "glfw" + u));

    #region Create

    public SNGLFW.CursorNativeGLFW CreateCursor(SNGLFW.ImageNativeGLFW image, int xhot, int yhot);
    public SNGLFW.CursorNativeGLFW CreateStandardCursor(ENGLFW.CursorTypeGLFW shape);
    public SNGLFW.WindowNativeGLFW CreateWindow(int width, int height, string title, SNGLFW.MonitorNativeGLFW monitor, SNGLFW.WindowNativeGLFW share); 

    #endregion

    #region Is

    public bool RawMouseMotionSupported();
    public bool WindowShouldClose(SNGLFW.WindowNativeGLFW window);

    #endregion

    #region Get

    public ENGLFW.ErrorsGLFW GetError(out IntPtr description_string);
    public SCU.PointerStringAnsi GetVersionString();
    public ENGLFW.InputStateGLFW GetKey(SNGLFW.WindowNativeGLFW window, ENGLFW.KeysGLFW key);
    public ENGLFW.InputStateGLFW GetMouseButton(SNGLFW.WindowNativeGLFW window, ENGLFW.MouseButtonGLFW button);
    public void GetCursorPos(SNGLFW.WindowNativeGLFW window, out double xpos, out double ypos);
    public void GetWindowSize(SNGLFW.WindowNativeGLFW window, out int width, out int height);
    public void GetWindowPos(SNGLFW.WindowNativeGLFW window, out int xpos, out int ypos);
    public bool GetInputMode(SNGLFW.WindowNativeGLFW window, ENGLFW.InputModeGLFW mode);
    public ENGLFW.CursorModeValueGLFW GetInputMode(SNGLFW.WindowNativeGLFW window, ENGLFW.CursorModeGLFW mode);
    public SNGLFW.WindowNativeGLFW GetCurrentContext();
    public int GetKeyScancode(ENGLFW.KeysGLFW key);
    public SCU.PointerStringAnsi GetKeyName(ENGLFW.KeysGLFW key, int scancode);
    public IntPtr GetWindowUserPointer(SNGLFW.WindowNativeGLFW window);
    public SNGLFW.MonitorNativeGLFW GetWindowMonitor(SNGLFW.WindowNativeGLFW window);
    public float GetWindowOpacity(SNGLFW.WindowNativeGLFW window);
    public void GetFramebufferSize(SNGLFW.WindowNativeGLFW window, out int width, out int height);
    public void GetWindowFrameSize(SNGLFW.WindowNativeGLFW window, out int left, out int top, out int right, out int bottom);
    public void GetWindowContentScale(SNGLFW.WindowNativeGLFW window, out float xscale, out float yscale);
    public SNGLFW.GammaRampNativeGLFW GetGammaRamp(SNGLFW.MonitorNativeGLFW monitor);
    public void GetVersion(out int major, out int minor, out int rev);
    public SNGLFW.MonitorNativeGLFW GetPrimaryMonitor();
    public void GetMonitorPos(SNGLFW.MonitorNativeGLFW monitor, out int xpos, out int ypos);
    public void GetMonitorWorkarea(SNGLFW.MonitorNativeGLFW monitor, out int xpos, out int ypos, out int width, out int height);
    public void GetMonitorPhysicalSize(SNGLFW.MonitorNativeGLFW monitor, out int widthMM, out int heightMM);
    public void GetMonitorContentScale(SNGLFW.MonitorNativeGLFW monitor, out float xscale, out float yscale);
    public SCU.PointerStringAnsi GetMonitorName(SNGLFW.MonitorNativeGLFW monitor);
    public IntPtr GetMonitorUserPointer(SNGLFW.MonitorNativeGLFW monitor);
    public SNGLFW.VidmodeNativeGLFW GetVideoMode(SNGLFW.MonitorNativeGLFW monitor);
    public SCU.PointerArray<SNGLFW.MonitorNativeGLFW> GetMonitors(out int count);
    public SCU.PointerArray<SNGLFW.VidmodeNativeGLFW> GetVideoModes(SNGLFW.MonitorNativeGLFW monitor, out int count);
    public int GetWindowAttrib(SNGLFW.WindowNativeGLFW window, ENGLFW.WindowAttribGetIntGLFW attrib);
    public bool GetWindowAttrib(SNGLFW.WindowNativeGLFW window, ENGLFW.WindowAttribGetBoolGLFW attrib);
    public ENGLFW.WindowHintRobustnessValueGLFW GetWindowAttrib(SNGLFW.WindowNativeGLFW window, ENGLFW.WindowHintRobustnessGLFW attrib);
    public ENGLFW.WindowHintOpenGLProfileValueGLFW GetWindowAttrib(SNGLFW.WindowNativeGLFW window, ENGLFW.WindowHintOpenGLProfileGLFW attrib);
    public ENGLFW.WindowHintReleaseBehaviorValueGLFW GetWindowAttrib(SNGLFW.WindowNativeGLFW window, ENGLFW.WindowHintReleaseBehaviorGLFW attrib);

    #endregion

    #region Set

    public void SetCursorPos(SNGLFW.WindowNativeGLFW window, double xpos, double ypos);
    public void SetInputMode(SNGLFW.WindowNativeGLFW window, ENGLFW.CursorModeGLFW mode, ENGLFW.CursorModeValueGLFW value);
    public void SetInputMode(SNGLFW.WindowNativeGLFW window, ENGLFW.InputModeGLFW mode, bool value);
    public void WindowHint(ENGLFW.WindowHintRobustnessGLFW hint, ENGLFW.WindowHintRobustnessValueGLFW value);
    public void WindowHint(ENGLFW.WindowHintReleaseBehaviorGLFW hint, ENGLFW.WindowHintReleaseBehaviorValueGLFW value);
    public void WindowHint(ENGLFW.WindowHintOpenGLProfileGLFW hint, ENGLFW.WindowHintOpenGLProfileValueGLFW value);
    public void WindowHint(ENGLFW.WindowHintIntGLFW hint, int value);
    public void WindowHint(ENGLFW.WindowHintBoolGLFW hint, bool value);
    public void SwapInterval(int interval);
    public void SetCursor(SNGLFW.WindowNativeGLFW window, SNGLFW.CursorNativeGLFW cursor);
    public void SetWindowUserPointer(SNGLFW.WindowNativeGLFW window, IntPtr pointer);
    public void SetWindowMonitor(SNGLFW.WindowNativeGLFW window, SNGLFW.MonitorNativeGLFW monitor,
        int xpos, int ypos, int width, int height, int refreshRate);
    public void SetWindowOpacity(SNGLFW.WindowNativeGLFW window, float opacity);
    public void SetWindowShouldClose(SNGLFW.WindowNativeGLFW window, bool value);
    public void SetWindowTitle(SNGLFW.WindowNativeGLFW window, string title);
    public void SetWindowIcon(SNGLFW.WindowNativeGLFW window, int count, SCU.PointerArray<SNGLFW.ImageNativeGLFW> images);
    public void SetWindowPos(SNGLFW.WindowNativeGLFW window, int xpos, int ypos);
    public void SetWindowSizeLimits(SNGLFW.WindowNativeGLFW window, int minwidth, int minheight, int maxwidth, int maxheight);
    public void SetWindowAspectRatio(SNGLFW.WindowNativeGLFW window, int numer, int denom);
    public void SetWindowSize(SNGLFW.WindowNativeGLFW window, int width, int height);
    public void SetGammaRamp(SNGLFW.MonitorNativeGLFW monitor, SNGLFW.GammaRampNativeGLFW ramp);
    public void SetMonitorUserPointer(SNGLFW.MonitorNativeGLFW monitor, IntPtr pointer);
    public void SetGamma(SNGLFW.MonitorNativeGLFW monitor, float gamma);
    public void SetWindowAttrib(SNGLFW.WindowNativeGLFW window, ENGLFW.WindowAttribSetGLFW attrib, bool value);

    #endregion

    #region Action

    public bool Init();
    public void IconifyWindow(SNGLFW.WindowNativeGLFW window);
    public void RestoreWindow(SNGLFW.WindowNativeGLFW window);
    public void MaximizeWindow(SNGLFW.WindowNativeGLFW window);
    public void ShowWindow(SNGLFW.WindowNativeGLFW window);
    public void HideWindow(SNGLFW.WindowNativeGLFW window);
    public void FocusWindow(SNGLFW.WindowNativeGLFW window);
    public void RequestWindowAttention(SNGLFW.WindowNativeGLFW window);
    public void DefaultWindowHints();
    public void SwapBuffers(SNGLFW.WindowNativeGLFW window);
    public void MakeContextCurrent(SNGLFW.WindowNativeGLFW window);
    public void DestroyCursor(SNGLFW.CursorNativeGLFW cursor);
    public void PollEvents();
    public void WaitEvents();
    public void WaitEventsTimeout(double timeout);
    public void PostEmptyEvent();
    public void DestroyWindow(SNGLFW.WindowNativeGLFW window);

    #endregion

    #region Callback

    public CNGLFW.WindowScrollCallbackGLFW SetScrollCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowScrollCallbackGLFW callback);
    public CNGLFW.MonitorCallbackGLFW SetMonitorCallback(CNGLFW.MonitorCallbackGLFW callback);
    public CNGLFW.ErrorCallbackGLFW SetErrorCallback(CNGLFW.ErrorCallbackGLFW callback);
    public CNGLFW.WindowPositionCallbackGLFW SetWindowPosCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowPositionCallbackGLFW callback);
    public CNGLFW.WindowSizeCallbackGLFW SetWindowSizeCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowSizeCallbackGLFW callback);
    public CNGLFW.WindowCloseCallbackGLFW SetWindowCloseCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowCloseCallbackGLFW callback);
    public CNGLFW.WindowRefreshCallbackGLFW SetWindowRefreshCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowRefreshCallbackGLFW callback);
    public CNGLFW.WindowFocusCallbackGLFW SetWindowFocusCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowFocusCallbackGLFW callback);
    public CNGLFW.WindowIconifyCallbackGLFW SetWindowIconifyCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowIconifyCallbackGLFW callback);
    public CNGLFW.WindowMaximizeCallbackGLFW SetWindowMaximizeCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowMaximizeCallbackGLFW callback);
    public CNGLFW.FrameBufferSizeCallbackGLFW SetFramebufferSizeCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.FrameBufferSizeCallbackGLFW callback);
    public CNGLFW.WindowContentScaleCallbackGLFW SetWindowContentScaleCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.WindowContentScaleCallbackGLFW callback);
    public CNGLFW.KeyCallbackGLFW SetKeyCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.KeyCallbackGLFW callback);
    public CNGLFW.CharCallbackGLFW SetCharCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.CharCallbackGLFW callback);
    public CNGLFW.CharModsCallbackGLFW SetCharModsCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.CharModsCallbackGLFW callback);
    public CNGLFW.MouseButtonCallbackGLFW SetMouseButtonCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.MouseButtonCallbackGLFW callback);
    public CNGLFW.CursorPositionCallbackGLFW SetCursorPosCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.CursorPositionCallbackGLFW callback);
    public CNGLFW.CursorEnterCallbackGLFW SetCursorEnterCallback(SNGLFW.WindowNativeGLFW window, CNGLFW.CursorEnterCallbackGLFW callback);

    #endregion
}