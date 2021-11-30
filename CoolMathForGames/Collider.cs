using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    /// <summary>
    /// To identify agensts the types of collider
    /// </summary>
    enum ColliderType
    {
        //Circle collider type
        CIRCLE,
        //AABB or square collider
        AABB
    }

    class Collider 
    {
        //The owner of the collision collider
        private Actor _owner;
        //Type of collider this collider has
        private ColliderType _colliderType;

        /// <summary>
        /// Type of collider this collider has
        /// </summary>
        public ColliderType ColliderType { get { return _colliderType; } }

        /// <summary>
        /// The owner of the collision collider
        /// </summary>
        public Actor Owner { get { return _owner; } set { _owner = value; } }

        /// <summary>
        /// Collider deconstructor meant to creata prorameter 
        /// in order to check for collision with it's sorrounding
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="colliderType"></param>
        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        /// <summary>
        /// Checks to see what type of collider it has in 
        /// as well what it's colliding with
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool CheckCollision(Actor other)
        {
            //if the other actor's collider type is a circle 
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
                //return weather there has been a collision with that collider type
                return CheckCollisionCircle((CircleCollider)other.Collider);
            //if the other actor's collider type is a AABB or square 
            else if (other.Collider.ColliderType == ColliderType.AABB)
                //return weather there has been a collision with that collider type
                return CheckCollisionAABB((AABBCollider)other.Collider);
            //If not just returns false
            return false;
        }

        /// <summary>
        /// Created to be overrided later
        /// </summary>
        public virtual bool CheckCollisionCircle(CircleCollider other) { return false; }

        /// <summary>
        /// Created to be overrided later
        /// </summary>
        public virtual bool CheckCollisionAABB(AABBCollider other) { return false; }

        /// <summary>
        /// Created to be overrided later
        /// </summary>
        public virtual void Draw()
        {

        }
    }

    
}
