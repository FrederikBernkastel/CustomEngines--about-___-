namespace FrederikaStudio.GLFW.Native;

public readonly record struct Cursor(IntPtr Handle);
public readonly record struct Window(IntPtr Handle);
public readonly record struct Monitor(IntPtr Handle);
public readonly record struct Image(
    int Width, int Height, _UnsafeWork.PointerArray<byte> Pixels);
public readonly record struct GammaRamp(
    _UnsafeWork.PointerArray<ushort> Red,
    _UnsafeWork.PointerArray<ushort> Green,
    _UnsafeWork.PointerArray<ushort> Blue,
    uint Size);
public readonly record struct Vidmode(
    int Width, int Height, int RedBits, 
    int GreenBits, int BlueBits, int RefreshRate);
public readonly record struct GammaRampRGB(
    ushort Red, ushort Green, ushort Blue);