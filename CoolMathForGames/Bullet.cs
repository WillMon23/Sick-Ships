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
            

            SetScale(20, 20);
            CircleCollider circleCollider = new CircleCollider(20,this);
            Collider = circleCollider;
        }

        public override void Update(float deltaTime)
        {
            
            LocalPosition += Forward.Normalzed * Speed * deltaTime;
            base.Update(deltaTime);

            if(_lifeSpan >= 10f)
            {
                SceneManager.RemoverActor(this);
                _lifeSpan = 0;
            }    
           _lifeSpan += deltaTime; 
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

        public override void OnCollision(Actor actor)
        {
            if (actor.Name == "PlayerBullet")
            {
                SceneManager.RemoverActor(this);
                SceneManager.RemoverActor(actor);
                
            }

            if (actor.Name == "Enemey")
                SceneManager.RemoverActor(this);

        }
    }
}
