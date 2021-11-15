using System;
using System.Collections.Generic;
using System.Text;

namespace Sick_Ship
{
    class GameManager
    {
        private static Player _player;

        public static int _enemyCounter;

        public static int EnemyCounter { get { return _enemyCounter; } set { _enemyCounter = value; } }

        public static Player Player
        {
            get { return new Player(200, 800, 500, "Player", "Images/player.png"); }
            set
            {
                _player = value;
            }
        }
    }
}
