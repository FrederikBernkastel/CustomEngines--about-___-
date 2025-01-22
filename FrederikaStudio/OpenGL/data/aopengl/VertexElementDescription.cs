namespace FrederikaStudio.OpenGL;

public readonly record struct VertexElementDescription(
    string Name, VertexElementSemantic Semantic, VertexElementFormat Format, uint Offset = 0);