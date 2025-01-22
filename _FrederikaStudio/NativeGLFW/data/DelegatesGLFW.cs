namespace FrederikaStudio.GLFW.Native;

public static class CNGLFW
{
    public delegate void WindowScrollCallbackGLFW(SNGLFW.WindowNativeGLFW window, double xoffset, double yoffset);
    public delegate void MonitorCallbackGLFW(SNGLFW.MonitorNativeGLFW monitor, ENGLFW.ConnectionStatusGLFW _event);
    public delegate void ErrorCallbackGLFW(ENGLFW.ErrorsGLFW error, SCU.PointerStringAnsi description);
    public delegate void WindowPositionCallbackGLFW(SNGLFW.WindowNativeGLFW window, int xpos, int ypos);
    public delegate void WindowSizeCallbackGLFW(SNGLFW.WindowNativeGLFW window, int width, int height);
    public delegate void WindowCloseCallbackGLFW(SNGLFW.WindowNativeGLFW window);
    public delegate void WindowRefreshCallbackGLFW(SNGLFW.WindowNativeGLFW window);
    public delegate void WindowFocusCallbackGLFW(SNGLFW.WindowNativeGLFW window, bool focused);
    public delegate void WindowIconifyCallbackGLFW(SNGLFW.WindowNativeGLFW window, bool iconifed);
    public delegate void WindowMaximizeCallbackGLFW(SNGLFW.WindowNativeGLFW window, bool maximized);
    public delegate void FrameBufferSizeCallbackGLFW(SNGLFW.WindowNativeGLFW window, int width, int height);
    public delegate void WindowContentScaleCallbackGLFW(SNGLFW.WindowNativeGLFW window, float xscale, float yscale);
    public delegate void MouseButtonCallbackGLFW(SNGLFW.WindowNativeGLFW window, ENGLFW.MouseButtonGLFW button, ENGLFW.InputStateGLFW action, ENGLFW.ModsGLFW mods);
    public delegate void CursorPositionCallbackGLFW(SNGLFW.WindowNativeGLFW window, double xpos, double ypos);
    public delegate void CursorEnterCallbackGLFW(SNGLFW.WindowNativeGLFW window, bool entered);
    public delegate void KeyCallbackGLFW(SNGLFW.WindowNativeGLFW window, ENGLFW.KeysGLFW key, int scancode, ENGLFW.InputStateGLFW action, ENGLFW.ModsGLFW mods);
    public delegate void CharCallbackGLFW(SNGLFW.WindowNativeGLFW window, uint codepoint);
    public delegate void CharModsCallbackGLFW(SNGLFW.WindowNativeGLFW window, uint codepoint, ENGLFW.ModsGLFW mods);
}