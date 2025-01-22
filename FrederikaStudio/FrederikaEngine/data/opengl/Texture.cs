namespace FrederikaStudio.OpenGL;

public record class TextureDescription(
    _Math.Vector2D<uint> Size,
    uint Depth,
    uint MipLevels,
    uint ArrayLayers,
    _nOpenGL.PixelFormat Format,
    _nOpenGL.TextureUsage Usage,
    _nOpenGL.TextureTarget Target)
{
    /// <summary>
    /// The total width, in texels.
    /// </summary>
    public uint Width;
    /// <summary>
    /// The total height, in texels.
    /// </summary>
    public uint Height;
    /// <summary>
    /// The total depth, in texels.
    /// </summary>
    public uint Depth;
    /// <summary>
    /// The number of mipmap levels.
    /// </summary>
    public uint MipLevels;
    /// <summary>
    /// The number of array layers.
    /// </summary>
    public uint ArrayLayers;
    /// <summary>
    /// The format of individual texture elements.
    /// </summary>
    public PixelFormat Format;
    /// <summary>
    /// Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader, then
    /// <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.
    /// If the Texture will be used as a 2D cubemap, then <see cref="TextureUsage.Cubemap"/> must be included.
    /// </summary>
    public TextureUsage Usage;
    /// <summary>
    /// The type of Texture to create.
    /// </summary>
    public TextureType Type;
    /// <summary>
    /// The number of samples. If equal to <see cref="TextureSampleCount.Count1"/>, this instance does not describe a
    /// multisample <see cref="Texture"/>.
    /// </summary>
    public TextureSampleCount SampleCount;

    /// <summary>
    /// Contsructs a new TextureDescription describing a non-multisampled <see cref="Texture"/>.
    /// </summary>
    /// <param name="width">The total width, in texels.</param>
    /// <param name="height">The total height, in texels.</param>
    /// <param name="depth">The total depth, in texels.</param>
    /// <param name="mipLevels">The number of mipmap levels.</param>
    /// <param name="arrayLayers">The number of array layers.</param>
    /// <param name="format">The format of individual texture elements.</param>
    /// <param name="usage">Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader,
    /// then <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.
    /// If the Texture will be used as a 2D cubemap, then <see cref="TextureUsage.Cubemap"/> must be included.</param>
    /// <param name="type">The type of Texture to create.</param>
    public TextureDescription(
        uint width,
        uint height,
        uint depth,
        uint mipLevels,
        uint arrayLayers,
        PixelFormat format,
        TextureUsage usage,
        TextureType type)
    {
        Width = width;
        Height = height;
        Depth = depth;
        MipLevels = mipLevels;
        ArrayLayers = arrayLayers;
        Format = format;
        Usage = usage;
        SampleCount = TextureSampleCount.Count1;
        Type = type;
    }

    /// <summary>
    /// Contsructs a new TextureDescription.
    /// </summary>
    /// <param name="width">The total width, in texels.</param>
    /// <param name="height">The total height, in texels.</param>
    /// <param name="depth">The total depth, in texels.</param>
    /// <param name="mipLevels">The number of mipmap levels.</param>
    /// <param name="arrayLayers">The number of array layers.</param>
    /// <param name="format">The format of individual texture elements.</param>
    /// <param name="usage">Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader,
    /// then <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.
    /// If the Texture will be used as a 2D cubemap, then <see cref="TextureUsage.Cubemap"/> must be included.</param>
    /// <param name="type">The type of Texture to create.</param>
    /// <param name="sampleCount">The number of samples. If any other value than <see cref="TextureSampleCount.Count1"/> is
    /// provided, then this describes a multisample texture.</param>
    public TextureDescription(
        uint width,
        uint height,
        uint depth,
        uint mipLevels,
        uint arrayLayers,
        PixelFormat format,
        TextureUsage usage,
        TextureType type,
        TextureSampleCount sampleCount)
    {
        Width = width;
        Height = height;
        Depth = depth;
        MipLevels = mipLevels;
        ArrayLayers = arrayLayers;
        Format = format;
        Usage = usage;
        Type = type;
        SampleCount = sampleCount;
    }

    /// <summary>
    /// Creates a description for a non-multisampled 1D Texture.
    /// </summary>
    /// <param name="width">The total width, in texels.</param>
    /// <param name="mipLevels">The number of mipmap levels.</param>
    /// <param name="arrayLayers">The number of array layers.</param>
    /// <param name="format">The format of individual texture elements.</param>
    /// <param name="usage">Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader,
    /// then <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.
    /// </param>
    /// <returns>A new TextureDescription for a non-multisampled 1D Texture.</returns>
    public static TextureDescription Texture1D(
        uint width,
        uint mipLevels,
        uint arrayLayers,
        PixelFormat format,
        TextureUsage usage)
    {
        return new TextureDescription(
            width,
            1,
            1,
            mipLevels,
            arrayLayers,
            format,
            usage,
            TextureType.Texture1D,
            TextureSampleCount.Count1);
    }

    /// <summary>
    /// Creates a description for a non-multisampled 2D Texture.
    /// </summary>
    /// <param name="width">The total width, in texels.</param>
    /// <param name="height">The total height, in texels.</param>
    /// <param name="mipLevels">The number of mipmap levels.</param>
    /// <param name="arrayLayers">The number of array layers.</param>
    /// <param name="format">The format of individual texture elements.</param>
    /// <param name="usage">Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader,
    /// then <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.
    /// If the Texture will be used as a 2D cubemap, then <see cref="TextureUsage.Cubemap"/> must be included.</param>
    /// <returns>A new TextureDescription for a non-multisampled 2D Texture.</returns>
    public static TextureDescription Texture2D(
        uint width,
        uint height,
        uint mipLevels,
        uint arrayLayers,
        PixelFormat format,
        TextureUsage usage)
    {
        return new TextureDescription(
            width,
            height,
            1,
            mipLevels,
            arrayLayers,
            format,
            usage,
            TextureType.Texture2D,
            TextureSampleCount.Count1);
    }

    /// <summary>
    /// Creates a description for a 2D Texture.
    /// </summary>
    /// <param name="width">The total width, in texels.</param>
    /// <param name="height">The total height, in texels.</param>
    /// <param name="mipLevels">The number of mipmap levels.</param>
    /// <param name="arrayLayers">The number of array layers.</param>
    /// <param name="format">The format of individual texture elements.</param>
    /// <param name="usage">Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader,
    /// then <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.
    /// If the Texture will be used as a 2D cubemap, then <see cref="TextureUsage.Cubemap"/> must be included.</param>
    /// <param name="sampleCount">The number of samples. If any other value than <see cref="TextureSampleCount.Count1"/> is
    /// provided, then this describes a multisample texture.</param>
    /// <returns>A new TextureDescription for a 2D Texture.</returns>
    public static TextureDescription Texture2D(
        uint width,
        uint height,
        uint mipLevels,
        uint arrayLayers,
        PixelFormat format,
        TextureUsage usage,
        TextureSampleCount sampleCount)
    {
        return new TextureDescription(
            width,
            height,
            1,
            mipLevels,
            arrayLayers,
            format,
            usage,
            TextureType.Texture2D,
            sampleCount);
    }

    /// <summary>
    /// Creates a description for a 3D Texture.
    /// </summary>
    /// <param name="width">The total width, in texels.</param>
    /// <param name="height">The total height, in texels.</param>
    /// <param name="depth">The total depth, in texels.</param>
    /// <param name="mipLevels">The number of mipmap levels.</param>
    /// <param name="format">The format of individual texture elements.</param>
    /// <param name="usage">Controls how the Texture is permitted to be used. If the Texture will be sampled from a shader,
    /// then <see cref="TextureUsage.Sampled"/> must be included. If the Texture will be used as a depth target in a
    /// <see cref="Framebuffer"/>, then <see cref="TextureUsage.DepthStencil"/> must be included. If the Texture will be used
    /// as a color target in a <see cref="Framebuffer"/>, then <see cref="TextureUsage.RenderTarget"/> must be included.</param>
    /// <returns>A new TextureDescription for a 3D Texture.</returns>
    public static TextureDescription Texture3D(
        uint width,
        uint height,
        uint depth,
        uint mipLevels,
        PixelFormat format,
        TextureUsage usage)
    {
        return new TextureDescription(
            width,
            height,
            depth,
            mipLevels,
            1,
            format,
            usage,
            TextureType.Texture3D,
            TextureSampleCount.Count1);
    }
}
public sealed class RangeMemoryTexture2D
{
    public _Math.Vector2D<int> Offset { get; }
    public _Math.Vector2D<uint> Size { get; }
    public MemoryTexture2D 
}
public sealed class MemoryTexture2D
{
    public enum MemoryTextureType : byte
    {
        JPEG,
        PNG,
    }
    public _Math.Vector2D<uint> Size { get; }
    internal _nOpenGL.PixelFormat Format { get; }
    internal _nOpenGL.PixelType Type { get; }
    public MemoryTextureType TextureType { get; }
    internal byte[]? Data { get; private set; }
    public bool IsDisposed { get; private set; }

