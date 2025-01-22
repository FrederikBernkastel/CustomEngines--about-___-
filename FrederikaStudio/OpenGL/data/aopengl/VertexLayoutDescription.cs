namespace FrederikaStudio.OpenGL;

public readonly record struct VertexLayoutDescription(
    uint Stride, VertexElementDescription[] Elements, uint InstanceStepRate = 0)
{
    public VertexLayoutDescription(VertexElementDescription[] elements) : this(default, null!)
    {
        Elements = elements;
        uint computedStride = 0;
        for (int i = 0; i < elements.Length; i++)
        {
            uint elementSize = FormatSizeHelpers.GetSizeInBytes(elements[i].Format);
            computedStride = 
                elements[i].Offset != 0 ? elements[i].Offset + elementSize : computedStride + elementSize;
        }
        Stride = computedStride;
    }
}
