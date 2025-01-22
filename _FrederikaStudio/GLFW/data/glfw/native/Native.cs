namespace FrederikaStudio.GLFW;

public interface INativeGLFW : IDisposable
{
    public static INativeGLFW CreateGLFW(string path) => LibLoader.Load<INativeGLFW>(new SLL.LibraryThread(path, u => "glfw" + u), false);

    #region Create

    public SNGLFW.CursorGLFW CreateCursor(SNGLFW.ImageGLFW image, int xhot, int yhot);
    public SNGLFW.CursorGLFW CreateStandardCursor(ENGLFW.CursorTypeGLFW shape);
    public SNGLFW.WindowGLFW CreateWindow(int width, int height, string title, SNGLFW.MonitorGLFW monitor, SNGLFW.WindowGLFW share); 

    #endregion

    #region Is

    public bool RawMouseMotionSupported();
    public bool WindowShouldClose(SNGLFW.WindowGLFW window);

    #endregion

    #region Get

    public ENGLFW.ErrorsGLFW GetError(out SCU.PointerStringAnsi description_string);
    public string GetVersionString();
    public ENGLFW.InputStateGLFW GetKey(SNGLFW.WindowGLFW window, ENGLFW.KeysGLFW key);
    public ENGLFW.InputStateGLFW GetMouseButton(SNGLFW.WindowGLFW window, ENGLFW.MouseButtonGLFW button);
    public void GetCursorPos(SNGLFW.WindowGLFW window, out double xpos, out double ypos);
    public void GetWindowSize(SNGLFW.WindowGLFW window, out int width, out int height);
    public void GetWindowPos(SNGLFW.WindowGLFW window, out int xpos, out int ypos);
    public bool GetInputMode(SNGLFW.WindowGLFW window, ENGLFW.InputModeGLFW mode);
    public ENGLFW.CursorModeValueGLFW GetInputMode(SNGLFW.WindowGLFW window, ENGLFW.CursorModeGLFW mode);
    public SNGLFW.WindowGLFW GetCurrentContext();
    public int GetKeyScancode(ENGLFW.KeysGLFW key);
    public string GetKeyName(ENGLFW.KeysGLFW key, int scancode);
    public IntPtr GetWindowUserPointer(SNGLFW.WindowGLFW window);
    public SNGLFW.WindowGLFW GetWindowMonitor(SNGLFW.WindowGLFW window);
    public float GetWindowOpacity(SNGLFW.WindowGLFW window);
    public void GetFramebufferSize(SNGLFW.WindowGLFW window, out int width, out int height);
    public void GetWindowFrameSize(SNGLFW.WindowGLFW window, out int left, out int top, out int right, out int bottom);
    public void GetWindowContentScale(SNGLFW.WindowGLFW window, out float xscale, out float yscale);
    public SNGLFW.GammaRampGLFW GetGammaRamp(SNGLFW.MonitorGLFW monitor);
    public void GetVersion(out int major, out int minor, out int rev);
    public SNGLFW.MonitorGLFW GetPrimaryMonitor();
    public void GetMonitorPos(SNGLFW.MonitorGLFW monitor, out int xpos, out int ypos);
    public void GetMonitorWorkarea(SNGLFW.MonitorGLFW monitor, out int xpos, out int ypos, out int width, out int height);
    public void GetMonitorPhysicalSize(SNGLFW.MonitorGLFW monitor, out int widthMM, out int heightMM);
    public void GetMonitorContentScale(SNGLFW.MonitorGLFW monitor, out float xscale, out float yscale);
    public string GetMonitorName(SNGLFW.MonitorGLFW monitor);
    public IntPtr GetMonitorUserPointer(SNGLFW.MonitorGLFW monitor);
    public SNGLFW.VidmodeGLFW GetVideoMode(SNGLFW.MonitorGLFW monitor);
    public SCU.PointerArray<SNGLFW.MonitorGLFW> GetMonitors(out int count);
    public SCU.PointerArray<SNGLFW.VidmodeGLFW> GetVideoModes(SNGLFW.MonitorGLFW monitor, out int count);
    public int GetWindowAttrib(SNGLFW.WindowGLFW window, ENGLFW.WindowAttribGetIntGLFW attrib);
    public bool GetWindowAttrib(SNGLFW.WindowGLFW window, ENGLFW.WindowAttribGetBoolGLFW attrib);
    public ENGLFW.WindowHintRobustnessValueGLFW GetWindowAttrib(SNGLFW.WindowGLFW window, ENGLFW.WindowHintRobustnessGLFW attrib);
    public ENGLFW.WindowHintOpenGLProfileValueGLFW GetWindowAttrib(SNGLFW.WindowGLFW window, ENGLFW.WindowHintOpenGLProfileGLFW attrib);
    public ENGLFW.WindowHintReleaseBehaviorValueGLFW GetWindowAttrib(SNGLFW.WindowGLFW window, ENGLFW.WindowHintReleaseBehaviorGLFW attrib);

