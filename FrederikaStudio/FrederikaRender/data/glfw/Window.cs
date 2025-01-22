namespace FrederikaStudio.GLFW;

internal sealed class Window : IWindow
{
    private _Math.Vector2D<int> AspectRatioTemp { get; set; }
    private _Math.Vector4D<int> SizeLimitsTemp { get; set; }

    public IContextAttributes ContextAttributes { get; init; }
    public IWindowAttributes WindowAttributes { get; init; }
    public IWindowInputMode InputMode { get; init; }
    //public Mouse Mouse { get; }
    //public Keyboard Keyboard { get; }
    public _nGLFW.Window Handle { get; init; }

    public IntPtr UserPointer
    {
        set => Library.GLFW.SetWindowUserPointer(Handle, value);
        get => Library.GLFW.GetWindowUserPointer(Handle);
    }
    public void SetMonitor(IMonitor monitor, int xpos, int ypos, int width, int height, int refreshRate) =>
        Library.GLFW.SetWindowMonitor(Handle, monitor.Handle, xpos, ypos, width, height, refreshRate);
    public float Opacity
    {
        set => Library.GLFW.SetWindowOpacity(Handle, value);
        get => Library.GLFW.GetWindowOpacity(Handle);
    }
    public void Close(bool value) => Library.GLFW.SetWindowShouldClose(Handle, value);
    public bool IsOpen => !Library.GLFW.WindowShouldClose(Handle);
    public string Title
    {
        set => Library.GLFW.SetWindowTitle(Handle, value);
    }
    public void SetWindowIcon(_nGLFW.Image[] images) => throw new Exception();
    public _Math.Vector2D<int> Position
    {
        set => Library.GLFW.SetWindowPos(Handle, value.X, value.Y);
        get
        {
            Library.GLFW.GetWindowPos(Handle, out var xpos, out var ypos);
            return new(xpos, ypos);
        }
    }
    public _Math.Vector4D<int> SizeLimits
    {
        set
        {
            Library.GLFW.SetWindowSizeLimits(Handle, value.X, value.Y, value.Z, value.W);
            SizeLimitsTemp = value;
        }
        get => SizeLimitsTemp;
    }
    public _Math.Vector2D<int> AspectRatio
    {
        set
        {
            Library.GLFW.SetWindowAspectRatio(Handle, value.X, value.Y);
            AspectRatioTemp = value;
        }
        get => AspectRatioTemp;
    }
    public _Math.Vector2D<int> Size
    {
        set => Library.GLFW.SetWindowSize(Handle, value.X, value.Y);
        get
        {
            Library.GLFW.GetWindowSize(Handle, out var width, out var height);
            return new(width, height);
        }
    }
    public IMonitor Monitor => IMonitor.ListMonitors[Library.GLFW.GetWindowMonitor(Handle)];
    public _Math.Vector2D<int> FramebufferSize
    {
        get
        {
            Library.GLFW.GetFramebufferSize(Handle, out var width, out var height);
            return new(width, height);
        }
    }
    public _Math.Vector4D<int> FrameSize
    {
        get
        {
            Library.GLFW.GetWindowFrameSize(Handle, out var left, out var top, out var right, out var bottom);
            return new(left, top, right, bottom);
        }
    }
    public _Math.Vector2D<float> ContentScale
    {
        get
        {
            Library.GLFW.GetWindowContentScale(Handle, out var xscale, out var yscale);
            return new(xscale, yscale);
        }
    }
    public void SwapBuffers() => Library.GLFW.SwapBuffers(Handle);
    public void MakeContextCurrent() => Library.GLFW.MakeContextCurrent(Handle);
    public void IconifyWindow() => Library.GLFW.IconifyWindow(Handle);
    public void RestoreWindow() => Library.GLFW.RestoreWindow(Handle);
    public void MaximizeWindow() => Library.GLFW.MaximizeWindow(Handle);
    public void ShowWindow() => Library.GLFW.ShowWindow(Handle);
    public void HideWindow() => Library.GLFW.HideWindow(Handle);
    public void FocusWindow() => Library.GLFW.FocusWindow(Handle);
    public void RequestWindowAttention() => Library.GLFW.RequestWindowAttention(Handle);
    public void Dispose()
    {
        Library.GLFW.DestroyWindow(Handle);
        IWindow.ListWindows.Remove(Handle);
    }
}
//public static class KeyboardGLFW
//{
//    public static ProccessingEventsKeyboardGLFW Proccessing { get; } = new();

