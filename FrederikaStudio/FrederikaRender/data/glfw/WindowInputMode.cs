namespace FrederikaStudio.GLFW;

public interface IWindowInputMode
{
    public static IWindowInputMode CreateWindowInputMode(_nGLFW.Window window) => 
        new WindowInputMode() { Window = window };

    public bool IsStickyKeys { get; set; }
    public bool IsLockKeyMods { get; set; }
    public bool IsRawMouseMotion { get; set; }
    public _nGLFW.CursorModeValue InputModeCursor { get; set; }
}
internal sealed class WindowInputMode : IWindowInputMode
{
    public _nGLFW.Window Window { get; init; }

    public bool IsStickyKeys
    {
        get => Library.GLFW.GetInputMode(Window, _nGLFW.InputMode.StickyKeys);
        set => Library.GLFW.SetInputMode(Window, _nGLFW.InputMode.StickyKeys, value);
    }
    public bool IsLockKeyMods
    {
        get => Library.GLFW.GetInputMode(Window, _nGLFW.InputMode.LockKeyMods);
        set => Library.GLFW.SetInputMode(Window, _nGLFW.InputMode.LockKeyMods, value);
    }
    public bool IsRawMouseMotion
    {
        get => Library.GLFW.GetInputMode(Window, _nGLFW.InputMode.RawMouseMotion);
        set => Library.GLFW.SetInputMode(Window, _nGLFW.InputMode.RawMouseMotion, value);
    }
    public _nGLFW.CursorModeValue InputModeCursor
    {
        get => Library.GLFW.GetInputMode(Window, _nGLFW.CursorMode.CursorMode);
        set => Library.GLFW.SetInputMode(Window, _nGLFW.CursorMode.CursorMode, value);
    }
}
