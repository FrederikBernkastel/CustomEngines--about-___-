﻿namespace FrederikaStudio.OpenGL;

/// <summary>
/// A utility class managing the relationships between textures, samplers, and their binding locations.
/// </summary>
internal unsafe class OpenGLTextureSamplerManager
{
    private readonly int _maxTextureUnits;
    private readonly uint _lastTextureUnit;
    private readonly OpenGLTextureView[] _textureUnitTextures;
    private readonly BoundSamplerStateInfo[] _textureUnitSamplers;
    private uint _currentActiveUnit = 0;

    public OpenGLTextureSamplerManager()
    {
        int maxTextureUnits;
        glGetIntegerv(GetPName.MaxCombinedTextureImageUnits, &maxTextureUnits);
        _maxTextureUnits = Math.Max(maxTextureUnits, 8); // OpenGL spec indicates that implementations must support at least 8.
        _textureUnitTextures = new OpenGLTextureView[_maxTextureUnits];
        _textureUnitSamplers = new BoundSamplerStateInfo[_maxTextureUnits];

        _lastTextureUnit = (uint)(_maxTextureUnits - 1);
    }

    public void SetTexture(uint textureUnit, OpenGLTextureView textureView)
    {
        uint textureID = textureView.GLTargetTexture;

        if (_textureUnitTextures[textureUnit] != textureView)
        {
            glBindTextureUnit(textureUnit, textureID);
            EnsureSamplerMipmapState(textureUnit, textureView.MipLevels > 1);
            _textureUnitTextures[textureUnit] = textureView;
        }
    }

    public void SetTextureTransient(TextureTarget target, uint texture)
    {
        _textureUnitTextures[_lastTextureUnit] = null;
        SetActiveTextureUnit(_lastTextureUnit);
        glBindTexture(target, texture);
    }

    public void SetSampler(uint textureUnit, OpenGLSampler sampler)
    {
        if (_textureUnitSamplers[textureUnit].Sampler != sampler)
        {
            bool mipmapped = false;
            OpenGLTextureView texBinding = _textureUnitTextures[textureUnit];
            if (texBinding != null)
            {
                mipmapped = texBinding.MipLevels > 1;
            }

            uint samplerID = mipmapped ? sampler.MipmapSampler : sampler.NoMipmapSampler;
            glBindSampler(textureUnit, samplerID);
            CheckLastError();

            _textureUnitSamplers[textureUnit] = new BoundSamplerStateInfo(sampler, mipmapped);
        }
        else if (_textureUnitTextures[textureUnit] != null)
        {
            EnsureSamplerMipmapState(textureUnit, _textureUnitTextures[textureUnit].MipLevels > 1);
        }
    }

    private void SetActiveTextureUnit(uint textureUnit)
    {
        if (_currentActiveUnit != textureUnit)
        {
            glActiveTexture(TextureUnit.Texture0 + (int)textureUnit);
            CheckLastError();
            _currentActiveUnit = textureUnit;
        }
    }

    private void EnsureSamplerMipmapState(uint textureUnit, bool mipmapped)
    {
        if (_textureUnitSamplers[textureUnit].Sampler != null && _textureUnitSamplers[textureUnit].Mipmapped != mipmapped)
        {
            OpenGLSampler sampler = _textureUnitSamplers[textureUnit].Sampler;
            uint samplerID = mipmapped ? sampler.MipmapSampler : sampler.NoMipmapSampler;
            glBindSampler(textureUnit, samplerID);

            _textureUnitSamplers[textureUnit].Mipmapped = mipmapped;
        }
    }

    private struct BoundSamplerStateInfo
    {
        public OpenGLSampler Sampler;
        public bool Mipmapped;

        public BoundSamplerStateInfo(OpenGLSampler sampler, bool mipmapped)
        {
            Sampler = sampler;
            Mipmapped = mipmapped;
        }
    }
}
