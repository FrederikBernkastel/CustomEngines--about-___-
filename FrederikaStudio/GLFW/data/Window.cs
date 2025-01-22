using FrederikaStudio.GLFW.Native;

namespace FrederikaStudio.GLFW;

public static class Events
{
    public static void PollEvents() => Context.NativeGLFW.PollEvents();
    public static void WaitEvents() => Context.NativeGLFW.WaitEvents();
    public static void WaitEventsTimeout(double timeout) => Context.NativeGLFW.WaitEventsTimeout(timeout);
    public static void PostEmptyEvent() => Context.NativeGLFW.PostEmptyEvent();
}
public record StyleWindow
{
    public _Math.Vector2D<int> Size { get; set; } = new(500, 500);
    public string Title { get; set; } = "HelloWorld";
    public Monitor? FullScreen { get; set; } = default;
    public StyleHintContext StyleHintContext { get; set; } = new();
    public StyleHintWindow StyleHintWindow { get; set; } = new();
    public StyleHintMonitor StyleHintMonitor { get; set; } = new();
    public StyleHintFrameBuffer StyleHintFrameBuffer { get; set; } = new();
}
public sealed class Window
{
    internal static Dictionary<_nGLFW.Window, Window> ListWindows { get; } = new();
    public static Dictionary<_nGLFW.Window, Window>.ValueCollection Windows => ListWindows.Values;
    public static Window? CurrentContext
    {
        get
        {
            var window = Context.NativeGLFW.GetCurrentContext();
            return window.Handle == IntPtr.Zero ? default : ListWindows[window];
        }
    }

    private _Math.Vector2D<int> AspectRatioTemp { get; set; }
    private _Math.Vector4D<int> SizeLimitsTemp { get; set; }
    private string TitleTemp { get; set; }

    public _nGLFW.Window Handle { get; }
    public WindowAttributes Attributes { get; }
    public Keyboard Keyboard { get; }
    public Mouse Mouse { get; }
    public WindowInputMode InputMode { get; }

    public Window(StyleWindow styleWindow)
    {
        Context.NativeGLFW.DefaultWindowHints();
        styleWindow.StyleHintContext.Update();
        styleWindow.StyleHintFrameBuffer.Update();
        styleWindow.StyleHintMonitor.Update();
        styleWindow.StyleHintWindow.Update();

        Handle = Context.NativeGLFW.CreateWindow(
            styleWindow.Size.X, styleWindow.Size.Y, styleWindow.Title, styleWindow.FullScreen?.Handle ?? default, default);

        Attributes = new(Handle);
        Keyboard = new(Handle);
        Mouse = new(Handle);
        InputMode = new(Handle);

        TitleTemp = styleWindow.Title;

        ListWindows[Handle] = this;
    }

    public IntPtr UserPointer
    {
        set => Context.NativeGLFW.SetWindowUserPointer(Handle, value);
        get => Context.NativeGLFW.GetWindowUserPointer(Handle);
    }
    public void SetMonitor(Monitor monitor, int xpos, int ypos, int width, int height, int refreshRate) =>
        Context.NativeGLFW.SetWindowMonitor(Handle, monitor.Handle, xpos, ypos, width, height, refreshRate);
    public float Opacity
    {
        set => Context.NativeGLFW.SetWindowOpacity(Handle, value);
        get => Context.NativeGLFW.GetWindowOpacity(Handle);
    }
    public void Close(bool value) => Context.NativeGLFW.SetWindowShouldClose(Handle, value);
    public bool IsOpen => !Context.NativeGLFW.WindowShouldClose(Handle);
    public string Title
    {
        set
        {
            Context.NativeGLFW.SetWindowTitle(Handle, value);
            TitleTemp = value;
        }
        get => TitleTemp;
    }
    public _Math.Vector2D<int> Position
    {
        set => Context.NativeGLFW.SetWindowPos(Handle, value.X, value.Y);
        get
        {
            Context.NativeGLFW.GetWindowPos(Handle, out var xpos, out var ypos);
            return new(xpos, ypos);
        }
    }
    public _Math.Vector4D<int> SizeLimits
    {
        set
        {
            Context.NativeGLFW.SetWindowSizeLimits(Handle, value.X, value.Y, value.Z, value.W);
            SizeLimitsTemp = value;
        }
        get => SizeLimitsTemp;
    }
    public _Math.Vector2D<int> AspectRatio
    {
        set
        {
            Context.NativeGLFW.SetWindowAspectRatio(Handle, value.X, value.Y);
            AspectRatioTemp = value;
        }
        get => AspectRatioTemp;
    }
    public _Math.Vector2D<int> Size
    {
        set => Context.NativeGLFW.SetWindowSize(Handle, value.X, value.Y);
        get
        {
            Context.NativeGLFW.GetWindowSize(Handle, out var width, out var height);
            return new(width, height);
        }
    }
    public Monitor Monitor => Monitor.ListMonitors[Context.NativeGLFW.GetWindowMonitor(Handle)];
    public _Math.Vector2D<int> FramebufferSize
    {
        get
        {
            Context.NativeGLFW.GetFramebufferSize(Handle, out var width, out var height);
            return new(width, height);
        }
    }
    public _Math.Vector4D<int> FrameSize
    {
        get
        {
            Context.NativeGLFW.GetWindowFrameSize(Handle, out var left, out var top, out var right, out var bottom);
            return new(left, top, right, bottom);
        }
    }
    public _Math.Vector2D<float> ContentScale
    {
        get
        {
            Context.NativeGLFW.GetWindowContentScale(Handle, out var xscale, out var yscale);
            return new(xscale, yscale);
        }
    }
    public void SwapBuffers() => Context.NativeGLFW.SwapBuffers(Handle);
    public void MakeContextCurrent() => Context.NativeGLFW.MakeContextCurrent(Handle);
    public void IconifyWindow() => Context.NativeGLFW.IconifyWindow(Handle);
    public void RestoreWindow() => Context.NativeGLFW.RestoreWindow(Handle);
    public void MaximizeWindow() => Context.NativeGLFW.MaximizeWindow(Handle);
    public void ShowWindow() => Context.NativeGLFW.ShowWindow(Handle);
    public void HideWindow() => Context.NativeGLFW.HideWindow(Handle);
    public void FocusWindow() => Context.NativeGLFW.FocusWindow(Handle);
    public void RequestWindowAttention() => Context.NativeGLFW.RequestWindowAttention(Handle);
    public void Dispose()
    {
        Context.NativeGLFW.DestroyWindow(Handle);
        ListWindows.Remove(Handle);
    }
}