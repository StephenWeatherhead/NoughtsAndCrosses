using System;
using Xunit;
using NoughtsAndCrosses;

namespace NoughtsAndCrosses.Test
{
    public class GameTests
    {
        [Fact]
        public void DrawBoard()
        {
            char[,] board = new char[3, 3] { { '1', '2', '3' },
                { '4', '5', '6' },
            { '7', '8', '9' } };

            Assert.Equal("      0   1   2\n" +
"    -------------\n" +
"  a | 1 | 2 | 3 |\n" +
"    -------------\n" +
"  b | 4 | 5 | 6 |\n" +
"    -------------\n" +
"  c | 7 | 8 | 9 |\n" +
"    -------------\n", Game.DrawBoard(board));
        }
    }
}
