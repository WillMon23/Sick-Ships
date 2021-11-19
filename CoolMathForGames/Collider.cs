using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    enum ColliderType
    {
        CIRCLE,
        AABB
    }

    class Collider 
    {
        private Actor _owner;
        private ColliderType _colliderType;

        public ColliderType ColliderType { get { return _colliderType; } }

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
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
                return CheckCollisionCircle((CircleCollider)other.Collider);

            else if (other.Collider.ColliderType == ColliderType.AABB)
                return CheckCollisionAABB((AABBCollider)other.Collider);

            return false;
        }

        public virtual bool CheckCollisionCircle(CircleCollider other) { return false; }

        public virtual bool CheckCollisionAABB(AABBCollider other) { return false; }

        public virtual void Draw()
        {

        }
    }

    
}
