namespace FrederikaStudio.GLFW;

public sealed class WindowAttributes
{
    private _nGLFW.Window Window { get; }

    internal WindowAttributes(_nGLFW.Window window) => Window = window;

    #region Context

    public _Math.Vector3D<int> Version
    {
        get
        {
            var major = Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetInt.VersionMajor);
            var minor = Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetInt.VersionMinor);
            var revision = Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetInt.Revision);
            return new(major, minor, revision);
        }
    }
    public bool ForwardCompat => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.ForwardCompat);
    public bool Debug => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.OpenglDebug);
    public _nGLFW.WindowHintRobustnessValue Robustness => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowHintRobustness.Robustness);
    public _nGLFW.WindowHintOpenGLProfileValue OpenGLProfile => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowHintOpenGLProfile.OpenGLProfile);
    public _nGLFW.WindowHintReleaseBehaviorValue ReleaseBehavior => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowHintReleaseBehavior.ReleaseBehavior);

    #endregion

    #region Window

    public bool IsFocus => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Focus);
    public bool IsIconify => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Iconify);
    public bool IsMaximize => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Maximized);
    public bool IsHover => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Hover);
    public bool IsVisible => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Visible);
    public void SetResizable(bool flag) => Context.NativeGLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.Resizable, flag);
    public bool GetIsResizable => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Resizable);
    public void SetDecorate(bool flag) => Context.NativeGLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.Decorate, flag);
    public bool GetIsDecorate => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Decorate);
    public void SetAutoIconify(bool flag) => Context.NativeGLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.AutoIconify, flag);
    public bool GetIsAutoIconify => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.AutoIconify);
    public void SetFloating(bool flag) => Context.NativeGLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.Floating, flag);
    public bool GetIsFloating => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.Floating);
    public bool GetIsTransparentFrameBuffer => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.TransparentFrameBuffer);
    public void SetFocusOnShow(bool flag) => Context.NativeGLFW.SetWindowAttrib(Window, _nGLFW.WindowAttribSet.FocusOnShow, flag);
    public bool GetIsFocusOnShow => Context.NativeGLFW.GetWindowAttrib(Window, _nGLFW.WindowAttribGetBool.FocusOnShow);

    #endregion
}
