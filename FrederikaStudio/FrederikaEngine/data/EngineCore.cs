namespace FrederikaStudio.FrederikaEngine;

//internal sealed class BufferIndicesObject<T, Y> where T: struct where Y: struct
//{
//    public FSOG.VBO Handle { get; }
//    public uint TotalLength { get; private set; }
//    public Vector4D<uint> Location { get; private set; }
//    public Vector4D<uint> Size { get; private set; }
//    public FSOG.DrawElements_type TypeElements { get; }

//    public BufferIndicesObject(FSOG.DrawElements_type type)
//    {
//        Handle = GlobalField.FactoryObjects.CreateVBO();
//        TypeElements = type;
//    }

//    public void Allocate(Vector2D<uint> location, Vector2D<uint> length, FSOG.BufferData_usage usage)
//    {
//        Location = new((uint)(location.X * Marshal.SizeOf<T>()), (uint)(location.Y * Marshal.SizeOf<Y>()), location.X, location.Y);
//        TotalLength = (uint)(length.X * Marshal.SizeOf<T>() + length.Y * Marshal.SizeOf<Y>());
//        Librarys.OpenGL.NamedBufferData(Handle, TotalLength, IntPtr.Zero, usage);
//    }
//    public void UpdateDataVertex(T[] data)
//    {
//        var ptr = FSC.ExtensionUnsafe.GetPointer(Handle);
//        Librarys.OpenGL.NamedBufferSubData(Handle, IntPtr.Zero, data.LengthInBytes(), ptr.Pointer);
//        Size = new(data.LengthInBytes(), Size.Y, (uint)data.Length, Size.W);
//    }
//    public void UpdateDataIndices(Y[] data)
//    {
//        using var _data = new AutoPinner(data);
//        Librarys.OpenGL.NamedBufferSubData(Handle, new(Location.Y), data.LengthInBytes(), _data.Pointer);
//        Size = new(Size.X, data.LengthInBytes(), Size.Z, (uint)data.Length);
//    }
//}
//internal sealed class ArrayVertexObject<T, Y> where T : struct where Y : struct
//{
//    public FSOG.VAO Handle { get; }

//    public ArrayVertexObject(BufferIndicesObject<T, Y> buffer)
//    {
//        Handle = GlobalField.FactoryObjects.CreateVAO();

//        Librarys.OpenGL.VertexArrayVertexBuffer(Handle, 0, buffer.Handle, new(buffer.Location.X), (uint)Marshal.SizeOf<T>());
//        Librarys.OpenGL.VertexArrayElementBuffer(Handle, buffer.Handle);
//        Librarys.OpenGL.EnableVertexArrayAttrib(Handle, 0);
//        Librarys.OpenGL.VertexArrayAttribFormat(Handle, 0, 2, 0x1406, false, 0);
//        Librarys.OpenGL.VertexArrayAttribBinding(Handle, 0, 0);
//    }

//    public void BindArrayVertexObject() => Librarys.OpenGL.BindVertexArray(Handle);
//}
//internal readonly record struct VertexPosition<T>(T X, T Y) where T : struct;
//internal readonly record struct VertexColor<T>(T R, T G, T B, T A) where T : struct;
//internal readonly record struct VertexTexCoords<T>(T X, T Y) where T : struct;
//internal readonly record struct IndicesTringles<T>(T VertexOne, T VertexTwo, T VertexThree) where T: struct;
//internal sealed class VertexProgramDefaultOne
//{
//    public FSOG.Program Handle { get; }

//    public VertexProgramDefaultOne()
//    {
//        string vert_str = @"
//        #version 450

//        out gl_PerVertex { vec4 gl_Position; };

//        layout (location = 0) in vec2 aPosition;

//        uniform mat4 uModel;
//        uniform mat4 uView;
//        uniform mat4 uProjection;

//        void main()
//        {
//            gl_Position = projection * view * model * vec4(position, 0, 1);
//        }";

//        Handle = Instance.FactoryProgram!.CreateProgram(
//            FSOG.CreateShader_shaderType.GL_VERTEX_SHADER, vert_str);
//    }
//}
//internal sealed class FragmentProgramDefaultOne
//{
//    public FSOG.Program Handle { get; }

//    public FragmentProgramDefaultOne()
//    {
//        string frag_str = @"
//        #version 450

//        out vec4 FragColor;

//        uniform vec4 uColor;

//        void main()
//        {
//            FragColor = ourColor;
//        }";

//        Handle = Instance.FactoryProgram!.CreateProgram(
//            FSOG.CreateShader_shaderType.GL_FRAGMENT_SHADER, frag_str);
//    }
//}
//internal sealed class FactoryProgram
//{
//    public VertexProgramDefaultOne CreateVertexProgramDefaultOne()
//    {

//    }
//    public FragmentProgramDefaultOne CreateFragmentProgramDefaultOne()
//    {

