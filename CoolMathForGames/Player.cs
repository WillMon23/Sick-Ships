using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
{
 
    class Player : Actor
    {
        public enum Phase
        {
            DEADPHASE,
            FIRSTPHASE,
            SECONDPHASE,
            THIRDPHASE

        }

        private static float _speed;
        private Vector2 _volocity;
        private float _coolDown;
        private int _lives;

        private bool _scaledUp;

        Phase _phase = Phase.FIRSTPHASE;

        ShipUpgrade  _leftHandSide;

        ShipUpgrade _rightHandSide;

        
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
            SetScale(100, 100);
            AABBCollider playerBoxCollider = new AABBCollider(100, 100, this);
            Collider = playerBoxCollider;
            _coolDown = 0;

            _scaledUp = false;

            _lives = 1;

            _leftHandSide = new ShipUpgrade(.5f, -.5f);
            _rightHandSide = new ShipUpgrade(.5f, .5f);
        }

        /// <summary>
        /// Update raylib once perframe
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {

            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && _coolDown > .5f)
            {
                ShootAShot();
                _coolDown = 0;
            }
            _coolDown += deltaTime;




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

            LocalPosition += Volocity;

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor.Name == "EnemyBullet")
            {
                SceneManager.RemoverActor(actor);
                if (_scaledUp)
                {
                    SetScale(100, 100);
                    _scaledUp = false;
                }
                else
                {
                    if (_phase == Phase.THIRDPHASE)
                    {

                        RemoveChild(_rightHandSide);
                        SceneManager.RemoverActor(_rightHandSide);
                        _phase = Phase.SECONDPHASE;
                        _lives--;

                    }
                    else if (_phase == Phase.SECONDPHASE)
                    {
                        RemoveChild(_leftHandSide);
                        SceneManager.RemoverActor(_leftHandSide);
                        _phase = Phase.FIRSTPHASE;
                        _lives--;
                    }
                    else if (_phase == Phase.FIRSTPHASE && _scaledUp)
                        _phase = Phase.DEADPHASE;
                    
                }
            }
            if (actor.Name == "Scaler")
            {
                if (!_scaledUp)
                {
                    SetScale(200, 200);
                    _scaledUp = true;
                }

                SceneManager.RemoverActor(actor);
            }
            if (actor.Name == "Adaption")
            {
                SceneManager.RemoverActor(actor);
                if (_phase == Phase.FIRSTPHASE)
                {
                    _lives++;
                    SceneManager.AddActor(_leftHandSide);
                    AddChild(_leftHandSide);
                    _phase = Phase.SECONDPHASE;
                }
                else if (_phase == Phase.SECONDPHASE)
                {
                    SceneManager.AddActor(_rightHandSide);
                    AddChild(_rightHandSide);
                    _lives++;
                    _phase = Phase.THIRDPHASE; 
                }
                
            }

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
        /// </summary>sd
        /// <returns></returns>
        public void ShootAShot()
        {
            //Random number genarator 
            Random rng = new Random();

            int chance = rng.Next(1, 5);

            Bullet shot = new Bullet(GlobalTransform.M02, GlobalTransform.M12, (Speed * 2), "PlayerBullet", "Images/Planets/nebula.png", this);

            SceneManager.AddActor(shot);
        }

    }
}
