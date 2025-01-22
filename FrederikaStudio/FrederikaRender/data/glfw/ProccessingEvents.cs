namespace FrederikaStudio.GLFW;

//public sealed class StorageEvents
//{
//    private event Action<int, int> WindowPosition = delegate { };
//    private event Action<int, int> WindowSize = delegate { };
//    private event Action WindowClose = delegate { };
//    private event Action<double, double> CursorPosition = delegate { };
//    private event Action<char> CharEnter = delegate { };
//    private event Action<double, double> WindowScroll = delegate { };
//    private event Action<bool> WindowIconify = delegate { };
//    private event Action<bool> WindowFocus = delegate { };
//    private event Action<bool> WindowMaximize = delegate { };
//    private event Action<bool> CursorEnter = delegate { };
//    public Dictionary<Action, InfoKeyCallback> ListKeyCallbacks { get; } = new();
//    public Dictionary<Action, InfoButtonCallback> ListButtonCallbacks { get; } = new();

//    public void AddCallbackWindowPosition(Action<int, int> action) => WindowPosition += action;
//    public void AddCallbackWindowSize(Action<int, int> action) => WindowSize += action;
//    public void AddCallbackWindowClose(Action action) => WindowClose += action;
//    public void AddCallbackCursorPosition(Action<double, double> action) => CursorPosition += action;
//    public void AddCallbackCharEnter(Action<char> action) => CharEnter += action;
//    public void AddCallbackWindowScroll(Action<double, double> action) => WindowScroll += action;
//    public void AddCallbackWindowIconify(Action<bool> action) => WindowIconify += action;
//    public void AddCallbackWindowFocus(Action<bool> action) => WindowFocus += action;
//    public void AddCallbackWindowMaximize(Action<bool> action) => WindowMaximize += action;
//    public void AddCallbackCursorEnter(Action<bool> action) => CursorEnter += action;
//    public void AddCallbackKey(FSNG.KeysGLFW key, FSNG.InputStateGLFW state, Action action) =>
//        ListKeyCallbacks[action] = new((ushort)key, (byte)state);
//    public void AddCallbackButton(FSNG.MouseButtonGLFW button, FSNG.InputStateGLFW state, Action action) =>
//        ListButtonCallbacks[action] = new((byte)button, (byte)state);
//    /////////////////////////////////////////////////////////////////////////
//    public void RemoveCallbackWindowPosition(Action<int, int> action) => WindowPosition -= action;
//    public void RemoveCallbackWindowSize(Action<int, int> action) => WindowSize -= action;
//    public void RemoveCallbackWindowClose(Action action) => WindowClose -= action;
//    public void RemoveCallbackCursorPosition(Action<double, double> action) => CursorPosition -= action;
//    public void RemoveCallbackCharEnter(Action<char> action) => CharEnter -= action;
//    public void RemoveCallbackWindowScroll(Action<double, double> action) => WindowScroll -= action;
//    public void RemoveCallbackWindowIconify(Action<bool> action) => WindowIconify -= action;
//    public void RemoveCallbackWindowFocus(Action<bool> action) => WindowFocus -= action;
//    public void RemoveCallbackWindowMaximize(Action<bool> action) => WindowMaximize -= action;
//    public void RemoveCallbackCursorEnter(Action<bool> action) => CursorEnter -= action;
//    public void RemoveCallbackKey(Action action) => ListKeyCallbacks.Remove(action);
//    public void RemoveCallbackButton(Action action) => ListButtonCallbacks.Remove(action);
//    /////////////////////////////////////////////////////////////////////////
//    internal void InvokeWindowPosition(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeWindowSize(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeWindowClose(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeCursorPosition(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeCharEnter(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeWindowScroll(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeWindowIconify(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeWindowFocus(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeWindowMaximize(int xpos, int ypos) => WindowPosition(xpos, ypos);
//    internal void InvokeCursorEnter(int xpos, int ypos) => WindowPosition(xpos, ypos);

//    [StructLayout(LayoutKind.Sequential)]
//    public readonly record struct InfoKeyCallback(ushort Key, byte State);
//    [StructLayout(LayoutKind.Sequential)]
//    public readonly record struct InfoButtonCallback(byte Button, byte State);
//}
//public static class ProccessingEvents
//{
//    //private ProccessingFactory<T, Y> Factory { get; }
//    //private AProccessingEvents Proccessing { get; }
//    /////////////////////////////////////////////////////////////////////////

