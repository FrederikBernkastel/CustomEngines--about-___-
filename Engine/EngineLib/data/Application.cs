namespace EngineLib;

public sealed class Application
{
    public static Application EntryApplication { get; } = new();
    private RenderWindow RenderWindow { get; }
    internal Window Window => RenderWindow;
    internal RenderTarget Render => RenderWindow;

    private Application()
    {
        RenderWindow = new(new(500, 500), "Project");
        Window.Closed += (_, _) => RenderWindow.Close();
    }

    public void Run()
    {
        const int TICKS_PER_SECOND = 60;
        const int SKIP_TICKS = 1000 / TICKS_PER_SECOND;
        const int MAX_FRAMESKIP = 5;

        int next_game_tick = Environment.TickCount;

        Stopwatch stopwatch = new();
        stopwatch.Start();

        EntryScene scene = new();

        while (Window.IsOpen)
        {
            int loops = 0;
            while (Environment.TickCount > next_game_tick && loops < MAX_FRAMESKIP)
            {
                RenderWindow.DispatchEvents();
                scene.DispatchEvents();

                scene.Update();

                next_game_tick += SKIP_TICKS;
                loops++;
            }

            RenderWindow.Clear();

            var interpolation =
                (float)(Environment.TickCount + SKIP_TICKS - next_game_tick) / (float)SKIP_TICKS;
            scene.Render();

            RenderWindow.Display();
        }
    }
}
