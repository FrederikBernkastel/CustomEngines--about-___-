namespace FrederikaStudio.ImGUI;

public struct ImGuiPayload
{
    public IntPtr Data;
    public int DataSize;
    public uint SourceId, SourceParentId;
    public int DataFrameCount;
    [MarshalAs(UnmanagedType.LPArray, SizeConst = 33)]
    public char[] DataType;
    public bool Preview, Delivery;
}
