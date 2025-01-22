namespace FrederikaStudio.GLFW;

//public static class ManagerResourcesFS
//{
//    private static byte[] ByteImages { get; } = new byte[100 * 1024 * 1024];
//    private static List<Vector2D<int>> EmptyArea { get; } = new() { new(0, 100 * 1024 * 1024) };
//    public static int FreePlace => ByteImages.Length - Images.Values.Select(u => u.Y - u.X).Aggregate((u, e) => u + e);
//    private static Dictionary<string, Vector2D<int>> Images { get; } = new();
//    public static void UnloadImage(string name)
//    {
//        var place = Images[name];
//        Images.Remove(name);
//        EmptyArea.Add(place);
//    }
//    private static void FragmentationEmptyArea()
//    {

//    }
//    public static void LoadImage(string path, string name)
//    {
//        using var stream = File.OpenRead(path);
//        using var image = Image.Load<Rgba32>(stream);
//        var length = image.Width * image.Height * Marshal.SizeOf<Rgba32>();
//        if (length >= FreePlace)
//            throw new Exception();
//        Vector2D<int> vector = EmptyArea.FirstOrDefault(u => length < u.Y - u.X);
//        if (vector.Y == 0)
//        {
//            //
//        }
//        var pixelBytes = new byte[length];
//        image.CopyPixelDataTo(pixelBytes);
//        Buffer.BlockCopy(pixelBytes, 0, ByteImages, vector.X, length);
//        Images[name] = new(vector.X, vector.X + length);
//        EmptyArea.Remove(vector);
//        if (length < vector.Y - vector.X)
//            EmptyArea.Add(new(vector.X + length, vector.Y));
//    }
//}
//public sealed class ButtonsKeyboardMouseGLFW
//{
//    private _WindowGLFW Window { get; }

//    internal ButtonsKeyboardMouseGLFW(_WindowGLFW window) => Window = window;

//    public ConstGLFW.InputState GetKey(ConstGLFW.Keys key) => CoreGLFW.GLFW.GetKey(Window, key);
//    public ConstGLFW.InputState GetMouseButton(ConstGLFW.MouseButton button) => CoreGLFW.GLFW.GetMouseButton(Window, button);
//    public void SetLockKeyMods(bool mode) => CoreGLFW.GLFW.SetInputMode(Window, (int)ConstGLFW.InputMode.LockKeyMods, mode ? 1 : 0);
//    public bool GetIsLockKeyMods => CoreGLFW.GLFW.GetInputMode(Window, (int)ConstGLFW.InputMode.LockKeyMods) == 1;
//    public static int GetKeyScancode(ConstGLFW.Keys key) => CoreGLFW.GLFW.GetKeyScancode(key);
//    public static string GetKeyName(ConstGLFW.Keys key) => CoreGLFW.GLFW.GetKeyName(key, GetKeyScancode(key));
//}
//public sealed class MouseGLFW
//{
//    private _WindowGLFW Window { get; }

//    internal MouseGLFW(_WindowGLFW window)
//    {
//        Window = window;
//        CoreGLFW.GLFW.SetScrollCallback(window, SetCursorOffset);
//    }

//    public void SetRawMouseMotion(bool mode) => CoreGLFW.GLFW.SetInputMode(Window, (int)ConstGLFW.InputMode.RawMouseMotion, mode ? 1 : 0);
//    public bool GetIsRawMouseMotion => CoreGLFW.GLFW.GetInputMode(Window, (int)ConstGLFW.InputMode.RawMouseMotion) == 1;
//    public void SetCursorMode(ConstGLFW.CursorMode mode) => CoreGLFW.GLFW.SetInputMode(Window, 0x00033001, (int)mode);
//    public ConstGLFW.CursorMode GetCursorMode => (ConstGLFW.CursorMode)CoreGLFW.GLFW.GetInputMode(Window, 0x00033001);

//    public Vector2D<double> GetCursorOffset { get; private set; }
//    internal void SetCursorOffset(_WindowGLFW _, double w, double e) => GetCursorOffset = new(w, e);
//}
public sealed class _WindowGLFW
{

    //public MouseGLFW? Mouse { get; }
    //public ButtonsKeyboardMouseGLFW? ButtonsKeyboardMouse { get; }




