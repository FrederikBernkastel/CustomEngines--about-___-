namespace FrederikaStudio.GLFW;

[_Core.InvokeStaticCtor]
public static class Versions
{
    public static Version Version { get; }
    public static string VersionString { get; }

    static Versions()
    {
        Library.GLFW.GetVersion(out var major, out var minor, out var rev);
        Version = new(major, minor, rev);
        VersionString = Library.GLFW.GetVersionString();
    }
}
