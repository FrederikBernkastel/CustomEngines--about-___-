namespace FrederikaStudio.FrederikaEngine;

internal interface IDisposeObject
{
    public void Dispose();
}
internal static class Instance
{
    public static Engine? Engine { get; private set; }
    public static GraphicDevice? GraphicDevice { get; private set; }
    public static FactoryObjectsOpenGL? FactoryObjectsOpenGL { get; private set; }
    public static WindowObject? Window { get; private set; }
    public static FactoryProgram? FactoryProgram { get; private set; }

    public static void Init(SettingsInstance settings_instance)
    {
        Window = FactoryInstance.CreateWindowObject(settings_instance.SettingsWindow);
        Engine = FactoryInstance.CreateEngine(settings_instance.SettingsEngine);
        GraphicDevice = FactoryInstance.CreateGraphicDevice(settings_instance.SettingsGraphicDevice);
        FactoryObjectsOpenGL = FactoryInstance.CreateFactoryObjectsOpenGL();
        FactoryProgram = FactoryInstance.CreateFactoryProgram();
    }
    public static void Dispose()
    {
        IDisposeObject[] disposeObjects = { Engine!, GraphicDevice!, Window! };
        foreach (var s in disposeObjects)
            s.Dispose();
        FactoryObjectsOpenGL!.Dispose(true);
    }

    private static class FactoryInstance
    {
        public static Engine CreateEngine(SettingsEngine settings_engine)
        {
            Engine engine = new(settings_engine);
            return engine;
        }
        public static GraphicDevice CreateGraphicDevice(SettingsGraphicDevice settings_graphic_device)
        {
            if (settings_graphic_device.Debug)
                DebugingOpenGL.Init();

            GraphicDevice graphicDevice = new(settings_graphic_device);
            return graphicDevice;
        }
        public static WindowObject CreateWindowObject(SettingsWindow settings_window)
        {
            if (settings_window.Debug)
                DebugingGLFW.Init();

            WindowObject window = new(settings_window);
            window.MakeContextCurrent();
            return window;
        }
        public static FactoryObjectsOpenGL CreateFactoryObjectsOpenGL()
        {
            FactoryObjectsOpenGL factoryObjectsOpenGL = new();
            return factoryObjectsOpenGL;
        }
        public static FactoryProgram CreateFactoryProgram()
        {
            FactoryProgram factoryProgram = new();
            return factoryProgram;
        }
    }
}
