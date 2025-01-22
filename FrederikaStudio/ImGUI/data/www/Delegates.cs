namespace FrederikaStudio.ImGUI;

public delegate Core.PointerArray<char> GetClipboardTextCallback(IntPtr user_data);
public delegate void SetClipboardTextCallback(IntPtr user_data, Core.PointerArray<char> text);
//public delegate void SetPlatformImeDataCallback(Pointer<ImGuiViewport> viewport, Pointer<ImGuiPlatformImeData> data);
