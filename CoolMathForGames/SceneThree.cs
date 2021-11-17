using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    /// <summary>
    /// MEant to be made once a player attacks 
    /// </summary>
    class SceneThree : Scene
    {
        public override void Start()
        {
            base.Start();

            GameManager.EnemyCounter = 0;

            EnemySpawner EnemySpawner = new EnemySpawner(100);
            AddActor(EnemySpawner);

            Planet cosmo = new Planet(800, 450, "Cosmo", "Images/Planets/cosmo.png", true);
            cosmo.SetScale(2000, 2000);

            Boss sceneThreeBoss = new Boss(1500, 450, "SceneThreeBoss", "");

            AddActor(cosmo);

            AddActor(GameManager.Player);
        }
    }
}