//    internal static bool IsPressedKey(WindowGLFW window, FSNG.KeysGLFW key) => 
//        GLFW.NativeGLFW.GetKey(window.Window, key) == FSNG.InputStateGLFW.Press;
//    internal static char KeyName(FSNG.KeysGLFW key) => GLFW.NativeGLFW.GetKeyName(key, 0)[0];
//    internal static int KeyScancode(FSNG.KeysGLFW key) => GLFW.NativeGLFW.GetKeyScancode(key);
//}
//public sealed class StorageEventsKeyboardGLFW
//{
//    internal Dictionary<Action<char>, byte> CharEnter { get; } = new(100);
//    internal Dictionary<Action, InfoKeyCallback> ListKeyCallbacks { get; } = new(100);

//    public void AddCallbackKey(FSNG.KeysGLFW key, FSNG.InputStateGLFW state, Action action) =>
//        ListKeyCallbacks[action] = new((ushort)key, (byte)state);
//    public void RemoveCallbackKey(Action action) => ListKeyCallbacks.Remove(action);
//    public void AddCallbackCharEnter(Action<char> action) => CharEnter[action] = 0;
//    public void RemoveCallbackCharEnter(Action<char> action) => CharEnter.Remove(action);

//    [StructLayout(LayoutKind.Sequential)]
//    public readonly record struct InfoKeyCallback(ushort Key, byte State);
//}
//public sealed class StorageEventsMouseGLFW
//{
//    internal Dictionary<Action, InfoButtonCallback> ListButtonCallbacks { get; } = new();
//    internal Dictionary<Action<double, double>, byte> CursorPosition { get; } = new();
//    internal Dictionary<Action<bool>, byte> CursorEnter { get; } = new();
//    internal Dictionary<Action<double, double>, byte> CursorScroll { get; } = new();

//    public void AddCallbackCursorPosition(Action<double, double> action) => CursorPosition[action] = 0;
//    public void RemoveCallbackCursorPosition(Action<double, double> action) => CursorPosition.Remove(action);
//    public void AddCallbackCursorEnter(Action<bool> action) => CursorEnter[action] = 0;
//    public void RemoveCallbackCursorEnter(Action<bool> action) => CursorEnter.Remove(action);
//    public void AddCallbackButton(FSNG.MouseButtonGLFW button, FSNG.InputStateGLFW state, Action action) =>
//        ListButtonCallbacks[action] = new((byte)button, (byte)state);
//    public void RemoveCallbackButton(Action action) => ListButtonCallbacks.Remove(action);
//    public void AddCallbackWindowScroll(Action<double, double> action) => CursorScroll[action] = 0;
//    public void RemoveCallbackWindowScroll(Action<double, double> action) => CursorScroll.Remove(action);

//    [StructLayout(LayoutKind.Sequential)]
//    public readonly record struct InfoButtonCallback(byte Button, byte State);
//}
//public sealed class ProccessingEventsKeyboardGLFW
//{
//    private Dictionary<ushort, int> KeysIndex { get; }
//    private bool[] ListKeys { get; }
//    /////////////////////////////////////////////////////////////////
//    public static bool IsThreadEnterChar { get; set; } = false;

//    internal ProccessingEventsKeyboardGLFW()
//    {
//        int index = 0;
//        KeysIndex = Enum.GetValues<FSNG.KeysGLFW>().Cast<int>().ToDictionary(u => (ushort)u, u => index++);
//        ListKeys = new bool[KeysIndex.Count * 2];
//    }

