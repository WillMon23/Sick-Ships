using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Sick_Ship
{
    class ShipUpgrade : Actor
    {
        private float _coolDown = 0;

        public ShipUpgrade(float x, float y): base(x,y, "Upgrades", "Images/player.png")
        {

        }

        public override void Start()
        {
            base.Start();
            CircleCollider circleCollider = new CircleCollider(20, this);
            Collider = circleCollider;
            SetScale(1f, 1f);

            
        }

        public override void Update(float deltaTime)
        {
            Forward = GameManager.Player.Forward;
            base.Update(deltaTime);
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && _coolDown > .5f)
            {
               
                ShootAShot();
                _coolDown = 0;
            }
            _coolDown += deltaTime;
            


        }

        /// <summary>
        /// Creats bullets for the player to shot at there target
        /// </summary>sd
        /// <returns></returns>
        public void ShootAShot()
        {
            //Random number genarator 
            Random rng = new Random();

            int chance = rng.Next(1, 5);

            Bullet shot = new Bullet(GlobalTransform.M02, GlobalTransform.M12, 2000f , "PlayerBullet", "Images/bullet.png", this);
            

            SceneManager.AddActor(shot);
        }
    }
}
