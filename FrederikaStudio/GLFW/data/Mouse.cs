namespace FrederikaStudio.GLFW;

[Flags]
public enum InputState : byte
{
    NonePress,
    Release,
    Press,
    Repeat,
}
public sealed class Mouse
{
    private InputState[] ListStateButtons { get; } = new InputState[3];
    private _nGLFW.Window Handle { get; }

    internal Mouse(_nGLFW.Window handle)
    {
        Handle = handle;
        _ = Context.NativeGLFW.SetScrollCallback(Handle, ScrollCallback);
    }

    private void ScrollCallback(_nGLFW.Window window, double xoffset, double yoffset) =>
        OffsetScroll = new(xoffset, yoffset);
    public static bool RawMouseMotionSupported => Context.NativeGLFW.RawMouseMotionSupported();
    public _Math.Vector2D<double> OffsetScroll { get; private set; }
    public _Math.Vector2D<double> Position
    {
        get
        {
            Context.NativeGLFW.GetCursorPos(Handle, out var xpos, out var ypos);
            return new(xpos, ypos);
        }
        set => Context.NativeGLFW.SetCursorPos(Handle, value.X, value.Y);
    }
    public InputState GetMouseButton(_nGLFW.MouseButton button) => ListStateButtons[(int)button];
    public void PollEvents()
    {
        foreach (var s in Enum.GetValues<_nGLFW.MouseButton>())
        {
            var flag = Context.NativeGLFW.GetMouseButton(Handle, s) == _nGLFW.InputState.Press;
            var last_state = ListStateButtons[(int)s];
            ListStateButtons[(int)s] = flag ?
                (last_state == InputState.NonePress ? InputState.Press :
                last_state == InputState.Press || last_state == InputState.Repeat ? InputState.Repeat : default) :
                (last_state == InputState.Press || last_state == InputState.Repeat ? InputState.Release :
                last_state == InputState.Release || last_state == InputState.NonePress ? InputState.NonePress : default);

        }
    }
}