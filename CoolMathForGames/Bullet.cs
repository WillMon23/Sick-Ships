using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Bullet : Actor
    {
        public Bullet(float x, float y, string name = "Bullet", string path = "Images/bullet.png") : base(x, y, name, path)
        {

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
            WorldPosition += Forward * 10 * deltaTime;
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
