namespace FrederikaStudio.ImGUI;

[System.Flags]
public enum ImGuiComboFlags
{
    None = 0,
    PopupAlignLeft = 1,
    HeightSmall = 2,
    HeightRegular = 4,
    HeightLarge = 8,
    HeightLargest = 16,
    NoArrowButton = 32,
    NoPreview = 64,
    HeightMask = 30,
}
