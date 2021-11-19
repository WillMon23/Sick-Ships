using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Sick_Ship
{

    class SceneManager
    {
        private static Scene[] _scenes = new Scene[0];
        private static int _currentSceneIndex;
        private static bool _applicationShouldClose = false;

        public static bool ApplicationShoouldClose { get { return _applicationShouldClose; } set { _applicationShouldClose = value; } }

        public void Start()
        {

            
             
            _currentSceneIndex = AddScene(new SceneOne());
            _scenes[_currentSceneIndex].Start();
            
        }

        public void Update(float deltaTime)
        {
            SceneTransition();

            _scenes[_currentSceneIndex].Update(deltaTime);
            


            while (Console.KeyAvailable)
                Console.ReadKey(true);

            Console.WriteLine("Delta TIme: " + deltaTime);
        }


        public void Draw()
        {
            Console.CursorVisible = false;

            // Resets the cursor position to the top
            Console.SetCursorPosition(0, 0);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            //Adds all actor icon to buffer
            _scenes[_currentSceneIndex].Draw();


            Raylib.EndDrawing();
        }

        public void End()
        {

        }


        /// <summary>
        /// Created to append new scnene to the current listing of scene 
        /// </summary>
        /// <param name="scene">Scene being added to the current list of scens</param>
        /// <returns>returns the new ammount of scenes</returns>
        public static int AddScene(Scene scene)
        {
            // Creats a Temporary array 
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copys all the values from old array info to the temp array
            for (int i = 0; i < _scenes.Length; i++)
                tempArray[i] = _scenes[i];

            //Sets adds the new scene to the new size
            tempArray[_scenes.Length] = scene;

            // Set the old array to the new array
            _scenes = tempArray;

            // returns the new allocated size
            return _scenes.Length - 1;
        }


        /// <summary>
        /// when called will end the game
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }

        /// <summary>
        /// Removes Actors from the scene 
        /// </summary>
        /// <param name="actor"></param>
        public static bool RemoverActor(Actor actor)
        {
            if (_scenes[_currentSceneIndex].RemoveActor(actor))
            {
                actor.End();
                return true;
            }
            return false;
        }

        // Adds actors to currrent array of actors in a scene 
        public static void AddActor(Actor actor)
        {
            _scenes[_currentSceneIndex].AddActor(actor);
        }

        /// <summary>
        /// Creatrs scenes then sets it to that scene as its being created 
        /// </summary>
        private void SceneTransition()
        {

             if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE) && GameManager.EnemyCounter > 0)
            {

                _currentSceneIndex = AddScene(new SceneOne());
                _scenes[_currentSceneIndex].Start();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO) && GameManager.EnemyCounter > 0)
            {

                _currentSceneIndex = AddScene(new SceneTwo());
                _scenes[_currentSceneIndex].Start();
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_THREE) && GameManager.EnemyCounter > 0)
            {
                _currentSceneIndex = AddScene(new SceneThree());
                _scenes[_currentSceneIndex].Start();
            }
        }
    }
}
