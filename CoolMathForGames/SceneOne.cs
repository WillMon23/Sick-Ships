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

            Upgrades scaler = new Upgrades(700, 700, "Scaler", "Images/Upgrades/Adaption.png");
            CircleCollider circleCollider = new CircleCollider(20, scaler);
            scaler.Collider = circleCollider;

            Spawner EnemySpawner = new Spawner(5);
            AddActor(EnemySpawner);


            sun.AddChild(earth);
            earth.AddChild(moon);
            
            

            GameManager.Player = new Player(200, 400, 500, "Player", "Images/player.png");
            AddActor(GameManager.Player);

            AddActor(scaler);


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
