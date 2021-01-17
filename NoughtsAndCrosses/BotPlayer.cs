using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NoughtsAndCrosses
{
    public class BotPlayer : IPlayer
    {
        private Player _player;
        public BotPlayer(Player player)
        {
            _player = player;
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
        public static Move GetNextMove(char[,] board, Player player)
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
        public static Move WinRule(char[,] board, Player player)
        {
            return GetWins(board, player).FirstOrDefault();
        }

        public static IEnumerable<Move> GetWins(char[,] board, Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game.IsUnmarked(board[i, j]))
                    {
                        board[i, j] = Game.GetPlayerChar(player);
                        var winState = Game.GetWinState(board);
                        board[i, j] = Game.GetUnmarked();
                        if (winState == WinState.OWon || winState == WinState.XWon)
                        {
                            yield return new Move { Row = i, Column = j };
                        }
                    }
                }
            }
        }

        public static Move BlockRule(char[,] board, Player player)
        {
            Move move = WinRule(board, Game.GetOppositePlayer(player));
            if (move != null)
            {
                return move;
            }
            return null;
        }
        public static Move ForkRule(char[,] board, Player player)
        {
            return GetForks(board, player).FirstOrDefault();
        }

        public static IEnumerable<Move> GetForks(char[,] board, Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Game.IsUnmarked(board[i, j]))
                    {
                        board[i, j] = Game.GetPlayerChar(player);
                        int wins = GetWins(board, player).Count();
                        board[i, j] = Game.GetUnmarked();
                        if (wins > 1)
                        {
                            yield return new Move { Row = i, Column = j };
                        }
                    }
                }
            }
        }

        public static Move BlockForkRule(char[,] board, Player player)
        {
            List<Move> forks = GetForks(board, Game.GetOppositePlayer(player)).ToList();
            if(forks.Count > 1)
            {
                foreach(Move fork in forks)
                {
                    board[fork.Row, fork.Column] = Game.GetPlayerChar(player);
                    Move win = WinRule(board, player);
                    if(win != null)
                    {
                        Move winFork = GetForks(board, Game.GetOppositePlayer(player)).First();
                        if (winFork != null)
                        {
                            return fork;
                        }
                    }
                    board[fork.Row, fork.Column] = Game.GetUnmarked();
                }
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        board[i, j] = Game.GetPlayerChar(player);
                        Move win = GetWins(board, player).FirstOrDefault();
                        if (win != null && GetForks(board, Game.GetOppositePlayer(player)).Count() > 1)
                        {
                            return new Move { Row = i, Column = j };
                        }
                        board[i, j] = Game.GetUnmarked();
                    }
                }
                throw new InvalidOperationException("We should not reach here");
            }
            else if(forks.Count == 1)
            {
                return forks[0];
            }
            else
            {
                return null;
            }
        }
        public static Move CentreRule(char[,] board, Player player)
        {
            throw new NotImplementedException();
        }
        public static Move OppositeCornerRule(char[,] board, Player player)
        {
            throw new NotImplementedException();
        }
        public static Move EmptyCornerRule(char[,] board, Player player)
        {
            throw new NotImplementedException();
        }
        public static Move EmptySideRule(char[,] board, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
