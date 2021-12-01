using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class EnemySpawner : Actor
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


        /// <summary>
        /// Amount going to me replacated 
        /// </summary>
        public int TotalSpawning { get { return _totalSpawning; } set { _totalSpawning = value; } }

        public EnemySpawner(int totalSpawning) : base(0, 0, "Spawner","")
        {
            _totalSpawning = totalSpawning;
        }

        public override void Start()
        {
            //Creats an Random variable used to give a diffrnece in location
            Random rng = new Random();
            base.Start();

            //Creats a atarting instance of an enemy
            Enemy enemy1 = new Enemy(1300, 100 * rng.Next(-1 , 10), 50, "Enemy");
            //Adds enemy to the scene
            SceneManager.AddActor(enemy1);
            //Creats a atarting instance of an enemy
            Enemy enemy2 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            //Adds enemy to the scene
            SceneManager.AddActor(enemy2);
            //Creats a atarting instance of an enemy
            Enemy enemy3 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            //Adds enemy to the scene
            SceneManager.AddActor(enemy3);
            //Creats a atarting instance of an enemy
            Enemy enemy4 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            //Adds enemy to the scene
            SceneManager.AddActor(enemy4);
            //Creats a atarting instance of an enemy
            Enemy enemy5 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            //Adds enemy to the scene
            SceneManager.AddActor(enemy5);
        }

        /// <summary>
        /// Updates once per frame
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //Spawns Enemy to the scene
            SpawnEnemys(deltaTime);
            //Does the base update of actor
            base.Update(deltaTime);

        }

        /// <summary>
        /// Creats a new instance of an enemy every update
        /// based on how much can be created at a time
        /// </summary>
        /// <param name="deltaTime"></param>
        private void SpawnEnemys(float deltaTime)
        {
            //Declaring an emey instance 
            Enemy _enemy;
            //An Instance of a random generating 
            Random rng = new Random();

            //If Cooldown is greater then 5 seconds 
            if (_coolDown >= .5f)
            {   // if the counter is less then the total spawner. . . 
                if (_counter < TotalSpawning)
                {
                    //creat a new instance of an enemy with a random location 
                    _enemy = new Enemy(1500, 100 * rng.Next(0, 9), 35, "Enemy");
                    //Adds the enemy to the scene
                    SceneManager.AddActor(_enemy);
                }
                //Resets the timer back  to 0 
                _coolDown = 0;
                //Adds to the count of enemies
                _counter++;
            }
            //ADds deltat time to the coool down timer
            _coolDown += deltaTime;
        }
    }
}
