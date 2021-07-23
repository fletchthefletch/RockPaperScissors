using System;

namespace RockPaperScissors
{
    class Menu
    {
        public static void printOptions()
        {
            Console.WriteLine("(1) - Rock");
            Console.WriteLine("(2) - Paper");
            Console.WriteLine("(3) - Scissors");
        }
        public static void printLine(int choice)
        {
            switch (choice)
            {
                case 0:
                    Console.WriteLine("**************************************************************");
                    return;
                case 1:
                    // Rock move
                    Console.Write("Rock");
                    return;
                case 2:
                    // Paper move
                    Console.Write("Paper");
                    return;
                case 3:
                    // Scissors move
                    Console.Write("Scissors");
                    return;
                case 4:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~");
                    return;
                default:
                    Console.WriteLine("**************************************************************");
                    return;
            }
        }
        public Menu()
        {
            // Launch game

            while (true)
            {
                Console.WriteLine("--*-*-*-*-*-Welcome to Rock, Paper, & Scissors!-*-*-*-*-*--");
                Console.WriteLine("Play Game (1), Modify settings (2), or Quit (3)?");
                printLine(0);
                Console.Write("Menu>");
                string selection = Console.ReadLine();

                if (selection.Equals("3")) // Quit
                {
                    break;
                }
                else if (selection.Equals("2"))
                {
                    new Settings();
                }
                else if (selection.Equals("1"))
                {
                    new GamePlay();
                }
            }

        }
    }
}
