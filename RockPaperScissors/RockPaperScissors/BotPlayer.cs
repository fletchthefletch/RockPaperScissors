using System;

namespace RockPaperScissors
{
    class BotPlayer : Player, Input
    {
        static Random rand = new Random();
        static int numberOfBotPlayers = 1;

        // concrete derived class 
        public BotPlayer()
        {
            // give bot randomised name
            long nameBits = rand.Next(1, 999999);
            base.setPlayerName("bot[" + nameBits.ToString() + "]");
        }

        public static void changeNumberOfBots(int val)
        {
            numberOfBotPlayers = val;
        }
        public static int getNumberOfBots()
        {
            return numberOfBotPlayers;
        }

        public override int getInput()
        {
            try
            {
                currentVal = rand.Next(1, 3);
                return currentVal;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1; // this is acceptable only because valid moves are positive
            }
        }
    }

}