//    }
//    public FSOG.Program CreateProgram(FSOG.CreateShader_shaderType type, string str)
//    {
//        FSOG.Program program = Instance.FactoryObjectsOpenGL!.CreateProgram(type, 1, new string[] { str });
//        Librarys.OpenGL.ValidateProgram(program);
//        Librarys.OpenGL.GetProgramiv(
//            program, FSOG.GetProgramiv_pname.GL_VALIDATE_STATUS, out var frag_handle_status);
//        if (frag_handle_status == 0)
//            throw new Exception();
//        return program;
//    }
//}
//internal sealed class ShadersPipelineDefaultOne
//{
//    public FSOG.ProgramPipeline Handle { get; }
//    public VertexProgramDefaultOne VertexProgram { get; }
//    public FragmentProgramDefaultOne FragmentProgram { get; }

//    public ShadersPipeline(VertexProgramDefaultOne vertexProgram, FragmentProgramDefaultOne fragmentProgram)
//    {











//        Handle = Instance.FactoryObjectsOpenGL!.CreateProgramPipeline();

//        Librarys.OpenGL.UseProgramStages(Pipeline, FSOG.UseProgramStages_stages.GL_VERTEX_SHADER_BIT, VertexProgram);
//        Librarys.OpenGL.UseProgramStages(Pipeline, FSOG.UseProgramStages_stages.GL_FRAGMENT_SHADER_BIT, FragmentProgram);

//        Librarys.OpenGL.ValidateProgramPipeline(Pipeline);

//        Librarys.OpenGL.GetProgramPipelineiv(Pipeline, (int)FSOG.GetProgramiv_pname.GL_VALIDATE_STATUS, out var handle_status);

//        if (handle_status == 0)
//            throw new Exception();
//    }

//    public void Bind()
//    {
//        Librarys.OpenGL.BindProgramPipeline(Handle);
//    }
//}
//internal sealed class Rendering
//{
//    private FSOG.VAO VAO { get; }
//    private FSOG.ProgramPipeline Pipeline { get; }
//    private FSOG.Program VertexProgram { get; }
//    private FSOG.Program FragmentProgram { get; }
//    private BufferIndicesObject<Vector2D<float>, uint> Buffer { get; }
//    private ArrayVertexObject<Vector2D<float>, uint> ArrayVertex { get; }

//    public Rendering()
//    {


//        Buffer = new(FSOG.DrawElements_type.UnsignedInt);

//        VertexPosition<float>[] vertexPositions = { new(0.5f, 0.5f), new(0.5f, -0.5f), new(-0.5f, -0.5f), new(-0.5f, 0.5f) };
//        VertexColor<float>[] vertexColors = { new(1, 1, 1, 1), new(1, 1, 1, 1) , new(1, 1, 1, 1) , new(1, 1, 1, 1) };
//        VertexTexCoords<float>[] vertexTexCoords = { new(0, 0), new(0, 1) , new(1, 0) , new(1, 1) };
//        IndicesTringles<byte>[] indicesTringles = { new(0, 1, 3), new(1, 2, 3) };



//        Buffer.Allocate(new(0, (uint)vertices.Length), new((uint)vertices.Length, (uint)indices.Length), FSOG.BufferData_usage.StaticDraw);
//        Buffer.UpdateDataVertex(vertices); Buffer.UpdateDataIndices(indices);





//        Librarys.OpenGL.VertexArrayVertexBuffer(VAO, 0, VBO, IntPtr.Zero, 2 * sizeof(float));
//        Librarys.OpenGL.VertexArrayElementBuffer(VAO, VBO);
//        Librarys.OpenGL.EnableVertexArrayAttrib(VAO, 0);
//        Librarys.OpenGL.VertexArrayAttribFormat(VAO, 0, 2, 0x1406, false, 0);
//        Librarys.OpenGL.VertexArrayAttribBinding(VAO, 0, 0);




//        VertexProgram = GlobalField.FactoryObjects.CreateProgram(FSOG.CreateShader_shaderType.GL_VERTEX_SHADER, 1, new string[] { vert_str });
//        FragmentProgram = GlobalField.FactoryObjects.CreateProgram(FSOG.CreateShader_shaderType.GL_FRAGMENT_SHADER, 1, new string[] { frag_str });

//        Librarys.OpenGL.ValidateProgram(VertexProgram);
//        Librarys.OpenGL.ValidateProgram(FragmentProgram);

//        Librarys.OpenGL.GetProgramiv(VertexProgram, FSOG.GetProgramiv_pname.GL_VALIDATE_STATUS, out var vert_handle_status);
//        Librarys.OpenGL.GetProgramiv(FragmentProgram, FSOG.GetProgramiv_pname.GL_VALIDATE_STATUS, out var frag_handle_status);

//        if (vert_handle_status == 0 || frag_handle_status == 0)
//            throw new Exception();

