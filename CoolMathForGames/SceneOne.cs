using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class SceneOne : Scene
    { 
        private float _timer = 0;

        public override void Start()
        {
            base.Start();


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

            

            Spawner EnemySpawner = new Spawner(5);
            
            
            


            sun.AddChild(earth);
            earth.AddChild(moon);
            
            

            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            AddActor(GameManager.Player);

            AddActor(EnemySpawner);

        }

        public override void Update(float deltaTime)
        {
            if (_timer >= 1f)
            { 
                SpawningUpgrades();
                _timer = 0;
            }
            _timer += deltaTime;
            base.Update(deltaTime);
        }

        /// <summary>
        /// Handles Spawning for the possible upgrades
        /// </summary>
        private void SpawningUpgrades()
        {
            Random rng = new Random();

            Upgrade upgrade;

            if(rng.Next(0,3) == 1)
                upgrade = new Upgrade(100 * rng.Next(6,16), 100 * rng.Next(3,9), "Scaler", "Images/Upgrades/ScaleUp.png");

            else
                upgrade = new Upgrade(100 * rng.Next(6, 16), 100 * rng.Next(3, 9), "Adaption", "Images/Upgrades/Adaption.png");

            SceneManager.AddActor(upgrade);



        } 


    }
}
