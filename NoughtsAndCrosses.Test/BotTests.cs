using System;
using Xunit;
using NoughtsAndCrosses;

namespace NoughtsAndCrosses.Test
{
    public class BotTests
    {
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
        [Fact]
        public void BlockForkTest()
        {
            Move move = BotPlayer.BlockForkRule(new char[,]
            {
                { ' ', 'X', ' ' },
                { 'O', 'O', 'X' },
                { ' ', ' ', ' ' }
            }, Player.O);
            Assert.Equal(0, move.Row);
            Assert.Equal(2, move.Column);
        }
        [Fact]
        public void BlockForkDefendTest()
        {
            Move move = BotPlayer.BlockForkRule(new char[,]
            {
                { 'X', ' ', 'X' },
                { ' ', 'O', ' ' },
                { ' ', ' ', ' ' }
            }, Player.O);
            Assert.False(move.Row == 2 && move.Column == 0);
            Assert.False(move.Row == 2 && move.Column == 2);
        }

        [Fact]
        public void CentreTest()
        {
            Move move1 = BotPlayer.CentreRule(new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            }, Player.O);
            Assert.Equal(1, move1.Row);
            Assert.Equal(1, move1.Column);
            Move move2 = BotPlayer.CentreRule(new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', 'X', ' ' },
                { ' ', ' ', ' ' }
            }, Player.O);
            Assert.Null(move2);
        }
        [Fact]
        public void OppositeCornerTest()
        {
            Move move = BotPlayer.OppositeCornerRule(new char[,]
            {
                { 'X', ' ', ' ' },
                { ' ', 'O', ' ' },
                { ' ', ' ', ' ' }
            }, Player.O);
            Assert.True(move.Row == 0 && move.Column == 2 || move.Row == 2 && move.Column == 0);
        }
    }
}
