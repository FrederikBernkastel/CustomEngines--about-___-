namespace FrederikaStudio.GLFW;

public interface IWindow : IObjectDispose
{
    internal static Dictionary<_nGLFW.Window, IWindow> ListWindows { get; } = new();
    public static Dictionary<_nGLFW.Window, IWindow>.ValueCollection Windows => ListWindows.Values;
    public static IWindow CurrentContext => ListWindows[Library.GLFW.GetCurrentContext()];
    public static void SwapInterval(bool interval) => Library.GLFW.SwapInterval(interval);
    public static IWindow DefaultWindow { get; internal set; }

    public _nGLFW.Window Handle { get; }

    public IContextAttributes ContextAttributes { get; }
    public IWindowAttributes WindowAttributes { get; }

    public IntPtr UserPointer { get; set; }
    public float Opacity { get; set; }
    public bool IsOpen { get; }
    public _Math.Vector2D<int> Position { get; set; }
    public _Math.Vector4D<int> SizeLimits { get; set; }
    public _Math.Vector2D<int> AspectRatio { get; set; }
    public _Math.Vector2D<int> Size { get; set; }
    public IMonitor Monitor { get; }
    public _Math.Vector2D<int> FramebufferSize { get; }
    public _Math.Vector4D<int> FrameSize { get; }
    public _Math.Vector2D<float> ContentScale { get; }
    public string Title { set; }
    public void SetMonitor(IMonitor monitor, int xpos, int ypos, int width, int height, int refreshRate);
    public void Close(bool value);
    public void SetWindowIcon(_nGLFW.Image[] images);
    public void SwapBuffers();
    public void MakeContextCurrent();
    public void IconifyWindow();
    public void RestoreWindow();
    public void MaximizeWindow();
    public void ShowWindow();
    public void HideWindow();
    public void FocusWindow();
    public void RequestWindowAttention();
}