    public MemoryTexture2D(string path, MemoryTextureType type)
    {
        switch (type)
        {
            case MemoryTextureType.PNG:
                Format = _nOpenGL.PixelFormat.Rgba;
                Type = _nOpenGL.PixelType.UnsignedByte;
                TextureType = MemoryTextureType.PNG;
                break;
            case MemoryTextureType.JPEG:
                Format = _nOpenGL.PixelFormat.Rgb;
                Type = _nOpenGL.PixelType.UnsignedByte;
                TextureType = MemoryTextureType.JPEG;
                break;
        }
        using _ImageSharp.Image<_ImageSharp.PixelFormats.Rgba32> image = 
            _ImageSharp.Image.Load<_ImageSharp.PixelFormats.Rgba32>(path);
        Data = new byte[image.Width * image.Height * 4];
        image.CopyPixelDataTo(Data);
        Size = new((uint)image.Width, (uint)image.Height);
    }

    public RangeMemoryTexture2D GetRangeData(_Math.Vector2D<int> offset, _Math.Vector2D<uint> size)
    {

    }
    public void Dispose()
    {
        Data = default;
        IsDisposed = true;
    }
}
public sealed class Texture2D
{
    public _nOpenGL.Texture Handle { get; private set; }
    public bool IsDisposed { get; private set; }
    public TextureDescription Description { get; }

