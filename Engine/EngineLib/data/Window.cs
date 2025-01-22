sealed class Content
{
    public static Content Resorces {get;} = 
        new(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? PathWindows : PathLinux);
    private static string PathWindows => @"Content";
    private static string PathLinux => @"/root/code/res/Content";
    private Dictionary<string, Texture> ListTexture {get;} = new();
    private Dictionary<string, Font> ListFont {get;} = new();
    
    private Content(string path)
    {
        string split = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? @"\" : @"/";
        foreach (var s in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
        {
            var name = s.Split(split)[^1];
            switch (name.Split('.')[^1])
            {
                case "otf":
                    ListFont[name.Split('.')[0]] = new(s);
                    break;
                case "ttf":
                    goto case "otf";
                case "jpg":
                    ListTexture[name.Split('.')[0]] = new(s);
                    break;
                case "png":
                    goto case "jpg";
            }
        }
    }

    public Texture GetTexture(string name) => ListTexture[name];
    public Font GetFont(string name) => ListFont[name];
}
abstract class Scene
{
    private Action[] ListDispatchEvents {get;}
    private Action[] ListUpdate {get;}
    private Action[] ListRender {get;}
    
    public Scene(Action[] listDispatchEvents, Action[] listUpdate, Action[] listRender)
    {
        ListDispatchEvents = listDispatchEvents;
        ListUpdate = listUpdate;
        ListRender = listRender;
    }
    
    public void DispatchEvents()
    {
        foreach (var s in ListDispatchEvents)
            s();
    }
    public void Update()
    {
        foreach (var s in ListUpdate)
            s();
    }
    public void Render()
    {
        foreach (var s in ListRender)
            s();
    }
}
sealed class RenderTexture
{
    private RectangleShape Rectangle {get;}

    public RenderTexture()
    {
        Rectangle = new()
        {
            Texture = Content.Resorces.GetTexture("menufon"),
            Size = new(200, 200),
        };
    }
    
    public void Render()
    {
        Application.EntryApplication.Render.Draw(Rectangle);
    }
}
sealed class EntryScene : Scene
{
    public EntryScene() : base(new Action[] 
    {
        () => 
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                Application.EntryApplication.Window.Close();
        },
    },
    Array.Empty<Action>(),
    new Action[] 
    {
        new RenderTexture().Render,
    })
    {

    }
}
sealed class StateButton
{
    public SharpColor Enter {get;set;}
    public SharpColor Leave {get;set;}
    private Button Button {get;}
    
    public StateButton(Button button) => Button = button;

    public void Update()
    {
        var trans = Button.Transformable;
        //if (new IntRect(trans.Position, ) Mouse.GetPosition(EntryWindow.Window))
    }
}
sealed class Label
{

}
sealed class Button : GUIObject
{
    
    private RectangleShape RectangleShape {get;} = new();
    public Vector2f Size {get;} = new(0.5f, 0.5f);
    public Vector2f Position {get;} = new(0.5f, 0.5f);

    public override Vector2f GetGlobalPosition()
    {
        // if (Parent is null)
        //     return new(EntryWindow.Window.Size.X * Position.X, EntryWindow.Window.Size.Y * Position.Y);
        var rect = Parent.GetGlobalBounds();
        return new(rect.Left + rect.Width * Position.X, rect.Top + rect.Height * Position.Y);
    }
    public override Vector2f GetGlobalSize()
    {
        // if (Parent is null)
        //     return new(EntryWindow.Window.Size.X * Size.X, EntryWindow.Window.Size.Y * Size.Y);
        var size = Parent.GetGlobalSize();
        return new(size.X * Size.X, size.Y * Size.Y);
    }
    public override FloatRect GetGlobalBounds()
    {
        throw new NotImplementedException();
    }
    public override void Draw(RenderTarget target, RenderStates states)
    {
        // RectangleShape.Size = new(ParentSize.X * Size.X, ParentSize.Y * Size.Y);
        // Transformable.Origin = RectangleShape.Size / 2;
        // Transformable.Position = new(ParentSize.X * Position.X, ParentSize.Y * Position.Y);
        
        states.Transform *= Transformable.Transform;

        target.Draw(RectangleShape, states);
    }
}
sealed class Grid
{

}
// static class FactoryObject
// {
//     public static Label CreateLabel()
//     {

//     }
//     public static Button CreateButton()
//     {

//     }
//     public static Grid CreateGrid()
//     {

//     }
// }
sealed class StorageObjects
{
    private List<Drawable> ListObjects {get;} = new();
    
    public StorageObjects()
    {

    }

    public void AddRenderObject(Drawable drawable)
    {
        ListObjects.Add(drawable);
    }
    public IEnumerable<Drawable> GetListObjects() => ListObjects;
}
static class GlobalSettings
{
    public static uint CharacterSize {get;set;} = 15;
}
abstract class GUIObject : Drawable
{
    public GUIObject? Parent {get;set;}
    public Transformable Transformable {get;} = new();

    public abstract Vector2f GetGlobalPosition();
    public abstract Vector2f GetGlobalSize();
    public abstract FloatRect GetGlobalBounds();
    public virtual void Draw(RenderTarget target, RenderStates states) {}
}