//    private void PollEventsKey(WindowGLFW window, StorageEventsKeyboardGLFW storage)
//    {
//        var IsPressedAnyKey = false;
//        int index = default, length = ListKeys.Length / 2;
//        Buffer.BlockCopy(ListKeys, length, ListKeys, 0, length);
//        Action[]? actions = default;
//        foreach (var s in KeysIndex.Keys)
//        {
//            var flag = GLFW.NativeGLFW.GetKey(window.Window, (FSNG.KeysGLFW)s) == FSNG.InputStateGLFW.Press;
//            IsPressedAnyKey = IsPressedAnyKey || flag;
//            ListKeys[length + index++] = flag;
//        }
//        if (IsPressedAnyKey)
//        {
//            actions = new Action[storage.ListKeyCallbacks.Count];
//            index = 0;
//            foreach (var s in storage.ListKeyCallbacks)
//            {
//                int button = KeysIndex[s.Value.Key];
//                if (new bool[3] {
//                    !ListKeys[button + length] && ListKeys[button],
//                    ListKeys[button + length] && !ListKeys[button],
//                    ListKeys[button + length] }[s.Value.State])
//                    actions[index++] = s.Key;
//            }
//        }
//        if (IsPressedAnyKey)
//            for (var i = 0; i < index; i++)
//                actions![i]();
//    }
//    private void PollEventsChar(WindowGLFW window, StorageEventsKeyboardGLFW storage)
//    {
//        var IsPressedAnyKey = false;
//        int index = default;
//        char ch = default;
//        foreach (var s in KeysIndex.Keys)
//        {
//            if (KeyboardGLFW.IsPressedKey(window, (FSNG.KeysGLFW)s))
//            {
//                ch = KeyboardGLFW.KeyName((FSNG.KeysGLFW)s);
//                IsPressedAnyKey = true;
//                index++;
//            }
//            if (index > 1)
//            {
//                IsPressedAnyKey = false;
//                return;
//            }
//        }
//        if (IsPressedAnyKey)
//            foreach (var s in storage.CharEnter.Keys)
//                s(ch);
//    }
//    public void PollEvents(WindowGLFW window, StorageEventsKeyboardGLFW storage)
//    {
//        if (IsThreadEnterChar)
//            PollEventsChar(window, storage);
//        else
//            PollEventsKey(window, storage);
//    }
//}
//public sealed class ProccessingEventsMouseGLFW
//{
//    private Dictionary<byte, int> ButtonsIndex { get; }
//    private bool[] ListButtons { get; }
//    /////////////////////////////////////////////////////////////////
//    private bool LastHoverCursor { get; set; }
//    /////////////////////////////////////////////////////////////////
//    private Vector2<double> LastCursorPosition { get; set; }

//    internal ProccessingEventsMouseGLFW()
//    {
//        int index = 0;
//        ButtonsIndex = Enum.GetValues<FSNG.MouseButtonGLFW>().Cast<int>().ToDictionary(u => (byte)u, u => index++);
//        ListButtons = new bool[ButtonsIndex.Count * 2];
//    }

//    public void PollEvents(WindowGLFW window, StorageEventsMouseGLFW storage, WindowAttributesGLFW attributes)
//    {
//        var IsChangeHoverCursor = false;
//        var IsPressedAnyKey = false;
//        var IsMoveCursor = false;
//        int index = default, length = ListButtons.Length / 2;
//        Buffer.BlockCopy(ListButtons, length, ListButtons, 0, length);
//        Action[]? actions = default;
//        foreach (var s in ButtonsIndex.Keys)
//        {
//            var flag = MouseGLFW.IsPressedButton(window, (FSNG.MouseButtonGLFW)s);
//            IsPressedAnyKey = IsPressedAnyKey || flag;
//            ListButtons[length + index++] = flag;
//        }
//        if (IsPressedAnyKey)
//        {
//            actions = new Action[storage.ListButtonCallbacks.Count];
//            index = 0;
//            foreach (var s in storage.ListButtonCallbacks)
//            {
//                int button = ButtonsIndex[s.Value.Button];
//                if (new bool[3] {
//                    !ListButtons[button + length] && ListButtons[button],
//                    ListButtons[button + length] && !ListButtons[button],
//                    ListButtons[button + length] }[s.Value.State])
//                    actions[index++] = s.Key;
//            }
//        }
//        var flag1 = attributes.IsHover;
//        if (flag1 != LastHoverCursor)
//            IsChangeHoverCursor = true;
//        LastHoverCursor = flag1;
//        MouseGLFW.GetCursorPosition(window, out var xpos, out var ypos);
//        if (xpos != LastCursorPosition.X || ypos != LastCursorPosition.Y)
//            IsMoveCursor = true;
//        LastCursorPosition = new(xpos, ypos);
//        if (IsPressedAnyKey)
//            for (var i = 0; i < index; i++) 
//                actions![i]();
//        if (IsChangeHoverCursor)
//            foreach (var s in storage.CursorEnter.Keys)
//                s(flag1);
//        if (IsMoveCursor)
//            foreach (var s in storage.CursorPosition.Keys)
//                s(xpos, ypos);
//    }

