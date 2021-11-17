using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace Sick_Ship
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;

        /// <summary>
        /// The wide of the collison box 
        /// </summary>
        public float Width { get { return _width; } set { _width = value; } }

        /// <summary>
        /// The height of the collision box 
        /// </summary>
        public float Height { get { return _height; } set { _height = value; } }

        /// <summary>
        /// Furthest opposing Left 
        /// </summary>
        public float Left { get { return Owner.WorldPosition.X - (Height / 2) ; } }

        /// <summary>
        /// Furthest opposing Right
        /// </summary>
        public float Right { get { return Owner.WorldPosition.X + (Height / 2); } }

        /// <summary>
        /// Furthest opposing Top
        /// </summary>
        public float Top { get { return Owner.WorldPosition. Y - (Width / 2); } }

        /// <summary>
        /// Furthest opposing Bottom
        /// </summary>
        public float Bottom { get { return Owner.WorldPosition.Y + (Width / 2); } }


        public AABBCollider(float width, float height, Actor owner) : base(owner, ColliderType.AABB)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Creatas a space based on the width and height 
        /// to check for collision 
        /// </summary>
        /// <param name="other">WHose being collided with</param>
        /// <returns>In case there is a collision with the other </returns>
        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Checks collision with it self
            if (other.Owner == Owner)
                return false;
            // Returns true if there is a overlap
            if(other.Left <= Right &&
                other.Top <= Bottom &&
                Left <= other.Right &&
                Top <= other.Bottom)
            {
                return true;
            }

            // returns false if there is no overlap
            return false;
        }

        /// <summary>
        /// Checks the other collision and just checks if it 
        /// collided with someone else 
        /// </summary>
        /// <param name="other"> Otherer collision</param>
        /// <returns></returns>
        public override bool CheckCollisionCircle(CircleCollider other)
        {
            return other.CheckCollisionAABB(this);
        }

        /// <summary>
        /// Debug purposum 
        /// Draws a square around the actor if they hace a 
        /// square collider
        /// </summary>
        public override void Draw()
        {
            Raylib.DrawRectangleLines((int)Left, (int)Top, (int)Width, (int)Height, Color.GREEN);
        }

    }


}
