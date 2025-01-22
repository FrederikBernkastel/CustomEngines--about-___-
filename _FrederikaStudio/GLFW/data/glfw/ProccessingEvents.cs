namespace FrederikaStudio.GLFW;

public sealed class ProccessingGLFW : AProccessing
{
    private SNGLFW.WindowGLFW Handle { get; }

    internal ProccessingGLFW(SNGLFW.WindowGLFW handle) => Handle = handle;

    protected internal override void ProccessingKeys(Span<bool> keys)
    {
        int index = 0;
        foreach (var s in Enum.GetValues<ENGLFW.KeysGLFW>())
        {
            keys[index] = LibraryGLFW.GLFW.GetKey(Handle, s) == ENGLFW.InputStateGLFW.Press;
            index++;
        }
    }
    protected internal override void ProccessingButtons(Span<bool> buttons)
    {
        int index = 0;
        foreach (var s in Enum.GetValues<ENGLFW.MouseButtonGLFW>())
        {
            buttons[index] = LibraryGLFW.GLFW.GetMouseButton(Handle, s) == ENGLFW.InputStateGLFW.Press;
            index++;
        }
    }
}
public sealed class ProccessingEventsGLFW : AProccessingEvents<ENGLFW.KeysGLFW, ENGLFW.MouseButtonGLFW>
{
    public ProccessingEventsGLFW(ProccessingGLFW proccessing) : base(proccessing) { }

    public void AddCallback(ENGLFW.KeysGLFW key, ENGLFW.InputStateGLFW state, Action action) =>
        AddCallback(new InfoKeyCallback((ushort)key, (byte)state, action));
    public void AddCallback(ENGLFW.MouseButtonGLFW button, ENGLFW.InputStateGLFW state, Action action) =>
        AddCallback(new InfoButtonCallback((byte)button, (byte)state, action));
}
