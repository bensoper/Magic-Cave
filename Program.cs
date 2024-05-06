using System;

namespace MagicCaveGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Magic Cave!");

            int lives = 3;
            int treasures = 0;
            bool hasSword = false;
            bool hasCodex = false;
            int score = 0;

            while (lives > 0)
            {
                Console.WriteLine("\nYou are in the magic cave. You have " + lives + " lives and " + treasures + " treasures.");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Go deeper into the cave");
                Console.WriteLine("2. Exit the cave");

                string choice = Console.ReadLine()!;

                if (choice == "1")
                {
                    Random random = new Random();
                    int encounter = random.Next(1, 5);

                    if (encounter == 1)
                    {
                        Console.WriteLine("You encountered a puzzle!");
                        // Implement puzzle logic here
                        if (hasCodex)
                        {
                            Console.WriteLine("You used the codex to solve the puzzle!");
                            hasCodex = false; // if you want the codex to be used up
                        }
                        else
                        {
                            int num1 = random.Next(1, 10);
                            int num2 = random.Next(1, 10);
                            Console.WriteLine($"Solve this puzzle: {num1} + {num2} = ?");
                            int answer = Convert.ToInt32(Console.ReadLine());
                            if (answer == num1 + num2)
                            {
                                Console.WriteLine("Correct! You solved the puzzle.");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect! You lost a life.");
                                lives--;
                            }
                        }
                    }

                    else if (encounter == 2)
                    {
                        Console.WriteLine("You encountered a magical creature!");
                        // Implement creature logic here
                        if (hasSword)
                        {
                            Console.WriteLine("You used your sword to fend off the creature!");
                            hasSword = false;
                        }
                        else if (treasures > 0)
                        {
                            Console.WriteLine("You threw a treasure to distract the creature and escaped!");
                            treasures--;
                        }
                        else
                        {
                            Console.WriteLine("You have nothing to defend yourself with. You lost a life.");
                            lives--;
                        }
                    }
                    else if (encounter == 3)
                    {
                        Console.WriteLine("You found a treasure!");
                        treasures++;
                    }
                    else
                    {
                        int item = random.Next(1, 3);
                        if (item == 1)
                        {
                            Console.WriteLine("You found a sword!");
                            hasSword = true;
                        }
                        else
                        {
                            Console.WriteLine("You found a codex!");
                            hasCodex = true;
                        }
                    }
                }
                else if (choice == "2")
                {
                    score = treasures + lives;
                    Console.WriteLine("You exit the cave with " + treasures + " treasures. Your score is " + score + ". Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose 1 or 2.");
                }
            }

            if (lives == 0)
            {
                Console.WriteLine("You lost all your lives. Game over!");
            }
        }
    }
}
