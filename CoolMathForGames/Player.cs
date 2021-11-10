using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace CoolMathForGames
{
    class Player : Actor
    {
        private static float _speed;
        private Vector2 _volocity;
        private int _lives;
        
        public static float Speed { get { return _speed; } set { _speed = value; } }

        public Vector2 Volocity {  get { return _volocity; } set { _volocity = value; } }

        public int Lives {  get { return _lives; } set { _lives = value; } }

        public Player( float x, float y, float speed, string name, string path = "") 
            :base(   x,  y,  name , path)
        {
            _speed = speed;
            
        }

        public override void Start()
        {
            base.Start();
            Volocity = new Vector2 { X = 2, Y = 3 };
            SetScale(100, 50);
        }

        public override void Update(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                ShootAShot();
                



            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A)) 
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W)) 
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            Vector2 moveDirecton = new Vector2(xDirection, yDirection);

            Volocity =  moveDirecton * Speed * deltaTime;

            if (Volocity.Magnitude > 0)
                Forward = Volocity.Normalzed;

            LocalPosition += Volocity;
            
            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {

        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
        
        /// <summary>
        /// Creats bullets for the player to shot at there target
        /// </summary>
        /// <returns></returns>
        public Bullet ShootAShot()
        {
            //Random number genarator 
            Random rng = new Random();

            int chance = rng.Next(1, 5);

            Bullet shot = new Bullet(LocalPosition, 10f, this, "PlayerBullet", "Images/bullet.png");


            return shot;

        }


    }
}
