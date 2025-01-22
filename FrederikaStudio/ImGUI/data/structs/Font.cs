namespace FrederikaStudio.ImGUI;

public struct ImFont
{
    public IntPtr IndexAdvanceX; // ImVector<float>
    public float FallbackAdvanceX;
    public float FontSize;
    public IntPtr IndexLookup; // ImVector<ushort>
    public IntPtr Glyphs; // ImVector<ImFontGlyph>
    public IntPtr FallbackGlyph; // Pointer<ImFontGlyph>
    public IntPtr ContainerAtlas; // Pointer<ImFontAtlas>
    public IntPtr ConfigData; // Pointer<ImFontConfig>
    public short ConfigDataCount;
    public ushort FallbackChar;
    public ushort EllipsisChar;
    public ushort DotChar;
    public bool DirtyLookupTables;
    public float Scale;
    public float Ascent, Descent;
    public int MetricsTotalSurface;
}
