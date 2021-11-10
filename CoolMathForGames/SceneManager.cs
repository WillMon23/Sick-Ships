﻿using System;
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

        private Player _player;
        private Enemy[] _enemys;


        public void Start()
        {
            //Creats a window  using raylibaaa
            Raylib.InitWindow(1600, 900, "Math For Games");

            Raylib.SetTargetFPS(0);

            //Initulises the characters 
            Scene scene = new Scene();

            //Lead Protaganise 
            _player = new Player(200, 800, 500, "Player", "Images/player.png");
            
            CircleCollider playerCollider = new CircleCollider(20, _player);
            AABBCollider playerBoxCollider = new AABBCollider(50, 50, _player);
            _player.Collider = playerBoxCollider;

            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(200, 200);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);


            sun.AddChild(earth);
            earth.AddChild(moon);

            scene.AddActor(sun);
            scene.AddActor(earth);
            scene.AddActor(moon);

            scene.AddActor(_player);
            _currentSceneIndex = AddScene(scene);
        }

        public void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime);


            while (Console.KeyAvailable)
                Console.ReadKey(true);
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

        public static void RemoverActor(Actor actor)
        {
            _scenes[_currentSceneIndex].RemoveActor(actor);
        }

        public static void AddActorToScene(Actor actor)
        {
            _scenes[_currentSceneIndex].AddActor(actor);
        }
    }
}
