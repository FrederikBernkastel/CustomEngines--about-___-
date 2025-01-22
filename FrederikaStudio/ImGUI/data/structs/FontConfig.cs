namespace FrederikaStudio.ImGUI;

public struct ImFontConfig
{
    public IntPtr FontData;
    public int FontDataSize;
    public bool FontDataOwnedByAtlas;
    public int FontNo;
    public float SizePixels;
    public int OversampleH, OversampleV;
    public bool PixelSnapH;
    public Math.Vector2D<float> GlyphExtraSpacing, GlyphOffset;
    public Core.PointerArray<ushort> GlyphRanges;
    public float GlyphMinAdvanceX, GlyphMaxAdvanceX;
    public bool MergeMode;
    public uint FontBuilderFlags;
    public float RasterizerMultiply;
    public ushort EllipsisChar;
    [MarshalAs(UnmanagedType.LPArray, SizeConst = 40)]
    public char[] Name;
    public Core.PointerStruct<ImFont> DstFont;
}
