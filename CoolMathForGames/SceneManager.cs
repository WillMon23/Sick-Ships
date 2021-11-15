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

        private int _currentAmountOfEnemies;

        public static Scene _thisSceen = new Scene();

        private Player _player;
        private Enemy[] _enemys;


        public void Start()
        {
            //Creats a window  using raylib
            Raylib.InitWindow(1600, 900, "Math For Games");

            Raylib.SetTargetFPS(0);

            SceneOne();

            SceneTwo();
        }

        public void Update(float deltaTime)
        {
            
            if((_currentSceneIndex < _scenes.Length))
                if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
                    _currentSceneIndex++;

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
        /// Starting Initalization of my first Scenes Oporations 
        /// </summary>
        private void SceneOne()
        {
            //Initulises the characters 

            _thisSceen = new Scene();

            //Lead Protaganise 
            _player = new Player(200, 800, 500, "Player", "Images/player.png");

            CircleCollider playerCollider = new CircleCollider(20, _player);
            AABBCollider playerBoxCollider = new AABBCollider(50, 50, _player);
            _player.Collider = playerBoxCollider;

            EnemySpawner();

            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(200, 200);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);

            Upgrades scaler = new Upgrades(700, 700, "Scaler", "Images/Upgrades/Adaption.png");

            Bullet bullet = new Bullet(new MathLibrary.Vector2(700,300) , 20, _player, "Bullet", "Images/bullet.png");

            sun.AddChild(earth);
            earth.AddChild(moon);

            _thisSceen.AddActor(sun);
            _thisSceen.AddActor(earth);
            _thisSceen.AddActor(moon);

            _thisSceen.AddActor(bullet);
            

            _thisSceen.AddActor(_player);
            
            _thisSceen.AddActor(scaler);

            AddScene(_thisSceen);

        }

        /// <summary>
        /// Starting Inittalization of my second Scene Oporations 
        /// </summary>
        private void SceneTwo()
        {
            _thisSceen = new Scene();

            //Lead Protaganise 
            _player = new Player(200, 800, 500, "Player", "Images/player.png");

            CircleCollider playerCollider = new CircleCollider(20, _player);
            AABBCollider playerBoxCollider = new AABBCollider(50, 50, _player);
            _player.Collider = playerBoxCollider;

            EnemySpawner();

            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(200, 200);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);

            _thisSceen.AddActor(sun);
            _thisSceen.AddActor(earth);
            _thisSceen.AddActor(moon);

            _thisSceen.AddActor(_player);

            AddScene(_thisSceen);
        }


        /// <summary>
        /// Created to append new scnene to the current listing of scene 
        /// </summary>
        /// <param name="scene">Scene being added to the current list of scens</param>
        /// <returns>returns the new ammount of scenes</returns>
        public int AddScene(Scene scene)
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
        private int EnemySpawner()
        {
            int enemyCounter = 0;
            _enemys = new Enemy[(_currentSceneIndex + 1) * 5];
            for(int i = 0; i < _enemys.Length; i++)
            {
                Enemy enemy = new Enemy(1500, (220 * i), 25 * (i + 1), _player, "Enemy_" + (i + 1), "Images/enemy.png");
                AddActor(enemy);
                enemyCounter++;
            }
            return enemyCounter;
        }
    }
}
