using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
{
 
    class Player : Actor
    {
        /// <summary>
        /// Creats states for the player 
        /// </summary>
        public enum Phase
        {
            FIRSTPHASE,
            SECONDPHASE,
            THIRDPHASE

        }

        /// <summary>
        /// The speed mommnetom in witch the player moves
        /// </summary>
        private static float _speed;
        /// <summary>
        /// Direction x Speed x delta Time
        /// </summary>
        private Vector2 _volocity;
        /// <summary>
        /// Times between each bullet that gets shot out by
        /// the player
        /// </summary>
        private float _coolDown;
        /// <summary>
        /// Amount of lives held by the player 
        /// </summary>
        private int _lives = 1;
        /// <summary>
        /// Checks weither the player has gotten bigger or not
        /// </summary>
        private bool _scaledUp;
        /// <summary>
        /// Current phase of the player
        /// </summary>
        Phase _currentPhase = Phase.FIRSTPHASE;
        /// <summary>
        /// Upgrade ship placed on the left hand side
        /// </summary>
        ShipUpgrade  _leftHandSide;
        /// <summary>
        /// Upgrade ship located on the right hand side
        /// </summary>
        ShipUpgrade _rightHandSide;

        /// <summary>
        /// The speed mommnetom in witch the player moves
        /// </summary>
        public static float Speed { get { return _speed; } set { _speed = value; } }

        /// <summary>
        /// Direction x Speed x delta Time
        /// </summary>
        public Vector2 Volocity {  get { return _volocity; } set { _volocity = value; } }

        /// <summary>
        /// Amount of lives held by the player 
        /// </summary>
        public int Lives {  get { return _lives; } set { _lives = value; } }

        /// <summary>
        /// Initalized state of the player
        /// </summary>
        /// <param name="x">x location</param>
        /// <param name="y">y location</param>
        /// <param name="speed">speed mommnetom</param>
        /// <param name="name">the players name</param>
        /// <param name="path">sprite path</param>
        public Player( float x, float y, float speed, string name, string path = "") 
            :base(   x,  y,  name , path)
        {
            _speed = speed;
        }

        /// <summary>
        /// Creates at thw start of the players Update 
        /// </summary>
        public override void Start()
        {
            // Actors base start update
            base.Start();
            //Sets players scale
            SetScale(100, 100);
            //Creats an instance of the players ox collision
            AABBCollider playerBoxCollider = new AABBCollider(75, 75, this);
            //Sets the type of collision to the player
            Collider = playerBoxCollider;
            //Sets the cooldown to be 0 at start of the update 
            _coolDown = 0;
            //Player is pree set to false at start 
            _scaledUp = false;
            // Initalizes the ship upgrade to the left hand side of the player 
            _leftHandSide = new ShipUpgrade(.5f, -.5f);
            // Initalizes the ship to the right hand side of the player
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

            //Adds an addition to help for debug use
            if (Raylib.IsKeyDown(KeyboardKey.KEY_T))
                _lives += 100;
                

            // Adds delta time to _coolDown
            _coolDown += deltaTime;

            //Check if a particular input has been press
            //Then returns 0, 1 or -1 if it was pressed or released
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A)) 
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W)) 
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            // Places the direction in a new vector 2 for every update
            Vector2 moveDirecton = new Vector2(xDirection, yDirection);

            //Set the volocity to be the direction on which the player wants to move by the speed times delta time 
            Volocity =  moveDirecton * Speed * deltaTime;

            // IF Volocity magnitude is less then 0
            if (Volocity.Magnitude > 0)
                //Set the forwars to be the volocity normalized
                Forward = Volocity.Normalzed;
            // Add the volocity to the local posistion every frame
            LocalPosition += Volocity;
            //Does actors base update
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
                    
                }
                //. . . removes reduces lives by 1
                _lives--;
            }
            // if actor is named Scaler. . . 
            if (actor.Name == "Scaler")
            {
                //if not scaled up. . .
                if (!_scaledUp)
                {
                    // add a live to the player
                    _lives++;
                    //set the player scale to be 200 width 200 height
                    SetScale(200, 200);
                    //Set the player scale up to be true
                    _scaledUp = true;
                }
                //Remove the actor that collided with player
                SceneManager.RemoverActor(actor);
            }
            //If the actor is named Adaption
            if (actor.Name == "Adaption")
            {
                //if the current phase is set FirstPhase
                if (_currentPhase == Phase.FIRSTPHASE)
                {
                    //Add a life to player
                    _lives++;
                    //Add _leftHandSide to the scene
                    SceneManager.AddActor(_leftHandSide);
                    // Make _leftHandSide a chid of the player
                    AddChild(_leftHandSide);
                    //Sets player current phase to be SecondPhase
                    _currentPhase = Phase.SECONDPHASE;
                }
                //else if the current phase is set to the second phase 
                else if (_currentPhase == Phase.SECONDPHASE)
                {
                    //ass a life to the player
                    _lives++;
                    //adds the actor _rightHandSide to the scene 
                    SceneManager.AddActor(_rightHandSide);
                    //Makes the _rightHandSide to ba child of the player
                    AddChild(_rightHandSide);
                    _currentPhase = Phase.THIRDPHASE; 
                }
                //Removed the actor that was collided with
                SceneManager.RemoverActor(actor);
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
            // Picks a number in between 1 and 5
            int chance = rng.Next(1, 5);

            //Creats a new instance of a bullet
            Bullet shot = new Bullet(GlobalTransform.M02, GlobalTransform.M12, (Speed * 2), "PlayerBullet", "Images/Planets/nebula.png", this);
            //Adds shot to the scene
            SceneManager.AddActor(shot);
        }

    }
}
