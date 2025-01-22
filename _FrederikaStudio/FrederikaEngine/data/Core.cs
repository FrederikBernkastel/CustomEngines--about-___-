using System.Diagnostics;

namespace FrederikaStudio.FrederikaEngine;

#pragma warning disable CS8618

//internal sealed class RenderEngine
//{
//    public int FPS { get; set; }

//    public void Render(float alpha)
//    {
//        double newTime = Environment.TickCount;
//        double frameTime = newTime - currentTime;
//        currentTime = newTime;
//        accumulator += frameTime;

//        while (accumulator >= dt)
//        {
//            Window.DispatchEvents();
//            accumulator -= dt;
//        }
//    }
//}
//public static class Core
//{
//    private static Window Window;
//    private static RenderFactory FactoryRender;
//    private static RenderTarget RenderWindow;

//    public static void Run()
//    {
//        InitEngine();
//        RunEngine();
//        DisposeEngine();
//    }
//    private static void InitEngine()
//    {
//        FactoryRender = new();
//        var renderWindow = FactoryRender.CreateRenderWindow(new() 
//        {
//            VideoMode = new(800, 800),
//            Title = "TestingFrederikaEngined",
//            Styles = Styles.Default,
//        });
//        Window = renderWindow;
//        RenderWindow = renderWindow;
//        Window.Closed += (u, e) => (u as Window)?.Close();
//        Window.SetVerticalSyncEnabled(false);
//        //Window.SetFramerateLimit(0);
//    }
//    private static void RunEngine()
//    {
//        Font font = new(@"D:\code\FrederikaStudio\resources\fonts\font3.otf");
//        Text text = new()
//        {
//            Font = font,
//            CharacterSize = 20,
//            FillColor = Color.White,
//            Position = new(100, 100),
//        };
//        text.DisplayedString = "UPS = " + 0;

//        Stopwatch stopwatch = new();

//        const double dt = 1000.0f / 60.0f;
//        const double dtRender = 1000.0f / 2.0f;
//        double currentTime = Environment.TickCount;
//        double accumulator = 0;
//        double accumulatorRender = 0;
//        while (Window.IsOpen)
//        {
//            stopwatch.Stop();
//            long bnm = stopwatch.ElapsedMilliseconds;
//            stopwatch.Restart();
//            double newTime = Environment.TickCount;
//            double frameTime = newTime - currentTime;
//            currentTime = newTime;
            
//            //accumulator += frameTime;
//            //accumulatorRender += frameTime;

//            Window.DispatchEvents();
//            //while (accumulator >= dt)
//            //{

//            //    accumulator -= dt;
//            //}
//            //while (accumulatorRender >= dtRender)
//            //{
//            //    text.DisplayedString = "UPS = " + frameTime;
//            //    accumulatorRender -= dtRender;
//            //}
//            //float alpha = (float)(accumulator / dt);
//            //accumulatorRender += frameTime;
//            RenderWindow.Clear();
//            //while (accumulatorRender >= dtRender)
//            //{
//            //    RenderWindow.Clear();
//            //    text.DisplayedString = "UPS = " + accumulator;
//            //    RenderWindow.Draw(text);
//            //    accumulatorRender -= dtRender;
//            //}
//            //RenderWindow.Draw(text);
//            Window.Display();
//            Console.WriteLine("UPS = " + bnm);
//        }
//    }
//    private static void DisposeEngine() { }
//}
