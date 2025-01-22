namespace FrederikaStudio.OpenGL.Native;

public interface IOpenGL_4_5
{
    public static IOpenGL_4_5 CreateOpenGL_4_5(Func<string, IntPtr> getProcAddress) =>
        LibLoader.Load<IOpenGL_4_5>(getProcAddress, u => "gl" + u);

    ///////////////////////////////////////////////////////////////////// Debug

    public void DebugMessageCallback(DebugProc callback, IntPtr userParam);
    public void DebugMessageControl(
        DebugSource source, DebugType type, DebugSeverity severity, uint count, uint[] ids, bool enabled);
    public void DebugMessageInsert(
        DebugSource source, DebugType type, uint id, DebugSeverity severity, uint length, byte[] message);
    public void GetDebugMessageLog(
        uint count, uint bufSize, DebugSource[] sources, DebugType[] types, uint[] ids, DebugSeverity[] severities, uint[] lengths, byte[] messageLog);
    public void GetObjectLabel(ObjectLabelIdentifier identifier, uint name, uint bifSize, out uint length, byte[] label);
    public void GetObjectPtrLabel(IntPtr ptr, uint bifSize, out uint length, byte[] label);
    public void GetPointerv(int pname, out IntPtr @params); // pname
    public void GetProgramInterfaceiv(Program program, ProgramInterface programInterface, int pname, out int @params); // pname
    public void ObjectLabel(ObjectLabelIdentifier identifier, uint name, uint length, byte[] label);
    public void ObjectPtrLabel(IntPtr ptr, uint length, byte[] label);
    public void PopDebugGroup();
    public void PushDebugGroup(DebugSource source, uint id, uint length, byte[] message);

    ///////////////////////////////////////////////////////////////////// Debug
    ///////////////////////////////////////////////////////////////////// Shaders

