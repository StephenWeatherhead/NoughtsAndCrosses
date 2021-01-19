using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class HumanPlayer : IPlayer
    {
        public Move GetNextMove(char[,] board)
        {
            int row = -1;
            int column = -1;
            while(row == -1 || column == -1)
            {
                Console.WriteLine("Please enter your move (e.g. 'a0')");
                string move = Console.ReadLine().ToLower();
                if(move == "q")
                {
                    return null;
                }
                if(!string.IsNullOrWhiteSpace(move) && move.Length > 1)
                {
                    row = "abc".IndexOf(move[0]);
                    column = "012".IndexOf(move[1]);
                    if(row != -1 && column != -1 && !Game.IsUnmarked(board[row, column]))
                    {
                        row = -1;
                        column = -1;
                        Console.WriteLine("That space is already marked");
                        Console.WriteLine();
                    }
                }
            }
            return new Move { Row = row, Column = column };
        }
    }
}
