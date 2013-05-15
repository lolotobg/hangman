using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    class GameRunner
    {
        static void Main()
        {
            GameEngine game = new GameEngine();
            game.GameLoop();
        }
    }
}
