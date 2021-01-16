using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Noughts and Crosses!");
            Game game = new Game();
            while (game.WinState == WinState.NoWin)
            {
                Console.WriteLine(game);
                string move = Console.ReadLine().ToLower();
                Console.WriteLine();
                game.Mark(game.CurrentPlayer, "abc".IndexOf(move[0]), "012".IndexOf(move[1]));
            }
            Console.WriteLine(game);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
