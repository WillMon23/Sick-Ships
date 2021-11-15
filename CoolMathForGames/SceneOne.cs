using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class SceneOne : Scene
    { 

        public override void Start()
        {
            base.Start();


            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(200, 200);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);

            Upgrades scaler = new Upgrades(700, 700, "Scaler", "Images/Upgrades/Adaption.png");

            Bullet bullet = new Bullet(700, 300);

            //EnemySpawner();

            sun.AddChild(earth);
            earth.AddChild(moon);

            AddActor(sun);
            AddActor(earth);
            AddActor(moon);

            AddActor(bullet);


            AddActor(SceneManager.Player);

            AddActor(scaler);
        }
    }
}
