namespace FrederikaStudio.GLFW.Native;

public static class SNGLFW
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct CursorNativeGLFW(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct WindowNativeGLFW(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct MonitorNativeGLFW(IntPtr Handle);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct ImageNativeGLFW(int Width, int Height, SCU.PointerArray<byte> Pixels);
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct GammaRampNativeGLFW
    {
        [MarshalAs(UnmanagedType.LPArray)]
        private readonly ushort[] Red, Green, Blue;
        private readonly uint Size;

        public GammaRampNativeGLFW(IEnumerable<GammaRampRGB> rgb)
        {
            Size = (uint)rgb.Count();
            Red = rgb.Select(u => u.Red).ToArray();
            Green = rgb.Select(u => u.Green).ToArray();
            Blue = rgb.Select(u => u.Blue).ToArray();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct VidmodeNativeGLFW(int Width, int Height, int RedBits, int GreenBits, int BlueBits, int RefreshRate);
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct GammaRampRGB(ushort Red, ushort Green, ushort Blue);
}