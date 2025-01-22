namespace FrederikaStudio.OpenGL;

public delegate void DebugProc(DebugSource source, DebugType type, uint id, DebugSeverity severity, uint length, SCU.PointerStringAnsi message, IntPtr userParam);