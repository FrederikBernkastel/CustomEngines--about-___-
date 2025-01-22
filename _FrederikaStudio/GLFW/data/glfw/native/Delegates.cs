namespace FrederikaStudio.GLFW;

public static class CNGLFW
{
    public delegate void WindowScrollCallbackGLFW(SNGLFW.WindowGLFW window, double xoffset, double yoffset);
    public delegate void MonitorCallbackGLFW(SNGLFW.MonitorGLFW monitor, ENGLFW.ConnectionStatusGLFW _event);
    public delegate void ErrorCallbackGLFW(ENGLFW.ErrorsGLFW error, SCU.PointerStringAnsi description);
    public delegate void WindowPositionCallbackGLFW(SNGLFW.WindowGLFW window, int xpos, int ypos);
    public delegate void WindowSizeCallbackGLFW(SNGLFW.WindowGLFW window, int width, int height);
    public delegate void WindowCloseCallbackGLFW(SNGLFW.WindowGLFW window);
    public delegate void WindowRefreshCallbackGLFW(SNGLFW.WindowGLFW window);
    public delegate void WindowFocusCallbackGLFW(SNGLFW.WindowGLFW window, bool focused);
    public delegate void WindowIconifyCallbackGLFW(SNGLFW.WindowGLFW window, bool iconifed);
    public delegate void WindowMaximizeCallbackGLFW(SNGLFW.WindowGLFW window, bool maximized);
    public delegate void FrameBufferSizeCallbackGLFW(SNGLFW.WindowGLFW window, int width, int height);
    public delegate void WindowContentScaleCallbackGLFW(SNGLFW.WindowGLFW window, float xscale, float yscale);
    public delegate void MouseButtonCallbackGLFW(SNGLFW.WindowGLFW window, ENGLFW.MouseButtonGLFW button, ENGLFW.InputStateGLFW action, ENGLFW.ModsGLFW mods);
    public delegate void CursorPositionCallbackGLFW(SNGLFW.WindowGLFW window, double xpos, double ypos);
    public delegate void CursorEnterCallbackGLFW(SNGLFW.WindowGLFW window, bool entered);
    public delegate void KeyCallbackGLFW(SNGLFW.WindowGLFW window, ENGLFW.KeysGLFW key, int scancode, ENGLFW.InputStateGLFW action, ENGLFW.ModsGLFW mods);
    public delegate void CharCallbackGLFW(SNGLFW.WindowGLFW window, uint codepoint);
    public delegate void CharModsCallbackGLFW(SNGLFW.WindowGLFW window, uint codepoint, ENGLFW.ModsGLFW mods);
}