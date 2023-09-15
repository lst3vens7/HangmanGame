using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "hangman";
            bool gameLost = false;
            int lives = 6;


            string[] characters = word.Select(x => new string(x, 1)).ToArray();
            string[] guesses = characters;


            for (int i = 0 ; i < guesses.Length; i++)
            {
                guesses[i] = "_";
            }
            //char[] characters = word.ToCharArray();

            characters = word.Select(x => new string(x, 1)).ToArray();


            while (gameLost == false)
            {
                bool letterGuessed = false;

                for (int i = 0; i < guesses.Length; i++)
                {
                    Console.Write(guesses[i]);
                }
                Console.WriteLine();

                Console.WriteLine("Please input a letter: ");
                string input = Console.ReadLine();
                input = input.ToLower();

                //char charInput = char.Parse(input);

                for (int i =  0; i < characters.Length; i++)
                {
                    if (input == characters[i])
                    {
                        guesses[i] = characters[i];


                        if (String.Join("", guesses) == word)
                        {
                            Console.WriteLine(word);
                            Console.WriteLine("You win!!");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        letterGuessed = true;
                    }
                }

                if (letterGuessed == false)
                {
                    lives = lives - 1;
                    Console.WriteLine("Lives remaining: {0}", lives);
                    if (lives == 0)
                    {
                        Console.WriteLine("You lose!!");
                        gameLost = true;
                    }
                }
            }

            Console.ReadLine();

        }
    }
}
