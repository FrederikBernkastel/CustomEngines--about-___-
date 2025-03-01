﻿using static Veldrid.OpenGL.OpenGLUtil;
using System;
using System.Diagnostics;

namespace Veldrid.OpenGL
{
    internal unsafe class OpenGLTexture : Texture, OpenGLDeferredResource
    {
        private readonly OpenGLGraphicsDevice _gd;
        private uint _texture;
        private uint[] _framebuffers;
        private uint[] _pbos;
        private uint[] _pboSizes;
        private bool _disposeRequested;
        private bool _disposed;

        private string _name;
        private bool _nameChanged;
        
        public override string Name { get => _name; set { _name = value; _nameChanged = true; } }

        public uint Texture => _texture;

        public OpenGLTexture(OpenGLGraphicsDevice gd, ref TextureDescription description)
        {
            _gd = gd;

            Width = description.Width;
            Height = description.Height;
            Depth = description.Depth;
            Format = description.Format;
            MipLevels = description.MipLevels;
            ArrayLayers = description.ArrayLayers;
            Usage = description.Usage;
            Type = description.Type;
            SampleCount = description.SampleCount;

            _framebuffers = new uint[MipLevels * ArrayLayers];
            _pbos = new uint[MipLevels * ArrayLayers];
            _pboSizes = new uint[MipLevels * ArrayLayers];

            GLPixelFormat = OpenGLFormats.VdToGLPixelFormat(Format);
            GLPixelType = OpenGLFormats.VdToGLPixelType(Format);
            GLInternalFormat = OpenGLFormats.VdToGLPixelInternalFormat(Format);

            if ((Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil)
            {
                GLPixelFormat = FormatHelpers.IsStencilFormat(Format)
                    ? GLPixelFormat.DepthStencil
                    : GLPixelFormat.DepthComponent;
                if (Format == PixelFormat.R16_UNorm)
                {
                    GLInternalFormat = PixelInternalFormat.DepthComponent16;
                }
                else if (Format == PixelFormat.R32_Float)
                {
                    GLInternalFormat = PixelInternalFormat.DepthComponent32f;
                }
            }

            if ((Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
            {
                TextureTarget = ArrayLayers == 1 ? TextureTarget.TextureCubeMap : TextureTarget.TextureCubeMapArray;
            }
            else if (Type == TextureType.Texture1D)
            {
                TextureTarget = ArrayLayers == 1 ? TextureTarget.Texture1D : TextureTarget.Texture1DArray;
            }
            else if (Type == TextureType.Texture2D)
            {
                if (ArrayLayers == 1)
                {
                    TextureTarget = SampleCount == TextureSampleCount.Count1 ? TextureTarget.Texture2D : TextureTarget.Texture2DMultisample;
                }
                else
                {
                    TextureTarget = SampleCount == TextureSampleCount.Count1 ? TextureTarget.Texture2DArray : TextureTarget.Texture2DMultisampleArray;
                }
            }
            else
            {
                Debug.Assert(Type == TextureType.Texture3D);
                TextureTarget = TextureTarget.Texture3D;
            }
        }

        public OpenGLTexture(OpenGLGraphicsDevice gd, uint nativeTexture, ref TextureDescription description)
        {
            _gd = gd;
            _texture = nativeTexture;
            Width = description.Width;
            Height = description.Height;
            Depth = description.Depth;
            Format = description.Format;
            MipLevels = description.MipLevels;
            ArrayLayers = description.ArrayLayers;
            Usage = description.Usage;
            Type = description.Type;
            SampleCount = description.SampleCount;

            _framebuffers = new uint[MipLevels * ArrayLayers];
            _pbos = new uint[MipLevels * ArrayLayers];
            _pboSizes = new uint[MipLevels * ArrayLayers];

            GLPixelFormat = OpenGLFormats.VdToGLPixelFormat(Format);
            GLPixelType = OpenGLFormats.VdToGLPixelType(Format);
            GLInternalFormat = OpenGLFormats.VdToGLPixelInternalFormat(Format);

            if ((Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil)
            {
                GLPixelFormat = FormatHelpers.IsStencilFormat(Format)
                    ? GLPixelFormat.DepthStencil
                    : GLPixelFormat.DepthComponent;
                if (Format == PixelFormat.R16_UNorm)
                {
                    GLInternalFormat = PixelInternalFormat.DepthComponent16;
                }
                else if (Format == PixelFormat.R32_Float)
                {
                    GLInternalFormat = PixelInternalFormat.DepthComponent32f;
                }
            }

            if ((Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
            {
                TextureTarget = ArrayLayers == 1 ? TextureTarget.TextureCubeMap : TextureTarget.TextureCubeMapArray;
            }
            else if (Type == TextureType.Texture1D)
            {
                TextureTarget = ArrayLayers == 1 ? TextureTarget.Texture1D : TextureTarget.Texture1DArray;
            }
            else if (Type == TextureType.Texture2D)
            {
                if (ArrayLayers == 1)
                {
                    TextureTarget = SampleCount == TextureSampleCount.Count1 ? TextureTarget.Texture2D : TextureTarget.Texture2DMultisample;
                }
                else
                {
                    TextureTarget = SampleCount == TextureSampleCount.Count1 ? TextureTarget.Texture2DArray : TextureTarget.Texture2DMultisampleArray;
                }
            }
            else
            {
                Debug.Assert(Type == TextureType.Texture3D);
                TextureTarget = TextureTarget.Texture3D;
            }

            Created = true;
        }

        public override uint Width { get; }

        public override uint Height { get; }

        public override uint Depth { get; }

        public override PixelFormat Format { get; }

        public override uint MipLevels { get; }

        public override uint ArrayLayers { get; }

        public override TextureUsage Usage { get; }

        public override TextureType Type { get; }

        public override TextureSampleCount SampleCount { get; }

        public override bool IsDisposed => _disposeRequested;

        public GLPixelFormat GLPixelFormat { get; }
        public GLPixelType GLPixelType { get; }
        public PixelInternalFormat GLInternalFormat { get; }
        public TextureTarget TextureTarget { get; internal set; }

        public bool Created { get; private set; }

        public void EnsureResourcesCreated()
        {
            if (!Created)
            {
                CreateGLResources();
            }
            if (_nameChanged)
            {
                _nameChanged = false;
                if (_gd.Extensions.KHR_Debug)
                {
                    SetObjectLabel(ObjectLabelIdentifier.Texture, _texture, _name);
                }
            }
        }

        private void CreateGLResources()
        {
            bool dsa = _gd.Extensions.ARB_DirectStateAccess;
            if (dsa)
            {
                uint[] texture = new uint[1];
                Internal.OpenGL.CreateTextures(TextureTarget, 1, texture);
                CheckLastError();
                _texture = texture[0];
            }
            else
            {
                Internal.OpenGL.GenTextures(1, out _texture);
                CheckLastError();

                _gd.TextureSamplerManager.SetTextureTransient(TextureTarget, _texture);
                CheckLastError();
            }

            bool isDepthTex = (Usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil;

            if (TextureTarget == TextureTarget.Texture1D)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage1D(
                        _texture,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width);
                    CheckLastError();
                }
                else if (_gd.Extensions.TextureStorage)
                {
                    Internal.OpenGL.TexStorage1D(
                        TextureTarget.Texture1D,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width);
                    CheckLastError();
                }
                else
                {
                    uint levelWidth = Width;
                    for (int currentLevel = 0; currentLevel < MipLevels; currentLevel++)
                    {
                        // Set size, load empty data into texture
                        Internal.OpenGL.TexImage1D(
                            TextureTarget.Texture1D,
                            currentLevel,
                            GLInternalFormat,
                            levelWidth,
                            0, // border
                            GLPixelFormat,
                            GLPixelType,
                            IntPtr.Zero);
                        CheckLastError();

                        levelWidth = Math.Max(1, levelWidth / 2);
                    }
                }
            }
            else if (TextureTarget == TextureTarget.Texture2D || TextureTarget == TextureTarget.Texture1DArray)
            {
                uint heightOrArrayLayers = TextureTarget == TextureTarget.Texture2D ? Height : ArrayLayers;
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage2D(
                        _texture,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        heightOrArrayLayers);
                    CheckLastError();
                }
                else if (_gd.Extensions.TextureStorage)
                {
                    Internal.OpenGL.TexStorage2D(
                        TextureTarget,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        heightOrArrayLayers);
                    CheckLastError();
                }
                else
                {
                    uint levelWidth = Width;
                    uint levelHeight = heightOrArrayLayers;
                    for (int currentLevel = 0; currentLevel < MipLevels; currentLevel++)
                    {
                        // Set size, load empty data into texture
                        Internal.OpenGL.TexImage2D(
                            TextureTarget,
                            currentLevel,
                            GLInternalFormat,
                            levelWidth,
                            levelHeight,
                            0, // border
                            GLPixelFormat,
                            GLPixelType,
                            IntPtr.Zero);
                        CheckLastError();

                        levelWidth = Math.Max(1, levelWidth / 2);
                        if (TextureTarget == TextureTarget.Texture2D)
                        {
                            levelHeight = Math.Max(1, levelHeight / 2);
                        }
                    }
                }
            }
            else if (TextureTarget == TextureTarget.Texture2DArray)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage3D(
                        _texture,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        ArrayLayers);
                    CheckLastError();
                }
                else if (_gd.Extensions.TextureStorage)
                {
                    Internal.OpenGL.TexStorage3D(
                        TextureTarget.Texture2DArray,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        ArrayLayers);
                    CheckLastError();
                }
                else
                {
                    uint levelWidth = Width;
                    uint levelHeight = Height;
                    for (int currentLevel = 0; currentLevel < MipLevels; currentLevel++)
                    {
                        Internal.OpenGL.TexImage3D(
                            TextureTarget.Texture2DArray,
                            currentLevel,
                            GLInternalFormat,
                            levelWidth,
                            levelHeight,
                            ArrayLayers,
                            0, // border
                            GLPixelFormat,
                            GLPixelType,
                            IntPtr.Zero);
                        CheckLastError();

                        levelWidth = Math.Max(1, levelWidth / 2);
                        levelHeight = Math.Max(1, levelHeight / 2);
                    }
                }
            }
            else if (TextureTarget == TextureTarget.Texture2DMultisample)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage2DMultisample(
                        _texture,
                        FormatHelpers.GetSampleCountUInt32(SampleCount),
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        false);
                    CheckLastError();
                }
                else
                {
                    if (_gd.Extensions.TextureStorageMultisample)
                    {
                        Internal.OpenGL.TexStorage2DMultisample(
                            TextureTarget.Texture2DMultisample,
                            FormatHelpers.GetSampleCountUInt32(SampleCount),
                            OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                            Width,
                            Height,
                            false);
                        CheckLastError();
                    }
                    else
                    {
                        Internal.OpenGL.TexImage2DMultiSample(
                            TextureTarget.Texture2DMultisample,
                            FormatHelpers.GetSampleCountUInt32(SampleCount),
                            GLInternalFormat,
                            Width,
                            Height,
                            false);
                    }
                    CheckLastError();
                }
            }
            else if (TextureTarget == TextureTarget.Texture2DMultisampleArray)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage3DMultisample(
                        _texture,
                        FormatHelpers.GetSampleCountUInt32(SampleCount),
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        ArrayLayers,
                        false);
                    CheckLastError();
                }
                else
                {
                    if (_gd.Extensions.TextureStorageMultisample)
                    {
                        Internal.OpenGL.TexStorage3DMultisample(
                            TextureTarget.Texture2DMultisampleArray,
                            FormatHelpers.GetSampleCountUInt32(SampleCount),
                            OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                            Width,
                            Height,
                            ArrayLayers,
                            false);
                    }
                    else
                    {
                        Internal.OpenGL.TexImage3DMultisample(
                            TextureTarget.Texture2DMultisampleArray,
                            FormatHelpers.GetSampleCountUInt32(SampleCount),
                            GLInternalFormat,
                            Width,
                            Height,
                            ArrayLayers,
                            false);
                        CheckLastError();
                    }
                }
            }
            else if (TextureTarget == TextureTarget.TextureCubeMap)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage2D(
                        _texture,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height);
                    CheckLastError();
                }
                else if (_gd.Extensions.TextureStorage)
                {
                    Internal.OpenGL.TexStorage2D(
                        TextureTarget.TextureCubeMap,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height);
                    CheckLastError();
                }
                else
                {
                    uint levelWidth = Width;
                    uint levelHeight = Height;
                    for (int currentLevel = 0; currentLevel < MipLevels; currentLevel++)
                    {
                        for (int face = 0; face < 6; face++)
                        {
                            // Set size, load empty data into texture
                            Internal.OpenGL.TexImage2D(
                                TextureTarget.TextureCubeMapPositiveX + face,
                                currentLevel,
                                GLInternalFormat,
                                levelWidth,
                                levelHeight,
                                0, // border
                                GLPixelFormat,
                                GLPixelType,
                                IntPtr.Zero);
                            CheckLastError();
                        }

                        levelWidth = Math.Max(1, levelWidth / 2);
                        levelHeight = Math.Max(1, levelHeight / 2);
                    }
                }
            }
            else if (TextureTarget == TextureTarget.TextureCubeMapArray)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage3D(
                        _texture,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        ArrayLayers * 6);
                    CheckLastError();
                }
                else if (_gd.Extensions.TextureStorage)
                {
                    Internal.OpenGL.TexStorage3D(
                        TextureTarget.TextureCubeMapArray,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        ArrayLayers * 6);
                    CheckLastError();
                }
                else
                {
                    uint levelWidth = Width;
                    uint levelHeight = Height;
                    for (int currentLevel = 0; currentLevel < MipLevels; currentLevel++)
                    {
                        for (int face = 0; face < 6; face++)
                        {
                            // Set size, load empty data into texture
                            Internal.OpenGL.TexImage3D(
                                TextureTarget.Texture2DArray,
                                currentLevel,
                                GLInternalFormat,
                                levelWidth,
                                levelHeight,
                                ArrayLayers * 6,
                                0, // border
                                GLPixelFormat,
                                GLPixelType,
                                IntPtr.Zero);
                            CheckLastError();
                        }

                        levelWidth = Math.Max(1, levelWidth / 2);
                        levelHeight = Math.Max(1, levelHeight / 2);
                    }
                }
            }
            else if (TextureTarget == TextureTarget.Texture3D)
            {
                if (dsa)
                {
                    Internal.OpenGL.TextureStorage3D(
                        _texture,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        Depth);
                    CheckLastError();
                }
                else if (_gd.Extensions.TextureStorage)
                {
                    Internal.OpenGL.TexStorage3D(
                        TextureTarget.Texture3D,
                        MipLevels,
                        OpenGLFormats.VdToGLSizedInternalFormat(Format, isDepthTex),
                        Width,
                        Height,
                        Depth);
                    CheckLastError();
                }
                else
                {
                    uint levelWidth = Width;
                    uint levelHeight = Height;
                    uint levelDepth = Depth;
                    for (int currentLevel = 0; currentLevel < MipLevels; currentLevel++)
                    {
                        for (int face = 0; face < 6; face++)
                        {
                            // Set size, load empty data into texture
                            Internal.OpenGL.TexImage3D(
                                TextureTarget.Texture3D,
                                currentLevel,
                                GLInternalFormat,
                                levelWidth,
                                levelHeight,
                                levelDepth,
                                0, // border
                                GLPixelFormat,
                                GLPixelType,
                                IntPtr.Zero);
                            CheckLastError();
                        }

                        levelWidth = Math.Max(1, levelWidth / 2);
                        levelHeight = Math.Max(1, levelHeight / 2);
                        levelDepth = Math.Max(1, levelDepth / 2);
                    }
                }
            }
            else
            {
                throw new VeldridException("Invalid texture target: " + TextureTarget);
            }

            Created = true;
        }

        public uint GetFramebuffer(uint mipLevel, uint arrayLayer)
        {
            Debug.Assert(!FormatHelpers.IsCompressedFormat(Format));
            Debug.Assert(Created);

            uint subresource = CalculateSubresource(mipLevel, arrayLayer);
            if (_framebuffers[subresource] == 0)
            {
                FramebufferTarget framebufferTarget = SampleCount == TextureSampleCount.Count1
                    ? FramebufferTarget.DrawFramebuffer
                    : FramebufferTarget.ReadFramebuffer;

                Internal.OpenGL.GenFramebuffers(1, out _framebuffers[subresource]);
                CheckLastError();

                Internal.OpenGL.BindFramebuffer(framebufferTarget, _framebuffers[subresource]);
                CheckLastError();

                _gd.TextureSamplerManager.SetTextureTransient(TextureTarget, Texture);

                if (TextureTarget == TextureTarget.Texture2D || TextureTarget == TextureTarget.Texture2DMultisample)
                {
                    Internal.OpenGL.FramebufferTexture2D(
                        framebufferTarget,
                        GLFramebufferAttachment.ColorAttachment0,
                        TextureTarget,
                        Texture,
                        (int)mipLevel);
                    CheckLastError();
                }
                else if (TextureTarget == TextureTarget.Texture2DArray
                    || TextureTarget == TextureTarget.Texture2DMultisampleArray
                    || TextureTarget == TextureTarget.Texture3D)
                {
                    Internal.OpenGL.FramebufferTextureLayer(
                        framebufferTarget,
                        GLFramebufferAttachment.ColorAttachment0,
                        Texture,
                        (int)mipLevel,
                        (int)arrayLayer);
                    CheckLastError();
                }

                FramebufferErrorCode errorCode = Internal.OpenGL.CheckFramebufferStatus(framebufferTarget);
                if (errorCode != FramebufferErrorCode.FramebufferComplete)
                {
                    throw new VeldridException("Failed to create texture copy FBO: " + errorCode);
                }
            }

            return _framebuffers[subresource];
        }

        public uint GetPixelBuffer(uint subresource)
        {
            Debug.Assert(Created);
            if (_pbos[subresource] == 0)
            {
                Internal.OpenGL.GenBuffers(1, out _pbos[subresource]);
                CheckLastError();

                Internal.OpenGL.BindBuffer(BufferTarget.CopyWriteBuffer, _pbos[subresource]);
                CheckLastError();

                uint dataSize = Width * Height * FormatSizeHelpers.GetSizeInBytes(Format);
                Internal.OpenGL.BufferData(
                    BufferTarget.CopyWriteBuffer,
                    (UIntPtr)dataSize,
                    IntPtr.Zero,
                    BufferUsageHint.StaticCopy);
                CheckLastError();
                _pboSizes[subresource] = dataSize;
            }

            return _pbos[subresource];
        }

        public uint GetPixelBufferSize(uint subresource)
        {
            Debug.Assert(Created);
            Debug.Assert(_pbos[subresource] != 0);
            return _pboSizes[subresource];
        }

        private protected override void DisposeCore()
        {
            if (!_disposeRequested)
            {
                _disposeRequested = true;
                _gd.EnqueueDisposal(this);
            }
        }

        public void DestroyGLResources()
        {
            if (!_disposed)
            {
                _disposed = true;

                Internal.OpenGL.DeleteTextures(1, ref _texture);
                CheckLastError();

                for (int i = 0; i < _framebuffers.Length; i++)
                {
                    if (_framebuffers[i] != 0)
                    {
                        Internal.OpenGL.DeleteFramebuffers(1, ref _framebuffers[i]);
                    }
                }

                for (int i = 0; i < _pbos.Length; i++)
                {
                    if (_pbos[i] != 0)
                    {
                        Internal.OpenGL.DeleteBuffers(1, ref _pbos[i]);
                    }
                }
            }
        }
    }
}