    public Texture2D(TextureDescription description)
    {
        Description = description;
        Context.NativeOpenGL.CreateTextures(Description.Target, 1, out var handle);
        Handle = handle;
        Context.NativeOpenGL.TextureSto
    }

    public readonly record struct UpdateDataInfo(
        int Level = 0, _Math.Vector2D<int> Offset = default, _Math.Vector2D<uint> Size,
        _nOpenGL.PixelFormat Format, _nOpenGL.PixelType Type, IntPtr Data);
    public void UpdateData()
    {
        Context.NativeOpenGL.TextureSubImage2D(); _nOpenGL.PixelType
    }
    public void CreateGLResources()
    {
        if (IsCreated)
            return;
        Context.NativeOpenGL.CreateTextures(TextureTarget, 1, out var handle);
        Handle = handle;

        bool isDepthTex = (Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil;

        if (TextureTarget == TextureTarget.Texture1D)
        {
            glTextureStorage1D(
                    _texture,
                    MipLevels,
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width);
        }
        else if (TextureTarget == TextureTarget.Texture2D || TextureTarget == TextureTarget.Texture1DArray)
        {
            uint heightOrArrayLayers = TextureTarget == TextureTarget.Texture2D ? Height : ArrayLayers;
            glTextureStorage2D(
                    _texture,
                    MipLevels,
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    heightOrArrayLayers);
        }
        else if (TextureTarget == TextureTarget.Texture2DArray)
        {
            glTextureStorage3D(
                    _texture,
                    MipLevels,
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    Height,
                    ArrayLayers);
        }
        else if (TextureTarget == TextureTarget.Texture2DMultisample)
        {
            glTextureStorage2DMultisample(
                    _texture,
                    FormatHelpers.GetSampleCountUInt32(SampleCount),
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    Height,
                    false);
        }
        else if (TextureTarget == TextureTarget.Texture2DMultisampleArray)
        {
            glTextureStorage3DMultisample(
                    _texture,
                    FormatHelpers.GetSampleCountUInt32(SampleCount),
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    Height,
                    ArrayLayers,
                    false);
        }
        else if (TextureTarget == TextureTarget.TextureCubeMap)
        {
            glTextureStorage2D(
                    _texture,
                    MipLevels,
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    Height);
        }
        else if (TextureTarget == TextureTarget.TextureCubeMapArray)
        {
            glTextureStorage3D(
                    _texture,
                    MipLevels,
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    Height,
                    ArrayLayers * 6);
        }
        else if (TextureTarget == TextureTarget.Texture3D)
        {
            glTextureStorage3D(
                    _texture,
                    MipLevels,
                    OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                    Width,
                    Height,
                    Depth);
        }

        IsCreated = true;
    }
    public void DestroyGLResources()
    {
        if (IsDisposed) return;
        IsDisposed = true;
        var handle = Handle;
        Context.NativeOpenGL.DeleteTextures(1, ref handle);
    }
}
