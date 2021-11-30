using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Boss : Actor
    {
        //Keeps tab of where the boss started from
        private Vector2 _startPosition;

        //Fow fast the movemnt of the enemy 
        private float _freguency = 800F;
        //Distance from the wabble 
        private float _magnitude = 100f;

        private float _offset = 1f;
        //Timer for every shoot 
        private float _coolDown = 0;

        public Boss(float x, float y, string name = "Boss", string path = "" ): base(x, y, name, path) { }

        //Initalizes at the start of the actor
        public override void Start()
        {
            base.Start();
            SetScale(500, 500);
            _startPosition = LocalPosition;
            Forward = new Vector2(-1, 0);
            AABBCollider BossBoxCollider = new AABBCollider(400, 400, this);
            Collider = BossBoxCollider;

        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //Shakes the bosses location
            LocalPosition = _startPosition + new Vector2(0, -1) * (float)Math.Cos(deltaTime * _freguency + _offset) * _magnitude;

            ShootsFired();


            _coolDown += deltaTime;
        }

        public override void Draw()
        {
            base.Draw();
            //Collider.Draw();
        }

        /// <summary>
        /// Creats bullets to create an obstical to player
        /// </summary>
        private void ShootsFired()
        {
            if (_coolDown >= .3f)
            {
                Bullet shot1 = new Bullet(LocalPosition.X, LocalPosition.Y + 200, 500, "EnemyBullet", "Images/bullet.png", this);
                SceneManager.AddActor(shot1);

                Bullet shot2 = new Bullet(LocalPosition.X, LocalPosition.Y, 500, "EnemyBullet", "Images/bullet.png", this);
                SceneManager.AddActor(shot2);

                Bullet shot3 = new Bullet(LocalPosition.X, LocalPosition.Y - 200, 500, "EnemyBullet", "Images/bullet.png", this);
                SceneManager.AddActor(shot3);
                _coolDown = 0;
            }
        }
    }

}
