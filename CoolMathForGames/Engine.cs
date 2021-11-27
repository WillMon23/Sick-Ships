using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;
using Raylib_cs;
using System.Diagnostics;


namespace Sick_Ship
{
    class Engine
    {
        /// <summary>
        /// intializes a new instance of a stop watch
        /// </summary>
        Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// intializes a new instance of a stop watch
        /// </summary>
        SceneManager _sceneManager = new SceneManager();

        /// <summary>
        /// Called to begin the application 
        /// </summary>
        public void Run()
        {
            // Call start for the entire application 
            Start();
            float currentTme = 0;
            float lastTime = 0;
            float deltTime = 0;
            // Loop until the application is told to close
            while (!Raylib.WindowShouldClose() && GameManager.Player.Lives > 0)
            {
                //Get how much time has passed since the application started 
                currentTme = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set delta time to be the diffrence in time from the last time recorded to the current time
                deltTime = currentTme - lastTime;

                //Update Application
                Update(deltTime);
                //Draw The Update
                Draw();

                //Set the last recorded to be the current time
                lastTime = currentTme;

            }
            // Called end for the entire applicationa
            End();
        }

        /// <summary>
        /// Called when application starts 
        /// </summary>
        private void Start()
        {
            //Creats a window  using raylib
            Raylib.InitWindow(1600, 900, "Math For Games");
            Raylib.SetTargetFPS(60);

            _stopwatch.Start();
            _sceneManager.Start();

        }

        /// <summary>
        /// Called to draw to the scene 
        /// </summary>
        private void Draw()
        {
            _sceneManager.Draw();
        }

        /// <summary>
        /// Updates the application and notifies the console of any changes 
        /// </summary>
        private void Update(float deltaTime)
        {
            _sceneManager.Update(deltaTime);
            
        }

        /// <summary>
        /// Called once the game has been set to game over 
        /// </summary>
        private void End()
        {
            _sceneManager.End();
        }
    }

}
