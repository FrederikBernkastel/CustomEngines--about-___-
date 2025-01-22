namespace FrederikaStudio.GLFW;

public static class Versions
{
    public static _Math.Vector3D<int> Version
    {
        get
        {
            Context.NativeGLFW.GetVersion(out var major, out var minor, out var rev);
            return new(major, minor, rev);
        }
    }
    public static string VersionString => Context.NativeGLFW.GetVersionString();
}
