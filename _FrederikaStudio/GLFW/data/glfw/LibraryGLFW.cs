namespace FrederikaStudio.GLFW;

public static class LibraryGLFW
{
    internal static INativeGLFW GLFW { get; } = INativeGLFW.CreateGLFW(@"D:\code\FrederikaStudio\resources\lib\glfw_native.dll");

    static LibraryGLFW()
    {
        GLFW.Init();
    }

    public static void SwapInterval(int interval) => GLFW.SwapInterval(interval);
    public static void PollEvents() => GLFW.PollEvents();
    public static void Dispose() => GLFW.Dispose();
    internal static void IsErrors()
    {
        if (GLFW.GetError(out var ptr) == ENGLFW.ErrorsGLFW.NoError)
            return;
        Stack<string> array = new();
        array.Push(Marshal.PtrToStringAnsi(ptr.Handle)!);
        while (GLFW.GetError(out var _ptr) != ENGLFW.ErrorsGLFW.NoError)
            array.Push(Marshal.PtrToStringAnsi(_ptr.Handle)!);
        throw new Exception(array.Aggregate((u, e) => u + "\n" + e + "\n"));
    }
}
