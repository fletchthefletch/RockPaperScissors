using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class GamePlay
    {
        static int numberOfPointsToWin = 3;
        List<Player> players = new List<Player>();
        List<Player> winners = new List<Player>();
        int[,] gameRules = new int[3, 3];

        public GamePlay()
        {
            // create humans
            for (int i = 0; i < HumanPlayer.getNumberOfHumans(); i++)
            {
                players.Add(new HumanPlayer(i + 1));
            }
            // create bots
            for (int i = 0; i < BotPlayer.getNumberOfBots(); i++)
            {
                players.Add(new BotPlayer());
            }

            playGame();
            return;
        }

        public void setRules()
        {
            /* [row, col] 
             * 0 = draw
             * 1 = rock wins
             * 2 = paper wins
             * 3 = scissors wins
             */
            gameRules[0, 0] = 0; // rock vs rock
            gameRules[0, 1] = 2; // rock vs paper
            gameRules[0, 2] = 1; // rock vs scissors
            gameRules[1, 0] = 2; // paper vs rock
            gameRules[1, 1] = 0; // paper vs paper
            gameRules[1, 2] = 3; // paper vs scissors
            gameRules[2, 0] = 1; // scissors vs rock
            gameRules[2, 1] = 3; // scissors vs paper
            gameRules[2, 2] = 0; // scissors vs scissors

        }
        private void playGame()
        {
            Console.Clear();
            setRules();
            Menu.printLine(0);
            Console.WriteLine("            GAME ON");
            Menu.printLine(0);
            Console.WriteLine("Let's Play...");
            Menu.printLine(0);
            Console.WriteLine("Number of humans:        {0}", HumanPlayer.getNumberOfHumans());
            Console.WriteLine("Number of bots:          {0}", BotPlayer.getNumberOfBots());
            Console.WriteLine("Number of points to win: {0}", GamePlay.getNumberOfPointsToWin());
            Menu.printLine(0);

            int numOfTotalPlayers = HumanPlayer.getNumberOfHumans() + BotPlayer.getNumberOfBots();
            bool someoneHasWon = false;
            int currentRound = 1;

            while (!someoneHasWon)
            {
                Menu.printLine(4);
                Console.WriteLine(" -- Round {0}", currentRound);
                Menu.printLine(4);

                // Take move
                foreach (Player p in players)
                {
                    p.getInput();
                }

                // Check if any player has won
                someoneHasWon = checkWins(numOfTotalPlayers);
                currentRound++;

                if (someoneHasWon)
                {
                    // Someone has won at this point
                    // the game is over
                    // return to main menu once the user presses any key
                    Menu.printLine(0);
                    int i = 1;
                    foreach (Player player in winners)
                    {
                        Console.WriteLine("{0}. Champion {1} ({2} points)", i, player.getName(), player.getNumberOfPoints());
                        i++;
                    }
                    Menu.printLine(0);

                }
            }
        }

        private bool checkWins(int numOfTotalPlayers)
        {

            int temp;
            bool someoneHasWon = false;
            for (int i = 0; i < numOfTotalPlayers - 1; i++)
            {
                for (int j = i + 1; j < numOfTotalPlayers; j++)
                {
                    temp = gameRules[players[i].getCurrentInput() - 1, players[j].getCurrentInput() - 1];
                    int playerAchoice = players[i].getCurrentInput();
                    int playerBchoice = players[j].getCurrentInput();
                    Console.Write("| {0} (", players[i].getName());
                    Menu.printLine(playerAchoice);
                    Console.Write(") vs ");
                    Console.Write("{0} (", players[j].getName());
                    Menu.printLine(playerBchoice);
                    Console.Write(")");

                    if (temp == players[i].getCurrentInput())
                    {
                        // Player wins
                        players[i].setNumberOfPoints(players[i].getNumberOfPoints() + 1);
                        Console.WriteLine(", {0} wins!", players[i].getName());
                    }
                    else if (temp == players[j].getCurrentInput())
                    {
                        // Other player wins 
                        players[j].setNumberOfPoints(players[j].getNumberOfPoints() + 1);
                        Console.WriteLine(", {0} wins!", players[j].getName());

                        // The below code exists in case the other player is the last player in the list
                        // It ensures that the last player's points are also checked
                        if (j == numOfTotalPlayers - 1) // Final loop iteration
                        {
                            if (players[j].getNumberOfPoints() >= numberOfPointsToWin)
                            {
                                // This player is also one of the champion(s)
                                someoneHasWon = true; // we do not exit at this point, as there may be multiple winners
                                winners.Add(players[j]);
                            }
                        }
                    }
                    else if (temp == 0)
                    {
                        // draw
                        Console.WriteLine(", this round was a draw.", players[i].getName());
                        continue;
                    }
                }
                if (players[i].getNumberOfPoints() >= numberOfPointsToWin)
                {
                    // This player is one of the champion(s)
                    someoneHasWon = true; // we do not exit at this point, as there may be multiple winners
                    winners.Add(players[i]);
                }

            }
            if (someoneHasWon)
            {
                return true;
            }
            return false;
        }

        public static void changeNumberOfPointsToWin(int val)
        {
            numberOfPointsToWin = val;
        }
        public static int getNumberOfPointsToWin()
        {
            return numberOfPointsToWin;
        }
    }
}
