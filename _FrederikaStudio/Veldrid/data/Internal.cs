namespace Veldrid;

internal static class Internal
{
    public static IOpenGL_4_5 OpenGL { get; }

    static Internal()
    {
        OpenGL = IOpenGL_4_5.OpenGL_4_5;
    }
}
