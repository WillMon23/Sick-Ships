using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    /// <summary>
    /// Keeeps track pf key functionality im or
    /// to refer to them in one instance 
    /// </summary>
    class GameManager
    {
        private static Player _player;

        public static int _enemyCounter = 0;

        public static int EnemyCounter { get { return _enemyCounter; } set { _enemyCounter = value; } }

        public static Player Player { get { return _player; } set { _player = value; } }

        public static void Update()
        {
            
        }
    }

   
}
