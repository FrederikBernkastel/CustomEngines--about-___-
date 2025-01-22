namespace FrederikaStudio.GLFW;

public sealed class MonitorGLFW
{
    private static IDictionary<IntPtr, MonitorGLFW> MonitorList { get; }

    static MonitorGLFW()
    {
        MonitorList = SCU.CoreArray.PtrToArray(LibraryGLFW.GLFW.GetMonitors(out var count), count)
            .ToArray().Select(u => new MonitorGLFW(u)).ToDictionary(u => u.Handle.Handle, u => u);
    }

    public static MonitorGLFW PrimaryMonitor => MonitorList[LibraryGLFW.GLFW.GetPrimaryMonitor().Handle];
    public static ICollection<MonitorGLFW> Monitors => MonitorList.Values;

    internal SNGLFW.MonitorGLFW Handle { get; }

    public string Name { get; }
    public Vector2D<int> PhysicalSize { get; }
    public IEnumerable<SNGLFW.VidmodeGLFW> VideoModeList { get; }

    private MonitorGLFW(SNGLFW.MonitorGLFW handle)
    {
        Handle = handle;
        Name = LibraryGLFW.GLFW.GetMonitorName(handle);
        VideoModeList = SCU.CoreArray.PtrToArray(LibraryGLFW.GLFW.GetVideoModes(handle, out var count), count).ToArray().AsEnumerable();
        LibraryGLFW.GLFW.GetMonitorPhysicalSize(handle, out var widthMM, out var heightMM);
        PhysicalSize = new(widthMM, heightMM);
    }

    public Vector2D<int> MonitorPosition
    {
        get
        {
            LibraryGLFW.GLFW.GetMonitorPos(Handle, out var xpos, out var ypos);
            return new(xpos, ypos);
        }
    }
    public Vector4D<int> MonitorWorkarea
    {
        get
        {
            LibraryGLFW.GLFW.GetMonitorWorkarea(Handle, out var xpos, out var ypos, out var width, out var height);
            return new(xpos, ypos, width, height);
        }
    }
    public Vector2D<float> MonitorContentScale
    {
        get
        {
            LibraryGLFW.GLFW.GetMonitorContentScale(Handle, out var xscale, out var yscale);
            return new(xscale, yscale);
        }
    }
    public IntPtr MonitorUserPointer
    {
        set => LibraryGLFW.GLFW.SetMonitorUserPointer(Handle, value);
        get => LibraryGLFW.GLFW.GetMonitorUserPointer(Handle);
    }
    public SNGLFW.VidmodeGLFW CurrentVideoMode => LibraryGLFW.GLFW.GetVideoMode(Handle);
    public void SetGammaRamp(SNGLFW.GammaRampGLFW gammaRamp) => LibraryGLFW.GLFW.SetGammaRamp(Handle, gammaRamp);
    public SNGLFW.GammaRampGLFW CurrentGammaRamp => LibraryGLFW.GLFW.GetGammaRamp(Handle);
    public void SetGamma(float gamma) => LibraryGLFW.GLFW.SetGamma(Handle, gamma);
}
