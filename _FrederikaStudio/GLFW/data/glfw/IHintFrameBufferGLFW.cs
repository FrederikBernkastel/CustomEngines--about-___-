namespace FrederikaStudio.GLFW;

public interface IHintFrameBufferGLFW
{
    public int RedBits { get; set; }
    public int GreenBits { get; set; }
    public int BlueBits { get; set; }
    public int AlphaBits { get; set; }
    public int DepthBits { get; set; }
    public int StencilBits { get; set; }
    public int AccumRedBits { get; set; }
    public int AccumGreenBits { get; set; }
    public int AccumBlueBits { get; set; }
    public int AccumAlphaBits { get; set; }
    public int AuxBuffers { get; set; }
    public int Samples { get; set; }
    public bool Stereo { get; set; }
    public bool SrgbCapable { get; set; }
    public bool DoubleBuffer { get; set; }
}
