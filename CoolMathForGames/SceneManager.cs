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
        private static bool _applicationShouldClose;


        public static Scene _thisSceen = new Scene();
        public static int _enemyCounter;
        
        private int _currentAmountOfEnemies;

        private static Player _player;
        private Enemy[] _enemys;

        public static int EnemyCounter { get { return _enemyCounter; }  set { _enemyCounter = value; } }

        public static Player Player { get { return new Player(200, 800, 500, "Player", "Images/player.png"); } set { _player = value; } } 


        public void Start()
        {
           

            _currentSceneIndex = AddScene(new SceneOne());

            

            _scenes[_currentSceneIndex].Start();
            
        }

        public void Update(float deltaTime)
        {

            if ((_currentSceneIndex < _scenes.Length))
                if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
                {
                    _scenes[_currentSceneIndex].End();
                    _currentSceneIndex = AddScene(new SceneTwo());
                    _scenes[_currentSceneIndex].Start();
                }

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
        public static void RemoverActor(Actor actor)
        {
            _scenes[_currentSceneIndex].RemoveActor(actor);
            actor.End();
        }

        public static void AddActor(Actor actor)
        {
            _thisSceen.AddActor(actor);
        }

        /// <summary>
        /// Creats enemy to spwan based on what scene 
        /// </summary>
        private void EnemySpawner()
        {
            int enemyCounter = 0;
            _enemys = new Enemy[(_currentSceneIndex + 1) * 5];
            for(int i = 0; i < _enemys.Length; i++)
            {
                Enemy enemy = new Enemy(1500, (220 * i), 25 * (i + 1), _player, "Enemy_" + (i + 1), "Images/enemy.png");
                AddActor(enemy);
                enemyCounter++;
            }
            
        }
    }
}
