using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class HumanPlayer : IPlayer
    {
        private Player _player;
        public HumanPlayer(Player player)
        {
            _player = player;
        }

        public Move GetNextMove(char[,] board)
        {
            string move = Console.ReadLine().ToLower();
            return new Move { Row = "abc".IndexOf(move[0]), Column = "012".IndexOf(move[1]) };
        }
    }
}