    public void UseProgram(Program program);
    public void LinkProgram(Program program);
    public Program CreateProgram();
    public void AttachShader(Program program, uint shader);
    public void ShaderSource(Shader shader, uint count, byte[][] @string, int[] length);
    public Shader CreateShader(ShaderType shaderType);
    public void CompileShader(Shader shader);
    public void GetShaderiv(Shader shader, ShaderParameter pname, out int @params);
    public void GetShaderInfoLog(Shader shader, uint maxLength, out uint length, byte[] infoLog);
    public void DeleteShader(Shader shader);
    public void BindAttribLocation(Program program, uint index, byte[] name);
    public void BindFragDataLocation(Program program, uint colorNumber, byte[] name);
    public void BindFragDataLocationIndexed(Program program, uint colorNumber, uint index, byte[] name);
    public Program CreateShaderProgramv(ShaderType shaderType, uint count, byte[][] strings);
    public void DeleteProgram(Program program);
    public void GetActiveAtomicCounterBufferiv(Program program, uint bufferIndex, int pname, out int @params); // pname
    public void GetActiveAttrib(Program program, uint index, uint bufSize, out uint length, out int size, out int type, byte[] name); // type
    public void GetActiveSubroutineName(Program program, ShaderType shaderType, uint index, uint bufsize, out uint length, byte[] name);
    public void GetActiveSubroutineUniformiv(
        Program program, ShaderType shadertype, uint index, int pname, out int values); // pname
    public void GetActiveSubroutineUniformName(
        Program program, ShaderType shadertype, uint index, uint bufsize, out uint length, byte[] name);
    public void GetActiveUniform(Program program, uint index, uint bufSize, out uint length, out int size, out int type, byte[] name); // type
    public void GetActiveUniformBlockiv(Program program, uint uniformBlockIndex, ActiveUniformBlockParameter pname, out int @params);
    public void GetActiveUniformBlockName(Program program, uint uniformBlockIndex, uint bufSize, out uint length, byte[] uniformBlockName);
    public void GetActiveUniformName(Program program, uint uniformIndex, uint bufSize, out uint length, byte[] uniformName);
    public void GetActiveUniformsiv(Program program, uint uniformCount, uint[] uniformIndices, int pname, int[] @params); // pname
    public void GetAttachedShaders(Program program, uint maxCount, out uint count, uint[] shaders);
    public int GetAttribLocation(Program program, byte[] name);
    public int GetFragDataIndex(Program program, byte[] name);
    public int GetFragDataLocation(Program program, byte[] name);
    public void GetProgramiv(Program program, GetProgramParameterName pname, out int @params);
    public void GetProgramBinary(Program program, uint bufsize, out uint length, out int binaryFormat, IntPtr binary); // binaryFormat
    public void GetProgramInfoLog(Program program, uint maxLength, out uint length, byte[] infoLog);
    public void GetProgramResourceiv(
        Program program, ProgramInterface programInterface, uint index, uint propCount, int[] props, uint bufSize, out uint length, int[] @params); // props
    public uint GetProgramResourceIndex(Program program, ProgramInterface programInterface, byte[] name);
    public int GetProgramResourceLocation(Program program, ProgramInterface programInterface, byte[] name);
    public int GetProgramResourceLocationIndex(Program program, ProgramInterface programInterface, byte[] name);
    public void GetProgramResourceName(Program program, ProgramInterface programInterface, uint index, uint bufSize, out uint length, byte[] name);
    public void GetProgramStageiv(Program program, ShaderType shadertype, int pname, out int values); // pname
    public void GetShaderPrecisionFormat(ShaderType shaderType, int precisionType, int[] range, out int precision); // precisionType
    public uint GetSubroutineIndex(Program program, ShaderType shadertype, byte[] name);
    public int GetSubroutineUniformLocation(Program program, ShaderType shadertype, byte[] name);
    public void GetUniformfv(Program program, int location, out float @params);
    public void GetUniformiv(Program program, int location, out int @params);
    public void GetUniformuiv(Program program, int location, out uint @params);
    public void GetUniformdv(Program program, int location, out double @params);
    public void GetnUniformfv(Program program, int location, float[] @params);
    public void GetnUniformiv(Program program, int location, int[] @params);
    public void GetnUniformuiv(Program program, int location, uint[] @params);
    public void GetnUniformdv(Program program, int location, double[] @params);
    public uint GetUniformBlockIndex(Program program, byte[] uniformBlockName);
    public void GetUniformIndices(Program program, uint uniformCount, byte[][] uniformNames, uint[] uniformIndices);
    public int GetUniformLocation(Program program, byte[] name);
    public void GetUniformSubroutineuiv(ShaderType shadertype, int location, out uint values);
    public void MinSampleShading(float value);
    public void ProgramBinary(Program program, int binaryFormat, IntPtr binary, uint length); // binaryFormat
    public void ProgramParameteri(Program program, int pname, int value); // pname
    public void ProgramUniform1f(Program program, int location, float v0);
    public void ProgramUniform2f(Program program, int location, float v0, float v1);
    public void ProgramUniform3f(Program program, int location, float v0, float v1, float v2);
    public void ProgramUniform4f(Program program, int location, float v0, float v1, float v2, float v3);
    public void ProgramUniform1i(Program program, int location, int v0);
    public void ProgramUniform2i(Program program, int location, int v0, int v1);
    public void ProgramUniform3i(Program program, int location, int v0, int v1, int v2);
    public void ProgramUniform4i(Program program, int location, int v0, int v1, int v2, int v3);
    public void ProgramUniform1ui(Program program, int location, uint v0);
    public void ProgramUniform2ui(Program program, int location, uint v0, uint v1);
    public void ProgramUniform3ui(Program program, int location, uint v0, uint v1, uint v2);
    public void ProgramUniform4ui(Program program, int location, uint v0, uint v1, uint v2, uint v3);
    public void ProgramUniform1fv(Program program, int location, uint count, float[] value);
    public void ProgramUniform2fv(Program program, int location, uint count, float[] value);
    public void ProgramUniform3fv(Program program, int location, uint count, float[] value);
    public void ProgramUniform4fv(Program program, int location, uint count, float[] value);
    public void ProgramUniform1iv(Program program, int location, uint count, int[] value);
    public void ProgramUniform2iv(Program program, int location, uint count, int[] value);
    public void ProgramUniform3iv(Program program, int location, uint count, int[] value);
    public void ProgramUniform4iv(Program program, int location, uint count, int[] value);
    public void ProgramUniform1uiv(Program program, int location, uint count, uint[] value);
    public void ProgramUniform2uiv(Program program, int location, uint count, uint[] value);
    public void ProgramUniform3uiv(Program program, int location, uint count, uint[] value);
    public void ProgramUniform4uiv(Program program, int location, uint count, uint[] value);
    public void ProgramUniformMatrix2fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix3fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix4fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix2x3fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix3x2fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix2x4fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix4x2fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix3x4fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ProgramUniformMatrix4x3fv(Program program, int location, uint count, bool transpose, float[] value);
    public void ReleaseShaderCompiler();
    public void ShaderStorageBlockBinding(Program program, uint storageBlockIndex, uint storageBlockBinding);
    public void UniformBlockBinding(Program program, uint uniformBlockIndex, uint uniformBlockBinding);
    public void UniformSubroutinesuiv(ShaderType shadertype, uint count, uint[] indices);
    public void ValidateProgram(Program program);

