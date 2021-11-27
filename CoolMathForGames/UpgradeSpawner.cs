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
            Random rng = new Random();

            Upgrade upgrade;

            if (rng.Next(0, 3) == 1)
                upgrade = new Upgrade(100 * rng.Next(6, 16), 100 * rng.Next(3, 9), "Scaler", "Images/Upgrades/ScaleUp.png");

            else
                upgrade = new Upgrade(100 * rng.Next(6, 16), 100 * rng.Next(3, 9), "Adaption", "Images/Upgrades/Adaption.png");

            SceneManager.AddActor(upgrade);
        }
        
        /// <summary>
        /// Counts down delta time until it reaches the time desired 
        /// to soawn the next upgrade
        /// </summary>
        /// <param name="deltaTime"></param>
        private void SpawnTimer(float deltaTime)
        {
            if (_timer >= _spawnRate)
            {
                SpawningUpgrades();
                _timer = 0;
            }
            _timer += deltaTime;
        }

    }
}
