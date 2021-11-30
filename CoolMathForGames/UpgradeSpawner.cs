using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class UpgradeSpawner : Actor
    {
        /// <summary>
        /// private dedicated dtimer meant to set as a limiter
        /// </summary>
        private float _timer = 0;

        /// <summary>
        /// The amount set to be spawn
        /// </summary>
        private float _spawnRate = 0;

        public UpgradeSpawner(float spawnRate) : base(0, 0, "UpgradeSpawner", "") 
        {
            _spawnRate = spawnRate;
        }

        /// <summary>
        /// Updates once per frame 
        /// </summary>
        /// <param name="deltaTime">time elaps devided by 1000 and reset </param>
        public override void Update(float deltaTime)
        {
            SpawnTimer(deltaTime);
            base.Update(deltaTime);
        }


        /// <summary>
        /// Handles Spawning all the upgrades to the scene
        /// </summary>
        private void SpawningUpgrades()
        {
            //Creats a random number
            Random rng = new Random();
            //New instance of an Upgrade
            Upgrade upgrade;

            //If rng is equal to 1
            if (rng.Next(0, 3) == 1)
                //Creats a SCale Up Upgrade
                upgrade = new Upgrade(100 * rng.Next(6, 16), 100 * rng.Next(3, 9), "Scaler", "Images/Upgrades/ScaleUp.png");
            //else. . .
            else
                //Creats a child that player can later inharate
                upgrade = new Upgrade(100 * rng.Next(6, 16), 100 * rng.Next(3, 9), "Adaption", "Images/Upgrades/Adaption.png");
            //Add actor to the scene
            SceneManager.AddActor(upgrade);
        }
        
        /// <summary>
        /// Counts down delta time until it reaches the time desired 
        /// to spawn the next upgrade
        /// </summary>
        /// <param name="deltaTime"></param>
        private void SpawnTimer(float deltaTime)
        {
            //If timer is greater or equal to the spawn rate 
            if (_timer >= _spawnRate)
            {
                //creaats an upgrade 
                SpawningUpgrades();
                //Sets timer back to being 0
                _timer = 0;
            }
            //Adds delta time to the timer
            _timer += deltaTime;
        }

    }
}
