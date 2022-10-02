using System;
using System.Collections.Generic;
//using static.System.Random;
using System.Text;


namespace HangmanGame
{
    internal class Program
    {

        //print function, track how many time user has guessed
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");// "\"is a special character skip and one is arm
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }

        }
        //print out the word function
        private static int printWord(List<char> guessedLetter, string randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\n");

            //loop through the array of randomword
            foreach (char c in randomWord)
            {
                if (guessedLetter.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write(" "); //Print nothing
                }
                counter += 1;
            }

            return rightLetters;
        }


        //print out the line for right letters
        private static void printLines(string randomWord)
        {
            Console.Write("\r");

            foreach (char c in randomWord)
            {
                //Gets or sets the encoding the console uses to write output.
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 "); //print the underline right under the letters
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the hangman game :) ");
            Console.WriteLine("-----------------------------------------");


            //define a random object
            Random random = new Random();

            //inital an array of random word
            List<String> wordDictionary = new List<string> { "hello", "sophia", "house", "happy", "life", "amazing" };
            //Returns a non-negative random integer.
            int index = random.Next(wordDictionary.Count);

            //create a random word
            string randomWord = wordDictionary[index];

            foreach (char x in randomWord) { Console.Write("_ "); }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                // Prompt user for input
                Console.Write("\r\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                // Check if that letter has already been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Check if letter is in randomWord
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }

                    // User is right
                    if (right)
                    {
                        printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    // User was wrong af
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Update the drawing
                        printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is over! Thank you for playing :)");




        }
    }
}
