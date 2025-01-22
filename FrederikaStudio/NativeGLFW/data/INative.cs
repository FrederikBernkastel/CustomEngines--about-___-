namespace FrederikaStudio.GLFW.Native;

public sealed class Library
{
    private _LibLoader.Library Lib { get; }
    public INative NativeGLFW { get; }
    public Library(string path)
    {
        Lib = new(path);
        NativeGLFW = Lib.Load<INative>(u => "glfw" + u);
    }
    public void Dispose() => Lib.Dispose();
}
public interface INative
{
    public Cursor CreateCursor(Image image, int xhot, int yhot);
    public Cursor CreateStandardCursor(CursorType shape);
    public Window CreateWindow(int width, int height, string title, Monitor monitor, Window share);
    public bool RawMouseMotionSupported();
    public IntPtr GetProcAddress(string name);
    public string GetVersionString();
    public Window GetCurrentContext();
    public int GetKeyScancode(Keys key);
    public string GetKeyName(Keys key, int scancode);
    public void GetVersion(out int major, out int minor, out int rev);
    public Monitor GetPrimaryMonitor();
    public _UnsafeWork.PointerArray<Monitor> GetMonitors(out int count);
    public void WindowHint(WindowHintRobustness hint, WindowHintRobustnessValue value);
    public void WindowHint(WindowHintReleaseBehavior hint, WindowHintReleaseBehaviorValue value);
    public void WindowHint(WindowHintOpenGLProfile hint, WindowHintOpenGLProfileValue value);
    public void WindowHint(WindowHintInt hint, int value);
    public void WindowHint(WindowHintBool hint, bool value);
    public void SwapInterval(bool interval);
    public bool Init();
    public void DefaultWindowHints();
    public void PollEvents();
    public void WaitEvents();
    public void WaitEventsTimeout(double timeout);
    public void PostEmptyEvent();
    public void DestroyCursor(Cursor cursor);
    public void SetGammaRamp(Monitor monitor, GammaRamp ramp);
    public void SetMonitorUserPointer(Monitor monitor, IntPtr pointer);
    public void SetGamma(Monitor monitor, float gamma);
    public _UnsafeWork.PointerArray<Vidmode> GetVideoModes(Monitor monitor, out int count);
    public void GetMonitorPos(Monitor monitor, out int xpos, out int ypos);
    public void GetMonitorWorkarea(Monitor monitor, out int xpos, out int ypos, out int width, out int height);
    public void GetMonitorPhysicalSize(Monitor monitor, out int widthMM, out int heightMM);
    public void GetMonitorContentScale(Monitor monitor, out float xscale, out float yscale);
    public string GetMonitorName(Monitor monitor);
    public IntPtr GetMonitorUserPointer(Monitor monitor);
    public Vidmode GetVideoMode(Monitor monitor);
    public GammaRamp GetGammaRamp(Monitor monitor);
    public void SetWindowAttrib(Window window, WindowAttribSet attrib, bool value);
    public void SetCursor(Window window, Cursor cursor);
    public void SetWindowUserPointer(Window window, IntPtr pointer);
    public void SetWindowMonitor(Window window, Monitor monitor,
        int xpos, int ypos, int width, int height, int refreshRate);
    public void SetWindowOpacity(Window window, float opacity);
    public void SetWindowShouldClose(Window window, bool value);
    public void SetWindowTitle(Window window, string title);
    public void SetWindowIcon(Window window, int count, Image[] images);
    public void SetWindowPos(Window window, int xpos, int ypos);
    public void SetWindowSizeLimits(Window window, int minwidth, int minheight, int maxwidth, int maxheight);
    public void SetWindowAspectRatio(Window window, int numer, int denom);
    public void SetWindowSize(Window window, int width, int height);
    public void SetCursorPos(Window window, double xpos, double ypos);
    public void SetInputMode(Window window, CursorMode mode, CursorModeValue value);
    public void SetInputMode(Window window, InputMode mode, bool value);
    public int GetWindowAttrib(Window window, WindowAttribGetInt attrib);
    public bool GetWindowAttrib(Window window, WindowAttribGetBool attrib);
    public WindowHintRobustnessValue GetWindowAttrib(Window window, WindowHintRobustness attrib);
    public WindowHintOpenGLProfileValue GetWindowAttrib(Window window, WindowHintOpenGLProfile attrib);
    public WindowHintReleaseBehaviorValue GetWindowAttrib(Window window, WindowHintReleaseBehavior attrib);
    public IntPtr GetWindowUserPointer(Window window);
    public Monitor GetWindowMonitor(Window window);
    public float GetWindowOpacity(Window window);
    public void GetFramebufferSize(Window window, out int width, out int height);
    public void GetWindowFrameSize(Window window, out int left, out int top, out int right, out int bottom);
    public void GetWindowContentScale(Window window, out float xscale, out float yscale);
    public InputState GetKey(Window window, Keys key);
    public InputState GetMouseButton(Window window, MouseButton button);
    public void GetCursorPos(Window window, out double xpos, out double ypos);
    public void GetWindowSize(Window window, out int width, out int height);
    public void GetWindowPos(Window window, out int xpos, out int ypos);
    public bool GetInputMode(Window window, InputMode mode);
    public CursorModeValue GetInputMode(Window window, CursorMode mode);
    public bool WindowShouldClose(Window window);
    public void SwapBuffers(Window window);
    public void MakeContextCurrent(Window window);
    public void IconifyWindow(Window window);
    public void RestoreWindow(Window window);
    public void MaximizeWindow(Window window);
    public void ShowWindow(Window window);
    public void HideWindow(Window window);
    public void FocusWindow(Window window);
    public void RequestWindowAttention(Window window);
    public void DestroyWindow(Window window);
    public WindowScrollCallback SetScrollCallback(Window window, WindowScrollCallback callback);
    public MonitorCallback SetMonitorCallback(MonitorCallback callback);
    public ErrorCallback SetErrorCallback(ErrorCallback callback);
    public WindowPositionCallback SetWindowPosCallback(Window window, WindowPositionCallback callback);
    public WindowSizeCallback SetWindowSizeCallback(Window window, WindowSizeCallback callback);
    public WindowCloseCallback SetWindowCloseCallback(Window window, WindowCloseCallback callback);
    public WindowRefreshCallback SetWindowRefreshCallback(Window window, WindowRefreshCallback callback);
    public WindowFocusCallback SetWindowFocusCallback(Window window, WindowFocusCallback callback);
    public WindowIconifyCallback SetWindowIconifyCallback(Window window, WindowIconifyCallback callback);
    public WindowMaximizeCallback SetWindowMaximizeCallback(Window window, WindowMaximizeCallback callback);
    public FrameBufferSizeCallback SetFramebufferSizeCallback(Window window, FrameBufferSizeCallback callback);
    public WindowContentScaleCallback SetWindowContentScaleCallback(Window window, WindowContentScaleCallback callback);
    public KeyCallback SetKeyCallback(Window window, KeyCallback callback);
    public CharCallback SetCharCallback(Window window, CharCallback callback);
    public CharModsCallback SetCharModsCallback(Window window, CharModsCallback callback);
    public MouseButtonCallback SetMouseButtonCallback(Window window, MouseButtonCallback callback);
    public CursorPositionCallback SetCursorPosCallback(Window window, CursorPositionCallback callback);
    public CursorEnterCallback SetCursorEnterCallback(Window window, CursorEnterCallback callback);
}