namespace FrederikaStudio.GLFW;

public sealed class Mouse
{
    //public static bool RawMouseMotionSupported => Library.GLFW.RawMouseMotionSupported();

    //private _nGLFW.Window Handle { get; }
    //private ICursor CursorTemp { get; set; }

    //internal Mouse(Window window)
    //{
    //    Handle = window.Handle;
    //    Cursor = new(_nGLFW.CursorType.Arrow);
    //}

    //public _Math.Vector2D<double> Position
    //{
    //    get
    //    {
    //        Library.GLFW.GetCursorPos(Handle, out var xpos, out var ypos);
    //        return new(xpos, ypos);
    //    }
    //    set => Library.GLFW.SetCursorPos(Handle, value.X, value.Y);
    //}
    //public ICursor Cursor
    //{
    //    set
    //    {
    //        Library.GLFW.SetCursor(Handle, value.Handle);
    //        CursorTemp = value;
    //    }
    //    get => CursorTemp;
    //}
    //public _nGLFW.InputState GetMouseButton(_nGLFW.MouseButton button) => Library.GLFW.GetMouseButton(Handle, button);
    //public void Dispose() => CursorTemp.Dispose();
}
