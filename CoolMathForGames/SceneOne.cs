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

            //Creats a ideration of enemies based on how much is placed 
            EnemySpawner EnemySpawner = new EnemySpawner(5);
            //Adds spawner to scene
            AddActor(EnemySpawner);

            UIText lostMenu = new UIText(400, 225, "Lost Screen", Color.RED, 400, 450, 1000, "You Lose");
            AddActor(lostMenu);

            //Creats a new planet that will be the scenes Sun
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            //sets the size of the sun
            sun.SetScale(300, 300);
            // adds moon to the sun
            AddActor(sun);

            //Creats a new planet that will be the scenes earth
            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            //sets the size of the earth 
            earth.SetScale(0.3f, 0.3f);
            // adds moon to the earrth
            AddActor(earth);
            //Makes earth a chid of the sun
            sun.AddChild(earth);

            //Creats a new planet that will be the scenes Moon
            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            //sets the size of the moon 
            moon.SetScale(0.3f, 0.3f);
            // adds moon to the scene
            AddActor(moon);
            //Makes moon a chid of the earth
            earth.AddChild(moon);


            //Creats a new planet that will be the scenes Shit
            Actor ship = new Actor(1f, 1f, "Ship", "Images/player.png");
            //sets the size of the ship 
            moon.SetScale(0.3f, 0.3f);
            // adds moon to the ship
            AddActor(ship);
            //Makes ship a chid of the moon
            moon.AddChild(ship);

            //Creats upgrades on the scene
            UpgradeSpawner upgradeSpawner = new UpgradeSpawner(5);
            AddActor(upgradeSpawner);

            // New ideration of the current player stats 
            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            // adds player to the ship
            AddActor(GameManager.Player);
        }
    }
}
