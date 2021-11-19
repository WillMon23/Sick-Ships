using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
{
    class CircleCollider : Collider
    {
        private float _collisionRadius;


        public float CollisionRadius { get { return _collisionRadius; } set { _collisionRadius = value; } }
        public CircleCollider(float colldionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = colldionRadius;
        }

        /// <summary>
        /// checks if there has been a collision with another 
        /// actor that also has circle collision
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool CheckCollisionCircle(CircleCollider other)
        {
            // if the other circle collider is it self theen. . . 
            if (other.Owner == Owner)
                //. . .Returns false
                return false;
            // Gets the disatance between two actors by subtracing there locations 
            float distance = Vector2.Distance(other.Owner.LocalPosition, Owner.LocalPosition);

            // Get both radii and adds them up 
            float combinedRadii = other.CollisionRadius + CollisionRadius;
            
            //If the distance from both is less then or equal to the combined radiii returns a bool
            return distance <= combinedRadii;
        }

        /// <summary>
        /// Gets the furthes distance form the square
        /// from the radius from the colliding circle
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool CheckCollisionAABB(AABBCollider other)
        {

            if (other.Owner == Owner)
                return false;
            //Get the direction from this collider to the AABB
            Vector2 direction = Owner.LocalPosition - other.Owner.LocalPosition;

            //Clamp the direction vector to be within the bounds of the AABB
            direction.X = Math.Clamp(direction.X, -other.Width / 2, other.Width / 2);
            direction.Y = Math.Clamp(direction.Y, -other.Height / 2, other.Height / 2);

            //Add the direction vector to the AABB center to get closet point to the circle
            Vector2 closetsPoint = other.Owner.LocalPosition + direction;

            //Find the distance from the circle's center to the closest point
            float distanceFromClosestPoint = Vector2.Distance(Owner.LocalPosition, closetsPoint);

            //Return whether or not distance is less than the circle's radius
            return distanceFromClosestPoint <= CollisionRadius;
        }

        public override void Draw()
        {
            Raylib.DrawCircleLines((int)Owner.LocalPosition.X,(int)Owner.LocalPosition.Y,CollisionRadius,Color.PINK);
        }




    }
}
