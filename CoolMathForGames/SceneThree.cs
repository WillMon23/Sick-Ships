using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class SceneThree : Scene
    {
        public override void Start()
        {
            base.Start();

            Planet cosmo = new Planet(800, 450, "Cosmo", "Images/Planets/cosmo.png", true);
            cosmo.SetScale(2000, 2000);

            Boss sceneThreeBoss = new Boss(1500, 450, "SceneThreeBoss", "");

            AddActor(cosmo);
        }
    }
}
