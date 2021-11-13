using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
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
            SetScale(50, 50);
        }

        /// <summary>
        /// Update raylib once perframe
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))  
                 ShootAShot();


            //Check if a particular input has been press
            //Then returns 0, 1 or -1 if it was pressed or released
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A)) 
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W)) 
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            // Places the direction in a new vector 2 for every update
            Vector2 moveDirecton = new Vector2(xDirection, yDirection);

            Volocity =  moveDirecton * Speed * deltaTime;

            if (Volocity.Magnitude > 0)
                Forward = Volocity.Normalzed;

            WorldPosition += Volocity;
            
            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {

        }

        /// <summary>
        /// Draws to Raylib once per frame 
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
        
        /// <summary>
        /// Creats bullets for the player to shot at there target
        /// </summary>
        /// <returns></returns>
        public void  ShootAShot()
        {
            //Random number genarator 
            Random rng = new Random();

            int chance = rng.Next(1, 5);

            Bullet shot = new Bullet(new Vector2(WorldPosition.X, WorldPosition.Y), 10f, this, "PlayerBullet", "Images/bullet.png");
            shot.SetScale(50, 50);

            SceneManager.AddActor(shot);
        }


    }
}
