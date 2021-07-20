/*
 * ~ Made by Fletcher van Ameringen on 20/7/2021
 * Enjoy :-)
 * 
 * Game limitations:
 *  - The game requires a minimum of two players (BOT & BOT | BOT & HUMAN | HUMAN & HUMAN)
 *  - Minimum number of points needed to win must be at least 1
 */

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // The main function simply acts as a launcher for the menu
            new Menu();
        }
    }
}
