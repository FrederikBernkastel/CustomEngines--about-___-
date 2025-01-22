namespace FrederikaStudio.ImGUI;

public struct ImGuiViewport
{
    public ImGuiViewportFlags Flags;
    public Math.Vector2D<float> Pos, Size, WorkPos, WorkSize;
    public IntPtr PlatformHandleRaw;
}