    ///////////////////////////////////////////////////////////////////// Shaders
    ///////////////////////////////////////////////////////////////////// Buffer Objects

    public void BindVertexArray(VAO vaobj);
    public void VertexArrayVertexBuffer(VAO vaobj, uint bindingindex, VBO buffer, IntPtr offset, uint stride);
    public void VertexArrayVertexBuffers(VAO vaobj, uint first, uint count, VBO[] buffers, IntPtr[] offsets, uint[] strides);
    public void NamedBufferData(VBO buffer, uint size, IntPtr data, BufferUsageHint usage);
    public void NamedBufferStorage(VBO buffer, uint size, IntPtr data, int flags); // flags
    public void NamedBufferSubData(VBO buffer, IntPtr offset, uint size, IntPtr data);
    public void ClearNamedBufferData(VBO buffer, int internalformat, int format, int type, IntPtr data); // internalformat || format || type
    public void ClearNamedBufferSubData(
        VBO buffer, int internalformat, IntPtr offset, UIntPtr size, int format, int type, IntPtr data); // internalformat || format || type
    public void CopyNamedBufferSubData(VBO readBuffer, VBO writeBuffer, IntPtr readOffset, IntPtr writeOffset, uint size);
    public void CreateBuffers(uint n, out VBO buffers);
    public void CreateVertexArrays(uint n, out VAO arrays);
    public void DeleteBuffers(uint n, ref VBO buffers);
    public void EnableVertexArrayAttrib(VAO vaobj, uint index);
    public void DisableVertexArrayAttrib(VAO vaobj, uint index);
    public void DrawBuffer(DrawBufferMode mode);
    public void DrawBuffers(uint n, DrawBuffersEnum[] bufs);
    public void DrawArrays(PrimitiveType mode, int first, uint count);
    public void DrawArraysIndirect(PrimitiveType mode, IntPtr indirect);
    public void DrawArraysInstanced(PrimitiveType mode, int first, uint count, uint primcount);
    public void DrawArraysInstancedBaseInstance(PrimitiveType mode, int first, uint count, uint primcount, uint baseinstance);
    public void DrawElements(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices);
    public void DrawElementsBaseVertex(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices, int basevertex);
    public void DrawElementsIndirect(PrimitiveType mode, DrawElementsType type, IntPtr indirect);
    public void DrawElementsInstanced(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices, uint primcount);
    public void DrawElementsInstancedBaseInstance(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices, uint primcount, uint baseinstance);
    public void DrawElementsInstancedBaseVertex(PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices, uint primcount, int basevertex);
    public void DrawElementsInstancedBaseVertexBaseInstance(
        PrimitiveType mode, uint count, DrawElementsType type, IntPtr indices, uint primcount, int basevertex, uint baseinstance);
    public void DrawRangeElements(PrimitiveType mode, uint start, uint end, uint count, DrawElementsType type, IntPtr indices);
    public void DrawRangeElementsBaseVertex(PrimitiveType mode, uint start, uint end, uint count, DrawElementsType type, IntPtr indices, int basevertex);
    public void FlushMappedNamedBufferRange(VBO buffer, IntPtr offset, uint length);
    public void GetNamedBufferParameteriv(VBO buffer, int pname, out uint @params); // pname
    public void GetNamedBufferPointerv(VBO buffer, int pname, out IntPtr @params); // pname
    public void GetNamedBufferSubData(VBO buffer, IntPtr offset, uint size, IntPtr data);
    public void GetVertexArrayIndexed64iv(VAO vaobj, uint index, int pname, long param); // pname
    public void GetVertexArrayIndexediv(VAO vaobj, uint index, int pname, int param); // pname
    public void GetVertexArrayiv(VAO vaobj, int pname, out int param); // pname
    public void InvalidateBufferData(VBO buffer);
    public void InvalidateBufferSubData(VBO buffer, IntPtr offset, UIntPtr length);
    public IntPtr MapNamedBuffer(VBO buffer, BufferAccess access);
    public IntPtr MapNamedBufferRange(VBO buffer, IntPtr offset, uint length, BufferAccessMask access);
    public void MultiDrawArrays(PrimitiveType mode, int[] first, uint[] count, uint drawcount);
    public void MultiDrawArraysIndirect(PrimitiveType mode, IntPtr indirect, uint drawcount, uint stride);
    public void MultiDrawElements(PrimitiveType mode, uint[] count, DrawElementsType type, IntPtr indirect, uint drawcount);
    public void MultiDrawElementsBaseVertex(PrimitiveType mode, uint[] count, DrawElementsType type, IntPtr indices, uint drawcount, int[] basevertex);
    public void MultiDrawElementsIndirect(PrimitiveType mode, DrawElementsType type, IntPtr indirect, uint drawcount, uint stride);
    public void PatchParameteri(int pname, int value); // pname
    public void PatchParameterfv(int pname, float[] values); // pname
    public void PrimitiveRestartIndex(uint index);
    public void ProvokingVertex(int provokeMode); // provokeMode
    public bool UnmapNamedBuffer(VBO buffer);
    public void VertexArrayElementBuffer(VAO vaobj, VBO buffer);
    public void VertexArrayAttribBinding(VAO vaobj, uint attribindex, uint bindingindex);
    public void VertexAttribDivisor(uint index, uint divisor);
    public void VertexArrayAttribFormat(VAO vaobj, uint attribindex, int size, int type, bool normalized, uint relativeoffset); // type
    public void VertexArrayAttribIFormat(VAO vaobj, uint attribindex, int size, int type, uint relativeoffset); // type
    public void VertexArrayAttribLFormat(VAO vaobj, uint attribindex, int size, int type, uint relativeoffset); // type
    public void VertexBindingDivisor(uint bindingindex, uint divisor);
    public void VertexArrayBindingDivisor(VAO vaobj, uint bindingindex, uint divisor);
    public void DeleteVertexArrays(uint n, ref VAO arrays);

