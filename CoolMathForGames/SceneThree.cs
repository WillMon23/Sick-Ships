using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    /// <summary>
    /// Third scene 
    /// meant to hold the hardests level of all the scenes 
    /// </summary>
    class SceneThree : Scene
    {
        public override void Start()
        {
            base.Start();

            // Decoration
            Planet cosmo = new Planet(800, 450, "Cosmo", "Images/Planets/nebula.png", true);
            cosmo.SetScale(2000, 2000);
            AddActor(cosmo);

            // Sets current state of enemy counter to 0
            GameManager.EnemyCounter = 0;
            // Creats a new set of enemies
            EnemySpawner EnemySpawner = new EnemySpawner(50);
            AddActor(EnemySpawner);

            // The Boss of the scene 
            Boss sceneThreeBoss = new Boss(1500, 450, "SceneThreeBoss", "Images/Saucer.png");
            AddActor(sceneThreeBoss);

            UpgradeSpawner upgradeSpawner = new UpgradeSpawner(1);
            AddActor(upgradeSpawner);

            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            AddActor(GameManager.Player);
        }
    }
}