    //public static WindowGLFW GetCurrentContext => new(CoreGLFW.GLFW.GetCurrentContext());


    ////////////////////////////////////////////////// AttributeContextGLFW
    //public Vector3D<int> GetVersion => new(
    //    CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.VersionMajor),
    //    CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.VersionMinor),
    //    CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Revision));
    //public bool IsForwardCompat => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.ForwardCompat) == 1;
    //public bool IsDebug => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.OpenglDebug) == 1;
    //public ConstGLFW.WindowHintRobustness GetRobustness => (ConstGLFW.WindowHintRobustness)CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Robustness);
    //public ConstGLFW.WindowHintOpenGLProfile GetOpenGLProfile => (ConstGLFW.WindowHintOpenGLProfile)CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.OpenGLProfile);
    //public ConstGLFW.WindowHintReleaseBehavior GetReleaseBehavior => (ConstGLFW.WindowHintReleaseBehavior)CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.ReleaseBehavior);
    ////////////////////////////////////////////////// AttributeContextGLFW

    ////////////////////////////////////////////////// AttributeWindowGLFW

    // Hints
    // Info after proccessing events
    // Action
    //public bool IsFocus => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Focus) == 1;
    //public bool IsIconify => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Iconify) == 1;
    //public bool IsMaximize => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Maximized) == 1;
    //public bool IsHover => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Hover) == 1;
    //public bool IsVisible => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Visible) == 1;
    //public void SetResizable(bool flag) => CoreGLFW.GLFW.SetWindowAttrib(Window, (int)HintAttrHip.Resizable, flag ? 1 : 0);
    //public bool GetIsResizable => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Resizable) == 1;
    //public void SetDecorate(bool flag) => CoreGLFW.GLFW.SetWindowAttrib(Window, (int)HintAttrHip.Decorate, flag ? 1 : 0);
    //public bool GetIsDecorate => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Decorate) == 1;
    //public void SetAutoIconify(bool flag) => CoreGLFW.GLFW.SetWindowAttrib(Window, (int)HintAttrHip.AutoIconify, flag ? 1 : 0);
    //public bool GetIsAutoIconify => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.AutoIconify) == 1;
    //public void SetFloating(bool flag) => CoreGLFW.GLFW.SetWindowAttrib(Window, (int)HintAttrHip.Floating, flag ? 1 : 0);
    //public bool GetIsFloating => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.Floating) == 1;
    //public bool GetIsTransparentFrameBuffer => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.TransparentFrameBuffer) == 1;
    //public void SetFocusOnShow(bool flag) => CoreGLFW.GLFW.SetWindowAttrib(Window, (int)HintAttrHip.FocusOnShow, flag ? 1 : 0);
    //public bool GetIsFocusOnShow => CoreGLFW.GLFW.GetWindowAttrib(Window, (int)HintAttrHip.FocusOnShow) == 1;

    ////////////////////////////////////////////////// AttributeWindowGLFW

    ////////////////////////////////////////////////// WindowGLFW














    //public void ActionSwapBuffers() => CoreGLFW.GLFW.SwapBuffers(Window);

    //public MonitorGLFW GetWindowMonitor => new(CoreGLFW.GLFW.GetWindowMonitor(Window));
    
    ////////////////////////////////////////////////// WindowGLFW


}
public sealed class WindowGLFW
{
    public static WindowHintGLFW Hint { get; } = new();

    private static WindowGLFW CreateWindow(int width, int height, string name, SNGLFW.MonitorGLFW monitor, SNGLFW.WindowGLFW share)
    {
        var ptr = LibraryGLFW.GLFW.CreateWindow(width, height, name, monitor, share);
        LibraryGLFW.IsErrors();
        return new(ptr);
    }
    public static WindowGLFW CreateWindow(int width, int height, string name, MonitorGLFW monitor, WindowGLFW share) => 
        CreateWindow(width, height, name, monitor.Handle, share.Handle);
    public static WindowGLFW CreateWindow(int width, int height, string name, MonitorGLFW monitor) =>
        CreateWindow(width, height, name, monitor.Handle, new());
    public static WindowGLFW CreateWindow(int width, int height, string name) =>
        CreateWindow(width, height, name, new SNGLFW.MonitorGLFW(), new());

