namespace FrederikaStudio.ImGUI;

public readonly record struct ImVector<T>(int Size, int Capacity, Core.PointerArray<T> Data) where T: unmanaged;