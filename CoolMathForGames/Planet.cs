using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    //Simulates a planet in rotstion 
    class Planet : Actor
    {
        private bool _rotate;
        public Planet(float x, float y, string name = "Planet", string path = "", bool rotate = true) : base(x, y, name, path)
        {
            _rotate = rotate;
        }

        public override void Update(float deltaTime)
        {
            if(_rotate)
                Rotate(-deltaTime);
            base.Update(deltaTime);
        }
    }
}
