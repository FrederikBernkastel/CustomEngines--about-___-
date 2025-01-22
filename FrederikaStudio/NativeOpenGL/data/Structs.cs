namespace FrederikaStudio.OpenGL.Native;

public readonly record struct Shader(uint Handle);
public readonly record struct Program(uint Handle);
public readonly record struct ProgramPipeline(uint Handle);
public readonly record struct VAO(uint Handle);
public readonly record struct VBO(uint Handle);
public readonly record struct Sampler(uint Handle);
public readonly record struct SyncObject(IntPtr Handle);
public readonly record struct Queries(uint Handle);
public readonly record struct Framebuffer(uint Handle);
public readonly record struct Renderbuffer(uint Handle);
public readonly record struct Texture(uint Handle);
public readonly record struct TransformFeedback(uint Handle);
