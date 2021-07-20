using System;

namespace RockPaperScissors
{
    class HumanPlayer : Player, Input
    {
        static int numberOfHumanPlayers = 1;
        // Concrete derived class 
        public HumanPlayer(int pID)
        {
            base.setPlayerName(pID);
        }
        public static void changeNumberOfHumans(int val)
        {
            numberOfHumanPlayers = val;
        }
        public static int getNumberOfHumans()
        {
            return numberOfHumanPlayers;
        }

        public override int getInput()
        {
            try
            {
                while (true)
                {
                    // get input from user
                    Console.WriteLine("({0}) Enter your move (? for help)", this.getName());
                    Console.Write(">");
                    string moveStr;
                    moveStr = Console.ReadLine();
                    if (moveStr.Equals("?"))
                    {
                        Menu.printOptions();
                        continue;
                    }
                    else if (!moveStr.Equals("1") && !moveStr.Equals("2") && !moveStr.Equals("3"))
                    {
                        // invalid move selection
                        Console.WriteLine("Invalid move - please enter another move!");
                        continue;
                    }
                    else
                    {
                        // valid move
                        currentVal = Int32.Parse(moveStr);
                        return currentVal;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1; // this is acceptable only because valid moves are positive
            }
        }
    }

}
