﻿namespace FrederikaStudio.OpenGL.Native;

public enum DebugMessageControl_type
{
    GL_DONT_CARE = 0x1100,
    GL_DEBUG_TYPE_ERROR = 0x824C,
    GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR = 0x824D,
    GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR = 0x824E,
    GL_DEBUG_TYPE_PORTABILITY = 0x824F,
    GL_DEBUG_TYPE_PERFORMANCE = 0x8250,
    GL_DEBUG_TYPE_MARKER = 0x8268,
    GL_DEBUG_TYPE_PUSH_GROUP = 0x8269,
    GL_DEBUG_TYPE_POP_GROUP = 0x826A,
    GL_DEBUG_TYPE_OTHER = 0x8251,
}
