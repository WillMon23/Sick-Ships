using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace Sick_Ship
{
    class Upgrade : Actor
    {
        /// <summary>
        /// MAkes a consumable item that enhances players 
        /// ablility and survavability
        /// </summary>
        /// <param name="x">X axes location</param>
        /// <param name="y">y axes location</param>
        /// <param name="name">Name of upgrade</param>
        /// <param name="path">image png location</param>
        public Upgrade(float x, float y, string name, string path) : base(x, y, name, path)
        {
        }

        /// <summary>
        /// Initalize at the start of the object
        /// </summary>
        public override void Start()
        {
            //Calls base start from actor
            base.Start();
            //Creates a circle collider and set its raduis 
            CircleCollider circleCollider = new CircleCollider(20, this);
            //Sets the the collider to be on this object
            Collider = circleCollider;
            //Sets a defeeult scale for this object
            SetScale(50, 50);
        }

        /// <summary>
        /// Updates once per frame 
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            // Sets the location to change once per frame tp gp once on the X axis x 20f x delta Time 
            LocalPosition += new Vector2(-1, 0) * 20f * deltaTime;
            //Changes the rottion on every update excahnge based on the cosnoles bite rate 
            Rotate(deltaTime);
            //Calls base update from actor
            base.Update(deltaTime);
        }

        /// <summary>
        /// What reactio happens once a collision has acured
        /// </summary>
        /// <param name="actor">Actor that has collided with this obejct</param>
        public override void OnCollision(Actor actor)
        {
            //If actor is named 'Player'. . . 
            if (actor.Name == "Player")
                // Remove this actor from the scene
                SceneManager.RemoverActor(this);
        }
    }
}