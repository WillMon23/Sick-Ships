using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace Sick_Ship
{
    class ShipUpgrade : Actor
    {
        /// <summary>
        /// Sets a elaps timer in between each item being created  
        /// </summary>
        private float _coolDown = 0;

        /// <summary>
        /// What defines a Ship upgrade
        /// </summary>
        /// <param name="x">location in the x axes </param>
        /// <param name="y">location in the y axis </param>
        public ShipUpgrade(float x, float y): base(x,y, "Upgrades", "Images/Rocket.png")
        {

        }

        /// <summary>
        /// Intitalizes at the start of the object
        /// </summary>
        public override void Start()
        {
            //Starts the base start for actor
            base.Start();
            //Creats a circle collider with a radius of 20 to this object 
            CircleCollider circleCollider = new CircleCollider(20, this);
            //Sets this collider to the new collider that was just created 
            Collider = circleCollider;
            //Sets it's defult scale
            SetScale(1f, 1f);
        }

        /// <summary>
        /// Updates once per frame 
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        { 
            //Runs Actor Update 
            base.Update(deltaTime);
            //If Space key has been pressed down and cooldown is greater then .5 
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && _coolDown > .5f)
            {
                //Creatas a bullet to shot off from
                Bullet shot = new Bullet(GlobalTransform.M02, GlobalTransform.M12, 2000f, "PlayerBullet", "Images/Planets/nebula.png", GameManager.Player);
                //Adds the shot to be in the scene
                SceneManager.AddActor(shot);
                //Resets timer to be defualt value
                _coolDown = 0;
            }
            //Adds delta time to cooldown every update
            _coolDown += deltaTime;
        }
    }
}
