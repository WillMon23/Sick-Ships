﻿using System;
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



        public int TotalSpawning { get { return _totalSpawning; } set { _totalSpawning = value; } }

        public Actor Coping { get { return _coping; } private set { _coping = value; } }
        public EnemySpawner(int totalSpawning) : base(0, 0, "Spawner","")
        {
            _totalSpawning = totalSpawning;
        }

        public override void Start()
        {

            Random rng = new Random();
            base.Start();

            Enemy enemy1 = new Enemy(1300, 100 * rng.Next(-1 , 10), 50, "Enemy");
            SceneManager.AddActor(enemy1);

            Enemy enemy2 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            SceneManager.AddActor(enemy2);

            Enemy enemy3 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            SceneManager.AddActor(enemy3);

            Enemy enemy4 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            SceneManager.AddActor(enemy4);

            Enemy enemy5 = new Enemy(1300, 100 * rng.Next(-1, 10), 50, "Enemy");
            SceneManager.AddActor(enemy5);
        }

        public override void Update(float deltaTime)
        {
            Enemy _enemy; 

            Random rng = new Random();
            

            if (_coolDown >= .5f)
            {
                if (_counter < TotalSpawning)
                {
                    _enemy = new Enemy(1500, 100 * rng.Next(0, 9), 35, "Enemy");
                    SceneManager.AddActor(_enemy);
                }
                _coolDown = 0;
                _counter++;
            }

            _coolDown += deltaTime;

            base.Update(deltaTime);

        }
    }
}