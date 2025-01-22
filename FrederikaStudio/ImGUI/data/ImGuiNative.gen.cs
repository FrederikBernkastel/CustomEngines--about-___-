namespace FrederikaStudio.ImGUI;

public interface IImGUI
{
    public INativeImGUI GUI { get; }
    public IImGuiIO IO { get; }
    public IImFontAtlas FontAtlas { get; }
    public IImFont Font { get; }
    public IImDrawData DrawData { get; }
    public IImDrawCmd DrawCmd { get; }
    public void Dispose();
    public static IImGUI CreateImGUI(string path) => new NativeImGUI(path);
    private sealed class NativeImGUI : IImGUI
    {
        private FSLL.Library Library { get; }
        public INativeImGUI GUI { get; }
        public IImGuiIO IO { get; }
        public IImFontAtlas FontAtlas { get; }
        public IImFont Font { get; }
        public IImDrawData DrawData { get; }
        public IImDrawCmd DrawCmd { get; }

        public NativeImGUI(string path)
        {
            Library = new(path);
            GUI = Library.Load<INativeImGUI>(u => "ig" + u);
            IO = Library.Load<IImGuiIO>(u => "ImGuiIO_" + u);
            FontAtlas = Library.Load<IImFontAtlas>(u => "ImFontAtlas_" + u);
            Font = Library.Load<IImFont>(u => "ImFont_" + u);
            DrawData = Library.Load<IImDrawData>(u => "ImDrawData_" + u);
            DrawCmd = Library.Load<IImDrawCmd>(u => "ImDrawCmd_" + u);
        }

