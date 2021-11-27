using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    //Simulates a planet in rotstion 
    class Planet : Actor
    {
        /// <summary>
        /// Wiether it can rotate or not
        /// </summary>
        private bool _rotate;
        public Planet(float x, float y, string name = "Planet", string path = "", bool rotate = true) : base(x, y, name, path)
        {
            _rotate = rotate;
        }

        public override void Update(float deltaTime)
        {
            RotationCheck(deltaTime);
            base.Update(deltaTime);
        }

        /// <summary>
        /// Checks the condition for the rotation based on the rotation it'll rotate 
        /// the plante on the radii by using delta time 
        /// </summary>
        /// <param name="deltaTime">delta Time</param>
        private void RotationCheck(float deltaTime)
        {
            //if rotation is true 
            if (_rotate)
                // if name is  not Planet
                if (Name != "Planet")
                    //Rotate cloack wise 
                    Rotate(deltaTime);
                else
                    //Rotates counter clock wise
                    Rotate(-deltaTime);
        }
    }
}
