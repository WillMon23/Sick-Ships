using System;
using System.Collections.Generic;
using System.Text;

namespace CoolMathForGames
{
    class Bullet : Actor
    {


        private float _timeCounter; 

        /// <summary>
        /// Collective keeps time on homw much time has passed 
        /// </summary>
        public float TimeCounter { get { return _timeCounter; } private set { _timeCounter = value; } }
        
        public Bullet(float x, float y, float timer,  string name = "Planet", string path = "") : base(x, y, name, path)
        {
            _timeCounter = timer;
        }

        public override void Update(float deltaTime)
        {
            Rotate(deltaTime);
        }
    }
}
