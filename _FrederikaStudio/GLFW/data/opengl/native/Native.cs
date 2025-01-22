namespace FrederikaStudio.OpenGL;

internal interface IOpenGL_4_5
{
    public static IOpenGL_4_5 OpenGL_4_5 => LibLoader.Load<IOpenGL_4_5>(
        new(wglGetProcAddress, u => "gl" + u),
        new(@"D:\code\FrederikaStudio\resources\lib\opengl_native.dll", u => "gl" + u), false);

    [DllImport(@"D:\code\FrederikaStudio\resources\lib\opengl_native.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
    private static extern IntPtr wglGetProcAddress(string name);

    //public void ClearColor(float red, float green, float blue, float alpha);
    //public void Clear(NativeEnumOpenGL.ClearBufferMask mask);
    //public void Viewport(int x, int y, uint width, uint height);
    //public void GenBuffers(uint size, ref uint buffers);
    //public void BindBuffer(NativeEnumOpenGL.BufferTarget target, uint buffer);
    //public void BufferData(NativeEnumOpenGL.BufferTarget target, uint size, IntPtr data, NativeEnumOpenGL.BufferUsage usage);
    //public uint CreateShader(NativeEnumOpenGL.ShaderType shaderType);
    //public void ShaderSource(uint shader, uint count, string[] source, IntPtr length);
    //public void CompileShader(uint shader);
    //public void GetShaderiv(uint shader, NativeEnumOpenGL.ShaderParameter pname, ref int _params);
    //public void GetShaderInfoLog(uint shader, uint maxLength, IntPtr length, char[] infoLog);
    //public uint CreateProgram();
    //public void AttachShader(uint program, uint shader);
    //public void LinkProgram(uint program);
    //public void GetProgramiv(uint program, NativeEnumOpenGL.ProgramParameter pname, ref int _params);
    //public void GetProgramInfoLog(uint program, uint maxLength, IntPtr length, string infoLog);
    //public void UseProgram(uint program);
    //public void DeleteShader(uint shader);
    //public void VertexAttribPointer(uint index, int size, NativeEnumOpenGL.ElementaryType type, bool normalized, uint stride, IntPtr pointer);
    //public void EnableVertexAttribArray(uint index);
    //public void GenVertexArrays(uint size, ref uint arrays); // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //public void BindVertexArray(uint array);
    //public void DrawArrays(NativeEnumOpenGL.PrimitiveType mode, int first, uint count);
    //public void DrawElements(NativeEnumOpenGL.PrimitiveType mode, uint count, NativeEnumOpenGL.ElementaryType type, IntPtr indices);
    //public void PolygonMode(NativeEnumOpenGL.PolygonModeFacePrameter face, NativeEnumOpenGL.PolygonMode mode);

    //////////////////////////////////////////////////////
    //public void TexParameterf(NativeEnumOpenGL.TexParameterTarget target, NativeEnumOpenGL.SamplerParameterName pname, float param);
    //public void TexParameteri(NativeEnumOpenGL.TexParameterTarget target, NativeEnumOpenGL.SamplerParameterName pname, int param);
    //public void TextureParameterf(uint texture, NativeEnumOpenGL.SamplerParameterName pname, float param);
    //public void TextureParameteri(uint texture, NativeEnumOpenGL.SamplerParameterName pname, int param);
    //public void TexParameterfv(NativeEnumOpenGL.TexParameterTarget target, NativeEnumOpenGL.SamplerParameterName pname, float[] _params);
    //public void TexParameteriv(NativeEnumOpenGL.TexParameterTarget target, NativeEnumOpenGL.SamplerParameterName pname, int[] _params);
    //public void TexParameterIiv(NativeEnumOpenGL.TexParameterTarget target, NativeEnumOpenGL.SamplerParameterName pname, int[] _params);
    //public void TexParameterIuiv(NativeEnumOpenGL.TexParameterTarget target, NativeEnumOpenGL.SamplerParameterName pname, uint[] _params);
    //public void TextureParameterfv(uint texture, NativeEnumOpenGL.SamplerParameterName pname, float[] _params);
    //public void TextureParameteriv(uint texture, NativeEnumOpenGL.SamplerParameterName pname, int[] _params);
    //public void TextureParameterIiv(uint texture, NativeEnumOpenGL.SamplerParameterName pname, int[] _params);
    //public void TextureParameterIuiv(uint texture, NativeEnumOpenGL.SamplerParameterName pname, uint[] _params);
    //////////////////////////////////////////////////////

    //public void GenTextures(uint size, ref uint textures);
    //public void BindTexture(NativeEnumOpenGL.BindTextureTarget target, uint texture);
    //public void TexImage2D(
    //    NativeEnumOpenGL.TexImage2DTarget target, 
    //    int level, 
    //    NativeEnumOpenGL.PixelInternalFormat internalFormat, 
    //    uint width, uint height, 
    //    int border, 
    //    NativeEnumOpenGL.TexImage2DFormat format, 
    //    NativeEnumOpenGL.PixelType type, 
    //    IntPtr data);
    //public void GenerateMipmap(NativeEnumOpenGL.GenerateMipmapTarget target);
    //public void ActiveTexture(NativeEnumOpenGL.TextureUnit texture);
    //public int GetUniformLocation(uint program, string name);

    //////////////////////////////////////////////////////
    //public void Uniform1i(int location, int v0);
    //public void Uniform2i(int location, int v0, int v1);
    //public void Uniform3i(int location, int v0, int v1, int v2);
    //public void Uniform4i(int location, int v0, int v1, int v2, int v3);
    //public void Uniform1f(int location, float v0);
    //public void Uniform2f(int location, float v0, float v1);
    //public void Uniform3f(int location, float v0, float v1, float v2);
    //public void Uniform4f(int location, float v0, float v1, float v2, float v3);
    //public void UniformMatrix2fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix3fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix4fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix2x3fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix3x2fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix2x4fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix4x2fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix3x4fv(int location, uint count, bool transpose, float[] value);
    //public void UniformMatrix4x3fv(int location, uint count, bool transpose, float[] value);
    //////////////////////////////////////////////////////

    //////////////////////////////////////////////////////
    //public void GetIntegerv(NativeEnumOpenGL.GetValueInt pname, ref int data);
    //public void GetBooleanv(NativeEnumOpenGL.GetValueBool pname, ref bool data);
    //public void GetDoublev(NativeEnumOpenGL.GetValueDouble pname, ref double data);
    //public void GetFloatv(NativeEnumOpenGL.GetValueFloat pname, ref float data);
    //public void GetInteger64v(NativeEnumOpenGL.GetValueLong pname, ref long data);
    //////////////////////////////////////////////////////

    //public void Enable(NativeEnumOpenGL.EnableCap cap);
    //public void Disable(NativeEnumOpenGL.EnableCap cap);
    //public void DepthMask(bool flag);
    //public void DepthFunc(NativeEnumOpenGL.DepthStencilFunction func);
    //public void StencilMask(uint mask);
    //public void StencilFunc(NativeEnumOpenGL.DepthStencilFunction func, int _ref, uint mask);
    //public void StencilOp(NativeEnumOpenGL.StencilOp sfail, NativeEnumOpenGL.StencilOp dpfail, NativeEnumOpenGL.StencilOp dppass);
    //public void BlendFunc(NativeEnumOpenGL.BlendingFactor sfactor, NativeEnumOpenGL.BlendingFactor dfactor);
    //public void BlendFuncSeparate(NativeEnumOpenGL.BlendingFactor srcRGB, NativeEnumOpenGL.BlendingFactor dstRGB, NativeEnumOpenGL.BlendingFactor srcAlpha, NativeEnumOpenGL.BlendingFactor dstAlpha);
    //public void BlendEquation(NativeEnumOpenGL.BlendEquationMode mode);
    //public void CullFace(NativeEnumOpenGL.CullFaceMode mode);
    //public void FrontFace(NativeEnumOpenGL.FrontFaceDirection mode);
    //public void GenFramebuffers(uint size, ref uint ids);
    //public void BindFramebuffer(NativeEnumOpenGL.FramebufferTarget target, uint framebuffer);
    //public NativeEnumOpenGL.FramebufferErrorCode CheckFramebufferStatus(NativeEnumOpenGL.FramebufferTarget target);
    //public void DeleteFramebuffers(uint size, ref uint framebuffers);


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void GenVertexArrays(uint n, out uint arrays);
    public uint GetError();
    public void BindVertexArray(uint array);
    public void ClearColor(float red, float green, float blue, float alpha);
    public void DrawBuffer(DrawBufferMode mode);
    public void DrawBuffers(uint n, ref DrawBuffersEnum bufs);
    public void Clear(ClearBufferMask mask);
    public void ClearDepth(double depth);
    public void ClearDepthf(float depth);
    public void ClearDepth_Compat(float depth);
    public void DrawElements(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices);
    public void DrawElementsBaseVertex(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices, int basevertex);
    public void DrawElementsInstanced(
        PrimitiveType mode,
        uint count,
        DrawElementsType type,
        IntPtr indices,
        uint primcount);
    public void DrawElementsInstancedBaseVertex(
        PrimitiveType mode,
        uint count,
        DrawElementsType type,
        IntPtr indices,
        uint primcount,
        int basevertex);
    public void DrawElementsInstancedBaseVertexBaseInstance(
        PrimitiveType mode,
        uint count,
        DrawElementsType type,
        IntPtr indices,
        uint primcount,
        int basevertex,
        uint baseinstance);
    public void DrawArrays(PrimitiveType mode, int first, uint count);
    public void DrawArraysInstanced(PrimitiveType mode, int first, uint count, uint primcount);
    public void DrawArraysInstancedBaseInstance(
        PrimitiveType mode,
        int first,
        uint count,
        uint primcount,
        uint baseinstance);
    public void GenBuffers(uint n, out uint buffers);
    public void DeleteBuffers(uint n, ref uint buffers);
    public void GenFramebuffers(uint n, out uint ids);
    public void ActiveTexture(TextureUnit texture);
    public void FramebufferTexture1D(
        FramebufferTarget target,
        GLFramebufferAttachment attachment,
        TextureTarget textarget,
        uint texture,
        int level);
    public void FramebufferTexture2D(
        FramebufferTarget target,
        GLFramebufferAttachment attachment,
        TextureTarget textarget,
        uint texture,
        int level);
    public void BindTexture(TextureTarget target, uint texture);
    public void BindFramebuffer(FramebufferTarget target, uint framebuffer);
    public void DeleteFramebuffers(uint n, ref uint framebuffers);
    public void GenTextures(uint n, out uint textures);
    public void DeleteTextures(uint n, ref uint textures);
    public FramebufferErrorCode CheckFramebufferStatus(FramebufferTarget target);
    public void BindBuffer(BufferTarget target, uint buffer);
    public void ViewportIndexed(uint index, float x, float y, float w, float h);
    public void Viewport(int x, int y, uint width, uint height);
    public void DepthRangeIndexed(uint index, double nearVal, double farVal);
    public void DepthRangef(float n, float f);
    public void BufferSubData(BufferTarget target, IntPtr offset, UIntPtr size, IntPtr data);
    public void NamedBufferSubData(uint buffer, IntPtr offset, uint size, IntPtr data);
    public void ScissorIndexed(uint index, int left, int bottom, uint width, uint height);
    public void Scissor(int x, int y, uint width, uint height);
    public void PixelStorei(PixelStoreParameter pname, int param);
    public void TexSubImage1D(
        TextureTarget target,
        int level,
        int xoffset,
        uint width,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr pixels);
    public void TexSubImage2D(
        TextureTarget target,
        int level,
        int xoffset,
        int yoffset,
        uint width,
        uint height,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr pixels);
    public void TexSubImage3D(
        TextureTarget target,
        int level,
        int xoffset,
        int yoffset,
        int zoffset,
        uint width,
        uint height,
        uint depth,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr pixels);
    public void ShaderSource(uint shader, uint count, byte[][] @string, ref int length);
    public uint CreateShader(ShaderType shaderType);
    public void CompileShader(uint shader);
    public void GetShaderiv(uint shader, ShaderParameter pname, int[] @params);
    public void GetShaderInfoLog(uint shader, uint maxLength, ref uint length, byte[] infoLog);
    public void DeleteShader(uint shader);
    public void GenSamplers(uint n, out uint samplers);
    public void SamplerParameterf(uint sampler, SamplerParameterName pname, float param);
    public void SamplerParameteri(uint sampler, SamplerParameterName pname, int param);
    public void SamplerParameterfv(uint sampler, SamplerParameterName pname, float[] @params);
    public void BindSampler(uint unit, uint sampler);
    public void DeleteSamplers(uint n, ref uint samplers);
    public void ColorMask(
        bool red,
        bool green,
        bool blue,
        bool alpha);
    public void ColorMaski(
        uint buf,
        bool red,
        bool green,
        bool blue,
        bool alpha);
    public void BlendFuncSeparatei(
        uint buf,
        BlendingFactorSrc srcRGB,
        BlendingFactorDest dstRGB,
        BlendingFactorSrc srcAlpha,
        BlendingFactorDest dstAlpha);
    public void BlendFuncSeparate(
        BlendingFactorSrc srcRGB,
        BlendingFactorDest dstRGB,
        BlendingFactorSrc srcAlpha,
        BlendingFactorDest dstAlpha);
    public void Enable(EnableCap cap);
    public void Enablei(EnableCap cap, uint index);
    public void Disable(EnableCap cap);
    public void Disablei(EnableCap cap, uint index);
    public void BlendEquationSeparatei(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha);
    public void BlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha);
    public void BlendColor(float red, float green, float blue, float alpha);
    public void DepthFunc(DepthFunction func);
    public void DepthMask(bool flag);
    public void CullFace(CullFaceMode mode);
    public void PolygonMode(MaterialFace face, PolygonMode mode);
    public uint CreateProgram();
    public void AttachShader(uint program, uint shader);
    public void BindAttribLocation(uint program, uint index, byte[] name);
    public void LinkProgram(uint program);
    public void GetProgramiv(uint program, GetProgramParameterName pname, int[] @params);
    public void GetProgramInfoLog(uint program, uint maxLength, ref uint length, byte[] infoLog);
    public void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
    public void DeleteProgram(uint program);
    public void Uniform1i(int location, int v0);
    public uint GetUniformBlockIndex(uint program, byte[] uniformBlockName);
    public int GetUniformLocation(uint program, byte[] name);
    public int GetAttribLocation(uint program, byte[] name);
    public void UseProgram(uint program);
    public void BindBufferRange(
        BufferRangeTarget target,
        uint index,
        uint buffer,
        IntPtr offset,
        UIntPtr size);
    public void DebugMessageCallback(DebugProc callback, IntPtr userParam);
    public void BufferData(BufferTarget target, UIntPtr size, IntPtr data, BufferUsageHint usage);
    public void NamedBufferData(uint buffer, uint size, IntPtr data, BufferUsageHint usage);
    public void TexImage1D(
        TextureTarget target,
        int level,
        PixelInternalFormat internalFormat,
        uint width,
        int border,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr data);
    public void TexImage2D(
        TextureTarget target,
        int level,
        PixelInternalFormat internalFormat,
        uint width,
        uint height,
        int border,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr data);
    public void TexImage3D(
        TextureTarget target,
        int level,
        PixelInternalFormat internalFormat,
        uint width,
        uint height,
        uint depth,
        int border,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr data);
    public void EnableVertexAttribArray(uint index);
    public void DisableVertexAttribArray(uint index);
    public void VertexAttribPointer(
        uint index,
        int size,
        VertexAttribPointerType type,
        bool normalized,
        uint stride,
        IntPtr pointer);
    public void VertexAttribIPointer(
        uint index,
        int size,
        VertexAttribPointerType type,
        uint stride,
        IntPtr pointer);
    public void VertexAttribDivisor(uint index, uint divisor);
    public void FrontFace(FrontFaceDirection mode);
    public void GetIntegerv(GetPName pname, ref int data);
    public void BindTextureUnit(uint unit, uint texture);
    public void TexParameteri(TextureTarget target, TextureParameterName pname, int param);
    public byte[] GetString(StringName name);
    public byte[] GetStringi(StringNameIndexed name, uint index);
    public void ObjectLabel(ObjectLabelIdentifier identifier, uint name, uint length, SCU.PointerStringAnsi label);
    public void TexImage2DMultiSample(
        TextureTarget target,
        uint samples,
        PixelInternalFormat internalformat,
        uint width,
        uint height,
        bool fixedsamplelocations);
    public void TexImage3DMultisample(
        TextureTarget target,
        uint samples,
        PixelInternalFormat internalformat,
        uint width,
        uint height,
        uint depth,
        bool fixedsamplelocations);
    public void BlitFramebuffer(
        int srcX0,
        int srcY0,
        int srcX1,
        int srcY1,
        int dstX0,
        int dstY0,
        int dstX1,
        int dstY1,
        ClearBufferMask mask,
        BlitFramebufferFilter filter);
    public void FramebufferTextureLayer(
        FramebufferTarget target,
        GLFramebufferAttachment attachment,
        uint texture,
        int level,
        int layer);
    public void DispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);
    public uint GetProgramResourceIndex(uint program, ProgramInterface programInterface, byte[] name);
    public void ShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding);
    public void DrawElementsIndirect(PrimitiveType mode, DrawElementsType type, IntPtr indirect);
    public void MultiDrawElementsIndirect(
        PrimitiveType mode,
        DrawElementsType type,
        IntPtr indirect,
        uint drawcount,
        uint stride);
    public void DrawArraysIndirect(PrimitiveType mode, IntPtr indirect);
    public void MultiDrawArraysIndirect(PrimitiveType mode, IntPtr indirect, uint drawcount, uint stride);
    public void DispatchComputeIndirect(IntPtr indirect);
    public void BindImageTexture(
        uint unit​,
        uint texture​,
        int level​,
        bool layered​,
        int layer​,
        TextureAccess access​,
        SizedInternalFormat format​);
    public void MemoryBarrier(MemoryBarrierFlags barriers);
    public void TexStorage1D(TextureTarget target, uint levels, SizedInternalFormat internalformat, uint width);
    public void TexStorage2D(
        TextureTarget target,
        uint levels,
        SizedInternalFormat internalformat,
        uint width,
        uint height);
    public void TexStorage3D(
        TextureTarget target,
        uint levels,
        SizedInternalFormat internalformat,
        uint width,
        uint height,
        uint depth);
    public void TextureStorage1D(uint texture, uint levels, SizedInternalFormat internalformat, uint width);
    public void TextureStorage2D(
        uint texture,
        uint levels,
        SizedInternalFormat internalformat,
        uint width,
        uint height);
    public void TextureStorage3D(
        uint texture,
        uint levels,
        SizedInternalFormat internalformat,
        uint width,
        uint height,
        uint depth);
    public void TextureStorage2DMultisample(
        uint texture,
        uint samples,
        SizedInternalFormat internalformat,
        uint width,
        uint height,
        bool fixedsamplelocations);
    public void TextureStorage3DMultisample(
        uint texture,
        uint samples,
        SizedInternalFormat internalformat,
        uint width,
        uint height,
        uint depth,
        bool fixedsamplelocations);
    public void TexStorage2DMultisample(
        TextureTarget target,
        uint samples,
        SizedInternalFormat internalformat,
        uint width,
        uint height,
        bool fixedsamplelocations);
    public void TexStorage3DMultisample(
        TextureTarget target,
        uint samples,
        SizedInternalFormat internalformat,
        uint width,
        uint height,
        uint depth,
        bool fixedsamplelocations);
    public void TextureView(
        uint texture,
        TextureTarget target,
        uint origtexture,
        PixelInternalFormat internalformat,
        uint minlevel,
        uint numlevels,
        uint minlayer,
        uint numlayers);
    public IntPtr MapBuffer(BufferTarget target, BufferAccess access);
    public IntPtr MapNamedBuffer(uint buffer, BufferAccess access);
    public bool UnmapBuffer(BufferTarget target);
    public bool UnmapNamedBuffer(uint buffer);
    public void CopyBufferSubData(
        BufferTarget readTarget,
        BufferTarget writeTarget,
        IntPtr readOffset,
        IntPtr writeOffset,
        IntPtr size);
    public void CopyTexSubImage2D(
        TextureTarget target,
        int level,
        int xoffset,
        int yoffset,
        int x,
        int y,
        uint width,
        uint height);
    public void CopyTexSubImage3D(
        TextureTarget target,
        int level,
        int xoffset,
        int yoffset,
        int zoffset,
        int x,
        int y,
        uint width,
        uint height);
    public IntPtr MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length, BufferAccessMask access);
    public IntPtr MapNamedBufferRange(uint buffer, IntPtr offset, uint length, BufferAccessMask access);
    public void GetTexImage(TextureTarget target, int level, GLPixelFormat format, GLPixelType type, IntPtr pixels);
    public void GetTextureSubImage(
        uint texture,
        int level,
        int xoffset,
        int yoffset,
        int zoffset,
        uint width,
        uint height,
        uint depth,
        GLPixelFormat format,
        GLPixelType type,
        uint bufSize,
        IntPtr pixels);
    public void CopyNamedBufferSubData(
        uint readBuffer,
        uint writeBuffer,
        IntPtr readOffset,
        IntPtr writeOffset,
        uint size);
    public void CreateBuffers(uint n, uint[] buffers);
    public void CreateTextures(TextureTarget target, uint n, uint[] textures);
    public void CompressedTexSubImage1D(
        TextureTarget target,
        int level,
        int xoffset,
        uint width,
        PixelInternalFormat internalformat,
        uint imageSize,
        IntPtr data);
    public void CompressedTexSubImage2D(
        TextureTarget target,
        int level,
        int xoffset,
        int yoffset,
        uint width,
        uint height,
        PixelInternalFormat format,
        uint imageSize,
        IntPtr data);
    public void CompressedTexSubImage3D(
        TextureTarget target,
         int level,
         int xoffset,
         int yoffset,
         int zoffset,
         uint width,
         uint height,
         uint depth,
         PixelInternalFormat format,
         uint imageSize,
         IntPtr data);
    public void CopyImageSubData(
        uint srcName,
        TextureTarget srcTarget,
        int srcLevel,
        int srcX,
        int srcY,
        int srcZ,
        uint dstName,
        TextureTarget dstTarget,
        int dstLevel,
        int dstX,
        int dstY,
        int dstZ,
        uint srcWidth,
        uint srcHeight,
        uint srcDepth);
    public void StencilFuncSeparate(CullFaceMode face, StencilFunction func, int @ref, uint mask);
    public void StencilOpSeparate(
        CullFaceMode face,
        StencilOp sfail,
        StencilOp dpfail,
        StencilOp dppass);
    public void StencilMask(uint mask);
    public void ClearStencil(int s);
    public void GetActiveUniformBlockiv(
        uint program,
        uint uniformBlockIndex,
        ActiveUniformBlockParameter pname,
        int[] @params);
    public void GetActiveUniformBlockName(
        uint program,
        uint uniformBlockIndex,
        uint bufSize,
        ref uint length,
        byte[] uniformBlockName);
    public void GetActiveUniform(
        uint program,
        uint index,
        uint bufSize,
        ref uint length,
        ref int size,
        ref uint type,
        byte[] name);
    public void GetCompressedTexImage(TextureTarget target, int level, IntPtr pixels);
    public void GetCompressedTextureImage(uint texture, int level, uint bufSize, IntPtr pixels);
    public void GetTexLevelParameteriv(
        TextureTarget target,
        int level,
        GetTextureParameter pname,
        int[] @params);
    public void FramebufferRenderbuffer(
        FramebufferTarget target,
        GLFramebufferAttachment attachment,
        RenderbufferTarget renderbuffertarget,
        uint renderbuffer);
    public void RenderbufferStorage(
        RenderbufferTarget target,
        uint internalFormat,
        uint width,
        uint height);
    public void GetRenderbufferParameteriv(
        RenderbufferTarget target,
        RenderbufferPname pname,
        out int parameters);
    public void GenRenderbuffers(uint count, out uint names);
    public void BindRenderbuffer(RenderbufferTarget bindPoint, uint name);
    public void GenerateMipmap(TextureTarget target);
    public void GenerateTextureMipmap(uint texture);
    public void ClipControl(ClipControlOrigin origin, ClipControlDepthRange depth);
    public void GetFramebufferAttachmentParameteriv(
        FramebufferTarget target,
        GLFramebufferAttachment attachment,
        FramebufferParameterName pname,
        int[] @params);
    public void Flush();
    public void Finish();
    public void PushDebugGroup(DebugSource source, uint id, uint length, byte[] message);
    public void PopDebugGroup();
    public void DebugMessageInsert(
        DebugSource source,
        DebugType type,
        uint id,
        DebugSeverity severity,
        uint length,
        byte[] message);
    public void InsertEventMarker(uint length, byte[] marker);
    public void PushGroupMarker(uint length, byte[] marker);
    public void PopGroupMarker();
    public void ReadPixels(
        int x,
        int y,
        uint width,
        uint height,
        GLPixelFormat format,
        GLPixelType type,
        IntPtr data);
}