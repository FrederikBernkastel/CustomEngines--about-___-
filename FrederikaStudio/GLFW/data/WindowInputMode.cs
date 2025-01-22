namespace FrederikaStudio.GLFW;

public sealed class WindowInputMode
{
    private _nGLFW.Window Handle { get; }

    internal WindowInputMode(_nGLFW.Window handle) => Handle = handle;

    public bool IsStickyKeys
    {
        get => Context.NativeGLFW.GetInputMode(Handle, _nGLFW.InputMode.StickyKeys);
        set => Context.NativeGLFW.SetInputMode(Handle, _nGLFW.InputMode.StickyKeys, value);
    }
    public bool IsLockKeyMods
    {
        get => Context.NativeGLFW.GetInputMode(Handle, _nGLFW.InputMode.LockKeyMods);
        set => Context.NativeGLFW.SetInputMode(Handle, _nGLFW.InputMode.LockKeyMods, value);
    }
    public bool IsRawMouseMotion
    {
        get => Context.NativeGLFW.GetInputMode(Handle, _nGLFW.InputMode.RawMouseMotion);
        set => Context.NativeGLFW.SetInputMode(Handle, _nGLFW.InputMode.RawMouseMotion, value);
    }
    public _nGLFW.CursorModeValue InputModeCursor
    {
        get => Context.NativeGLFW.GetInputMode(Handle, _nGLFW.CursorMode.CursorMode);
        set => Context.NativeGLFW.SetInputMode(Handle, _nGLFW.CursorMode.CursorMode, value);
    }
}
