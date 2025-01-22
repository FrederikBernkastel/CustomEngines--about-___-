namespace FrederikaStudio.GLFW;

[_Core.InvokeStaticCtor]
public interface IMonitor
{
    internal static Dictionary<_nGLFW.Monitor, IMonitor> ListMonitors { get; }
    public static Dictionary<_nGLFW.Monitor, IMonitor>.ValueCollection Monitors => ListMonitors.Values;
    public static IMonitor PrimaryMonitor => ListMonitors[Library.GLFW.GetPrimaryMonitor()];

    static IMonitor()
    {
        ListMonitors = 
            Library.GLFW.GetMonitors(out var coun).ToArray((uint)coun)
            .ToArray().ToDictionary<_nGLFW.Monitor, _nGLFW.Monitor, IMonitor>
            (u => u, e => new Monitor() { Handle = e });
    }

    public _nGLFW.Monitor Handle { get; }
    public _nGLFW.GammaRamp GammaRamp { get; set; }
    public IntPtr UserPointer { get; set; }
    public float Gamma { get; set; }
    public Span<_nGLFW.Vidmode> VideoModes { get; }
    public _Math.Vector2D<int> Position { get; }
    public _Math.Vector4D<int> Workarea { get; }
    public _Math.Vector2D<int> PhysicalSize { get; }
    public _Math.Vector2D<float> ContentScale { get; }
    public string Name { get; }
    public _nGLFW.Vidmode CurrentVideoMode { get; }
}
internal sealed class Monitor : IMonitor
{
    public _nGLFW.Monitor Handle { get; init; }
    private float GammaTemp { get; set; }

    public _nGLFW.GammaRamp GammaRamp
    {
        get => Library.GLFW.GetGammaRamp(Handle);
        set => Library.GLFW.SetGammaRamp(Handle, value);
    }
    public IntPtr UserPointer
    {
        get => Library.GLFW.GetMonitorUserPointer(Handle);
        set => Library.GLFW.SetMonitorUserPointer(Handle, value);
    }
    public float Gamma
    {
        set
        {
            Library.GLFW.SetGamma(Handle, value);
            GammaTemp = value;
        }
        get => GammaTemp;
    }
    public Span<_nGLFW.Vidmode> VideoModes => 
        Library.GLFW.GetVideoModes(Handle, out var count).ToArray((uint)count);
    public _Math.Vector2D<int> Position
    {
        get
        {
            Library.GLFW.GetMonitorPos(Handle, out var xpos, out var ypos);
            return new(xpos, ypos);
        }
    }
    public _Math.Vector4D<int> Workarea
    {
        get
        {
            Library.GLFW.GetMonitorWorkarea(Handle, out var xpos, out var ypos, out var width, out var height);
            return new(xpos, ypos, width, height);
        }
    }
    public _Math.Vector2D<int> PhysicalSize
    {
        get
        {
            Library.GLFW.GetMonitorPhysicalSize(Handle, out var widthMM, out var heightMM);
            return new(widthMM, heightMM);
        }
    }
    public _Math.Vector2D<float> ContentScale
    {
        get
        {
            Library.GLFW.GetMonitorContentScale(Handle, out var xscale, out var yscale);
            return new(xscale, yscale);
        }
    }
    public string Name => Library.GLFW.GetMonitorName(Handle);
    public _nGLFW.Vidmode CurrentVideoMode => Library.GLFW.GetVideoMode(Handle);
}
