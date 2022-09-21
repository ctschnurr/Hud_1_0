using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hud_v1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string gameName = "STATS TESTER!";

            float score = 0;
            float multiplier = 1;
            int health = 100;
            int medPack = 25;
            int lives = 3;
                                    
        showHud:
            string hudHealth = health.ToString();
            string hudLives = lives.ToString();
            string hudScore = score.ToString();
            string hudMult = multiplier.ToString();

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Welcome to " + gameName + "                                                By Schnurr Studio");
            Console.WriteLine(".------------------------------------------------------------------------------------------.");
            Console.WriteLine("|        Health: " + hudHealth.PadRight(12) + "Lives: " + hudLives.PadRight(12) + "Score: " + hudScore.PadRight(12) + "Multiplier: " + hudMult.PadRight(12) + "|");
            Console.WriteLine("'------------------------------------------------------------------------------------------'");
            Console.WriteLine("");
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("");
            Console.WriteLine("  1 - Simulate random damage");
            Console.WriteLine("  2 - Simulate battle won");
            Console.WriteLine("  3 - Add Health");
            Console.WriteLine("  4 - Add a Life");
            Console.WriteLine("  0 - Exit");
            Console.WriteLine("");
            Console.Write("Enter Choice: ");

            ConsoleKeyInfo choice;
            choice = Console.ReadKey();
            Console.WriteLine("");

            if (choice.Key == ConsoleKey.D1)
            {

                if (health == 0 && lives == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The player is out of lives!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;
                }

                else
                {
                    Random rand = new Random();
                    int damage = rand.Next(0, 100);
                    health = health - damage;

                    Console.WriteLine("");
                    Console.WriteLine("Player took " + damage + " damage!");
                    Console.WriteLine("");

                    if (health < 0)
                    {
                        Console.Write("Player has ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("DIED");
                        Console.ResetColor();
                        Console.WriteLine("!");
                        Console.WriteLine("");
                        lives = (lives - 1);

                        if (lives == -1)
                        {
                            health = 0;
                            lives = 0;
                            score = 0;
                            multiplier = 1;

                            Console.WriteLine("Press any key to continue");
                            Console.WriteLine("");
                            Console.ReadKey();

                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("Player is out of lives!");
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("GAME OVER");
                            Console.ResetColor();
                            Console.WriteLine("!");
                            Console.WriteLine("");
                            Console.WriteLine("Score and multiplier have been reset!");
                            Console.WriteLine("");
                            Console.WriteLine("Press any key to continue");
                            Console.WriteLine("");
                            Console.ReadKey();

                            goto showHud;
                        }

                        else
                        {
                            health = 100;
                        }

                    }
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;
                }

            }

            if (choice.Key == ConsoleKey.D3)
            {

                if (health == 0 && lives == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The player is dead and cannot be healed!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;
                }

                else
                {
                    health = health + 25;

                    Console.WriteLine("");
                    Console.WriteLine("Player received a +" + medPack + " health pack!");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;

                }
            }

            if (choice.Key == ConsoleKey.D4)
            {

                if (lives == 0 && health == 0)
                {
                    health = health + 100;

                    Console.WriteLine("");
                    Console.WriteLine("Player has been revived!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;
                }

                else
                {
                    lives = lives + 1;

                    Console.WriteLine("");
                    Console.WriteLine("Player received a 1Up!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;
                }
            }

            if (choice.Key == ConsoleKey.D2)
            {
                if (lives == 0 && health == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Player is dead and cannot simulate battles!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    goto showHud;

                }

                else
                {
                    Random rand = new Random();
                    int scoreUp = rand.Next(1, 5);
                    float scoreTot = scoreUp * multiplier;
                    scoreTot = (float)Math.Round(scoreTot, 1);

                    Console.WriteLine("");
                    Console.WriteLine("Player has won a battle!");
                    Console.WriteLine("");
                    Console.WriteLine("Player received " + scoreUp + " points, x " + multiplier + " for a total of " + scoreTot + " points!");
                    Console.WriteLine("");
                    Console.WriteLine("Multiplier has gone up!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to continue");
                    Console.WriteLine("");
                    Console.ReadKey();

                    score = (score + scoreTot);
                    multiplier = (multiplier + 0.1f);

                    score = (float)Math.Round(score, 1);
                    multiplier = (float)Math.Round(multiplier, 2);
                
                    goto showHud;

                }
                
            }

            if (choice.Key == ConsoleKey.D0)
            {
                return;
            }

            else
            {
                goto showHud;
            }

        }
    }

    
}
