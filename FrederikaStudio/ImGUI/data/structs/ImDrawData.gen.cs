namespace FrederikaStudio.ImGUI;

public struct ImDrawData
{
    public bool Valid;
    public int CmdListsCount, TotalIdxCount, TotalVtxCount;
    public Core.PointerArray<Core.PointerStruct<ImDrawList>> CmdLists;
    public Math.Vector2D<float> DisplayPos, DisplaySize, FramebufferScale;
}
