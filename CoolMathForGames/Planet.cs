using System;
using System.Collections.Generic;
using System.Text;

namespace CoolMathForGames
{
    class Planet : Actor
    {
        public Planet(float x, float y, string name = "Planet", string path = "") : base(x, y, name, path)
        {

        }

        public override void Update(float deltaTime)
        {
            Rotate(deltaTime);
            base.Update(deltaTime);
        }
    }
}
