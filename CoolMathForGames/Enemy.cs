using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
{
    class Enemy : Actor
    {
        /// <summary>
        /// Enemy's Movent Speed 
        /// </summary>
        private float _speed;
        /// <summary>
        /// Direction times the Speed Times Delta Time of the Actor
        /// </summary>
        private Vector2 _volocity;
        /// <summary>
        /// Target that's being targeted 
        /// </summary>
        private bool _target;
        /// <summary>
        /// Timer In between shot or bullets created  
        /// </summary>
        private float _coolDown;
        /// <summary>
        /// Distance from the player that the enemy can see from
        /// </summary>
        private float _lineOfSightRange = 900f;
        /// <summary>
        /// Enemy's Movent Speed 
        /// </summary>
        public float Speed { get { return _speed; } set { _speed = value; } }

        /// <summary>
        /// Direction times the Speed Times Delta Time of the Actor
        /// </summary>
        public Vector2 Volocity { get { return _volocity; } set { _volocity = value; } }

       

        /// <summary>
        /// Enemy decontructor 
        /// What defines to be a enemy 
        /// </summary>
        /// <param name="icon">What it looks like in the console</param>
        /// <param name="x">x cooridinet position</param>
        /// <param name="y">y cooridinet position</param>
        /// <param name="name"> classification</param>
        /// <param name="color">There Color</param>
        public Enemy(float x, float y, float speed,  string name, bool target = false, string path = "Images/enemy.png") : base( x, y, name, path)
        { 
            _speed = speed;
            _target = target;
        }

        /// <summary>
        /// Meant to initalize at the start of the object
        /// </summary>
        public override void Start()
        {
            //Incramnets Game managers Enemy Count 
            GameManager.EnemyCounter++;
            //Starts Base actor class
            base.Start();

            //Sets Forward to be the other side of player 
            Forward = new Vector2( -1 , 0);
            //Defualt Volcity values 
            Volocity = new Vector2 { X = 2, Y = 2 };
            //Sets the Enemies Scale 
            SetScale(50, 50);

            CircleCollider circleCollider = new CircleCollider(50, this);
            Collider = circleCollider;
        }

        public override void Update(float deltaTime)
        {
            Follow(deltaTime);

            ShootShot(deltaTime);

            base.Update(deltaTime);
            
        }

        /// <summary>
        /// Handles what happens when an enemy 
        /// collides with an instance
        /// </summary>
        /// <param name="actor">The collision check with</param>
        public override void OnCollision(Actor actor)
        {
            //If bullet name is PlayerBullet
            if (actor.Name == "PlayerBullet")
            {
                //removes this actor 
                SceneManager.RemoverActor(this);
                //removes the actor that was also collided with
                SceneManager.RemoverActor(actor);

            }
        }

        /// <summary>
        /// Checks the position of the 
        /// target actor and follows it once in reange
        /// </summary>
        /// <returns></returns>
        private bool GetTargetInSight()
        {
                // get the distance from the player local position and this enemies world position then it normalizes it 
                // to get a more scaled down depiction
                Vector2 directionTarget = (GameManager.Player.LocalPosition - WorldPosition).Normalzed;
                
                // Getst he distance from it current state and the player ans subtreacts it then gets the magnitude
                float distance = Vector2.Distance(GameManager.Player.LocalPosition, WorldPosition);
                
                float cosTarget = distance / LocalPosition.Magnitude;

                // Checks to see if it facing at the enemies current forward at a certen distance from the player 
                return (distance < _lineOfSightRange) || Vector2.DotProduct(directionTarget, Forward) < 0;
        }

        /// <summary>
        /// Moves Faster Once in Sight of Player only if the enemy 
        /// have a target to follow
        /// </summary>
        private void Follow(float deltaTime)
        {
            //if there is a target
            if (!_target)
            {
                //Set the volcity from the distance from the players worlds space and this enemy
                Volocity = GameManager.Player.WorldPosition - LocalPosition;
                //If the magnitude is greater then 0. . . 
                if (Volocity.Magnitude > 0)
                    //Set thid enemies Forward to the volocity normalized
                    Forward = Volocity.Normalzed;
                //Add on every update The volocity normalized x 10 (speed) x delta time
                LocalPosition += Volocity.Normalzed * 10 * deltaTime;
                //IF get the target in sight 
                if (GetTargetInSight())
                {
                    //Add on every update The volocity normalized x Speed x 2 x delta time
                    LocalPosition += Volocity.Normalzed * (Speed * 2) * deltaTime;
                }
            }
            else
                //Other then that it just keeps a steady paste 
                LocalPosition += Volocity.Normalzed * Speed * deltaTime;
        }

        /// <summary>
        /// Creats a bullets after meeting the float condition
        /// </summary>
        /// <param name="deltaTime"></param>
        private void ShootShot(float deltaTime)
        {
            //If cool down is greater then 3f. . . 
            if (_coolDown >= 3f)
            {
                //Create an instance of a bullet
                Bullet shot = new Bullet(LocalPosition.X, LocalPosition.Y, Speed * 5, "EnemyBullet", "Images/bullet.png", this);
                // Adds it to the scene
                SceneManager.AddActor(shot);
                //Rests the timer back to being 0
                _coolDown = 0;
            }
            //Adds delta time to cool down on every frame
            _coolDown += deltaTime;
        }

        public override void Draw()
        {
            base.Draw();
            //Collider.Draw();
        }
        /// <summary>
        /// Called after the end of update
        /// </summary>
        public override void End()
        {
            //Deducts from Enemy Counter
            GameManager.EnemyCounter--;
        }


    }
}
