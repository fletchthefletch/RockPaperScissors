using System;

namespace RockPaperScissors
{
    class Settings
    {
        ConsoleColor textColour, backgroundColour;

        public Settings()
        {
            // Set current colours
            textColour = Console.ForegroundColor;
            backgroundColour = Console.BackgroundColor;
            

            while (true)
            {
                Console.Clear();
                printSettings();

                Console.Write("Menu\\Settings>");
                string selection = Console.ReadLine();
                if (selection.Equals("6"))
                {
                    Console.Clear();
                    return;
                }
                else if (selection.Equals("1"))
                {
                    Console.Clear();
                    // Change num of bots
                    changeNumOfBots();
                }
                else if (selection.Equals("2"))
                {
                    Console.Clear();
                    // Change num of humans
                    changeNumOfHumans();
                }
                else if (selection.Equals("3"))
                {
                    Console.Clear();
                    // Change num of points to win
                    changeNumOfPoints();
                }
                else if (selection.Equals("4"))
                {
                    Console.Clear();
                    // Change text colour
                    changeTextColour();
                }
                else if (selection.Equals("5"))
                {
                    Console.Clear();
                    // Change background colour
                    changeBackgroundColour();
                }
            }
        }


        void printColourOptions()
        {
            Console.WriteLine("(1)  - Red");
            Console.WriteLine("(2)  - Green");
            Console.WriteLine("(3)  - Yellow");
            Console.WriteLine("(4)  - White");
            Console.WriteLine("(5)  - Gray");
            Console.WriteLine("(6)  - Black");
            Console.WriteLine("(7)  - Blue");
            Console.WriteLine("(8)  - Cyan");
            Console.WriteLine("(9)  - Dark Blue");
            Console.WriteLine("(10) - Dark Cyan");
            Console.WriteLine("(11) - Dark Gray");
            Console.WriteLine("(12) - Dark Green");
            Console.WriteLine("(13) - Dark Magenta");
            Console.WriteLine("(14) - Dark Red");
            Console.WriteLine("(15) - Dark Yellow");
        }
        ConsoleColor performTheColourChange(int colorId)
        {
            switch (colorId)
            {
                case 1:
                    return ConsoleColor.Red;
                case 2:
                    return ConsoleColor.Green;
                case 3:
                    return ConsoleColor.Yellow;
                case 4:
                    return ConsoleColor.White;
                case 5:
                    return ConsoleColor.Gray;
                case 6:
                    return ConsoleColor.Black;
                case 7:
                    return ConsoleColor.Blue;
                case 8:
                    return ConsoleColor.Cyan;
                case 9:
                    return ConsoleColor.DarkBlue;
                case 10:
                    return ConsoleColor.DarkCyan;
                case 11:
                    return ConsoleColor.DarkGray;
                case 12:
                    return ConsoleColor.DarkGreen;
                case 13:
                    return ConsoleColor.DarkMagenta;
                case 14:
                    return ConsoleColor.DarkRed;
                case 15:
                    return ConsoleColor.DarkYellow;
                default:
                    return ConsoleColor.Gray;
            }
        }
        void changeBackgroundColour()
        {
            Console.WriteLine("Select background colour from below");
            printColourOptions();
            while (true)
            {
                Console.Write("Menu\\Settings\\BackgroundColour>");
                string numStr = Console.ReadLine();

                try
                {
                    // Convert input to number
                    int num = Int32.Parse(numStr);

                    ConsoleColor temp = performTheColourChange(num);

                    if (temp == textColour)
                    {
                        Console.WriteLine("Error: background cannot be the same color as text.");
                        continue;
                    }
                    // Set text to this color
                    Console.BackgroundColor = temp;
                    Console.WriteLine("Settings saved...");
                    break;
                }
                catch (Exception)
                {
                    // Could not convert input to number
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }
        }

        void changeTextColour()
        {
            Console.WriteLine("Select text colour from below");
            printColourOptions();
            while (true)
            {
                Console.Write("Menu\\Settings\\TextColour>");
                string numStr = Console.ReadLine();

                try
                {
                    // Convert input to number
                    int num = Int32.Parse(numStr);

                    ConsoleColor temp = performTheColourChange(num);

                    if (temp == backgroundColour)
                    {
                        Console.WriteLine("Error: background cannot be the same color as text.");
                        continue;
                    }
                    // Set text to this color
                    Console.ForegroundColor = temp;
                    Console.WriteLine("Settings saved...");
                    break;
                }
                catch (Exception)
                {
                    // Could not convert input to number
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }
        }
        void changeNumOfBots()
        {
            Console.WriteLine("Enter number of bots (0 - 10)");
            while (true)
            {
                Console.Write("Menu\\Settings\\BotNum>");
                string numStr = Console.ReadLine();

                try
                {
                    // Convert input to number
                    int num = Int32.Parse(numStr);

                    if (num == 0)
                    {
                        if (HumanPlayer.getNumberOfHumans() < 2)
                        {
                            Console.WriteLine("Error: At least 2 players are required to play.");
                            continue;
                        }
                    }
                    else if (num == 1)
                    {
                        if (HumanPlayer.getNumberOfHumans() < 1)
                        {
                            Console.WriteLine("Error: At least 2 players are required to play.");
                            continue;
                        }
                    }

                    BotPlayer.changeNumberOfBots(num);
                    Console.WriteLine("Settings saved...");
                    break;
                }
                catch (Exception)
                {
                    // Could not convert input to number
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }

        }
        void changeNumOfHumans()
        {
            Console.WriteLine("Enter number of humans (0 - 10)");
            while (true)
            {
                Console.Write("Menu\\Settings\\HumanNum>");
                string numStr = Console.ReadLine();

                try
                {
                    // Convert input to number
                    int num = Int32.Parse(numStr);

                    // Require at least 2 players (any combination of bots and players is acceptable)
                    if (num == 0)
                    {
                        if (BotPlayer.getNumberOfBots() < 2)
                        {
                            Console.WriteLine("Error: At least 2 players are required to play.");
                            continue;
                        }
                    }
                    else if (num == 1)
                    {
                        if (BotPlayer.getNumberOfBots() < 1)
                        {
                            Console.WriteLine("Error: At least 2 players are required to play.");
                            continue;
                        }
                    }

                    HumanPlayer.changeNumberOfHumans(num);
                    Console.WriteLine("Settings saved...");
                    break;
                }
                catch (Exception)
                {
                    // Could not convert input to number
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }
        }
        void changeNumOfPoints()
        {
            Console.WriteLine("Enter number of points to win (> 0)");

            while (true)
            {
                Console.Write("Menu\\Settings\\PointsToWin>");
                string numStr = Console.ReadLine();

                try
                {
                    // Convert input to number
                    int num = Int32.Parse(numStr);

                    // At least 1 point needed to win
                    if (num < 1)
                    {
                        Console.WriteLine("Error: At least 1 point needed to win");
                        continue;
                    }

                    GamePlay.changeNumberOfPointsToWin(num);
                    Console.WriteLine("Settings saved...");
                    break;
                }
                catch (Exception)
                {
                    // Could not convert input to number
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            }
        }
        void printSettings()
        {
            Menu.printLine(0);
            Console.WriteLine("            SETTINGS");
            Menu.printLine(0);
            Console.Write("(1) - Change number of bots");
            Console.WriteLine("         {0}", BotPlayer.getNumberOfBots());
            Console.Write("(2) - Change number of humans");
            Console.WriteLine("       {0}", HumanPlayer.getNumberOfHumans());
            Console.Write("(3) - Change points needed to win");
            Console.WriteLine("   {0}", GamePlay.getNumberOfPointsToWin());
            Console.Write("(4) - Change text colour");
            Console.WriteLine("            {0}", Console.ForegroundColor);
            Console.Write("(5) - Change background colour");
            Console.WriteLine("      {0}", Console.BackgroundColor);
            Console.WriteLine("(6) - Quit");
        }
    }

}
