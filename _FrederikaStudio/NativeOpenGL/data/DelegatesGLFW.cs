﻿namespace FrederikaStudio.OpenGL.Native;

public delegate void DebugProc(DebugSource source, DebugType type, uint id, DebugSeverity severity, uint length, string message, IntPtr userParam);