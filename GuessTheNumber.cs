using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class GuessTheNumber {
     public static int lowestNumber = 0;
     public static int highestNumber = 0;

     public static int randomNumber = 0;

     public static Random rnd = new Random();

     public static int input = 0;

     public static string stringInput = "";
     public static void Main(string[] args) {
          Entrance();
     }

     static void Entrance() {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Welcome to Guess the Number!");
          Thread.Sleep(1000);
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine("If you do not know how to play 'Guess the number' please type, 'r' to view the rules and information. If not, just type any key (r/any): ");

          if (Console.ReadLine().ToLower() == "r") {
               Thread.Sleep(1000);
               Console.ForegroundColor = ConsoleColor.DarkGray;
               Console.WriteLine("So the rules and information of 'Guess the Number' are fairly simple. The program will think of a number and your goal is to try and guess it correctly... but with some fun hints!");
               Thread.Sleep(2000);
               Console.WriteLine("If you guess the number too low, it will tell you to guess higher or to guess a higher number. If you guess to high, it will ask you to guess a lower number.\n");
               Thread.Sleep(2000);
               Console.ForegroundColor = ConsoleColor.DarkRed;
               Console.WriteLine("That's it for the rules! If you want, you can access our other gamemode where you can completely turn the tables around and the *computer* will try to guess what number you're thinking of!");
          }

          Thread.Sleep(2000);
          Console.ForegroundColor = ConsoleColor.Magenta;
          Console.WriteLine("If you would like to play the gamemode where the robot is thinking of a number, press 'r'. Otherwise, press 'y' (r/y): ");

          if (Console.ReadLine().ToLower() == "r")
               Robot();
          else if (Console.ReadLine().ToLower() == "y")
               You();
          else if (Console.ReadLine().ToLower() == "q" || Console.ReadLine().ToLower() == "quit") {
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("Thanks for playing! Come back again!");
               Environment.Exit(1);
          }
     }

     static void Robot()
     {    
          while(true) {
               Console.ForegroundColor = ConsoleColor.DarkGray;
               Console.WriteLine("Enter a range of the numbers you will be guessing in. Enter the lowest number: ");
               try {
                    lowestNumber = Convert.ToInt32(Console.ReadLine());
               }
               catch (FormatException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid input. Please try again.");
                    continue;
               } catch (OverflowException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is too big or too small. Please try again.");
                    continue;
               }
               
               Console.WriteLine("Now enter the highest number: ");

               try {
                    highestNumber = Convert.ToInt32(Console.ReadLine());
               }
               catch (FormatException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid input. Please try again.");
                    continue;
               } catch (OverflowException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is too big or too small. Please try again.");
                    continue;
               }

               randomNumber = rnd.Next(lowestNumber, highestNumber);

               while(true) {  
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Enter a number in the range {lowestNumber} - {highestNumber}: ");

                    try {
                         input = Convert.ToInt32(Console.ReadLine());
                    } catch {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("That is not a valid input. Please try again");
                         continue;
                    }

                    if (input > highestNumber) {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("The number has exceeded the highest range. Please try again");
                         continue;
                    } else if (input < lowestNumber) {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("That number is too low! Please try again.");
                         continue;
                    } else {
                         if (input > randomNumber) {
                              Console.ForegroundColor = ConsoleColor.Cyan;
                              Console.WriteLine("Incorrect. The number is too high, please guess a lower number.");
                              continue;
                         } else if (input < randomNumber) {
                              Console.ForegroundColor = ConsoleColor.Red;
                              Console.WriteLine("Incorrect. The number is too low, please guess a higher number.");
                              continue;
                         } else {
                              Console.ForegroundColor = ConsoleColor.Green;
                              Console.WriteLine("Congratulations! You guesssed the correct number!");
                              break;
                         }
                    }   
               }

               Console.WriteLine("Do you want to play again? (y/n)");
               
               if (Console.ReadLine().ToLower() == "y") {
                    continue;
               } else {
                    Console.WriteLine("Do you want to play our other gamemode (gm) or just quit the application completely (q)? ");
                    if (Console.ReadLine().ToLower() == "gm") {
                         ResetVariables();
                         You();
                    } else {
                         Console.ForegroundColor = ConsoleColor.DarkGreen;
                         Console.WriteLine("Thanks for playing! Come back again another time!");
                         System.Environment.Exit(1);
                    }
               }
          }
     }

     static void ResetVariables() {
          randomNumber = 0;
          lowestNumber = 0;
          highestNumber = 0;
          input = 0;
     }

     static void You()
     {
          Console.WriteLine("Alright it's now my turn to guess. Please think of a number and enter the range in which I should guess.");
          Thread.Sleep(1000);

          while(true) {
               Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("Enter the lowest number for the range: ");
               try {
                    lowestNumber = Convert.ToInt32(Console.ReadLine());
               } catch (FormatException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
               } catch (OverflowException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is too big or too small. Please try again.");
                    continue;
               }

               Console.WriteLine("Enter the highest number for the range: ");
               try {
                    highestNumber = Convert.ToInt32(Console.ReadLine()) + 1;
               } catch (FormatException) {
                    Console.ForegroundColor  =ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
               } catch (OverflowException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number is too big or too small. Please try again.");
                    continue;
               }

               Thread.Sleep(1000);
               Console.ForegroundColor = ConsoleColor.Cyan;
               Console.WriteLine("Alright so now you're job is to tell me if my guess is low (l), high (h) or if it's correct (c). BE TRUTHFUL:  ");
               Thread.Sleep(1000);

               while(true) {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    randomNumber = rnd.Next(lowestNumber, highestNumber);
                    Console.WriteLine($"Alright so I'm guessing the number {randomNumber}. Is it correct? ");
                    stringInput = Console.ReadLine().ToLower();
                    if (stringInput == "l") {
                         lowestNumber = randomNumber;
                    } else if (stringInput == "h") {
                         highestNumber = randomNumber;
                    } else {
                         Console.ForegroundColor = ConsoleColor.Green;
                         Console.WriteLine("YOOO less gooooo im so good at this game u suck L jkjk u the top g.");
                         break;
                    }
               }

               Console.WriteLine("Do you want to play again? (y/n)");
               
               if (Console.ReadLine().ToLower() == "y") {
                    continue;
               } else {
                    Console.WriteLine("Do you want to play our other gamemode (gm) or just quit the application completely (q)? ");
                    if (Console.ReadLine().ToLower() == "gm") {
                         ResetVariables();
                         Robot();
                    } else {
                         Console.ForegroundColor = ConsoleColor.DarkGreen;
                         Console.WriteLine("Thanks for playing! Come back again another time!");
                         System.Environment.Exit(1);
                    }
               }
          }
     }
}