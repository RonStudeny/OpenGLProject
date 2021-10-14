﻿using GLFW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Drawing;
using static OpenGLProject.OpenGL.GL;

namespace OpenGLProject.Rendering.Display
{
    static class DisplayManager
    {
        public static Window Window { get; set; }

        public static Vector2 WindowSize { get; set; }

        public static void CreateWindow(int width, int height, string title)
        {
            WindowSize = new Vector2(width, height);

            Glfw.Init();

            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);

            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);

            Window = Glfw.CreateWindow(width, height, title, Monitor.None, Window.None);

            if (Window == Window.None)
            {
                return;
            }

            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - width) / 2;
            int y = (screen.Height - height) / 2;

            Glfw.SetWindowPosition(Window, x, y);

            Glfw.MakeContextCurrent(Window);
            Import(Glfw.GetProcAddress);

            glViewport(0, 0, width, height);
            Glfw.SwapInterval(0); // VSync
        }
        public static void CloseWindow()
        {
            Glfw.Terminate();
        }
    }
}
