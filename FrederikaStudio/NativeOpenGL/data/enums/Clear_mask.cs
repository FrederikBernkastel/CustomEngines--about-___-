namespace FrederikaStudio.OpenGL.Native;

[Flags]
public enum Clear_mask
{
    GL_DEPTH_BUFFER_BIT = 0x00000100,
    GL_STENCIL_BUFFER_BIT = 0x00000400,
    GL_COLOR_BUFFER_BIT = 0x00004000,
}
