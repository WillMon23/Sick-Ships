using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class UpgradeSpawner : Actor
    {
        private float _timer = 0;

        private float _spawnRate = 0;

        public UpgradeSpawner(float spawnRate) : base(0, 0, "UpgradeSpawner", "") 
        {
            _spawnRate = spawnRate;
        }

        public override void Update(float deltaTime)
        {
            if (_timer >= _spawnRate)
            {
                SpawningUpgrades();
                _timer = 0;
            }
            _timer += deltaTime;

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

    }
}