    ///////////////////////////////////////////////////////////////////// Buffer Objects
    ///////////////////////////////////////////////////////////////////// Program Pipelines

    public void ActiveShaderProgram(ProgramPipeline pipeline, Program program);
    public void BindProgramPipeline(ProgramPipeline pipeline);
    public void CreateProgramPipelines(uint n, out ProgramPipeline pipelines);
    public void DeleteProgramPipelines(uint n, ref ProgramPipeline pipelines);
    public void GetProgramPipelineiv(ProgramPipeline pipeline, int pname, out int @params); // pname
    public void GetProgramPipelineInfoLog(ProgramPipeline pipeline, uint bufSize, out uint length, char[] infoLog);
    public void ValidateProgramPipeline(ProgramPipeline pipeline);
    public void UseProgramStages(ProgramPipeline pipeline, int stages, Program program); // stages

    ///////////////////////////////////////////////////////////////////// Program Pipelines
    ///////////////////////////////////////////////////////////////////// Samplers

    public void BindSampler(uint unit, Sampler sampler);
    public void BindSamplers(uint first, uint count, Sampler[] samplers);
    public void CreateSamplers(uint n, out Sampler samplers);
    public void DeleteSamplers(uint n, ref Sampler samplers);
    public void GetSamplerParameterfv(Sampler sampler, SamplerParameterName pname, float[] @params);
    public void GetSamplerParameteriv(Sampler sampler, SamplerParameterName pname, int[] @params);
    public void GetSamplerParameterIiv(Sampler sampler, SamplerParameterName pname, int[] @params);
    public void GetSamplerParameterIuiv(Sampler sampler, SamplerParameterName pname, uint[] @params);
    public void SamplerParameterf(Sampler sampler, SamplerParameterName pname, float param);
    public void SamplerParameteri(Sampler sampler, SamplerParameterName pname, int param);
    public void SamplerParameterfv(Sampler sampler, SamplerParameterName pname, float[] @params);
    public void SamplerParameteriv(Sampler sampler, SamplerParameterName pname, int[] @params);
    public void SamplerParameterIiv(Sampler sampler, SamplerParameterName pname, int[] @params);
    public void SamplerParameterIuiv(Sampler sampler, SamplerParameterName pname, uint[] @params);

