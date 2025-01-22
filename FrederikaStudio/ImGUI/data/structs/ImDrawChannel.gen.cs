namespace FrederikaStudio.ImGUI;

public struct ImDrawChannel
{
    public ImVector<ImDrawCmd> _CmdBuffer;
    public ImVector<ushort> _IdxBuffer;
}
