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
            RuleResult result = Win(board, player);
            if (result.Success)
            {
                return result.Move;
            }
            result = Block(board, player);
            if(result.Success)
            {
                return result.Move;
            }
            result = Fork(board, player);
            if(result.Success)
            {
                return result.Move;
            }
            result = BlockFork(board, player);
            if(result.Success)
            {
                return result.Move;
            }
            result = Centre(board, player);
            if(result.Success)
            {
                return result.Move;
            }
            result = OppositeCorner(board, player);
            if(result.Success)
            {
                return result.Move;
            }
            result = EmptyCorner(board, player);
            if (result.Success)
            {
                return result.Move;
            }
            result = EmptySide(board, player);
            if (result.Success)
            {
                return result.Move;
            }
            throw new InvalidOperationException("There are no possible moves left");
        }
        public static RuleResult Win(char[,] board, char player)
        {
            throw new NotImplementedException();
        }

        public static RuleResult Block(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static RuleResult Fork(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static RuleResult BlockFork(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static RuleResult Centre(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static RuleResult OppositeCorner(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static RuleResult EmptyCorner(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
        public static RuleResult EmptySide(char[,] board, char player)
        {
            throw new NotImplementedException();
        }
    }
}