//    private readonly record struct Vector2<T>(T X, T Y);
//}
//public static class MouseGLFW
//{
//    public static ProccessingEventsMouseGLFW Proccessing { get; } = new();

//    internal static void GetCursorPosition(WindowGLFW window, out double xpos, out double ypos) => 
//        GLFW.NativeGLFW.GetCursorPos(window.Window, out xpos, out ypos);
//    public static void SetCursorPosition(WindowGLFW window, double xpos, double ypos) =>
//        GLFW.NativeGLFW.SetCursorPos(window.Window, xpos, ypos);
//    internal static bool IsPressedButton(WindowGLFW window, FSNG.MouseButtonGLFW button) =>
//        GLFW.NativeGLFW.GetMouseButton(window.Window, button) == FSNG.InputStateGLFW.Press;
//}
//public sealed class StorageEventsWindowGLFW
//{
//    private event Action<int, int> WindowPosition = delegate { };
//    private event Action<int, int> WindowSize = delegate { };
//    private event Action WindowClose = delegate { };
//    private event Action<bool> WindowIconify = delegate { };
//    private event Action<bool> WindowFocus = delegate { };
//    private event Action<bool> WindowMaximize = delegate { };
//}
//public sealed class WindowGLFW
//{
//    internal FSNG.WindowNativeGLFW Window { get; }
//    internal Vector2<double> ScrollOffset { get; set; }

//    public WindowAttributesGLFW Attributes { get; }
//    public StorageEventsMouseGLFW StorageEventsMouse { get; } = new();
//    public StorageEventsKeyboardGLFW StorageEventsKeyboard { get; } = new();
//    public StorageEventsWindowGLFW Events { get; } = new();

//    internal WindowGLFW(int width, int height, string title, FSNG.MonitorNativeGLFW monitor)
//    {
//        Window = GLFW.NativeGLFW.CreateWindow(width, height, title, monitor, default);
//        GLFW.IsErrors();
//        GLFW.NativeGLFW.SetScrollCallback(Window, (u, e, w) => ScrollOffset = new(e, w));
//        Attributes = new(Window);
//    }

//    public void GetWindowPosition(out int xpos, out int ypos) => GLFW.NativeGLFW.GetWindowPos(Window, out xpos, out ypos);
//    public void GetWindowSize(out int width, out int height) => GLFW.NativeGLFW.GetWindowSize(Window, out width, out height);

//    internal readonly record struct Vector2<T>(T X, T Y);
//}
//internal sealed class ProccessingEventsGLFW : FSW.AProccessingEvents
//{
//    private WindowAttrGLFW WindowAttr { get; }

//    public override bool WindowClose => GLFW.NativeGLFW.WindowShouldClose(WindowAttr.Window);
//    public override bool WindowIconify => WindowAttr.IsIconify;
//    public override bool WindowFocus => WindowAttr.IsFocus;
//    public override bool WindowMaximize => WindowAttr.IsMaximize;
//    public override bool CursorEnter => WindowAttr.IsHover;
//    public override char ConvertCodepointToChar(ushort codepoint) => GLFW.NativeGLFW.GetKeyName((FSNG.KeysGLFW)codepoint, 0)[0];
//    public override void CursorPosition(out double xpos, out double ypos)
//    {
//        GLFW.NativeGLFW.GetCursorPos(WindowAttr.Window, out var _xpos, out var _ypos);
//        xpos = _xpos;
//        ypos = _ypos;
//    }
//    public override bool PressButtonFunc(byte button) => 
//        GLFW.NativeGLFW.GetMouseButton(WindowAttr.Window, (FSNG.MouseButtonGLFW)button) == FSNG.InputStateGLFW.Press;
//    public override bool PressKeyFunc(ushort key) =>
//        GLFW.NativeGLFW.GetKey(WindowAttr.Window, (FSNG.KeysGLFW)key) == FSNG.InputStateGLFW.Press;
//    public override void WindowPosition(out int xpos, out int ypos)
//    {
//        GLFW.NativeGLFW.GetWindowPos(WindowAttr.Window, out var _xpos, out var _ypos);
//        xpos = _xpos;
//        ypos = _ypos;
//    }
//    public override void WindowScroll(out double xoffset, out double yoffset)
//    {
        
//    }

//    public override void WindowSize(out int width, out int height)
//    {
//        throw new NotImplementedException();
//    }
//}
