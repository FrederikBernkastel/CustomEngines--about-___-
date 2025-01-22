namespace FrederikaStudio.ImGUI;

public struct ImDrawList
{
    public ImVector<ImDrawCmd> CmdBuffer;
    public ImVector<ushort> IdxBuffer;
    public ImVector<ImDrawVert> VtxBuffer;
    public ImDrawListFlags Flags;
}
