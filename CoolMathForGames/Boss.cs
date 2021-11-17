using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class Boss : Actor
    {
        public Boss(float x, float y, string name = "Boss", string path = "" ): base(x, y, name, path) { }

        public override void Start()
        {
            base.Start();
            SetScale(1000, 1000);
        }
    }

}
