﻿using System;
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

            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(700, 700);

            Planet cosmo = new Planet(800, 450, "Cosmo", "Images/Planets/spiral.png", true);
            cosmo.SetScale(2000, 2000);
            AddActor(cosmo);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);

            EnemySpawner EnemySpawner = new EnemySpawner(10);

            UpgradeSpawner upgradeSpawner = new UpgradeSpawner(5);
            AddActor(upgradeSpawner);

            AddActor(sun);
            AddActor(earth); 
            AddActor(moon);
            sun.AddChild(earth);
            earth.AddChild(moon);

            AddActor(EnemySpawner);

            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            AddActor(GameManager.Player);

        }
    }
}