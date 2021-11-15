﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Upgrades : Actor
    {
        private Enum _upgradeType;

        /// <summary>
        /// MAkes a consumable item that enhances players 
        /// ablility and survavability
        /// </summary>
        /// <param name="x">X axes location</param>
        /// <param name="y">y axes location</param>
        /// <param name="name">Name of upgrade</param>
        /// <param name="path">image png location</param>
        public Upgrades(float x, float y, string name, string path) : base(x, y, name, path)
        {
        }

        public override void Start()
        {
            base.Start();
            CircleCollider circleCollider = new CircleCollider(20, this);
            Collider = circleCollider;
            SetScale(50, 50);
        }

        public override void Update(float deltaTime)
        {
            
            WorldPosition += new Vector2(1, 0) * 10 * deltaTime;
            Rotate(deltaTime);
            base.Update(deltaTime);


        }

        public override void OnCollision(Actor actor)
        {
            if (Name == "Player")
                SceneManager.RemoverActor(this);
        }
    }
}