    #endregion

    #region Set

    public void SetCursorPos(SNGLFW.WindowGLFW window, double xpos, double ypos);
    public void SetInputMode(SNGLFW.WindowGLFW window, ENGLFW.CursorModeGLFW mode, ENGLFW.CursorModeValueGLFW value);
    public void SetInputMode(SNGLFW.WindowGLFW window, ENGLFW.InputModeGLFW mode, bool value);
    public void WindowHint(ENGLFW.WindowHintRobustnessGLFW hint, ENGLFW.WindowHintRobustnessValueGLFW value);
    public void WindowHint(ENGLFW.WindowHintReleaseBehaviorGLFW hint, ENGLFW.WindowHintReleaseBehaviorValueGLFW value);
    public void WindowHint(ENGLFW.WindowHintOpenGLProfileGLFW hint, ENGLFW.WindowHintOpenGLProfileValueGLFW value);
    public void WindowHint(ENGLFW.WindowHintIntGLFW hint, int value);
    public void WindowHint(ENGLFW.WindowHintBoolGLFW hint, bool value);
    public void SwapInterval(int interval);
    public void SetCursor(SNGLFW.WindowGLFW window, SNGLFW.CursorGLFW cursor);
    public void SetWindowUserPointer(SNGLFW.WindowGLFW window, IntPtr pointer);
    public void SetWindowMonitor(SNGLFW.WindowGLFW window, SNGLFW.MonitorGLFW monitor,
        int xpos, int ypos, int width, int height, int refreshRate);
    public void SetWindowOpacity(SNGLFW.WindowGLFW window, float opacity);
    public void SetWindowShouldClose(SNGLFW.WindowGLFW window, bool value);
    public void SetWindowTitle(SNGLFW.WindowGLFW window, string title);
    public void SetWindowIcon(SNGLFW.WindowGLFW window, int count, SCU.PointerArray<SNGLFW.ImageGLFW> images);
    public void SetWindowPos(SNGLFW.WindowGLFW window, int xpos, int ypos);
    public void SetWindowSizeLimits(SNGLFW.WindowGLFW window, int minwidth, int minheight, int maxwidth, int maxheight);
    public void SetWindowAspectRatio(SNGLFW.WindowGLFW window, int numer, int denom);
    public void SetWindowSize(SNGLFW.WindowGLFW window, int width, int height);
    public void SetGammaRamp(SNGLFW.MonitorGLFW monitor, SNGLFW.GammaRampGLFW ramp);
    public void SetMonitorUserPointer(SNGLFW.MonitorGLFW monitor, IntPtr pointer);
    public void SetGamma(SNGLFW.MonitorGLFW monitor, float gamma);
    public void SetWindowAttrib(SNGLFW.WindowGLFW window, ENGLFW.WindowAttribSetGLFW attrib, bool value);

