using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class Game
    {
        char[,] board;
        public Game()
        {
            board = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
            WinState = WinState.NoWin;
            CurrentPlayer = Player.X;
        }
        /// <summary>
        /// This marks the board with the given player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Mark(Player player, int row, int column)
        {
            if(WinState != WinState.NoWin)
            {
                throw new InvalidOperationException("The game is complete, cannot mark the board.");
            }

            if (!IsUnmarked(board[row, column]))
            {
                throw new ArgumentException("That board space is already marked");
            }

            if(player != CurrentPlayer)
            {
                throw new ArgumentException("The player is not the current player");
            }

            board[row, column] = GetPlayerChar(player);

            ToggleCurrentPlayer();
            WinState = GetWinState(board);
        }

        public static char GetPlayerChar(Player player)
        {
            if (player == Player.X)
            {
                return 'X';
            }
            return 'O';
        }

        public static bool IsUnmarked(char c)
        {
            return c == ' ';
        }

        public void Mark(Player player, Move move)
        {
            Mark(player, move.Row, move.Column);
        }

        private void ToggleCurrentPlayer()
        {
            if(CurrentPlayer == Player.X)
            {
                CurrentPlayer = Player.O;
            }
            else
            {
                CurrentPlayer = Player.X;
            }
        }

        private static WinState GetWinState(char[,] board)
        {
            char? result = CheckRows(board);
            if (result != null)
            {
                return GetWinner(result.Value);
            }
            result = CheckColumns(board);
            if(result != null)
            {
                return GetWinner(result.Value);
            }
            result = CheckDiagonals(board);
            if(result != null)
            {
                return GetWinner(result.Value);
            }
            if(IsFull(board))
            {
                return WinState.Draw;
            }
            return WinState.NoWin;
        }

        private static bool IsFull(char[,] board)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static char? CheckDiagonals(char[,] board)
        {
            if (board[1, 1] != ' ' && (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
                board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2]))
            {
                return board[1, 1];
            }
            return null;
        }

        private static char? CheckRows(char[,] board)
        {
            if (board[0, 0] != ' ' && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
            {
                return board[0, 0];
            }
            else if (board[1, 0] != ' ' && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
            {
                return board[1, 0];
            }
            else if (board[2, 0] != ' ' && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
            {
                return board[2, 0];
            }
            return null;
        }
        private static char? CheckColumns(char[,] board)
        {
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
            {
                return board[0, 0];
            }
            else if (board[0, 1] != ' ' && board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
            {
                return board[0, 1];
            }
            else if (board[0, 2] != ' ' && board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
            {
                return board[0, 2];
            }
            return null;
        }
        private static WinState GetWinner(char c)
        {
            if (c == 'X')
                return WinState.XWon;
            else if(c == 'O')
                return WinState.OWon;
            throw new ArgumentException("The character must be a game piece");
        }

        public WinState WinState { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public override string ToString()
        {
            string boardString = DrawBoard(board);
            if(WinState == WinState.NoWin)
            {
                boardString += "Current Player: " + CurrentPlayer;
            }
            else
            {
                boardString += "Result: " + WinState;
            }
            return boardString;
        }

        public char[,] GetBoard()
        {
            char[,] boardCopy = new char[3, 3];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    boardCopy[i, j] = board[i, j];
                }
            }
            return boardCopy;
        }

        /// <summary>
        /// Returns a string representing the board
        /// </summary>
        /// <param name="board">a 3x3 char array representing the board</param>
        /// <returns></returns>
        public static string DrawBoard(char[,] board)
        {
            return "      0   1   2\n" +
                "    -------------\n" +
                $"  a | {board[0,0]} | {board[0,1]} | {board[0,2]} |\n" +
                "    -------------\n" +
                $"  b | {board[1,0]} | {board[1,1]} | {board[1,2]} |\n" +
                "    -------------\n" +
                $"  c | {board[2,0]} | {board[2,1]} | {board[2,2]} |\n" +
                "    -------------\n";
        }
    }
}
