using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class Spawner : Actor
    {
        /// <summary>
        /// Amount going to me replacated 
        /// </summary>
        private int _totalSpawning;

        /// <summary>
        /// THe acotr that is being replacated 
        /// </summary>
        private Actor _coping;

        /// <summary>
        /// Sets a cooldown til the next spawn
        /// </summary>
        private float _coolDown = 0;

        /// <summary>
        /// Keeping tabs on how many have spawned at a time 
        /// </summary>
        private float _counter = 0;



        public int TotalSpawning { get { return _totalSpawning; } set { _totalSpawning = value; } }

        public Actor Coping { get { return _coping; } private set { _coping = value; } }
        public Spawner(int totalSpawning) : base(0, 0, "Spawner","")
        {
            _totalSpawning = totalSpawning;
        }


        public override void Update(float deltaTime)
        {

            Random rng = new Random();
            Enemy enemy = new Enemy(0, 0, 0, "Defult");
            base.Update(deltaTime);

            _coolDown += deltaTime;

            

            if (_coolDown >= 1000)
            {
                if(_counter <= TotalSpawning)
                    enemy = new Enemy(1500, 100 * rng.Next(0,9), 35, "Enemy", GameManager.Player);
                SceneManager.AddActor(enemy);
                _coolDown = 0;
                _counter++;
            }

        }
    }
}
