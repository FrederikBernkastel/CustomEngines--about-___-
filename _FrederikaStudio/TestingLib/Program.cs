var hintWindow = WindowGLFW.Hint;
hintWindow.Context.VersionMajor = 4;
hintWindow.Context.VersionMinor = 5;
hintWindow.Context.OpenGLProfile = ENGLFW.WindowHintOpenGLProfileValueGLFW.Core;
var window = WindowGLFW.CreateWindow(700, 700, "HelloTest");
window.MakeContextCurrent();
LibraryGLFW.SwapInterval(1);
//var ptr = window.CreatePointerKeyCallback;
//window.AddKeyCallback(ptr, EnumGLFW.KeysGLFW.E, EnumGLFW.InputStateGLFW.Repeat, KeyCallback);
ProccessingEventsGLFW proccessing = new(window.Proccessing);

proccessing.AddCallback(ENGLFW.KeysGLFW.A, ENGLFW.InputStateGLFW.Press, KeyCallbackA);
proccessing.AddCallback(ENGLFW.KeysGLFW.D, ENGLFW.InputStateGLFW.Press, KeyCallbackD);
proccessing.AddCallback(ENGLFW.KeysGLFW.W, ENGLFW.InputStateGLFW.Press, KeyCallbackW);
proccessing.AddCallback(ENGLFW.KeysGLFW.S, ENGLFW.InputStateGLFW.Press, KeyCallbackS);

proccessing.AddCallback(ENGLFW.MouseButtonGLFW.Left, ENGLFW.InputStateGLFW.Repeat, ButtonLeftCallback);
proccessing.AddCallback(ENGLFW.MouseButtonGLFW.Right, ENGLFW.InputStateGLFW.Release, ButtonRightCallback);

//var size = window.GetFramebufferSize;
//IOpenGL.OpenGL.Viewport(0, 0, (uint)size.X, (uint)size.Y);

//IOpenGL.OpenGL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);

//var sprite = IFactoryRenderObject.FactoryRenderObject.CreateSprite2D();
//IPoolRenderObject.PoolRenderObject.AddRenderObject(sprite);

while (!window.WindowShouldClose)
{
    LibraryGLFW.PollEvents();
    proccessing.PoolEvents();
    //window.PoolEvents();
    //IOpenGL.OpenGL.Clear(
    //    FrederikaStudio.OpenGL.Native.NativeEnumOpenGL.ClearBufferMask.ColorBufferBit | 
    //    FrederikaStudio.OpenGL.Native.NativeEnumOpenGL.ClearBufferMask.DepthBufferBit |
    //    FrederikaStudio.OpenGL.Native.NativeEnumOpenGL.ClearBufferMask.StencilBufferBit);
    //IPoolRenderObject.PoolRenderObject.StartRendering();
    window.SwapBuffers();
}

window.Dispose();
LibraryGLFW.Dispose();


void KeyCallbackA()
{
    Console.WriteLine("A");
}
void KeyCallbackD()
{
    Console.WriteLine("D");
}
void KeyCallbackW()
{
    Console.WriteLine("W");
}
void KeyCallbackS()
{
    Console.WriteLine("S");
}
void ButtonLeftCallback()
{
    Console.WriteLine("Left");
}
void ButtonRightCallback()
{
    Console.WriteLine("Right");
}



//BuilderWindowGLFW builder = new(new());
//var context = builder.Context;
//context!.VersionMajor = 4;
//context!.VersionMinor = 5;
//var window = builder.Build;
//window.SetWindowIcon(new string[] { @"D:\code\FrederikaStudio\resources\graphics\air_in1a.png" });

////FrederikaStudio.GLFW.WindowGLFW window = new(new(700, 700), "LearnOpenGL");
////FrederikaStudio.NativeGLFW.ButtonsKeyboardMouseGLFW buttonsKeyboard = window.ButtonsKeyboardMouse;
////_ = window.GetMakeContextCurrent;
//var opengl = OpenGLLibFactory.OpenGL_4_5;

////var frame_size = window.GetFramebufferSize;
////opengl.Viewport(0, 0, (uint)frame_size.X, (uint)frame_size.Y);

//opengl.ClearColor(0, 0, 0, 1);


//float[] vertices = 
//{
//    -0.5f, -0.5f, 0.0f,
//     0.5f, -0.5f, 0.0f,
//     0.0f,  0.5f, 0.0f,
//};

//uint VAO = 0;
//opengl.GenVertexArrays(1, ref VAO);

//opengl.BindVertexArray(VAO);


//uint VBO = 0;
//opengl.GenBuffers(1, ref VBO);
//opengl.BindBuffer(BufferTarget.ArrayBuffer, VBO);

//var pinnedArray = GCHandle.Alloc(vertices, GCHandleType.Pinned);
//var pointer = pinnedArray.AddrOfPinnedObject();

//opengl.BufferData(BufferTarget.ArrayBuffer, 9 * sizeof(float), pointer, BufferUsage.StaticDraw);

//pinnedArray.Free();




//var vertexShader = opengl.CreateShader(ShaderType.VertexShader);
//opengl.ShaderSource(vertexShader, 1, new string[] { File.ReadAllText(@"D:\code\FrederikaStudio\resources\shaders\vertexShader.vs") }, IntPtr.Zero);
//opengl.CompileShader(vertexShader);

//int success = 0;
//string infoLog = "";
//opengl.GetShaderiv(vertexShader, ShaderParameter.CompileStatus, ref success);

//if (success == 0)
//{
//    opengl.GetShaderInfoLog(vertexShader, 512, IntPtr.Zero, infoLog);
//    throw new Exception(infoLog);
//}

//var fragmentShader = opengl.CreateShader(ShaderType.FragmentShader);
//opengl.ShaderSource(fragmentShader, 1, new string[] { File.ReadAllText(@"D:\code\FrederikaStudio\resources\shaders\fragmentShader.fs") }, IntPtr.Zero);
//opengl.CompileShader(fragmentShader);




//opengl.GetShaderiv(fragmentShader, ShaderParameter.CompileStatus, ref success);

//if (success == 0)
//{
//    opengl.GetShaderInfoLog(fragmentShader, 512, IntPtr.Zero, infoLog);
//    throw new Exception(infoLog);
//}


//var shaderProgram = opengl.CreateProgram();
//opengl.AttachShader(shaderProgram, vertexShader);
//opengl.AttachShader(shaderProgram, fragmentShader);
//opengl.LinkProgram(shaderProgram);



//opengl.GetProgramiv(shaderProgram, ProgramParameter.LinkStatus, ref success);

//if (success == 0)
//{
//    opengl.GetProgramInfoLog(shaderProgram, 512, IntPtr.Zero, infoLog);
//    throw new Exception(infoLog);
//}


//opengl.DeleteShader(vertexShader);
//opengl.DeleteShader(fragmentShader);


//opengl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
//opengl.EnableVertexAttribArray(0);


//opengl.BindVertexArray(0);






//while (!window.IsWindowShouldClose)
//{
//    FrederikaStudio.NativeGLFW.WindowGLFW.ActionPollEvents();
//    if (buttonsKeyboard.GetKey(ConstGLFW.Keys.F) == ConstGLFW.InputState.Press)
//        window.SetWindowShouldClose(true);
//    opengl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

//    opengl.UseProgram(shaderProgram);
//    opengl.BindVertexArray(VAO);
//    opengl.DrawArrays(PrimitiveType.Triangles, 0, 3);
//    opengl.BindVertexArray(0);

//    window.ActionSwapBuffers();
//}


//window.Dispose();