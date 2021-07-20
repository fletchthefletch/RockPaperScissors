using System;

namespace RockPaperScissors
{
    abstract class Player : Input
    {

        // Abstract super class
        private string playerName;
        private int numOfPoints;
        protected int currentVal;

        public void setPlayerName(int playerId)
        {
            Console.WriteLine("Please enter player {0}'s name", playerId);
            Console.Write(">");
            this.playerName = Console.ReadLine();
        }
        public void setPlayerName(string name)
        {
            this.playerName = name;
        }
        public string getName()
        {
            return this.playerName;
        }
        public int getNumberOfPoints()
        {
            return numOfPoints;
        }
        public void setNumberOfPoints(int val)
        {
            numOfPoints = val;
        }

        public abstract int getInput();
        public int getCurrentInput()
        {
            return this.currentVal;
        }
    }

}
