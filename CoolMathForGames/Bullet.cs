using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Bullet : Actor
    {
        private Actor _handler;

        private float _speed;

        private float _lifeSpan;

        public Actor Handler { get { return _handler; } set { _handler = value; } } 

        public float Speed { get { return _speed; }  set { _speed = value; } }
        /// <summary>
        /// Classifications of what a bullet is
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="handler"></param>
        public Bullet(float x, float y, float speed, string name = "Bullet", string path = "Images/bullet.png", Actor handler = null) : base(x, y, name, path)
        {
            _handler = handler;
            _speed = speed;
        }

        public override void Start()
        {
            base.Start();

            if (Handler != null)
                Forward = Handler.Forward;
            

            SetScale(50, 50);
            CircleCollider circleCollider = new CircleCollider(20,this);
            Collider = circleCollider;
        }

        public override void Update(float deltaTime)
        {
            //Changes current local position times that by the set speed and delta time
            LocalPosition += Forward.Normalzed * Speed * deltaTime;
            // actors base update 
            base.Update(deltaTime);
            // if the life span has passed moore than 10 seconds. . .
            if(_lifeSpan >= 10f)
            {
                // . . . Removes this actor 
                SceneManager.RemoverActor(this);
                // . . . Restes the timer back to 0
                _lifeSpan = 0;
            }    
            // adds cuurent time by delta time 
           _lifeSpan += deltaTime; 
        }

        public override void Draw()
        {
            base.Draw();
            //Collider.Draw();
        }

        /// <summary>
        /// checks for collisions with other actors 
        /// </summary>
        /// <param name="actor"></param>
        public override void OnCollision(Actor actor)
        {
            // If actor is named PlayerBullet. . . 
            if (actor.Name == "PlayerBullet")
            {
                // . . .Removes this actor from the scene 
                SceneManager.RemoverActor(this);
                // . . . if not removed already it's also removes the other actor
                SceneManager.RemoverActor(actor);
                
            }
            // if actor is named Player. . .
            if (actor.Name == "Player")
                // . . . Removes this actor
                SceneManager.RemoverActor(this);

            // if actor is named Enemy . . . 
            if (actor.Name == "Enemey")
                // . . . Removes this actor 
                SceneManager.RemoverActor(this);

        }
    }
}
