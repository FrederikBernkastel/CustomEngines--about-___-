namespace FrederikaStudio.GLFW;

public sealed class Keyboard
{
    public static int GetKeyScancode(_nGLFW.Keys key) => 
        Context.NativeGLFW.GetKeyScancode(key);
    public static string GetKeyName(_nGLFW.Keys key, int scancode) => 
        Context.NativeGLFW.GetKeyName(key, scancode);
    private InputState[] ListStateKeys { get; } = new InputState[349];
    private _nGLFW.Window Handle { get; }

    internal Keyboard(_nGLFW.Window handle) => Handle = handle;

    public InputState GetKey(_nGLFW.Keys key) => ListStateKeys[(int)key];
    public void PollEvents()
    {
        foreach (var s in Enum.GetValues<_nGLFW.Keys>())
        {
            var flag = Context.NativeGLFW.GetKey(Handle, s) == _nGLFW.InputState.Press;
            var last_state = ListStateKeys[(int)s];
            ListStateKeys[(int)s] = flag ?
                (last_state == InputState.NonePress ? InputState.Press :
                last_state == InputState.Press || last_state == InputState.Repeat ? InputState.Repeat : default) :
                (last_state == InputState.Press || last_state == InputState.Repeat ? InputState.Release :
                last_state == InputState.Release || last_state == InputState.NonePress ? InputState.NonePress : default);
        }
    }
}
