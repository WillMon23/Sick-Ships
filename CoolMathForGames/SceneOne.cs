using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Sick_Ship
{
    class SceneOne : Scene
    { 
        public override void Start()
        {
            base.Start();

            GameManager.EnemyCounter = 0;

            EnemySpawner EnemySpawner = new EnemySpawner(5);
            AddActor(EnemySpawner);

            UIText lostMenu = new UIText(400, 225, "Lost Screen", Color.RED, 400, 450, 1000, "You Lose");
            AddActor(lostMenu);

            Planet cosmo = new Planet(800, 450, "Cosmo", "Images/Planets/cosmo.png", true);
            cosmo.SetScale(2000, 2000);
            AddActor(cosmo);

            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(200, 200);
            AddActor(sun);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);
            AddActor(earth);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);
            AddActor(moon);

            UpgradeSpawner upgradeSpawner = new UpgradeSpawner(5);
            AddActor(upgradeSpawner);

            sun.AddChild(earth);
            earth.AddChild(moon);


            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            AddActor(GameManager.Player);
        }
    }
}