    internal WindowGLFW(SNGLFW.WindowGLFW handle)
    {
        Handle = handle;
        Proccessing = new(handle);
        //Version = new(
        //    ILibraryGLFW.GLFW.GetWindowAttrib(Handle, WindowAttribGetIntGLFW.VersionMajor),
        //    ILibraryGLFW.GLFW.GetWindowAttrib(Handle, WindowAttribGetIntGLFW.VersionMajor),
        //    ILibraryGLFW.GLFW.GetWindowAttrib(Handle, WindowAttribGetIntGLFW.VersionMajor));
    }

    public ProccessingGLFW Proccessing { get; }
    internal SNGLFW.WindowGLFW Handle { get; }
    public void SetWindowShouldClose(bool flag) => LibraryGLFW.GLFW.SetWindowShouldClose(Handle, flag);
    public bool WindowShouldClose => LibraryGLFW.GLFW.WindowShouldClose(Handle);
    public void MakeContextCurrent() => LibraryGLFW.GLFW.MakeContextCurrent(Handle);
    public void SwapBuffers() => LibraryGLFW.GLFW.SwapBuffers(Handle);
    public Vector2D<int> GetFramebufferSize
    {
        get
        {
            LibraryGLFW.GLFW.GetFramebufferSize(Handle, out var width, out var height);
            return new(width, height);
        }
    }
    //public void SetWindowMonitor(IMonitorGLFW monitor, IMonitorGLFW.VidmodeGLFW vidmode) => 
    //    ILibraryGLFW.GLFW.SetWindowMonitor(Handle, monitor.ObjectHandle.Handle, 0, 0, vidmode.Width, vidmode.Height, vidmode.RefreshRate);
    public void Dispose() => LibraryGLFW.GLFW.DestroyWindow(Handle);

    //public IntPtr WindowUserPointer
    //{
    //    get => ILibraryGLFW.GLFW.GetWindowUserPointer(Handle);
    //    set => ILibraryGLFW.GLFW.SetWindowUserPointer(Handle, value);
    //}
    //public void SetWindowIcon(IEnumerable<string> list_path)
    //{
    //    var list = list_path.Select(u =>
    //    {
    //        if (!File.Exists(u))
    //            throw new Exception();
    //        return LoadImage(u);
    //    }).ToArray();
    //    ILibraryGLFW.GLFW.SetWindowIcon(Handle, list.Length, list);
    //    ILibraryGLFW.IsErrors();
    //}
    //public void SetWindowIconDefault() => ILibraryGLFW.GLFW.SetWindowIcon(Handle, 0, Enumerable.Empty<ImageNativeGLFW>().ToArray());
    //public void SetWindowTitle(string title)
    //{
    //    ILibraryGLFW.GLFW.SetWindowTitle(Handle, title);
    //    CoreGLFW.IsErrors();
    //}
    //public void SetWindowSizeLimits(Vector4D<int> limits)
    //{
    //    ILibraryGLFW.GLFW.SetWindowSizeLimits(Handle, limits.X, limits.Y, limits.Z, limits.W);
    //    CoreGLFW.IsErrors();
    //}
    //public void SetWindowAspectRatio(Vector2D<int> ratio)
    //{
    //    ILibraryGLFW.GLFW.SetWindowAspectRatio(Handle, ratio.X, ratio.Y);
    //    CoreGLFW.IsErrors();
    //}
    //public void SetWindowSize(Vector2D<int> size)
    //{
    //    ILibraryGLFW.GLFW.SetWindowSize(Handle, size.X, size.Y);
    //    CoreGLFW.IsErrors();
    //}
    