//    /////////////////////////////////////////////////////////////////////////
//    private static bool[] ListKeysButtons { get; }
//    private static bool[] FieldsBool { get; } = new bool[11];
//    private static Vector2<int> PositionWindow { get; set; } = new(int.MinValue, int.MinValue);
//    private static Vector2<int> SizeWindow { get; set; } = new(int.MinValue, int.MinValue);
//    private static Vector2<double> PositionCursor { get; set; } = new(int.MinValue, int.MinValue);
//    private static Vector2<double> PositionScroll { get; set; } = new(int.MinValue, int.MinValue);
//    private static ushort LastChar { get; set; }
//    /////////////////////////////////////////////////////////////////////////
//    public static bool IsThreadEnterChar { get; set; } = false;

//    internal ProccessingEvents(ProccessingFactory<T, Y> factory, AProccessingEvents proccessing)
//    {
        
//        Factory = factory;
//        Proccessing = proccessing;
//        ListKeysButtons = new bool[factory.Keys.Count * 2 + factory.Buttons.Count * 2];
//    }

    
//    /////////////////////////////////////////////////////////////////////////
//    public static void PollEvents(WindowGLFW window)
//    {
//        Action<WindowGLFW> action = IsThreadEnterChar ? PollEventsCharEnter : PollEventsKeys;
//        PollEventsWindow(window);
//        action(window);
//    }
//    public static void InvokeCallbacks(WindowGLFW window)
//    {
//        Action<WindowGLFW> action = IsThreadEnterChar ? InvokeCallbacksCharEnter : InvokeCallbacksKeys;
//        InvokeCallbacksWindow(window);
//        action(window);
//    }
//    /////////////////////////////////////////////////////////////////////////
//    private static void PollEventsWindow(WindowGLFW window)
//    {
        
