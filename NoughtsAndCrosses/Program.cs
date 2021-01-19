using System;

namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Noughts and Crosses";
            Console.WriteLine("Welcome to Noughts and Crosses!");
            Console.WriteLine();
            GameMenuLoop();
        }

        private static void PrintGameMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter an option");
            Console.WriteLine("1 - single player");
            Console.WriteLine("2 - 2 players");
            Console.WriteLine("3 - computer versus itself");
            Console.WriteLine("q - quit");
            Console.WriteLine();
        }

        private static void GameMenuLoop()
        {
            while(true)
            {
                PrintGameMenu();
                string option = Console.ReadLine();
                if (option == "1")
                {
                    IPlayer playerX = new HumanPlayer();
                    IPlayer playerO = new BotPlayer(Player.O);
                    Game(playerX, playerO);
                }
                else if (option == "2")
                {
                    IPlayer playerX = new HumanPlayer();
                    IPlayer playerO = new HumanPlayer();
                    Game(playerX, playerO);

                }
                else if (option == "3")
                {
                    IPlayer playerX = new BotPlayer(Player.X);
                    IPlayer playerO = new BotPlayer(Player.O);
                    Game(playerX, playerO);
                }
                else if (option == "q")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("That is not a valid menu option");
                }
            }
        }

        static void Game(IPlayer playerX, IPlayer playerO)
        {
            Game game = new Game();
            while (game.WinState == WinState.NoWin)
            {
                IPlayer currentPlayer;
                if (game.CurrentPlayer == Player.X)
                {
                    currentPlayer = playerX;
                }
                else
                {
                    currentPlayer = playerO;
                }
                Console.WriteLine(game);
                Move move;
                try
                {
                    move = currentPlayer.GetNextMove(game.GetBoard());
                }
                catch (InvalidOperationException x)
                {
                    Console.WriteLine("There was an error. Please make an issue in the project GitHub repo:");
                    Console.WriteLine(x.Message);
                    return;
                }
                if(move == null)
                {
                    Console.WriteLine("Game quit");
                    return;
                }
                game.Mark(game.CurrentPlayer, move);
                Console.WriteLine();
            }
            Console.WriteLine(game);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
