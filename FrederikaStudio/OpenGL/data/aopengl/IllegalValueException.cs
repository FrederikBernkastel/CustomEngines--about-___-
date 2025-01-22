namespace FrederikaStudio.OpenGL;

internal static class Illegal
{
    internal static Exception Value<T>()
    {
        return new IllegalValueException<T>();
    }

    internal class IllegalValueException<T> : VeldridException
    {
    }
}
