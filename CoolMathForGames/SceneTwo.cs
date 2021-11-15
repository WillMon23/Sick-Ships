using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class SceneTwo : Scene
    {
        public override void Start()
        {
            base.Start();


            //Creats thr actors starting position
            Planet sun = new Planet(800, 450, "Sun", "Images/Planets/sun.png");
            sun.SetScale(700, 700);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);

            Spawner EnemySpawner = new Spawner(10);

            AddActor(sun);
            AddActor(earth);
            AddActor(moon);
            sun.AddChild(earth);
            earth.AddChild(moon);

            AddActor(EnemySpawner);

            AddActor(GameManager.Player);

        }
    }
}
