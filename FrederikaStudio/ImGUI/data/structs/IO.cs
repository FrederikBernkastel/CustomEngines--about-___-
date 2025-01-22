namespace FrederikaStudio.ImGUI;

public unsafe struct ImGuiIO
{
    public ImGuiConfigFlags ConfigFlags;
    public ImGuiBackendFlags BackendFlags;
    public Math.Vector2D<float> DisplaySize;
    public float DeltaTime, IniSavingRate;
    public char* IniFilename, LogFilename;
    public float
        MouseDoubleClickTime, MouseDoubleClickMaxDist,
        MouseDragThreshold, KeyRepeatDelay, KeyRepeatRate;
    public IntPtr UserData;
    public ImFontAtlas* Fonts; //Core.PointerStruct<ImFontAtlas>
    public float FontGlobalScale;
    public bool FontAllowUserScaling;
    public Core.PointerStruct<ImFont> FontDefault;
    public Math.Vector2D<float> DisplayFramebufferScale;
    public bool
        MouseDrawCursor, ConfigMacOSXBehaviors, ConfigInputTrickleEventQueue,
        ConfigInputTextCursorBlink, ConfigDragClickToInputText,
        ConfigWindowsResizeFromEdges, ConfigWindowsMoveFromTitleBarOnly;
    public float ConfigMemoryCompactTimer;
    public Core.PointerArray<char> BackendPlatformName, BackendRendererName;
    public IntPtr BackendPlatformUserData, BackendRendererUserData, BackendLanguageUserData;
    public IntPtr GetClipboardTextFn;
    public IntPtr SetClipboardTextFn;
    public IntPtr ClipboardUserData;
    public IntPtr SetPlatformImeDataFn;
    public IntPtr _UnusedPadding;
    public bool
        WantCaptureMouse, WantCaptureKeyboard, WantTextInput,
        WantSetMousePos, WantSaveIniSettings, NavActive, NavVisible;
    public float Framerate;
    public int
        MetricsRenderVertices, MetricsRenderIndices, MetricsRenderWindows,
        MetricsActiveWindows, MetricsActiveAllocations;
    public Math.Vector2D<float> MouseDelta, MousePos;
}
