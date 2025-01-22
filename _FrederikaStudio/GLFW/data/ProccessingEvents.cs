namespace FrederikaStudio.Window;

public sealed class ProccessingKeys<T, Y> where T : struct, Enum where Y : struct, Enum
{
    private ProccessingKeysFactory<T, Y> Factory { get; }
    private bool[] ListKeysButtons { get; }
    private Dictionary<Action, InfoKeyCallback> ListKeyCallbacks { get; } = new();
    private Dictionary<Action, InfoButtonCallback> ListButtonCallbacks { get; } = new();
    private Func<ushort, bool> PressKeyFunc { get; }
    private Func<byte, bool> PressButtonFunc { get; }

    internal ProccessingKeys(ProccessingKeysFactory<T, Y> factory, Func<ushort, bool> press_key_func, Func<byte, bool> press_button_func)
    {
        Factory = factory;
        PressKeyFunc = press_key_func;
        PressButtonFunc = press_button_func;
        ListKeysButtons = new bool[factory.Keys.Count * 2 + factory.Buttons.Count * 2];
    }

    public void AddCallback(T _enum, InputState state, Action action) => ListKeyCallbacks[action] =
            typeof(T).IsEnum ? new((ushort)new T[1] { _enum }.Cast<int>().First(), (byte)state) :
            throw new ArgumentException("T must be an enumerated type");
    public void AddCallback(Y _enum, InputState state, Action action) => ListButtonCallbacks[action] =
            typeof(Y).IsEnum ? new((byte)new Y[1] { _enum }.Cast<int>().First(), (byte)state) :
            throw new ArgumentException("T must be an enumerated type");
    public void RemoveKeyCallback(Action action) => ListKeyCallbacks.Remove(action);
    public void RemoveButtonCallback(Action action) => ListButtonCallbacks.Remove(action);
    public void InvokeCallbacks()
    {
        var dic_keys = Factory.Keys;
        var dic_buttons = Factory.Buttons;
        int index = 0, length = ListKeysButtons.Length / 2;
        var actions = new Action[ListKeyCallbacks.Count + ListButtonCallbacks.Count];
        foreach (var s in ListKeyCallbacks)
        {
            int key = dic_keys[s.Value.Key];
            if (new bool[3] {
                !ListKeysButtons[key + length] && ListKeysButtons[key],
                ListKeysButtons[key + length] && !ListKeysButtons[key],
                ListKeysButtons[key + length] }[s.Value.State])
            {
                actions[index] = s.Key;
                index++;
            }
        }
        foreach (var s in ListButtonCallbacks)
        {
            int button = dic_buttons[s.Value.Button];
            if (new bool[3] {
                !ListKeysButtons[button + length + dic_keys.Count] && ListKeysButtons[button + dic_keys.Count],
                ListKeysButtons[button + length + dic_keys.Count] && !ListKeysButtons[button + dic_keys.Count],
                ListKeysButtons[button + length + dic_keys.Count] }[s.Value.State])
            {
                actions[index] = s.Key;
                index++;
            }
        }
        for (var i = 0; i < index; i++)
            actions[i]();
    }
    public void PoolEvents()
    {
        var dic_keys = Factory.Keys;
        var dic_buttons = Factory.Buttons;
        int index = 0, length = ListKeysButtons.Length / 2;
        Buffer.BlockCopy(ListKeysButtons, length, ListKeysButtons, 0, length);
        foreach (var s in dic_keys.Keys)
        {
            ListKeysButtons[length + index] = PressKeyFunc(s);
            index++;
        }
        foreach (var s in dic_buttons.Keys)
        {
            ListKeysButtons[length + index] = PressButtonFunc(s);
            index++;
        }
        
    }

    public enum InputState
    {
        Release = 0,
        Press = 1,
        Repeat = 2,
    }
    [StructLayout(LayoutKind.Sequential)]
    private readonly record struct InfoKeyCallback(ushort Key, byte State);
    [StructLayout(LayoutKind.Sequential)]
    private readonly record struct InfoButtonCallback(byte Button, byte State);
}
public sealed class ProccessingKeysFactory<T, Y> where T : struct, Enum where Y : struct, Enum
{
    internal Dictionary<ushort, int> Keys { get; }
    internal Dictionary<byte, int> Buttons { get; }

    public ProccessingKeysFactory()
    {
        int index = 0;
        Keys = Enum.GetValues<T>().Cast<int>().ToDictionary(u => (ushort)u, u => index++); index = 0;
        Buttons = Enum.GetValues<Y>().Cast<int>().ToDictionary(u => (byte)u, u => index++);
    }

    public ProccessingKeys<T, Y> CreateProccessingKeys(Func<ushort, bool> press_key_func, Func<byte, bool> press_button_func) => 
        new(this, press_key_func, press_button_func);
}