//        proccessing.WindowPosition(out var xpos, out var ypos);
//        FieldsBool[0] = PositionWindow.X != xpos || PositionWindow.Y != ypos;
//        PositionWindow = new(xpos, ypos);
//        proccessing.WindowSize(out var width, out var height);
//        FieldsBool[1] = SizeWindow.X != width || SizeWindow.Y != height;
//        SizeWindow = new(width, height);
//        FieldsBool[2] = proccessing.WindowClose;
//        proccessing.CursorPosition(out var xpos1, out var ypos1);
//        FieldsBool[3] = PositionCursor.X != xpos1 || PositionCursor.Y != ypos1;
//        PositionCursor = new(xpos, ypos);
//        proccessing.WindowScroll(out var xoffset, out var yoffset);
//        FieldsBool[4] = PositionScroll.X != xoffset || PositionScroll.Y != yoffset;
//        PositionScroll = new(xoffset, yoffset);
//        FieldsBool[5] = proccessing.WindowIconify;
//        FieldsBool[6] = proccessing.WindowFocus;
//        FieldsBool[7] = proccessing.WindowMaximize;
//        FieldsBool[8] = proccessing.CursorEnter;
//    }
//    private static void PollEventsKeys(WindowGLFW window)
//    {
//        FieldsBool[9] = false; FieldsBool[10] = false;
//        int index = 0, length = ListKeysButtons.Length / 2;
//        Buffer.BlockCopy(ListKeysButtons, length, ListKeysButtons, 0, length);
//        foreach (var s in Factory.Keys.Keys)
//        {
//            var flag = proccessing.PressKeyFunc(s);
//            FieldsBool[9] = FieldsBool[9] || flag;
//            ListKeysButtons[length + index] = flag;
//            index++;
//        }
//        foreach (var s in Factory.Buttons.Keys)
//        {
//            var flag = proccessing.PressButtonFunc(s);
//            FieldsBool[10] = FieldsBool[10] || flag;
//            ListKeysButtons[length + index] = Proccessing.PressButtonFunc(s);
//            index++;
//        }
//    }
//    private static void PollEventsCharEnter(WindowGLFW window)
//    {
//        FieldsBool[9] = false;
//        int index = 0, length = ListKeysButtons.Length / 2;
//        Buffer.BlockCopy(ListKeysButtons, length, ListKeysButtons, 0, length);
//        foreach (var s in Factory.Keys.Keys)
//        {
//            var flag = Proccessing.PressKeyFunc(s);
//            if (flag)
//                LastChar = s;
//            ListKeysButtons[length + index] = flag;
//            index++;
//        }
//        if (ListKeysButtons.Count(u => u) == 1)
//        {
//            var ch = Proccessing.ConvertCodepointToChar(LastChar);
//            if (ch >= 33 && ch <= 125)
//                FieldsBool[9] = true;
//        }
//    }
//    /////////////////////////////////////////////////////////////////////////
//    private static void InvokeCallbacksWindow(WindowGLFW window)
//    {
//        if (FieldsBool[0])
//            WindowPosition(PositionWindow.X, PositionWindow.Y);
//        if (FieldsBool[1])
//            WindowSize(SizeWindow.X, SizeWindow.Y);
//        if (FieldsBool[2])
//            WindowClose();
//        if (FieldsBool[3])
//            CursorPosition(PositionCursor.X, PositionCursor.Y);
//        if (FieldsBool[4])
//            WindowScroll(PositionScroll.X, PositionScroll.Y);
//        if (FieldsBool[5])
//            WindowIconify(FieldsBool[5]);
//        if (FieldsBool[6])
//            WindowFocus(FieldsBool[6]);
//        if (FieldsBool[7])
//            WindowMaximize(FieldsBool[7]);
//        if (FieldsBool[8])
//            CursorEnter(FieldsBool[8]);
//    }
//    private static void InvokeCallbacksCharEnter(WindowGLFW window)
//    {
//        if (!FieldsBool[9])
//            return;
//        CharEnter(LastChar);
//    }
//    private static void InvokeCallbacksKeys(WindowGLFW window)
//    {
//        if (!FieldsBool[9] && !FieldsBool[10])
//            return;
//        var dic_keys = Factory.Keys;
//        var dic_buttons = Factory.Buttons;
//        int index = 0, length = ListKeysButtons.Length / 2;
//        var actions = new Action[ListKeyCallbacks.Count + ListButtonCallbacks.Count];
//        var count = Factory.Keys.Count;
//        if (FieldsBool[9])
//        {
//            foreach (var s in ListKeyCallbacks)
//            {
//                int key = Factory.Keys[s.Value.Key];
//                if (new bool[3] {
//                !ListKeysButtons[key + length] && ListKeysButtons[key],
//                ListKeysButtons[key + length] && !ListKeysButtons[key],
//                ListKeysButtons[key + length] }[s.Value.State])
//                {
//                    actions[index] = s.Key;
//                    index++;
//                }
//            }
//        }
//        if (FieldsBool[10])
//        {
//            foreach (var s in ListButtonCallbacks)
//            {
//                int button = Factory.Buttons[s.Value.Button];
//                if (new bool[3] {
//                !ListKeysButtons[button + length + count] && ListKeysButtons[button + count],
//                ListKeysButtons[button + length + count] && !ListKeysButtons[button + count],
//                ListKeysButtons[button + length + count] }[s.Value.State])
//                {
//                    actions[index] = s.Key;
//                    index++;
//                }
//            }
//        }
//        for (var i = 0; i < index; i++)
//            actions[i]();
//    }
//}
//internal sealed class ProccessingFactory<T, Y> where T : struct, Enum where Y : struct, Enum
//{
//    internal static Dictionary<ushort, int> Keys { get; }
//    internal static Dictionary<byte, int> Buttons { get; }

//    public ProccessingFactory()
//    {
//        if (!typeof(T).IsEnum || !typeof(Y).IsEnum)
//            throw new ArgumentException("T must be an enumerated type");
//        int index = 0;
//        Keys = Enum.GetValues<T>().Cast<int>().ToDictionary(u => (ushort)u, u => index++); index = 0;
//        Buttons = Enum.GetValues<Y>().Cast<int>().ToDictionary(u => (byte)u, u => index++);
//    }

//    public static ProccessingEvents<T, Y> CreateProccessingEvents(AProccessingEvents proccessing) where T : struct, Enum where Y : struct, Enum
//    {
//        new(this, proccessing);
//    }
//}