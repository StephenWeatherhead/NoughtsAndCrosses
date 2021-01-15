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
            GameState = GameState.NoWin;
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
            if(GameState != GameState.NoWin)
            {
                throw new InvalidOperationException("The game is complete, cannot mark the board.");
            }

            if (board[row, column] != ' ')
            {
                throw new ArgumentException("That board space is already marked");
            }

            if(player != CurrentPlayer)
            {
                throw new ArgumentException("The player is not the current player");
            }
            
            if(player == Player.X)
            {
                board[row, column] = 'X';
            }
            else
            {
                board[row, column] = 'O';
            }
            ToggleCurrentPlayer();
            //UpdateGameState();
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

        private void UpdateGameState()
        {
            throw new NotImplementedException();
        }

        public GameState GameState { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public override string ToString()
        {
            return DrawBoard(board) +
                $"Current Player: {CurrentPlayer}\n";
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