        public void Dispose() => Library.Dispose();
    }
}
public interface IImGuiIO
{
    //public void AddFocusEvent(Core.PointerStruct<ImGuiIO> self, bool focused);
    //public void AddInputCharacter(Core.PointerStruct<ImGuiIO> self, uint c);
    //public void AddInputCharactersUTF8(Core.PointerStruct<ImGuiIO> self, IntPtr str);
    //public void AddInputCharacterUTF16(Core.PointerStruct<ImGuiIO> self, ushort c);
    //public void AddKeyAnalogEvent(Core.PointerStruct<ImGuiIO> self, ImGuiKey key, bool down, float v);
    //public void AddKeyEvent(Core.PointerStruct<ImGuiIO> self, ImGuiKey key, bool down);
    //public void AddMouseButtonEvent(Core.PointerStruct<ImGuiIO> self, int button, bool down);
    //public void AddMousePosEvent(Core.PointerStruct<ImGuiIO> self, float x, float y);
    //public void AddMouseViewportEvent(Core.PointerStruct<ImGuiIO> self, uint id);
    //public void AddMouseWheelEvent(Core.PointerStruct<ImGuiIO> self, float wh_x, float wh_y);
    //public void ClearInputCharacters(Core.PointerStruct<ImGuiIO> self);
    //public void ClearInputKeys(Core.PointerStruct<ImGuiIO> self);
    //public void SetKeyEventNativeData(Core.PointerStruct<ImGuiIO> self, ImGuiKey key, int native_keycode, int native_scancode, int native_legacy_index);
}
public interface IImFontAtlas
{
    //public int AddCustomRectFontGlyph(
    //    Core.PointerStruct<ImFontAtlas> self, Core.PointerStruct<ImFont> font, ushort id, int width, int height, float advance_x, Vector2D<float> offset);
    //public int AddCustomRectRegular(Core.PointerStruct<ImFontAtlas> self, int width, int height);
    //public Core.PointerStruct<ImFont> AddFont(Core.PointerStruct<ImFontAtlas> self, Core.PointerStruct<ImFontConfig> font_cfg);
    //public Core.PointerStruct<ImFont> AddFontDefault(Core.PointerStruct<ImFontAtlas> self, Core.PointerStruct<ImFontConfig> font_cfg);
    //public Core.PointerStruct<ImFont> AddFontFromFileTTF(
    //    Core.PointerStruct<ImFontAtlas> self, IntPtr filename, float size_pixels, Core.PointerStruct<ImFontConfig> font_cfg, PointerArray<ushort> glyph_ranges);
    //public Core.PointerStruct<ImFont> AddFontFromMemoryCompressedBase85TTF(
    //    Core.PointerStruct<ImFontAtlas> self, IntPtr compressed_font_data_base85, float size_pixels, Core.PointerStruct<ImFontConfig> font_cfg, PointerArray<short> glyph_ranges);
    //public Core.PointerStruct<ImFont> AddFontFromMemoryCompressedTTF(
    //    Core.PointerStruct<ImFontAtlas> self, IntPtr compressed_font_data, int compressed_font_size, 
    //    float size_pixels, Core.PointerStruct<ImFontConfig> font_cfg, PointerArray<ushort> glyph_ranges);
    //public Core.PointerStruct<ImFont> AddFontFromMemoryTTF(
    //    Core.PointerStruct<ImFontAtlas> self, IntPtr font_data, int font_size, float size_pixels, Core.PointerStruct<ImFontConfig> font_cfg, PointerArray<ushort> glyph_ranges);
    //public bool Build(Pointer<ImFontAtlas> self);
    //public void CalcCustomRectUV(
    //    Core.PointerStruct<ImFontAtlas> self, Core.PointerStruct<ImFontAtlasCustomRect> rect, ref Vector2D<float> out_uv_min, ref Vector2D<float> out_uv_max);
    //public void Clear(Core.PointerStruct<ImFontAtlas> self);
    //public void ClearFonts(Core.PointerStruct<ImFontAtlas> self);
    //public void ClearInputData(Core.PointerStruct<ImFontAtlas> self);
    //public void ClearTexData(Core.PointerStruct<ImFontAtlas> self);
    //public Pointer<ImFontAtlasCustomRect> GetCustomRectByIndex(Pointer<ImFontAtlas> self, int index);
    //public PointerArray<ushort> GetGlyphRangesChineseFull(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesChineseSimplifiedCommon(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesCyrillic(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesDefault(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesJapanese(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesKorean(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesThai(Pointer<ImFontAtlas> self);
    //public PointerArray<ushort> GetGlyphRangesVietnamese(Pointer<ImFontAtlas> self);
    //public bool GetMouseCursorTexData(
    //    Pointer<ImFontAtlas> self, ImGuiMouseCursor cursor, ref Vector2D<float> out_offset, 
    //    ref Vector2D<float> out_size, ref Vector2D<float> out_uv_border, ref Vector2D<float> out_uv_fill);
    //public void GetTexDataAsAlpha8(Pointer<ImFontAtlas> self, ref IntPtr out_pixels, ref int out_width, ref int out_height, ref int out_bytes_per_pixel);
    //public void GetTexDataAsRGBA32(
    //    Core.PointerStruct<ImFontAtlas> self, out Core.PointerArray<byte> out_pixels, 
    //    out int out_width, out int out_height, Core.PointerStruct<int> out_bytes_per_pixel = default); // Core.PointerArray<Core.PointerArray<byte>>
    public unsafe void GetTexDataAsRGBA32(
        ImFontAtlas* self, out Core.PointerArray<byte> out_pixels,
        out int out_width, out int out_height, out int out_bytes_per_pixel); // Core.PointerArray<Core.PointerArray<byte>>
    //public bool IsBuilt(Pointer<ImFontAtlas> self);
    public void SetTexID(Core.PointerStruct<ImFontAtlas> self, ImTextureID id);
}
public interface IImFont
{
    //public void AddGlyph(
    //    Pointer<ImFont> self, Pointer<ImFontConfig> src_cfg, ushort c, float x0, float y0, 
    //    float x1, float y1, float u0, float v0, float u1, float v1, float advance_x);
    //public void AddRemapChar(Pointer<ImFont> self, ushort dst, ushort src, bool overwrite_dst);
    //public void BuildLookupTable(Pointer<ImFont> self);
    //public void CalcTextSizeA(
    //    ref Vector2D<float> pOut, Pointer<ImFont> self, float size, float max_width, float wrap_width, IntPtr text_begin, IntPtr text_end, ref IntPtr remaining);
    //public IntPtr CalcWordWrapPositionA(Pointer<ImFont> self, float scale, IntPtr text, IntPtr text_end, float wrap_width);
    //public void ClearOutputData(Pointer<ImFont> self);
    //public Pointer<ImFontGlyph> FindGlyph(Pointer<ImFont> self, ushort c);
    //public Pointer<ImFontGlyph> FindGlyphNoFallback(Pointer<ImFont> self, ushort c);
    //public float GetCharAdvance(Pointer<ImFont> self, ushort c);
    //public IntPtr GetDebugName(Pointer<ImFont> self);
    //public void GrowIndex(Pointer<ImFont> self, int new_size);
    //public bool IsGlyphRangeUnused(Pointer<ImFont> self, uint c_begin, uint c_last);
    //public bool IsLoaded(Pointer<ImFont> self);
    //public void RenderChar(Pointer<ImFont> self, Pointer<ImDrawList> draw_list, float size, Vector2D<float> pos, uint col, ushort c);
    //public void RenderText(
    //    Pointer<ImFont> self, Pointer<ImDrawList> draw_list, float size, Vector2D<float> pos, 
    //    uint col, Vector4D<float> clip_rect, IntPtr text_begin, IntPtr text_end, float wrap_width, bool cpu_fine_clip);
    //public void SetGlyphVisible(Pointer<ImFont> self, ushort c, bool visible);
}
public interface IImDrawData
{
    //public void Clear(Pointer<ImDrawData> self);
    //public void DeIndexAllBuffers(Pointer<ImDrawData> self);
    //public void ScaleClipRects(Pointer<ImDrawData> self, Vector2D<float> fb_scale);
}
public interface IImDrawCmd
{
    public ImTextureID GetTexID(Core.PointerStruct<ImDrawCmd> self);
}
public interface INativeImGUI
{
    //public Pointer<ImGuiPayload> AcceptDragDropPayload(IntPtr type, ImGuiDragDropFlags flags);
    //public void AlignTextToFramePadding();
    //public bool ArrowButton(IntPtr str_id, int dir);
    public bool Begin(Core.PointerArray<char> name, Core.PointerStruct<bool> p_open = default, ImGuiWindowFlags flags = 0);
    //public bool BeginChild_Str(IntPtr str_id, Vector2D<float> size, bool border, ImGuiWindowFlags flags);
    //public bool BeginChild_ID(uint id, Vector2D<float> size, bool border, ImGuiWindowFlags flags);
    //public bool BeginChildFrame(uint id, Vector2D<float> size, ImGuiWindowFlags flags);
    //public bool BeginCombo(IntPtr label, IntPtr preview_value, ImGuiComboFlags flags);
    //public void BeginDisabled(bool disabled);
    //public bool BeginDragDropSource(ImGuiDragDropFlags flags);
    //public bool BeginDragDropTarget();
    //public void BeginGroup();
    //public bool BeginListBox(IntPtr label, Vector2D<float> size);
    //public bool BeginMainMenuBar();
    //public bool BeginMenu(IntPtr label, bool enabled);
    //public bool BeginMenuBar();
    //public bool BeginPopup(IntPtr str_id, ImGuiWindowFlags flags);
    //public bool BeginPopupContextItem(IntPtr str_id, ImGuiPopupFlags popup_flags);
    //public bool BeginPopupContextVoid(IntPtr str_id, ImGuiPopupFlags popup_flags);
    //public bool BeginPopupContextWindow(IntPtr str_id, ImGuiPopupFlags popup_flags);
    //public bool BeginPopupModal(IntPtr name, IntPtr p_open, ImGuiWindowFlags flags);
    //public bool BeginTabBar(IntPtr str_id, ImGuiTabBarFlags flags);
    //public bool BeginTabItem(IntPtr label, IntPtr p_open, ImGuiTabItemFlags flags);
    //public bool BeginTable(IntPtr str_id, int column, ImGuiTableFlags flags, Vector2D<float> outer_size, float inner_width);
    //public void BeginTooltip();
    //public void Bullet();
    //public void BulletText(IntPtr fmt);
    //public bool Button(IntPtr label, Vector2D<float> size);
    //public float CalcItemWidth();
    //public void CalcTextSize(out Vector2D<float> pOut, IntPtr text, IntPtr text_end, bool hide_text_after_double_hash, float wrap_width);
    //public void CaptureKeyboardFromApp(bool want_capture_keyboard_value);
    //public void CaptureMouseFromApp(bool want_capture_mouse_value);
    //public bool Checkbox(IntPtr label, IntPtr v);
    //public bool CheckboxFlags_IntPtr(IntPtr label, int* flags, int flags_value);
    //public bool CheckboxFlags_UintPtr(IntPtr label, uint* flags, uint flags_value);
    //public void CloseCurrentPopup();
    //public bool CollapsingHeader_TreeNodeFlags(IntPtr label, ImGuiTreeNodeFlags flags);
    //public bool CollapsingHeader_BoolPtr(IntPtr label, IntPtr p_visible, ImGuiTreeNodeFlags flags);
    //public bool ColorButton(IntPtr desc_id, Vector4D<float> col, ImGuiColorEditFlags flags, Vector2D<float> size);
    //public uint ColorConvertFloat4ToU32(Vector4D<float> @in);
    //public void ColorConvertHSVtoRGB(float h, float s, float v, float* out_r, float* out_g, float* out_b);
    //public void ColorConvertRGBtoHSV(float r, float g, float b, float* out_h, float* out_s, float* out_v);
    //public void ColorConvertU32ToFloat4(out Vector4D<float> pOut, uint @in);
    //public bool ColorEdit3(IntPtr label, out Vector3D<float> col, ImGuiColorEditFlags flags);
    //public bool ColorEdit4(IntPtr label, out Vector4D<float> col, ImGuiColorEditFlags flags);
    //public bool ColorPicker3(IntPtr label, out Vector3D<float> col, ImGuiColorEditFlags flags);
    //public bool ColorPicker4(IntPtr label, out Vector4D<float> col, ImGuiColorEditFlags flags, float* ref_col);
    //public void Columns(int count, IntPtr id, bool border);
    //public bool Combo_Str_arr(IntPtr label, int* current_item, IntPtr* items, int items_count, int popup_max_height_in_items);
    //public bool Combo_Str(IntPtr label, int* current_item, IntPtr items_separated_by_zeros, int popup_max_height_in_items);
    //public ImContext CreateContext(Core.PointerStruct<ImFontAtlas> shared_font_atlas = default);
    public ImContext CreateContext(IntPtr shared_font_atlas = default);
    //public bool igDebugCheckVersionAndDataLayout(IntPtr version_str, uint sz_io, uint sz_style, uint sz_vec2, uint sz_vec4, uint sz_drawvert, uint sz_drawidx);
    public void DestroyContext(ImContext ctx = default);
    //public void DestroyPlatformWindows();
    //public uint DockSpace(uint id, Vector2D<float> size, ImGuiDockNodeFlags flags, ImGuiWindowClass* window_class);
    //public uint DockSpaceOverViewport(ImGuiViewport* viewport, ImGuiDockNodeFlags flags, ImGuiWindowClass* window_class);
    //public bool DragFloat(IntPtr label, float* v, float v_speed, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragFloat2(IntPtr label, out Vector2D<float> v, float v_speed, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragFloat3(IntPtr label, out Vector3D<float> v, float v_speed, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragFloat4(IntPtr label, out Vector4D<float> v, float v_speed, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragFloatRange2(IntPtr label, float* v_current_min, float* v_current_max, float v_speed, float v_min, float v_max, IntPtr format, IntPtr format_max, ImGuiSliderFlags flags);
    //public bool DragInt(IntPtr label, int* v, float v_speed, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragInt2(IntPtr label, int* v, float v_speed, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragInt3(IntPtr label, int* v, float v_speed, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragInt4(IntPtr label, int* v, float v_speed, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragIntRange2(IntPtr label, int* v_current_min, int* v_current_max, float v_speed, int v_min, int v_max, IntPtr format, IntPtr format_max, ImGuiSliderFlags flags);
    //public bool DragScalar(IntPtr label, ImGuiDataType data_type, IntPtr p_data, float v_speed, IntPtr p_min, IntPtr p_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool DragScalarN(IntPtr label, ImGuiDataType data_type, IntPtr p_data, int components, float v_speed, IntPtr p_min, IntPtr p_max, IntPtr format, ImGuiSliderFlags flags);
    //public void Dummy(Vector2D<float> size);
    public void End();
    //public void EndChild();
    //public void EndChildFrame();
    //public void EndCombo();
    //public void EndDisabled();
    //public void EndDragDropSource();
    //public void EndDragDropTarget();
    public void EndFrame();
    //public void EndGroup();
    //public void EndListBox();
    //public void EndMainMenuBar();
    //public void EndMenu();
    //public void EndMenuBar();
    //public void EndPopup();
    //public void EndTabBar();
    //public void EndTabItem();
    //public void EndTable();
    //public void EndTooltip();
    //public ImGuiViewport* FindViewportByID(uint id);
    //public ImGuiViewport* FindViewportByPlatformHandle(void* platform_handle);
    //public void GetAllocatorFunctions(IntPtr* p_alloc_func, IntPtr* p_free_func, void** p_user_data);
    //public ImDrawList* GetBackgroundDrawList_Nil();
    //public ImDrawList* GetBackgroundDrawList_ViewportPtr(ImGuiViewport* viewport);
    //public IntPtr GetClipboardText();
    //public uint GetColorU32_Col(ImGuiCol idx, float alpha_mul);
    //public uint GetColorU32_Vec4(Vector4D<float> col);
    //public uint GetColorU32_U32(uint col);
    //public int GetColumnIndex();
    //public float GetColumnOffset(int column_index);
    //public int GetColumnsCount();
    //public float GetColumnWidth(int column_index);
    //public void GetContentRegionAvail(Vector2D<float>* pOut);
    //public void GetContentRegionMax(Vector2D<float>* pOut);
    //public IntPtr GetCurrentContext();
    //public void GetCursorPos(Vector2D<float>* pOut);
    //public float GetCursorPosX();
    //public float GetCursorPosY();
    //public void GetCursorScreenPos(Vector2D<float>* pOut);
    //public void GetCursorStartPos(Vector2D<float>* pOut);
    //public ImGuiPayload* GetDragDropPayload();
    public Core.PointerStruct<ImDrawData> GetDrawData();
    //public IntPtr GetDrawListSharedData();
    //public ImFont* GetFont();
    //public float GetFontSize();
    //public void GetFontTexUvWhitePixel(Vector2D<float>* pOut);
    //public ImDrawList* GetForegroundDrawList_Nil();
    //public ImDrawList* GetForegroundDrawList_ViewportPtr(ImGuiViewport* viewport);
    //public int GetFrameCount();
    //public float GetFrameHeight();
    //public float GetFrameHeightWithSpacing();
    //public uint GetID_Str(IntPtr str_id);
    //public uint GetID_StrStr(IntPtr str_id_begin, IntPtr str_id_end);
    //public uint GetID_Ptr(void* ptr_id);
    //public Core.PointerStruct<ImGuiIO> GetIO();
    public unsafe ImGuiIO* GetIO();
    //public void GetItemRectMax(Vector2D<float>* pOut);
    //public void GetItemRectMin(Vector2D<float>* pOut);
    //public void GetItemRectSize(Vector2D<float>* pOut);
    //public int GetKeyIndex(ImGuiKey key);
    //public IntPtr GetKeyName(ImGuiKey key);
    //public int GetKeyPressedAmount(ImGuiKey key, float repeat_delay, float rate);
    //public ImGuiViewport* GetMainViewport();
    //public int GetMouseClickedCount(ImGuiMouseButton button);
    //public ImGuiMouseCursor GetMouseCursor();
    //public void GetMouseDragDelta(Vector2D<float>* pOut, ImGuiMouseButton button, float lock_threshold);
    //public void GetMousePos(Vector2D<float>* pOut);
    //public void GetMousePosOnOpeningCurrentPopup(Vector2D<float>* pOut);
    //public ImGuiPlatformIO* GetPlatformIO();
    //public float GetScrollMaxX();
    //public float GetScrollMaxY();
    //public float GetScrollX();
    //public float GetScrollY();
    //public ImGuiStorage* GetStateStorage();
    //public ImGuiStyle* GetStyle();
    //public IntPtr GetStyleColorName(ImGuiCol idx);
    //public Vector4D<float>* GetStyleColorVec4(ImGuiCol idx);
    //public float GetTextLineHeight();
    //public float GetTextLineHeightWithSpacing();
    //public double GetTime();
    //public float GetTreeNodeToLabelSpacing();
    //public IntPtr GetVersion();
    //public void GetWindowContentRegionMax(Vector2D<float>* pOut);
    //public void GetWindowContentRegionMin(Vector2D<float>* pOut);
    //public uint GetWindowDockID();
    //public float GetWindowDpiScale();
    //public ImDrawList* GetWindowDrawList();
    //public float GetWindowHeight();
    //public void GetWindowPos(Vector2D<float>* pOut);
    //public void GetWindowSize(Vector2D<float>* pOut);
    //public ImGuiViewport* GetWindowViewport();
    //public float GetWindowWidth();
    //public void Image(IntPtr user_texture_id, Vector2D<float> size, Vector2D<float> uv0, Vector2D<float> uv1, Vector4D<float> tint_col, Vector4D<float> border_col);
    //public bool ImageButton(IntPtr user_texture_id, Vector2D<float> size, Vector2D<float> uv0, Vector2D<float> uv1, int frame_padding, Vector4D<float> bg_col, Vector4D<float> tint_col);
    //public void Indent(float indent_w);
    //public bool InputDouble(IntPtr label, double* v, double step, double step_fast, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputFloat(IntPtr label, float* v, float step, float step_fast, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputFloat2(IntPtr label, Vector2D<float>* v, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputFloat3(IntPtr label, Vector3D<float>* v, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputFloat4(IntPtr label, Vector4D<float>* v, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputInt(IntPtr label, int* v, int step, int step_fast, ImGuiInputTextFlags flags);
    //public bool InputInt2(IntPtr label, int* v, ImGuiInputTextFlags flags);
    //public bool InputInt3(IntPtr label, int* v, ImGuiInputTextFlags flags);
    //public bool InputInt4(IntPtr label, int* v, ImGuiInputTextFlags flags);
    //public bool InputScalar(IntPtr label, ImGuiDataType data_type, void* p_data, void* p_step, void* p_step_fast, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputScalarN(IntPtr label, ImGuiDataType data_type, void* p_data, int components, void* p_step, void* p_step_fast, IntPtr format, ImGuiInputTextFlags flags);
    //public bool InputText(IntPtr label, IntPtr buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* user_data);
    //public bool InputTextMultiline(IntPtr label, IntPtr buf, uint buf_size, Vector2D<float> size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* user_data);
    //public bool InputTextWithHint(IntPtr label, IntPtr hint, IntPtr buf, uint buf_size, ImGuiInputTextFlags flags, ImGuiInputTextCallback callback, void* user_data);
    //public bool InvisibleButton(IntPtr str_id, Vector2D<float> size, ImGuiButtonFlags flags);
    //public bool IsAnyItemActive();
    //public bool IsAnyItemFocused();
    //public bool IsAnyItemHovered();
    //public bool IsAnyMouseDown();
    //public bool IsItemActivated();
    //public bool IsItemActive();
    //public bool IsItemClicked(ImGuiMouseButton mouse_button);
    //public bool IsItemDeactivated();
    //public bool IsItemDeactivatedAfterEdit();
    //public bool IsItemEdited();
    //public bool IsItemFocused();
    //public bool IsItemHovered(ImGuiHoveredFlags flags);
    //public bool IsItemToggledOpen();
    //public bool IsItemVisible();
    //public bool IsKeyDown(ImGuiKey key);
    //public bool IsKeyPressed(ImGuiKey key, bool repeat);
    //public bool IsKeyReleased(ImGuiKey key);
    //public bool IsMouseClicked(ImGuiMouseButton button, bool repeat);
    //public bool IsMouseDoubleClicked(ImGuiMouseButton button);
    //public bool IsMouseDown(ImGuiMouseButton button);
    //public bool IsMouseDragging(ImGuiMouseButton button, float lock_threshold);
    //public bool IsMouseHoveringRect(Vector2D<float> r_min, Vector2D<float> r_max, bool clip);
    //public bool IsMousePosValid(Vector2D<float>* mouse_pos);
    //public bool IsMouseReleased(ImGuiMouseButton button);
    //public bool IsPopupOpen_Str(IntPtr str_id, ImGuiPopupFlags flags);
    //public bool IsRectVisible_Nil(Vector2D<float> size);
    //public bool IsRectVisible_Vec2(Vector2D<float> rect_min, Vector2D<float> rect_max);
    //public bool IsWindowAppearing();
    //public bool IsWindowCollapsed();
    //public bool IsWindowDocked();
    //public bool IsWindowFocused(ImGuiFocusedFlags flags);
    //public bool IsWindowHovered(ImGuiHoveredFlags flags);
    //public void LabelText(IntPtr label, IntPtr fmt);
    //public bool ListBox_Str_arr(IntPtr label, int* current_item, IntPtr* items, int items_count, int height_in_items);
    //public void LoadIniSettingsFromDisk(IntPtr ini_filename);
    //public void LoadIniSettingsFromMemory(IntPtr ini_data, uint ini_size);
    //public void LogButtons();
    //public void LogFinish();
    //public void LogText(IntPtr fmt);
    //public void LogToClipboard(int auto_open_depth);
    //public void LogToFile(int auto_open_depth, IntPtr filename);
    //public void LogToTTY(int auto_open_depth);
    //public void* MemAlloc(uint size);
    //public void MemFree(void* ptr);
    //public bool MenuItem_Bool(IntPtr label, IntPtr shortcut, bool selected, bool enabled);
    //public bool MenuItem_BoolPtr(IntPtr label, IntPtr shortcut, IntPtr p_selected, bool enabled);
    public void NewFrame();
    //public void NewLine();
    //public void NextColumn();
    //public void OpenPopup_Str(IntPtr str_id, ImGuiPopupFlags popup_flags);
    //public void OpenPopup_ID(uint id, ImGuiPopupFlags popup_flags);
    //public void OpenPopupOnItemClick(IntPtr str_id, ImGuiPopupFlags popup_flags);
    //public void PlotHistogram_FloatPtr(IntPtr label, float* values, int values_count, int values_offset, IntPtr overlay_text, float scale_min, float scale_max, Vector2D<float> graph_size, int stride);
    //public void PlotLines_FloatPtr(IntPtr label, float* values, int values_count, int values_offset, IntPtr overlay_text, float scale_min, float scale_max, Vector2D<float> graph_size, int stride);
    //public void PopAllowKeyboardFocus();
    //public void PopButtonRepeat();
    //public void PopClipRect();
    //public void PopFont();
    //public void PopID();
    //public void PopItemWidth();
    //public void PopStyleColor(int count);
    //public void PopStyleVar(int count);
    //public void PopTextWrapPos();
    //public void ProgressBar(float fraction, Vector2D<float> size_arg, IntPtr overlay);
    //public void PushAllowKeyboardFocus(bool allow_keyboard_focus);
    //public void PushButtonRepeat(bool repeat);
    //public void PushClipRect(Vector2D<float> clip_rect_min, Vector2D<float> clip_rect_max, bool intersect_with_current_clip_rect);
    //public void PushFont(ImFont* font);
    //public void PushID_Str(IntPtr str_id);
    //public void PushID_StrStr(IntPtr str_id_begin, IntPtr str_id_end);
    //public void PushID_Ptr(void* ptr_id);
    //public void PushID_Int(int int_id);
    //public void PushItemWidth(float item_width);
    //public void PushStyleColor_U32(ImGuiCol idx, uint col);
    //public void PushStyleColor_Vec4(ImGuiCol idx, Vector4D<float> col);
    //public void PushStyleVar_Float(ImGuiStyleVar idx, float val);
    //public void PushStyleVar_Vec2(ImGuiStyleVar idx, Vector2D<float> val);
    //public void PushTextWrapPos(float wrap_local_pos_x);
    //public bool RadioButton_Bool(IntPtr label, bool active);
    //public bool RadioButton_IntPtr(IntPtr label, int* v, int v_button);
    public void Render();
    //public void RenderPlatformWindowsDefault(void* platform_render_arg, void* renderer_render_arg);
    //public void ResetMouseDragDelta(ImGuiMouseButton button);
    //public void SameLine(float offset_from_start_x, float spacing);
    //public void SaveIniSettingsToDisk(IntPtr ini_filename);
    //public IntPtr SaveIniSettingsToMemory(uint* out_ini_size);
    //public bool Selectable_Bool(IntPtr label, bool selected, ImGuiSelectableFlags flags, Vector2D<float> size);
    //public bool Selectable_BoolPtr(IntPtr label, IntPtr p_selected, ImGuiSelectableFlags flags, Vector2D<float> size);
    //public void Separator();
    //public void SetAllocatorFunctions(IntPtr alloc_func, IntPtr free_func, void* user_data);
    //public void SetClipboardText(IntPtr text);
    //public void SetColorEditOptions(ImGuiColorEditFlags flags);
    //public void SetColumnOffset(int column_index, float offset_x);
    //public void SetColumnWidth(int column_index, float width);
    //public void SetCurrentContext(IntPtr ctx);
    //public void SetCursorPos(Vector2D<float> local_pos);
    //public void SetCursorPosX(float local_x);
    //public void SetCursorPosY(float local_y);
    //public void SetCursorScreenPos(Vector2D<float> pos);
    //public bool SetDragDropPayload(IntPtr type, void* data, uint sz, ImGuiCond cond);
    //public void SetItemAllowOverlap();
    //public void SetItemDefaultFocus();
    //public void SetKeyboardFocusHere(int offset);
    //public void SetMouseCursor(ImGuiMouseCursor cursor_type);
    //public void SetNextItemOpen(bool is_open, ImGuiCond cond);
    //public void SetNextItemWidth(float item_width);
    //public void SetNextWindowBgAlpha(float alpha);
    //public void SetNextWindowClass(ImGuiWindowClass* window_class);
    //public void SetNextWindowCollapsed(bool collapsed, ImGuiCond cond);
    //public void SetNextWindowContentSize(Vector2D<float> size);
    //public void SetNextWindowDockID(uint dock_id, ImGuiCond cond);
    //public void SetNextWindowFocus();
    //public void SetNextWindowPos(Vector2D<float> pos, ImGuiCond cond, Vector2D<float> pivot);
    //public void SetNextWindowSize(Vector2D<float> size, ImGuiCond cond);
    //public void SetNextWindowSizeConstraints(Vector2D<float> size_min, Vector2D<float> size_max, ImGuiSizeCallback custom_callback, void* custom_callback_data);
    //public void SetNextWindowViewport(uint viewport_id);
    //public void SetScrollFromPosX_Float(float local_x, float center_x_ratio);
    //public void SetScrollFromPosY_Float(float local_y, float center_y_ratio);
    //public void SetScrollHereX(float center_x_ratio);
    //public void SetScrollHereY(float center_y_ratio);
    //public void SetScrollX_Float(float scroll_x);
    //public void SetScrollY_Float(float scroll_y);
    //public void SetStateStorage(ImGuiStorage* storage);
    //public void SetTabItemClosed(IntPtr tab_or_docked_window_label);
    //public void SetTooltip(IntPtr fmt);
    //public void SetWindowCollapsed_Bool(bool collapsed, ImGuiCond cond);
    //public void SetWindowCollapsed_Str(IntPtr name, bool collapsed, ImGuiCond cond);
    //public void SetWindowFocus_Nil();
    //public void SetWindowFocus_Str(IntPtr name);
    //public void SetWindowFontScale(float scale);
    //public void SetWindowPos_Vec2(Vector2D<float> pos, ImGuiCond cond);
    //public void SetWindowPos_Str(IntPtr name, Vector2D<float> pos, ImGuiCond cond);
    //public void SetWindowSize_Vec2(Vector2D<float> size, ImGuiCond cond);
    //public void SetWindowSize_Str(IntPtr name, Vector2D<float> size, ImGuiCond cond);
    //public void ShowAboutWindow(IntPtr p_open);
    //public void ShowDemoWindow(IntPtr p_open);
    //public void ShowFontSelector(IntPtr label);
    //public void ShowMetricsWindow(IntPtr p_open);
    //public void ShowStackToolWindow(IntPtr p_open);
    //public void ShowStyleEditor(ImGuiStyle* @ref);
    //public bool ShowStyleSelector(IntPtr label);
    //public void ShowUserGuide();
    //public bool SliderAngle(IntPtr label, float* v_rad, float v_degrees_min, float v_degrees_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderFloat(IntPtr label, float* v, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderFloat2(IntPtr label, Vector2D<float>* v, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderFloat3(IntPtr label, Vector3D<float>* v, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderFloat4(IntPtr label, Vector4D<float>* v, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderInt(IntPtr label, int* v, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderInt2(IntPtr label, int* v, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderInt3(IntPtr label, int* v, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderInt4(IntPtr label, int* v, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderScalar(IntPtr label, ImGuiDataType data_type, void* p_data, void* p_min, void* p_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SliderScalarN(IntPtr label, ImGuiDataType data_type, void* p_data, int components, void* p_min, void* p_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool SmallButton(IntPtr label);
    //public void Spacing();
    //public void StyleColorsClassic(ImGuiStyle* dst);
    //public void StyleColorsDark(ImGuiStyle* dst);
    //public void StyleColorsLight(ImGuiStyle* dst);
    //public bool TabItemButton(IntPtr label, ImGuiTabItemFlags flags);
    //public int TableGetColumnCount();
    //public ImGuiTableColumnFlags TableGetColumnFlags(int column_n);
    //public int TableGetColumnIndex();
    //public IntPtr TableGetColumnName_Int(int column_n);
    //public int TableGetRowIndex();
    //public ImGuiTableSortSpecs* TableGetSortSpecs();
    //public void TableHeader(IntPtr label);
    //public void TableHeadersRow();
    //public bool TableNextColumn();
    //public void TableNextRow(ImGuiTableRowFlags row_flags, float min_row_height);
    //public void TableSetBgColor(ImGuiTableBgTarget target, uint color, int column_n);
    //public void TableSetColumnEnabled(int column_n, bool v);
    //public bool TableSetColumnIndex(int column_n);
    //public void TableSetupColumn(IntPtr label, ImGuiTableColumnFlags flags, float init_width_or_weight, uint user_id);
    //public void TableSetupScrollFreeze(int cols, int rows);
    public unsafe void Text(char* fmt); // Core.PointerArray<byte>
    //public void TextColored(Vector4D<float> col, IntPtr fmt);
    //public void TextDisabled(IntPtr fmt);
    //public void TextUnformatted(IntPtr text, IntPtr text_end);
    //public void TextWrapped(IntPtr fmt);
    //public bool TreeNode_Str(IntPtr label);
    //public bool TreeNode_StrStr(IntPtr str_id, IntPtr fmt);
    //public bool TreeNode_Ptr(void* ptr_id, IntPtr fmt);
    //public bool TreeNodeEx_Str(IntPtr label, ImGuiTreeNodeFlags flags);
    //public bool TreeNodeEx_StrStr(IntPtr str_id, ImGuiTreeNodeFlags flags, IntPtr fmt);
    //public bool TreeNodeEx_Ptr(void* ptr_id, ImGuiTreeNodeFlags flags, IntPtr fmt);
    //public void TreePop();
    //public void TreePush_Str(IntPtr str_id);
    //public void TreePush_Ptr(void* ptr_id);
    //public void Unindent(float indent_w);
    //public void UpdatePlatformWindows();
    //public void Value_Bool(IntPtr prefix, bool b);
    //public void Value_Int(IntPtr prefix, int v);
    //public void Value_Uint(IntPtr prefix, uint v);
    //public void Value_Float(IntPtr prefix, float v, IntPtr float_format);
    //public bool VSliderFloat(IntPtr label, Vector2D<float> size, float* v, float v_min, float v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool VSliderInt(IntPtr label, Vector2D<float> size, int* v, int v_min, int v_max, IntPtr format, ImGuiSliderFlags flags);
    //public bool VSliderScalar(IntPtr label, Vector2D<float> size, ImGuiDataType data_type, void* p_data, void* p_min, void* p_max, IntPtr format, ImGuiSliderFlags flags);
}