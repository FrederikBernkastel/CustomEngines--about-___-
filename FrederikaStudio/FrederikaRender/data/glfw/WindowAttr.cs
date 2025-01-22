namespace FrederikaStudio.GLFW;

public interface IContextAttributes
{
    public Version Version { get; }
    public bool ForwardCompat { get; }
    public bool Debug { get; }
    public _nGLFW.WindowHintRobustnessValue Robustness { get; }
    public _nGLFW.WindowHintOpenGLProfileValue OpenGLProfile { get; }
    public _nGLFW.WindowHintReleaseBehaviorValue ReleaseBehavior { get; }
}
public interface IWindowAttributes
{
    public bool IsFocus { get; }
    public bool IsIconify { get; }
    public bool IsMaximize { get; }
    public bool IsHover { get; }
    public bool IsVisible { get; }
    public bool GetIsResizable { get; }
    public bool GetIsDecorate { get; }
    public bool GetIsAutoIconify { get; }
    public bool GetIsFloating { get; }
    public bool GetIsTransparentFrameBuffer { get; }
    public bool GetIsFocusOnShow { get; }
    public void SetFocusOnShow(bool flag);
    public void SetResizable(bool flag);
    public void SetFloating(bool flag);
    public void SetAutoIconify(bool flag);
    public void SetDecorate(bool flag);
}
public readonly record struct Version(int Major, int Minor, int Revision);
internal static class FactoryAttributes
{
    public static IContextAttributes CreateContextAttributes(_nGLFW.Window window)
    {
        ContextAttributes attributes = new()
        {
            Version = new(
                Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowAttribGetInt.VersionMajor),
                Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowAttribGetInt.VersionMinor),
                Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowAttribGetInt.Revision)),
            ForwardCompat = Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowAttribGetBool.ForwardCompat),
            Debug = Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowAttribGetBool.OpenglDebug),
            Robustness = Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowHintRobustness.Robustness),
            OpenGLProfile = Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowHintOpenGLProfile.OpenGLProfile),
            ReleaseBehavior = Library.GLFW.GetWindowAttrib(window, _nGLFW.WindowHintReleaseBehavior.ReleaseBehavior),
        };
        return attributes;
    }
    public static IWindowAttributes CreateWindowAttributes(_nGLFW.Window window)
    {
        WindowAttributes attributes = new() { Window = window };
        return attributes;
    }
}
internal sealed class ContextAttributes : IContextAttributes
{
    public Version Version { get; init; }
    public bool ForwardCompat { get; init; }
    public bool Debug { get; init; }
    public _nGLFW.WindowHintRobustnessValue Robustness { get; init; }
    public _nGLFW.WindowHintOpenGLProfileValue OpenGLProfile { get; init; }
    public _nGLFW.WindowHintReleaseBehaviorValue ReleaseBehavior { get; init; }
}
internal sealed class WindowAttributes : IWindowAttributes
{
    public _nGLFW.Window Window { get; init; }

    public bool IsFocus => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Focus);
    public bool IsIconify => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Iconify);
    public bool IsMaximize => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Maximized);
    public bool IsHover => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Hover);
    public bool IsVisible => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Visible);
    public void SetResizable(bool flag) => 
        Library.GLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.Resizable, flag);
    public bool GetIsResizable => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Resizable);
    public void SetDecorate(bool flag) => 
        Library.GLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.Decorate, flag);
    public bool GetIsDecorate => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Decorate);
    public void SetAutoIconify(bool flag) => 
        Library.GLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.AutoIconify, flag);
    public bool GetIsAutoIconify => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.AutoIconify);
    public void SetFloating(bool flag) => 
        Library.GLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.Floating, flag);
    public bool GetIsFloating => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Floating);
    public bool GetIsTransparentFrameBuffer => 
        Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.TransparentFrameBuffer);
    public void SetFocusOnShow(bool flag) => 
        Library.GLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.FocusOnShow, flag);
    public bool GetIsFocusOnShow => Library.GLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.FocusOnShow);
}