    #endregion

    #region Action

    public bool Init();
    public void IconifyWindow(SNGLFW.WindowGLFW window);
    public void RestoreWindow(SNGLFW.WindowGLFW window);
    public void MaximizeWindow(SNGLFW.WindowGLFW window);
    public void ShowWindow(SNGLFW.WindowGLFW window);
    public void HideWindow(SNGLFW.WindowGLFW window);
    public void FocusWindow(SNGLFW.WindowGLFW window);
    public void RequestWindowAttention(SNGLFW.WindowGLFW window);
    public void DefaultWindowHints();
    public void SwapBuffers(SNGLFW.WindowGLFW window);
    public void MakeContextCurrent(SNGLFW.WindowGLFW window);
    public void DestroyCursor(SNGLFW.CursorGLFW cursor);
    public void PollEvents();
    public void WaitEvents();
    public void WaitEventsTimeout(double timeout);
    public void PostEmptyEvent();
    public void DestroyWindow(SNGLFW.WindowGLFW window);

    #endregion

    #region Callback

    public CNGLFW.WindowScrollCallbackGLFW SetScrollCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowScrollCallbackGLFW callback);
    public CNGLFW.MonitorCallbackGLFW SetMonitorCallback(CNGLFW.MonitorCallbackGLFW callback);
    public CNGLFW.ErrorCallbackGLFW SetErrorCallback(CNGLFW.ErrorCallbackGLFW callback);
    public CNGLFW.WindowPositionCallbackGLFW SetWindowPosCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowPositionCallbackGLFW callback);
    public CNGLFW.WindowSizeCallbackGLFW SetWindowSizeCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowSizeCallbackGLFW callback);
    public CNGLFW.WindowCloseCallbackGLFW SetWindowCloseCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowCloseCallbackGLFW callback);
    public CNGLFW.WindowRefreshCallbackGLFW SetWindowRefreshCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowRefreshCallbackGLFW callback);
    public CNGLFW.WindowFocusCallbackGLFW SetWindowFocusCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowFocusCallbackGLFW callback);
    public CNGLFW.WindowIconifyCallbackGLFW SetWindowIconifyCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowIconifyCallbackGLFW callback);
    public CNGLFW.WindowMaximizeCallbackGLFW SetWindowMaximizeCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowMaximizeCallbackGLFW callback);
    public CNGLFW.FrameBufferSizeCallbackGLFW SetFramebufferSizeCallback(SNGLFW.WindowGLFW window, CNGLFW.FrameBufferSizeCallbackGLFW callback);
    public CNGLFW.WindowContentScaleCallbackGLFW SetWindowContentScaleCallback(SNGLFW.WindowGLFW window, CNGLFW.WindowContentScaleCallbackGLFW callback);
    public CNGLFW.KeyCallbackGLFW SetKeyCallback(SNGLFW.WindowGLFW window, CNGLFW.KeyCallbackGLFW callback);
    public CNGLFW.CharCallbackGLFW SetCharCallback(SNGLFW.WindowGLFW window, CNGLFW.CharCallbackGLFW callback);
    public CNGLFW.CharModsCallbackGLFW SetCharModsCallback(SNGLFW.WindowGLFW window, CNGLFW.CharModsCallbackGLFW callback);
    public CNGLFW.MouseButtonCallbackGLFW SetMouseButtonCallback(SNGLFW.WindowGLFW window, CNGLFW.MouseButtonCallbackGLFW callback);
    public CNGLFW.CursorPositionCallbackGLFW SetCursorPosCallback(SNGLFW.WindowGLFW window, CNGLFW.CursorPositionCallbackGLFW callback);
    public CNGLFW.CursorEnterCallbackGLFW SetCursorEnterCallback(SNGLFW.WindowGLFW window, CNGLFW.CursorEnterCallbackGLFW callback);

    #endregion
}