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
        private int _lives = 1;

        private bool _scaledUp;

        Phase _currentPhase = Phase.FIRSTPHASE;

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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_T))
                _lives += 20;
                


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

        // Set tigger for collsion
        public override void OnCollision(Actor actor)
        {
            // if actor name is Ennemybullet. . . 
            if (actor.Name == "EnemyBullet")
            {
                //Remove that actor from the scene 
                SceneManager.RemoverActor(actor);
                // this is scaled up. . . 
                if (_scaledUp)
                {
                    //Set the scale to 100 hieght and 100 width
                    SetScale(100, 100);
                    // sets scale to false
                    _scaledUp = false;
                }
                // else . . .
                else
                {
                    // if current phase equals Third Phase. . .
                    if (_currentPhase == Phase.THIRDPHASE)
                    {
                        // . . .Removes the right side as a child 
                        RemoveChild(_rightHandSide);
                        //. . . Removes right hand side as an actor
                        SceneManager.RemoverActor(_rightHandSide);
                        //. . . changes current phase to 
                        _currentPhase = Phase.SECONDPHASE;


                    }
                    // else if current phase equals Ssecond Phase. . .
                    else if (_currentPhase == Phase.SECONDPHASE)
                    {
                        // . . . removes left hand side actor 
                        RemoveChild(_leftHandSide);
                        // . . . Removes left hand side actor from the scene
                        SceneManager.RemoverActor(_leftHandSide);
                        // . . . Changes current scene to be First Phase
                        _currentPhase = Phase.FIRSTPHASE;
                    }
                    // else if current phase is equal to First phase or 
                    else if (_currentPhase == Phase.FIRSTPHASE && !_scaledUp)
                    { 
                        _currentPhase = Phase.DEADPHASE;
                    }
                    
                }
                //. . . removes reduces lives by 1
                _lives--;
            }
            if (actor.Name == "Scaler")
            {
                if (!_scaledUp)
                {
                    _lives++;
                    SetScale(200, 200);
                    _scaledUp = true;
                }

                SceneManager.RemoverActor(actor);
            }
            if (actor.Name == "Adaption")
            {
                SceneManager.RemoverActor(actor);
                if (_currentPhase == Phase.FIRSTPHASE)
                {
                    _lives++;
                    SceneManager.AddActor(_leftHandSide);
                    AddChild(_leftHandSide);
                    _currentPhase = Phase.SECONDPHASE;
                }
                else if (_currentPhase == Phase.SECONDPHASE)
                {
                    _lives++;
                    SceneManager.AddActor(_rightHandSide);
                    AddChild(_rightHandSide);
                    _lives++;
                    _currentPhase = Phase.THIRDPHASE; 
                }
                
            }

        }

        /// <summary>
        /// Draws to Raylib once per frame 
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            //Collider.Draw();
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
