using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Bullet : Actor
    {
        Actor _handler;

        public Actor Handler { get { return _handler; } set { _handler = value; } } 
        public Bullet(float x, float y, string name = "Bullet", string path = "Images/bullet.png", Actor handler = null) : base(x, y, name, path)
        {
            _handler = handler;
        }

        public override void Start()
        {
            base.Start();
            SetScale(20, 20);
            CircleCollider circleCollider = new CircleCollider(20,this);
            Collider = circleCollider;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if(Handler != null)
            {
                Forward = Handler.Forward;
            }
             
            WorldPosition += Forward * 10 * deltaTime;
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
