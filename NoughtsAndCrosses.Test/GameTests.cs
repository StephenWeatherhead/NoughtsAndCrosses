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
        [Fact]
        public void GameCanBeWonDiagonally()
        {
            Game game = new Game();
            game.Mark(Player.X, 0, 0);
            game.Mark(Player.O, 1, 0);
            game.Mark(Player.X, 1, 1);
            game.Mark(Player.O, 2, 0);
            game.Mark(Player.X, 2, 2);
            Assert.Equal(GameState.XWon, game.GameState);
        }
        [Fact]
        public void GameCanBeWonVertically()
        {
            Game game = new Game();
            game.Mark(Player.X, 1, 0);
            game.Mark(Player.O, 0, 0);
            game.Mark(Player.X, 1, 1);
            game.Mark(Player.O, 2, 0);
            game.Mark(Player.X, 1, 2);
            Assert.Equal(GameState.XWon, game.GameState);
        }
        [Fact]
        public void GameCanBeWonHorizontally()
        {
            Game game = new Game();
            game.Mark(Player.X, 0, 0);
            game.Mark(Player.O, 0, 1);
            game.Mark(Player.X, 1, 0);
            game.Mark(Player.O, 0, 2);
            game.Mark(Player.X, 2, 0);
            Assert.Equal(GameState.XWon, game.GameState);
        }
        [Fact]
        public void GameCanDraw()
        {
            Game game = new Game();
            game.Mark(Player.X, 0, 0);
            game.Mark(Player.O, 1, 0);
            game.Mark(Player.X, 0, 1);
            game.Mark(Player.O, 2, 1);
            game.Mark(Player.X, 1, 1);
            game.Mark(Player.O, 2, 2);
            game.Mark(Player.X, 1, 2);
            game.Mark(Player.O, 0, 2);
            game.Mark(Player.X, 2, 0);
            Assert.Equal(GameState.Draw, game.GameState);
        }
    }
}
