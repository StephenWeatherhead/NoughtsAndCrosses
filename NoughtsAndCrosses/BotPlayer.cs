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
            Move move = WinRuleCheckColumns(board, player);
            if (move != null)
            {
                return move;
            }
            move = WinRuleCheckRows(board, player);
            if(move != null)
            {
                return move;
            }
            move = WinRuleCheckDiagonals(board, player);
            if(move != null)
            {
                return move;
            }
            return null;
        }

        private static Move WinRuleCheckDiagonals(char[,] board, char player)
        {
            Move lastUnmarked = null;
            int playerCount = 0;
            for(int i = 0; i < 3; i++)
            {
                char c = board[i, i];
                if (Game.IsUnmarked(c))
                {
                    lastUnmarked = new Move { Row = i, Column = i };
                }
                else if (c == player)
                {
                    playerCount++;
                }
                else
                {
                    break;
                }
            }
            if (lastUnmarked != null && playerCount == 2)
            {
                return lastUnmarked;
            }
            lastUnmarked = null;
            playerCount = 0;
            for (int i = 0; i < 3; i++)
            {
                char c = board[2 - i, i];
                if (Game.IsUnmarked(c))
                {
                    lastUnmarked = new Move { Row = 2 - i, Column = i };
                }
                else if (c == player)
                {
                    playerCount++;
                }
                else
                {
                    break;
                }
            }
            if (lastUnmarked != null && playerCount == 2)
            {
                return lastUnmarked;
            }
            return null;
        }

        private static Move WinRuleCheckRows(char[,] board, char player)
        {
            for (int j = 0; j < 3; j++)
            {
                Move lastUnmarked = null;
                int playerCount = 0;
                for (int i = 0; i < 3; i++)
                {
                    char c = board[i, j];
                    if (Game.IsUnmarked(c))
                    {
                        lastUnmarked = new Move { Row = i, Column = j };
                    }
                    else if (c == player)
                    {
                        playerCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (lastUnmarked != null && playerCount == 2)
                {
                    return lastUnmarked;
                }
            }
            return null;
        }

        private static Move WinRuleCheckColumns(char[,] board, char player)
        {
            for(int i = 0; i < 3;i++)
            {
                Move lastUnmarked = null;
                int playerCount = 0;
                for(int j = 0; j < 3;j++)
                {
                    char c = board[i, j];
                    if (Game.IsUnmarked(c))
                    {
                        lastUnmarked = new Move { Row = i, Column = j };
                    }
                    else if(c == player)
                    {
                        playerCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(lastUnmarked != null && playerCount == 2)
                {
                    return lastUnmarked;
                }
            }
            return null;
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
