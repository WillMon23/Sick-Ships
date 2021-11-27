using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Sick_Ship
{

    class SceneManager
    {
        /// <summary>
        /// Collectively keeps tabs on  how many scenes have been created
        /// </summary>
        private static Scene[] _scenes = new Scene[0];

        /// <summary>
        /// Loctation in which a scene is currently being displayed to user 
        /// </summary>
        private static int _currentSceneIndex;
   
        /// <summary>
        /// current state of the application {if false = not closed, if true = open }
        /// </summary>
        private static bool _applicationShouldClose = false;

        /// <summary>
        /// current state of the application {if false = not closed, if true = open }
        /// </summary>
        public static bool ApplicationShoouldClose { get { return _applicationShouldClose; } set { _applicationShouldClose = value; } }

        /// <summary>
        /// Intitalises the current scenes oporation 
        /// </summary>
        public void Start()
        { 
            _currentSceneIndex = AddScene(new SceneOne());
            _scenes[_currentSceneIndex].Start();
            
        }

        /// <summary>
        /// Updates once per frame 
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            // Creatrs a new scene everytime it's being it's swapped to  if conditions are met  
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
        /// Creatrs a new scene everytime it's being it's swapped to  if conditions are met  
        /// </summary>
        private void SceneTransition()
        {
            //IF key number 1 is preessed or EnemyCounter is less then 0 . . .
             if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE) || GameManager.EnemyCounter < 0)
            {
                //Adds SceneOne to array, Changes current scene based on the abount in the _scene array
                _currentSceneIndex = AddScene(new SceneOne());
                //Starts the scene
                _scenes[_currentSceneIndex].Start();
            }

            //IF key number 2 is preessed or EnemyCounter is less then 0 . . .
            if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO) || GameManager.EnemyCounter < 0)
            {
                ////Adds SceneTwo to array, Changes current scene based on the abount in the _scene array
                _currentSceneIndex = AddScene(new SceneTwo());
                //Starts the scene
                _scenes[_currentSceneIndex].Start();
            }

            //IF key number 3 is preessed or EnemyCounter is less then 0 . . .
            if (Raylib.IsKeyDown(KeyboardKey.KEY_THREE) || GameManager.EnemyCounter < 0)
            {
                ////Adds SceneThree to array, Changes current scene based on the abount in the _scene array
                _currentSceneIndex = AddScene(new SceneThree());
                //Starts the scene
                _scenes[_currentSceneIndex].Start();
            }
        }
    }
}