//        Pipeline = GlobalField.FactoryObjects.CreateProgramPipeline();

//        Librarys.OpenGL.UseProgramStages(Pipeline, FSOG.UseProgramStages_stages.GL_VERTEX_SHADER_BIT, VertexProgram);
//        Librarys.OpenGL.UseProgramStages(Pipeline, FSOG.UseProgramStages_stages.GL_FRAGMENT_SHADER_BIT, FragmentProgram);

//        Librarys.OpenGL.ValidateProgramPipeline(Pipeline);

//        Librarys.OpenGL.GetProgramPipelineiv(Pipeline, (int)FSOG.GetProgramiv_pname.GL_VALIDATE_STATUS, out var handle_status);

//        if (handle_status == 0)
//            throw new Exception();
//    }

//    public void RenderingRectangle(Vector4D<float> color, Vector2D<float> position, Vector2D<float> scale)
//    {
//        Librarys.OpenGL.BindProgramPipeline(Pipeline);
//        Librarys.OpenGL.BindVertexArray(VAO);

//        Librarys.OpenGL.ProgramUniform4f(FragmentProgram, 0, color.X, color.Y, color.Z, color.W);
//        Librarys.OpenGL.ProgramUniform2f(Program, 0, position.X, position.Y);
//        Librarys.OpenGL.ProgramUniformMatrix4fv();

//        Librarys.OpenGL.DrawElements(
//            FSOG.DrawArrays_mode.Triangles, Buffer.Size.W, Buffer.TypeElements, new(Buffer.Location.Y));
//    }
//}
//internal readonly record struct SettingsEngine(
//    );
//internal readonly record struct SettingsGraphicDevice(
//    bool Debug,
//    FSM.Vector4D<float> ColorFramebuffer);
//internal readonly record struct SettingsWindow(
//    bool Debug,
//    string Title,
//    bool Sync);
//internal readonly record struct SettingsInstance(
//    SettingsEngine SettingsEngine,
//    SettingsGraphicDevice SettingsGraphicDevice,
//    SettingsWindow SettingsWindow);
//internal sealed class Engine : IDisposeObject
//{
//    public Engine(SettingsEngine settings_engine)
//    {

//    }

//    public void Update()
//    {
//        Librarys.GLFW.WaitEvents();
//    }
//    public void Dispose()
//    {

//    }
//}
//internal sealed class GraphicDevice : IDisposeObject
//{
//    public GraphicDevice(SettingsGraphicDevice settings_graphic_device)
//    {
//        var color_framebuffer = settings_graphic_device.ColorFramebuffer;
//        Librarys.OpenGL.ClearColor(
//            color_framebuffer.X,
//            color_framebuffer.Y,
//            color_framebuffer.Z,
//            color_framebuffer.W);
//    }

//    public void Render()
//    {
//        Librarys.OpenGL.Clear(FSOG.Clear_mask.GL_COLOR_BUFFER_BIT);

//        Rendering.RenderingRectangle(new(0, 0, 1, 1), new());

//        Instance.Window!.SwapBuffers();
//    }
//    public void Dispose()
//    {

//    }
//}
public sealed class Application
{
    private _GLFW.Window Window { get; }
    private _OpenGL.Native.IOpenGL_4_5 OpenGL { get; }

    public Application()
    {
        _GLFW.Context.Initialization(@"D:\code\resources\lib\glfw_native.dll");
        _GLFW.Debuging.Initialization();

        _GLFW.StyleWindow style_window = new();

        //style_window.FullScreen = _GLFW.Monitor.PrimaryMonitor;
        style_window.StyleHintContext.VersionOpenGL = new(4, 5);
        style_window.StyleHintContext.ContextH |= _GLFW.OptionContext.IsDebug;
        style_window.StyleHintWindow.WindowH ^= _GLFW.OptionWindow.Visible;

        Window = new _GLFW.Window(style_window);
        Window.MakeContextCurrent();

        _OpenGL.Context.Initialization(_GLFW.Context.GetProcAddress);
        _OpenGL.Debuging.Initialization();
        OpenGL = _OpenGL.Context.NativeOpenGL;

        OpenGL.ClearColor(1, 1, 1, 1);
    }

    public void Run()
    {
        Window.ShowWindow();
        while (Window.IsOpen)
        {
            _GLFW.Events.PollEvents();
            Window.Keyboard.PollEvents();
            Window.Mouse.PollEvents();
            if (Window.Keyboard.GetKey(_GLFW.Native.Keys.Escape) == _GLFW.InputState.Press)
                Window.Close(true);
            OpenGL.Clear(_OpenGL.Native.Clear_mask.GL_COLOR_BUFFER_BIT);
            Window.SwapBuffers();
        }
        Window.HideWindow();

        Window.Dispose();
        _GLFW.Context.Dispose();
    }
}
