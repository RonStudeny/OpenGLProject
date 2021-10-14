using OpenGLProject.Rendering.Display;
using GLFW;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGLProject.GameLoop
{
    abstract class Game
    {

        protected int InitalWindowWidth { get; set; }
        protected int InitalWindowHeight { get; set; }
        protected string InitalWindowTitle{ get; set; }
        public Game(int initalWindowWidth, int initalWindowHeight, string initalWindowTitle)
        {
            InitalWindowWidth = initalWindowWidth;
            InitalWindowHeight = initalWindowHeight;
            InitalWindowTitle = initalWindowTitle;
        }
        public void Run()
        {
            Initialize();

            DisplayManager.CreateWindow(InitalWindowWidth, InitalWindowHeight, InitalWindowTitle);

            LoadContent();

            while (!Glfw.WindowShouldClose(DisplayManager.Window))
            {
                GameTime.DeltaTime = (float)Glfw.Time - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = (float)Glfw.Time;

                Update();
                Glfw.PollEvents();
                Render();
            }

            DisplayManager.CloseWindow();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();

        protected abstract void Update();
        protected abstract void Render();

    }
}
