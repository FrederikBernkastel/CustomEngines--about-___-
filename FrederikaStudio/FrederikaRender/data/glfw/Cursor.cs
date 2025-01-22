namespace FrederikaStudio.GLFW;

public interface ICursor : IObjectDispose
{
    public _nGLFW.Cursor Handle { get; }
}
internal sealed class Cursor : ICursor
{
    public _nGLFW.Cursor Handle { get; init; }

    public void Dispose() => Library.GLFW.DestroyCursor(Handle);
}
public static class FactoryCursor
{
    public static ICursor CreateCursor(_nGLFW.CursorType type)
    {
        var handle = Library.GLFW.CreateStandardCursor(type);
        Cursor cursor = new() { Handle = handle };
        return cursor;
    }
    public static ICursor CreateCursor(_nGLFW.Image image, int xhot, int yhot)
    {
        var handle = Library.GLFW.CreateCursor(image, xhot, yhot);
        Cursor cursor = new() { Handle = handle };
        return cursor;
    }
}
