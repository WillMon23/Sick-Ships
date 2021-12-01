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

        public static bool _enemiesDied = false;

        /// <summary>
        /// Keeps tabs on how many enemies have been created 
        /// </summary>
        public static int EnemyCounter { get { return _enemyCounter; } set { _enemyCounter = value; } }

        /// <summary>
        /// MAkes sure to keep track of the main instance of the users player
        /// </summary>
        public static Player Player { get { return _player; } set { _player = value; } }

        public static void Update()
        {
        }
    }

   
}
