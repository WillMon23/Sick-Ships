using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Bullet : Actor
    {

        private Actor _actorHandler;
        private Actor _target;
        private float _lifeSpand; 

        /// <summary>
        /// Collective keeps time on homw much time has passed 
        /// </summary>
        public float TimeCounter { get { return _lifeSpand; } private set { _lifeSpand = value; } }

        public Actor ActorHandler { get { return _actorHandler; } private set { _actorHandler = value; } }

        public Actor Taget { get { return _target; } private set { _target = value; } }
        
        public Bullet(Vector2 position, float timer, Actor actorHandler,string name = "Bullet", string path = "Images/Upgrades/Adaption.png", Actor target = null) : base(position, name, path)
        {
            _lifeSpand = timer;
            _target = target;
            _actorHandler = actorHandler;
        }

        public override void Start()
        {
            base.Start();

            //WorldPosition = Taget.WorldPosition;

            CircleCollider thisCircleCollider = new CircleCollider(20, this);
            Collider = thisCircleCollider;


        }

        public override void Update(float deltaTime)
        {
            WorldPosition += new Vector2(1,0) * 10f * deltaTime;

            Rotate(deltaTime);
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

    }
}
