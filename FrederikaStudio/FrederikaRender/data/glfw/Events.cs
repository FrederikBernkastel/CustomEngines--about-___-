namespace FrederikaStudio.GLFW;

public static class Events
{
    public static void PollEvents() => Library.GLFW.PollEvents();
    public static void WaitEvents() => Library.GLFW.WaitEvents();
    public static void WaitEventsTimeout(double timeout) => Library.GLFW.WaitEventsTimeout(timeout);
    public static void PostEmptyEvent() => Library.GLFW.PostEmptyEvent();
}