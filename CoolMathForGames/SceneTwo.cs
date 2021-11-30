using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class SceneTwo : Scene
    {
        public override void Start()
        {
            base.Start();

            GameManager.EnemyCounter = 0;

            //GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");

            //Creats a new instance of planet called Sun set as decoration
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            //Changes the scale of the sun actor
            sun.SetScale(700, 700);

            //Creats a new instance of planet called spiral to be the backdrop
            Planet spiral = new Planet(800, 450, "Spiral", "Images/Planets/spiral.png", true);
            //Sets the scale for the palnet spiral
            spiral.SetScale(2000, 2000);
            //Adds spiral to the scene
            AddActor(spiral);

            //Creats a new instance of plamet named earth set to be placed as a background decoration
            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            //Sets scale of earth in order to scale off the sun
            earth.SetScale(0.3f, 0.3f);
            //Creats a new imstance of planet named moon that will surve to be decoration 
            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            //Sets the scale of the moon planet 
            moon.SetScale(0.3f, 0.3f);

            //Creats random instance of enemy based on how many are desired to be created
            EnemySpawner EnemySpawner = new EnemySpawner(10);
            //Sets updrade spawner at a rate to spawn from
            UpgradeSpawner upgradeSpawner = new UpgradeSpawner(5);
            AddActor(upgradeSpawner);
            //Adds Planet to Scene
            AddActor(sun);
            AddActor(earth); 
            AddActor(moon);

            //Sets earth to be a child of sun
            sun.AddChild(earth);
            //Sets Moon to be a child of earth
            earth.AddChild(moon);
            //Adds the enemy spwaner to scene
            AddActor(EnemySpawner);

            //Creats a new instance of Player
            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            //Adds Player to the scene
            AddActor(GameManager.Player);

        }
    }
}