    //public void SetWindowPosition(Vector2D<int> position)
    //{
    //    ILibraryGLFW.GLFW.SetWindowPos(Handle, position.X, position.Y);
    //    CoreGLFW.IsErrors();
    //}
    //public void SetWindowOpacity(float opacity)
    //{
    //    ILibraryGLFW.GLFW.SetWindowOpacity(Handle, opacity);
    //    CoreGLFW.IsErrors();
    //}
    //public void IconifyWindow() => ILibraryGLFW.GLFW.IconifyWindow(Handle);
    //public void RestoreWindow() => ILibraryGLFW.GLFW.RestoreWindow(Handle);
    //public void MaximizeWindow() => ILibraryGLFW.GLFW.MaximizeWindow(Handle);
    //public void ShowWindow() => ILibraryGLFW.GLFW.ShowWindow(Handle);
    //public void HideWindow() => ILibraryGLFW.GLFW.HideWindow(Handle);
    //public void FocusWindow() => ILibraryGLFW.GLFW.FocusWindow(Handle);
    //public void RequestWindowAttention() => ILibraryGLFW.GLFW.RequestWindowAttention(Handle);
    //public void MakeContextCurrent() => ILibraryGLFW.GLFW.MakeContextCurrent(Handle);
    //public void SetWindowMonitor(MonitorGLFW monitor, Vector4D<int> workarea, int refreshRate) =>
    //    ILibraryGLFW.GLFW.SetWindowMonitor(Handle, monitor.Monitor, workarea.X, workarea.Y, workarea.Z, workarea.W, refreshRate);

    //#endregion

    //#region Info

    //public Vector2D<int> GetWindowSize
    //{
    //    get
    //    {
    //        ILibraryGLFW.GLFW.GetWindowSize(Handle, out var width, out var height);
    //        return new(width, height);
    //    }
    //}
    //public Vector2D<int> GetWindowPosition
    //{
    //    get
    //    {
    //        ILibraryGLFW.GLFW.GetWindowPos(Handle, out var xpos, out var ypos);
    //        return new(xpos, ypos);
    //    }
    //}
    
    //public Vector2D<int> GetFramebufferSize
    //{
    //    get
    //    {
    //        ILibraryGLFW.GLFW.GetFramebufferSize(Handle, out var width, out var height);
    //        return new(width, height);
    //    }
    //}
    //public Vector<int> GetWindowFrameSize
    //{
    //    get
    //    {
    //        ILibraryGLFW.GLFW.GetWindowFrameSize(Handle, out var left, out var top, out var right, out var bottom);
    //        return new(left, top, right, bottom);
    //    }
    //}
    //public Vector2D<float> GetWindowContentScale
    //{
    //    get
    //    {
    //        ILibraryGLFW.GLFW.GetWindowContentScale(Handle, out var xscale, out var yscale);
    //        return new(xscale, yscale);
    //    }
    //}
    //public float GetWindowOpacity => ILibraryGLFW.GLFW.GetWindowOpacity(Handle);
    //public Vector3D<int> Version { get; }

    //#endregion

    //#region Mouse

    //private static ImageNativeGLFW LoadImage(string path)
    //{
    //    using var stream = File.OpenRead(path);
    //    using var image = Image.Load<Rgba32>(stream);
    //    var length = image.Width * image.Height * Marshal.SizeOf<Rgba32>();
    //    var pixelBytes = new byte[length];
    //    image.CopyPixelDataTo(pixelBytes);
    //    ImageNativeGLFW image_glfw = new(image.Width, image.Height, pixelBytes);
    //    return image_glfw;
    //}
    //public void SetCursor(string path, int xOffset, int yOffset)
    //{
    //    if (!File.Exists(path))
    //        throw new Exception();
    //    var image = LoadImage(path);
    //    var cursor = ILibraryGLFW.GLFW.CreateCursor(image, xOffset, yOffset);
    //    ILibraryGLFW.GLFW.SetCursor(Handle, cursor);
    //    CoreGLFW.IsErrors();
    //    ILibraryGLFW.GLFW.DestroyCursor(cursor);
    //}
    //public void SetCursor(IMouseGLFW.CursorType type) => ILibraryGLFW.GLFW.SetCursor(Handle, ILibraryGLFW.GLFW.CreateStandardCursor((CursorTypeGLFW)type));
    //public void SetCursorDefault() => ILibraryGLFW.GLFW.SetCursor(Handle, new());
    //public void SetCursorPosition(Vector2D<double> position)
    //{
    //    ILibraryGLFW.GLFW.SetCursorPos(Handle, position.X, position.Y);
    //    CoreGLFW.IsErrors();
    //}
    //public Vector2D<double> GetCursorPosition
    //{
    //    get
    //    {
    //        ILibraryGLFW.GLFW.GetCursorPos(Handle, out double xpos, out double ypos);
    //        return new(xpos, ypos);
    //    }
    //}

    
}
