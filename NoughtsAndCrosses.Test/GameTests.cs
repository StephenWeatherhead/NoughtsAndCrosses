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
        [Fact]
        public void ToStringTest()
        {
            Game game = new Game();
            game.Mark(Player.X, 0, 0);
            game.Mark(Player.O, 1, 1);
            game.Mark(Player.X, 2, 2);
            Assert.Equal("      0   1   2\n" +
"    -------------\n" +
"  a | X |   |   |\n" +
"    -------------\n" +
"  b |   | O |   |\n" +
"    -------------\n" +
"  c |   |   | X |\n" +
"    -------------\n" +
"Current Player: O\n", game.ToString());
        }
    }
}
