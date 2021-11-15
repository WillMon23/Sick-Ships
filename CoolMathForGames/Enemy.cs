using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
{
    class Enemy : Actor
    {

        private float _speed;

        private Vector2 _volocity;

        private Actor _target;

        private float _lineOfSightRange = 200f;

        private bool _alive = true;

        int _tally;

        public float Speed { get { return _speed; } set { _speed = value; } }

        public Vector2 Volocity { get { return _volocity; } set { _volocity = value; } }

        public bool Alive { get { return _alive; } }

        /// <summary>
        /// Enemy Contructor 
        /// What defines to be a enemy 
        /// </summary>
        /// <param name="icon">What it looks like in the console</param>
        /// <param name="x">x cooridinet position</param>
        /// <param name="y">y cooridinet position</param>
        /// <param name="name"> classification</param>
        /// <param name="color">There Color</param>
        public Enemy(float x, float y, float speed,Actor target, string name,  string path = "") : base( x, y, name, path)
        {
            _speed = speed;
            _target = target;
        }

        public override void Start()
        {
            base.Start();

            SceneManager.EnemyCounter++;

            _tally = 0;
            Volocity = new Vector2 { X = 2, Y = 2 };
            SetScale(50, 50);

            CircleCollider circleCollider = new CircleCollider(50, this);
            Collider = circleCollider;
        }

        public override void Update(float deltaTime)
        {
            if (_target != null)
            {
                Volocity = _target.WorldPosition - WorldPosition;

                if (Volocity.Magnitude > 0)
                    Forward = Volocity.Normalzed;

                WorldPosition += Volocity.Normalzed * 10 * deltaTime;

                if (GetTargetInSight())
                {
                    WorldPosition += Volocity.Normalzed * (Speed * 2) * deltaTime;
                    Bullet shot = new Bullet(WorldPosition.X, WorldPosition.Y);
                    CircleCollider circleCollider = new CircleCollider(20, shot);
                    shot.Collider = circleCollider;
                    SceneManager.AddActor(shot);
                }
            }
            else
                WorldPosition += Volocity.Normalzed * Speed * deltaTime;
                 

            base.Update(deltaTime);
            
        }
        public override void OnCollision(Actor actor)
        {
            if (actor.Name == "PlayerBullet")
            {
                //_alive = false;
            }
        }

        /// <summary>
        /// If the 
        /// </summary>
        /// <returns></returns>
        private bool GetTargetInSight()
        {
            
                Vector2 directionTarget = (_target.LocalPosition - WorldPosition).Normalzed;

                float distance = Vector2.Distance(_target.LocalPosition, WorldPosition);

                float cosTarget = distance / WorldPosition.Magnitude;

                return /*cosTarget < _lineOfSightRange && */(distance < _lineOfSightRange) || Vector2.DotProduct(directionTarget, Forward) < 0;
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

        public override void End()
        {
            base.End();
            SceneManager.EnemyCounter--;
        }


    }
}
