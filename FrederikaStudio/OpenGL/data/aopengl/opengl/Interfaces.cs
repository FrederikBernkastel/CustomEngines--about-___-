namespace FrederikaStudio.OpenGL;

public interface BindableResource { }
public interface MappableResource { }
internal interface OpenGLDeferredResource
{
    public bool Created { get; }
    public void EnsureResourcesCreated();
    public void DestroyGLResources();
}
public interface DeviceResource
{
    public string Name { get; set; }
}
