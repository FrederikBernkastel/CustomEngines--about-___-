namespace FrederikaStudio.GLFW;

public sealed class WindowSettings
{
    public string Title { get; init; } = "TitleDefault";
    public _nGLFW.Vidmode Vidmode { get; init; } = IMonitor.PrimaryMonitor.VideoModes[^1];
    public IMonitor? Monitor { get; init; } = default;
}
[_Core.InvokeStaticCtor]
public static class FactoryWindow
{
    public static IHintContext HintContext { get; }
    public static IHintWindow HintWindow { get; }
    public static IHintMonitor HintMonitor { get; }
    public static IHintFrameBuffer HintFrameBuffer { get; }

    static FactoryWindow()
    {
        HintContext = FactoryHint.CreateHintContext();
        HintWindow = FactoryHint.CreateHintWindow();
        HintMonitor = FactoryHint.CreateHintMonitor();
        HintFrameBuffer = FactoryHint.CreateHintFrameBuffer();
    }

    public static IWindow CreateWindow(WindowSettings settings)
    {
        var handle = Library.GLFW.CreateWindow(
            settings.Vidmode.Width,
            settings.Vidmode.Height,
            settings.Title,
            settings.Monitor?.Handle ?? default,
            default);
        var context_attr = FactoryAttributes.CreateContextAttributes(handle);
        var window_attr = FactoryAttributes.CreateWindowAttributes(handle);
        var input_mode = IWindowInputMode.CreateWindowInputMode(handle);
        Window window = new()
        {
            Handle = handle,
            WindowAttributes = window_attr,
            ContextAttributes = context_attr,
            InputMode = input_mode,
        };
        IWindow.ListWindows[handle] = window;
        return window;
    }
    internal static IWindow CreateDefaultWindow()
    {
        HintContext.IsDebug = true;
        HintContext.OpenGLProfile = _nGLFW.WindowHintOpenGLProfileValue.Core;
        HintContext.VersionMajor = 4;
        HintContext.VersionMinor = 5;
        HintWindow.Visible = false;
        HintWindow.Resizable = false;

        WindowSettings settings = new();

        var window = CreateWindow(settings);
        window.MakeContextCurrent();

        HintContext.DefaultHint();
        HintWindow.DefaultHint();

        return window;
    }
}
