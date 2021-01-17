using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NoughtsAndCrosses
{
    public class BotPlayer : IPlayer
    {
        private char _player;
        public BotPlayer(Player player)
        {
            _player = Game.GetPlayerChar(player);
        }

        public Move GetNextMove(char[,] board)
        {
            Thread.Sleep(1000);
            return GetNextMove(board, _player);
        }
        /// <summary>
        /// Implements Newell and Simon's 1972 tic-tac-toe strategy
        /// </summary>
        /// <param name="board"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Move GetNextMove(char[,] board, char player)
        {
            Move move = WinRule(board, player);
            if (move != null)
            {
                return move;
            }
            move = BlockRule(board, player);
            if(move != null)
            {
                return move;
            }
            move = ForkRule(board, player);
            if(move != null)
            {
                return move;
            }
            move = BlockForkRule(board, player);
            if(move != null)
            {
                return move;
            }
            move = CentreRule(board, player);
            if(move != null)
            {
                return move;
            }
            move = OppositeCornerRule(board, player);
            if(move != null)
            {
                return move;
            }
            move = EmptyCornerRule(board, player);
            if (move != null)
            {
                return move;
            }
            move = EmptySideRule(board, player);
            if (move != null)
            {
                return move;
            }
            throw new InvalidOperationException("There are no possible moves left");
        }
        public static Move WinRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }

        public static Move BlockRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static Move ForkRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static Move BlockForkRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static Move CentreRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static Move OppositeCornerRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static Move EmptyCornerRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static Move EmptySideRule(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
    }
}
