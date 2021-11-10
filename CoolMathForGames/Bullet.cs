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
        private float _timeCounter; 

        /// <summary>
        /// Collective keeps time on homw much time has passed 
        /// </summary>
        public float TimeCounter { get { return _timeCounter; } private set { _timeCounter = value; } }

        public Actor ActorHandler { get { return _actorHandler; } private set { _actorHandler = value; } }

        public Actor Taget { get { return _target; } private set { _target = value; } }
        
        public Bullet(Vector2 position, float timer, Actor actorHandler,string name = "Planet", string path = "", Actor target = null) : base(position, name, path)
        {
            _timeCounter = timer;
            _target = target;
            _actorHandler = actorHandler;
        }

        public override void Start()
        {
            base.Start();

            CircleCollider thisCircleCollider = new CircleCollider(10, this);
            Collider = thisCircleCollider;

        }

        public override void Update(float deltaTime)
        {
            Forward = ActorHandler.Forward;

            LocalPosition += Forward * 10f * deltaTime;

            Rotate(deltaTime);
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

    }
}
