namespace FrederikaStudio.GLFW;

public sealed class Monitor
{
    private static Dictionary<_nGLFW.Monitor, Monitor>? PrivateMonitors { get; set; }
    internal static Dictionary<_nGLFW.Monitor, Monitor> ListMonitors
    {
        get
        {
            if (PrivateMonitors is not null)
                return PrivateMonitors;
            PrivateMonitors = new();
            var list = Context.NativeGLFW.GetMonitors(out var count);
            foreach (var s in list.ToArray((uint)count))
                PrivateMonitors[s] = new(s);
            return PrivateMonitors;
        }
    }
    public static Dictionary<_nGLFW.Monitor, Monitor>.ValueCollection Monitors => ListMonitors.Values;
    public static Monitor PrimaryMonitor => ListMonitors[Context.NativeGLFW.GetPrimaryMonitor()];

    public _nGLFW.Monitor Handle { get; }
    private float GammaTemp { get; set; }

    private Monitor(_nGLFW.Monitor handle)
    {
        Handle = handle;
        GammaTemp = default;
    }

    public _nGLFW.GammaRamp GammaRamp
    {
        get => Context.NativeGLFW.GetGammaRamp(Handle);
        set => Context.NativeGLFW.SetGammaRamp(Handle, value);
    }
    public IntPtr UserPointer
    {
        get => Context.NativeGLFW.GetMonitorUserPointer(Handle);
        set => Context.NativeGLFW.SetMonitorUserPointer(Handle, value);
    }
    public float Gamma
    {
        set
        {
            Context.NativeGLFW.SetGamma(Handle, value);
            GammaTemp = value;
        }
        get => GammaTemp;
    }
    public Span<_nGLFW.Vidmode> VideoModes =>
        Context.NativeGLFW.GetVideoModes(Handle, out var count).ToArray((uint)count);
    public _Math.Vector2D<int> Position
    {
        get
        {
            Context.NativeGLFW.GetMonitorPos(Handle, out var xpos, out var ypos);
            return new(xpos, ypos);
        }
    }
    public _Math.Vector4D<int> Workarea
    {
        get
        {
            Context.NativeGLFW.GetMonitorWorkarea(Handle, out var xpos, out var ypos, out var width, out var height);
            return new(xpos, ypos, width, height);
        }
    }
    public _Math.Vector2D<int> PhysicalSize
    {
        get
        {
            Context.NativeGLFW.GetMonitorPhysicalSize(Handle, out var widthMM, out var heightMM);
            return new(widthMM, heightMM);
        }
    }
    public _Math.Vector2D<float> ContentScale
    {
        get
        {
            Context.NativeGLFW.GetMonitorContentScale(Handle, out var xscale, out var yscale);
            return new(xscale, yscale);
        }
    }
    public string Name => Context.NativeGLFW.GetMonitorName(Handle);
    public _nGLFW.Vidmode VideoMode => Context.NativeGLFW.GetVideoMode(Handle);
}
