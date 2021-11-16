using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class UpgradeSpawner : Actor
    {
        private Upgrade[] _upgrades;

        private int _spawnAmount;

        public Upgrade[] Upgrades { get { return _upgrades; } private set { _upgrades = value; } }

        public UpgradeSpawner(int spawnAmount, params Upgrade[] upgrades) : base(0, 0, "Spawner", "")
        {
            _spawnAmount = spawnAmount;
            _upgrades = upgrades;
        }



        public override void Start()
        {
            Random rng = new Random();
            foreach (Upgrade upgrade in Upgrades)
                    SceneManager.AddActor(upgrade);
                
        }
    }
}
