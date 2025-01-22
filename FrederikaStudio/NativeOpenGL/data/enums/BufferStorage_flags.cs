namespace FrederikaStudio.OpenGL.Native;

[Flags]
public enum BufferStorage_flags
{
    GL_DYNAMIC_STORAGE_BIT = 0x0100,
    GL_MAP_READ_BIT = 0x0001,
    GL_MAP_WRITE_BIT = 0x0002,
    GL_MAP_PERSISTENT_BIT = 0x0040,
    GL_MAP_COHERENT_BIT = 0x0080,
    GL_CLIENT_STORAGE_BIT = 0x0200,
}
