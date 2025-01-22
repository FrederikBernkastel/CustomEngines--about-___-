namespace FrederikaStudio.ImGUI;

public struct ImFontAtlas
{
    public ImFontAtlasFlags Flags;
    public Core.PointerStruct<ImTextureID> TexID;
    public int TexDesiredWidth, TexGlyphPadding;
    public bool Locked;
}
