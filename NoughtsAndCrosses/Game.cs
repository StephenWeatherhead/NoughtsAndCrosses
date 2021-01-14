using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class Game
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
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
