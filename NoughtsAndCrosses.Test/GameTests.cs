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
"Current Player: O", game.ToString());
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
            Assert.Equal(WinState.XWon, game.WinState);
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
            Assert.Equal(WinState.XWon, game.WinState);
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
            Assert.Equal(WinState.XWon, game.WinState);
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
            Assert.Equal(WinState.Draw, game.WinState);
        }
        [Fact]
        public void GetBoardCopiesBoard()
        {
            Game game = new Game();
            char[,] board1 = game.GetBoard();
            board1[0, 0] = 'X';
            char[,] board2 = game.GetBoard();
            Assert.Equal('X', board1[0, 0]);
            Assert.Equal(' ', board2[0, 0]);
        }
        [Fact]
        public void WinRuleTest()
        {
            Move move = BotPlayer.WinRule(new char[,] { { ' ', 'O', 'X' },
            { ' ', ' ', ' ' },
            { 'X', 'O', ' ' } }, Player.X);

            Assert.Equal(1, move.Row);
            Assert.Equal(1, move.Column);
        }
        [Fact]
        public void BlockRuleTest()
        {
            Move move = BotPlayer.BlockRule(new char[,] { { ' ', 'O', 'X' },
            { ' ', 'O', ' ' },
            { 'X', ' ', ' ' } }, Player.X);

            Assert.Equal(2, move.Row);
            Assert.Equal(1, move.Column);
        }
        [Fact]
        public void ForkTest()
        {
            Move move = BotPlayer.ForkRule(new char[,]
            {
                { ' ', 'X', ' ' },
                { 'O', 'O', 'X' },
                { ' ', ' ', ' ' }
            }, Player.X);
            Assert.Equal(0, move.Row);
            Assert.Equal(2, move.Column);
        }
    }
}
