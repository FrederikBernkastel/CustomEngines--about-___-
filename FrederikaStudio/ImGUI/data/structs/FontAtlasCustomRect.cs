namespace FrederikaStudio.ImGUI;

public struct ImFontAtlasCustomRect
{
    public ushort Width, Height;
    public ushort X, Y;
    public uint GlyphID;
    public float GlyphAdvanceX;
    public Math.Vector2D<float> GlyphOffset;
    public Core.PointerStruct<ImFont> Font;
}
