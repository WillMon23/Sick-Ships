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
            AddActor(sun);

            Planet earth = new Planet(.7f, .7f, "Earth", "Images/Planets/earth.png");
            earth.SetScale(0.3f, 0.3f);
            AddActor(earth);

            Planet moon = new Planet(1f, 1f, "Moon", "Images/Planets/moon.png");
            moon.SetScale(0.3f, 0.3f);
            AddActor(moon);

            Upgrade scaler = new Upgrade(700, 700, "Scaler", "Images/Upgrades/ScaleUp.png");

            Upgrade adaption = new Upgrade(300, 300, "Aption", "Images/Upgrades/Adaption.png");

            UpgradeSpawner upgradeSpawner = new UpgradeSpawner(100, scaler, adaption);
            AddActor(scaler);
            AddActor(adaption);
            

            Spawner EnemySpawner = new Spawner(5);
            AddActor(EnemySpawner);
            
            


            sun.AddChild(earth);
            earth.AddChild(moon);
            
            

            GameManager.Player = new Player(200, 400, 500, "Player", "Images/Rocket.png");
            AddActor(GameManager.Player);

            


        }

        public override void Update(float deltaTime)
        {
            

            for (int i = 0; i < Actors.Length; i++)
            {
                    if (!Actors[i].Alive)
                    {
                        SceneManager.RemoverActor(Actors[i]);
                        Actors[i].End();
                    }
                        
                   
            }
            base.Update(deltaTime);
        }
    }
}
