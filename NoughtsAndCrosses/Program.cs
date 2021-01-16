using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Noughts and Crosses!");
            Console.WriteLine();
            Game game = new Game();
            IPlayer playerX = new HumanPlayer();
            IPlayer playerO = new HumanPlayer();
            while (game.WinState == WinState.NoWin)
            {
                IPlayer currentPlayer;
                if(game.CurrentPlayer == Player.X)
                {
                    currentPlayer = playerX;
                }
                else
                {
                    currentPlayer = playerO;
                }
                Console.WriteLine(game);
                game.Mark(game.CurrentPlayer, currentPlayer.GetNextMove(game.GetBoard()));
                Console.WriteLine();
            }
            Console.WriteLine(game);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