    ///////////////////////////////////////////////////////////////////// Samplers
    ///////////////////////////////////////////////////////////////////// Syncing

    public int ClientWaitSync(SyncObject sync, int flags, ulong timeout); // return | flags
    public void DeleteSync(SyncObject sync);
    public SyncObject FenceSync(int condition, int flags); // condition | flags
    public void GetSynciv(SyncObject sync, int pname, uint bufSize, out uint length, int[] values); // pname
    public void TextureBarrier();
    public void WaitSync(SyncObject sync, int flags, ulong timeout); // flags

    ///////////////////////////////////////////////////////////////////// Syncing
    ///////////////////////////////////////////////////////////////////// Utility

    public void DispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);
    public void DispatchComputeIndirect(IntPtr indirect);
    public int GetGraphicsResetStatus(); // return
    public void GetInternalformativ(int target, int internalformat, int pname, uint bufSize, int[] @params); // target || internalformat || pname
    public void GetInternalformati64v(int target, int internalformat, int pname, uint bufSize, long[] @params); // target || internalformat || pname
    public void GetMultisamplefv(int pname, uint index, float[] val); // pname
    public byte[] GetString(StringName name);
    public byte[] GetStringi(StringNameIndexed name, uint index);
    public void MemoryBarrier(MemoryBarrierFlags barriers);
    public void MemoryBarrierByRegion(MemoryBarrierFlags barriers);

    ///////////////////////////////////////////////////////////////////// Utility
    ///////////////////////////////////////////////////////////////////// Rendering

    public void Clear(ClearBufferMask mask);
    public void ClearNamedFramebufferiv(Framebuffer framebuffer, int buffer, int drawbuffer, int[] value); // buffer
    public void ClearNamedFramebufferuiv(Framebuffer framebuffer, int buffer, int drawbuffer, uint[] value); // buffer
    public void ClearNamedFramebufferfv(Framebuffer framebuffer, int buffer, int drawbuffer, float[] value); // buffer
    public void ClearNamedFramebufferfi(Framebuffer framebuffer, int buffer, int drawbuffer, float depth, int stencil); // buffer
    public void ClearColor(float red, float green, float blue, float alpha);
    public void ClearDepth(double depth);
    public void ClearDepthf(float depth);
    public void ClearStencil(int s);
    public void NamedFramebufferDrawBuffer(Framebuffer framebuffer, int buf); // buf
    public void Finish();
    public void Flush();
    public void NamedFramebufferReadBuffer(Framebuffer framebuffer, int mode); // mode
    public void ReadPixels(int x, int y, uint width, uint height, PixelFormat format, PixelType type, IntPtr data);
    public void ReadnPixels(int x, int y, uint width, uint height, PixelFormat format, PixelType type, uint bufSize, IntPtr data);

    ///////////////////////////////////////////////////////////////////// Rendering
    ///////////////////////////////////////////////////////////////////// Queries

    public void BeginConditionalRender(Queries id, int mode); // mode
    public void EndConditionalRender();
    public void BeginQuery(int target, Queries id); // target
    public void EndQuery(int target); // target
    public void BeginQueryIndexed(int target, uint index, Queries id); // target
    public void EndQueryIndexed(int target, uint index); // target
    public void CreateQueries(int target, uint n, out Queries ids); // target
    public void DeleteQueries(uint n, ref Queries ids);
    public void GetQueryIndexediv(int target, uint index, int pname, out int @params); // target || pname
    public void GetQueryObjectiv(Queries id, int pname, out int @params); // pname
    public void GetQueryObjectuiv(Queries id, int pname, out uint @params); // pname
    public void GetQueryObjecti64v(Queries id, int pname, out long @params); // pname
    public void GetQueryObjectui64v(Queries id, int pname, out ulong @params); // pname
    public void GetQueryiv(int target, int pname, out int @params); // target || pname
    public void QueryCounter(Queries id, int target); // target

    ///////////////////////////////////////////////////////////////////// Queries
    ///////////////////////////////////////////////////////////////////// State Management

    public void BlendColor(float red, float green, float blue, float alpha);
    public void BlendEquation(BlendEquationMode mode);
    public void BlendEquationi(uint buf, BlendEquationMode mode);
    public void BlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha);
    public void BlendEquationSeparatei(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha);
    public void BlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);
    public void BlendFunci(uint buf, BlendingFactor sfactor, BlendingFactor dfactor);
    public void BlendFuncSeparate(BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha);
    public void BlendFuncSeparatei(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha);
    public void ClampColor(int target, int clamp); // target || clamp
    public void ClipControl(ClipControlOrigin origin, ClipControlDepthRange depth);
    public void ColorMask(bool red, bool green, bool blue, bool alpha);
    public void ColorMaski(uint buf, bool red, bool green, bool blue, bool alpha);
    public void CullFace(CullFaceMode mode);
    public void DepthFunc(DepthFunction func);
    public void DepthMask(bool flag);
    public void DepthRange(double nearVal, double farVal);
    public void DepthRangef(float nearVal, float farVal);
    public void DepthRangeArrayv(uint first, uint count, double[] v);
    public void DepthRangeIndexed(uint index, double nearVal, double farVal);
    public void Enable(EnableCap cap);
    public void Enablei(EnableCap cap, uint index);
    public void Disable(EnableCap cap);
    public void Disablei(EnableCap cap, uint index);
    public void FrontFace(FrontFaceDirection mode);
    public void GetBooleanv(GetPName pname, bool[] data);
    public void GetDoublev(GetPName pname, double[] data);
    public void GetFloatv(GetPName pname, float[] data);
    public void GetIntegerv(GetPName pname, int[] data);
    public void GetInteger64v(GetPName pname, long[] data);
    public void GetBooleani_v(int target, uint index, bool[] data); // target
    public void GetIntegeri_v(int target, uint index, int[] data); // target
    public void GetFloati_v(int target, uint index, float[] data); // target
    public void GetDoublei_v(int target, uint index, double[] data); // target
    public void GetInteger64i_v(int target, uint index, long[] data); // target
    public void Hint(int target, int mode); // target || mode
    public bool IsEnabled(EnableCap cap);
    public bool IsEnabledi(EnableCap cap, uint index);
    public void LineWidth(float width);
    public void LogicOp(int opcode); // opcode
    public void PixelStoref(PixelStoreParameter pname, float param); // pname
    public void PixelStorei(PixelStoreParameter pname, int param);
    public void PointParameterf(int pname, float param); // pname
    public void PointParameteri(int pname, int param); // pname
    public void PointParameterfv(int pname, float[] @params); // pname
    public void PointParameteriv(int pname, int[] @params); // pname
    public void PointSize(float size);
    public void PolygonMode(MaterialFace face, PolygonMode mode);
    public void PolygonOffset(float factor, float units);
    public void SampleCoverage(float value, bool invert);
    public void Scissor(int x, int y, uint width, uint height);
    public void ScissorArrayv(uint first, uint count, int[] v);
    public void ScissorIndexed(uint index, int left, int bottom, uint width, uint height);
    public void ScissorIndexedv(uint index, int[] v);
    public void StencilFunc(StencilFunction func, int @ref, uint mask);
    public void StencilFuncSeparate(CullFaceMode face, StencilFunction func, int @ref, uint mask);
    public void StencilMask(uint mask);
    public void StencilMaskSeparate(CullFaceMode face, uint mask);
    public void StencilOp(StencilOp sfail, StencilOp dpfail, StencilOp dppass);
    public void StencilOpSeparate(CullFaceMode face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);
    public void Viewport(int x, int y, uint width, uint height);
    public void ViewportArrayv(uint first, uint count, float[] v);
    public void ViewportIndexedf(uint index, float x, float y, float w, float h);
    public void ViewportIndexedfv(uint index, float[] v);

    ///////////////////////////////////////////////////////////////////// State Management
    ///////////////////////////////////////////////////////////////////// Framebuffers

    public void BlitNamedFramebuffer(
        Framebuffer readFramebuffer, Framebuffer drawFramebuffer,
        int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter);
    public FramebufferErrorCode CheckNamedFramebufferStatus(Framebuffer framebuffer, FramebufferTarget target);
    public void CreateFramebuffers(uint n, out Framebuffer ids);
    public void CreateRenderbuffers(uint n, out Renderbuffer renderbuffers);
    public void DeleteFramebuffers(uint n, Framebuffer[] framebuffers);
    public void DeleteRenderbuffers(uint n, Renderbuffer[] renderbuffers);
    public void NamedFramebufferDrawBuffers(Framebuffer framebuffer, uint n, DrawBuffersEnum[] bufs);
    public void NamedFramebufferParameteri(Framebuffer framebuffer, int pname, int param); // pname
    public void NamedFramebufferRenderbuffer(
        Framebuffer framebuffer, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, Renderbuffer renderbuffer);
    public void NamedFramebufferTexture(Framebuffer framebuffer, FramebufferAttachment attachment, Texture texture, int level);
    public void NamedFramebufferTextureLayer(Framebuffer framebuffer, FramebufferAttachment attachment, Texture texture, int level, int layer);
    public void GetNamedFramebufferAttachmentParameteriv(Framebuffer framebuffer, FramebufferAttachment attachment, int pname, int[] @params); // pname
    public void GetNamedFramebufferParameteriv(Framebuffer framebuffer, int pname, out int param); // pname
    public void GetNamedRenderbufferParameteriv(Renderbuffer renderbuffer, int pname, int[] @params);
    public void InvalidateNamedFramebufferData(Framebuffer framebuffer, uint numAttachments, FramebufferAttachment[] attachments);
    public void InvalidateNamedFramebufferSubData(
        Framebuffer framebuffer, uint numAttachments, FramebufferAttachment[] attachments, int x, int y, uint width, uint height);
    public void NamedRenderbufferStorage(Renderbuffer renderbuffer, PixelInternalFormat internalformat, uint width, uint height);
    public void NamedRenderbufferStorageMultisample(Renderbuffer renderbuffer, uint samples, PixelInternalFormat internalformat, uint width, uint height);
    public void SampleMaski(uint maskNumber, int mask); // mask

    ///////////////////////////////////////////////////////////////////// Framebuffers
    ///////////////////////////////////////////////////////////////////// Textures

    public void GenerateTextureMipmap(Texture texture);
    public void BindImageTexture(uint unit​, Texture texture​, int level​, bool layered​, int layer​, TextureAccess access​, SizedInternalFormat format​);
    public void BindImageTextures(uint first, uint count, Texture[] textures);
    public void BindTextureUnit(uint unit, Texture texture);
    public void BindTextures(uint first, uint count, Texture[] textures);
    public void ClearTexImage(Texture texture, int level, PixelFormat format, PixelType type, IntPtr data);
    public void ClearTexSubImage(
        Texture texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, PixelFormat format, PixelType type, IntPtr data);
    public void CompressedTextureSubImage1D(Texture texture, int level, int xoffset, uint width, PixelFormat format, uint imageSize, IntPtr data);
    public void CompressedTextureSubImage2D(
        Texture texture, int level, int xoffset, int yoffset, uint width, uint height, PixelFormat format, uint imageSize, IntPtr data);
    public void CompressedTextureSubImage3D(
        Texture texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, PixelFormat format, uint imageSize, IntPtr data);
    public void CopyImageSubData(
        Texture srcName, int srcTarget, int srcLevel, int srcX, int srcY, int srcZ,
        Texture dstName, int dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint srcWidth, uint srcHeight, uint srcDepth); // srcTarget || dstTarget
    public void CopyTextureSubImage1D(Texture texture, int level, int xoffset, int x, int y, uint width);
    public void CopyTextureSubImage2D(Texture texture, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    public void CopyTextureSubImage3D(Texture texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    public void CreateTextures(TextureTarget target, uint n, out Texture textures);
    public void DeleteTextures(uint n, ref Texture textures);
    public void GetCompressedTextureImage(Texture texture, int level, uint bufSize, IntPtr pixels);
    public void GetCompressedTextureSubImage(
        Texture texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint bufSize, IntPtr pixels);
    public void GetTextureImage(Texture texture, int level, PixelFormat format, PixelType type, uint bufSize, IntPtr pixels);
    public void GetTextureLevelParameterfv(Texture texture, int level, int pname, float[] @params); // pname
    public void GetTextureLevelParameteriv(Texture texture, int level, int pname, int[] @params); // pname
    public void GetTextureParameterfv(Texture texture, int pname, float[] @params); // pname
    public void GetTextureParameteriv(Texture texture, int pname, int[] @params); // pname
    public void GetTextureParameterIiv(Texture texture, int pname, int[] @params); // pname
    public void GetTextureParameterIuiv(Texture texture, int pname, uint[] @params); // pname
    public void GetTextureSubImage(
        Texture texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, PixelFormat format, PixelType type, uint bufSize, IntPtr pixels);
    public void InvalidateTexImage(Texture texture, int level);
    public void InvalidateTexSubImage(Texture texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth);
    public void TextureBuffer(Texture texture, SizedInternalFormat internalformat, VBO buffer);
    public void TextureBufferRange(Texture texture, SizedInternalFormat internalformat, VBO buffer, IntPtr offset, uint size);
    public void TextureParameterf(Texture texture, SamplerParameterName pname, float param);
    public void TextureParameteri(Texture texture, SamplerParameterName pname, int param);
    public void TextureParameterfv(Texture texture, SamplerParameterName pname, float[] @params);
    public void TextureParameteriv(Texture texture, SamplerParameterName pname, int[] @params);
    public void TextureParameterIiv(Texture texture, SamplerParameterName pname, int[] @params);
    public void TextureParameterIuiv(Texture texture, SamplerParameterName pname, uint[] @params);
    public void TextureStorage1D(Texture texture, uint levels, SizedInternalFormat internalformat, uint width);
    public void TextureStorage2D(Texture texture, uint levels, SizedInternalFormat internalformat, uint width, uint height);
    public void TextureStorage2DMultisample(
        Texture texture, uint samples, SizedInternalFormat internalformat, uint width, uint height, bool fixedsamplelocations);
    public void TextureStorage3D(Texture texture, uint levels, SizedInternalFormat internalformat, uint width, uint height, uint depth);
    public void TextureStorage3DMultisample(
        Texture texture, uint samples, SizedInternalFormat internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    public void TextureSubImage1D(Texture texture, int level, int xoffset, uint width, PixelFormat format, PixelType type, IntPtr pixels);
    public void TextureSubImage2D(Texture texture, int level, int xoffset, int yoffset, uint width, uint height, PixelFormat format, PixelType type, IntPtr pixels);
    public void TextureSubImage3D(
        Texture texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, PixelFormat format, PixelType type, IntPtr pixels);
    public void TextureView(
        Texture texture, TextureTarget target, Texture origtexture, PixelInternalFormat internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);

    ///////////////////////////////////////////////////////////////////// Textures
    ///////////////////////////////////////////////////////////////////// Transform Feedback

    public void BeginTransformFeedback(int primitiveMode); // primitiveMode
    public void EndTransformFeedback();
    public void CreateTransformFeedbacks(uint n, out TransformFeedback ids);
    public void DeleteTransformFeedbacks(uint n, TransformFeedback[] ids);
    public void DrawTransformFeedback(int mode, TransformFeedback id); // mode
    public void DrawTransformFeedbackInstanced(int mode, TransformFeedback id, uint primcount); // mode
    public void DrawTransformFeedbackStream(int mode, TransformFeedback id, uint stream); // mode
    public void DrawTransformFeedbackStreamInstanced(int mode, TransformFeedback id, uint stream, uint primcount); // mode
    public void GetTransformFeedbackiv(TransformFeedback xfb, int pname, int[] param); // pname
    public void GetTransformFeedbacki_v(TransformFeedback xfb, int pname, uint index, int[] param); // pname
    public void GetTransformFeedbacki64_v(TransformFeedback xfb, int pname, uint index, long[] param); // pname
    public void GetTransformFeedbackVarying(Program program, uint index, uint bufSize, out uint length, out uint size, out int type, byte[] name); // type
    public void PauseTransformFeedback();
    public void ResumeTransformFeedback();
    public void TransformFeedbackBufferBase(TransformFeedback xfb, uint index, VBO buffer);
    public void TransformFeedbackBufferRange(TransformFeedback xfb, uint index, VBO buffer, IntPtr offset, uint size);
    public void TransformFeedbackVaryings(Program program, uint count, byte[][] varyings, int bufferMode); // bufferMode

    ///////////////////////////////////////////////////////////////////// Transform Feedback
}
