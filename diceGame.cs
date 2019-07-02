using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many players are there? ");
            int players = Convert.ToInt32(Console.ReadLine());
            startGame(players);
        }
        static void startGame(int players)
        {
            int[] roll = new int[players];
            int[] score = new int [players];
            Console.WriteLine("Enter 'R' to start the game");
            string startGame = Console.ReadLine();
            if (startGame == "R" || startGame == "r")
            {
                rollDice(roll, score, players);
            }
        }
        static void rollDice(int[] roll, int[] score, int players)
        {
            Random rand = new Random();
            for(int i =0; i< players; i++)
            {
                int playerNum = i + 1;
                roll[i] = rand.Next(1, 6);
                Console.WriteLine("player " +playerNum+ " has rolled an  " + roll[i]);
                score[i] = score[i] + roll[i];
            }
            Console.ReadLine();
            CheckScore(roll, score, players);
        }
        static void playAgain(int []roll, int[] score, int players)
        {
            Console.WriteLine("Do you want to ... \n 1. Play again \n 2. End game");
            string play = Console.ReadLine();
            if (play == "1")
            {
                Console.WriteLine("You have choosen to play again!!");
                for (int i = 0; i<players;i++)
                {
                    roll[i] = 0;
                    score[i] = 0;
                }
                rollDice(roll, score, players);
            }
            else
            {
                Console.WriteLine("You have choosen to end game...\nClosing app...");
                closeApp();
            }
        }
        static void CheckScore(int[] roll, int []score, int players)
        {
            bool oneRolled= false;
            int newPlay = 0;
            bool aboveTwenty=false;
            int winScore = 0;
            for (int i =0; i<players; i++)
            {
                if (roll[i] == 1)
                {
                    oneRolled = true;
                    newPlay = i + 1;
                }
            }
            for (int i =0; i<players; i++)
            {
                if (score[i]>20)
                {
                    aboveTwenty = true;
                    newPlay = i + 1;
                    winScore = score[i];
                }
            }
            if (oneRolled == true)
            {
                rollEquals1(roll, score, players, oneRolled, newPlay);
            }
            else if(aboveTwenty == true)
            {
                scoreAboveTwenty(roll, score, players, aboveTwenty, newPlay, winScore);
            }
            else
            {
                for (int j = 0; j < players; j++)
                 {
                    int newPlayer = j + 1;
                    Console.WriteLine("Player " + newPlayer + "'s score currently is : " + score[j]);
                    
                }
                Console.ReadLine();

                Console.WriteLine("Enter 'R' to roll again ... ");
                string rollAgain = Console.ReadLine();
                if (rollAgain == "R" || rollAgain == "r")
                {
                   rollDice(roll, score, players);
                }
             }


            
               
        }
        static void rollEquals1(int[] roll, int[] score, int players, bool oneRolled, int newPlay)
        {
            if (oneRolled == true)
            {
                Console.Write("Unlucky Player " + newPlay + " has score a 1." +  "" + " Game Over!");
                playAgain(roll, score, players);
            }
        }
        static void scoreAboveTwenty(int[] roll, int[] score, int players, bool aboveTwenty, int newPlay, int winScore)
        {
            if (aboveTwenty == true)
            {
                Console.WriteLine("Congrats!! Player " + newPlay + " has won!! Your score is : " + winScore);
                Console.ReadLine();
                playAgain(roll, score, players);
            }
        }

        static void closeApp()
        {


        }
    }
}
