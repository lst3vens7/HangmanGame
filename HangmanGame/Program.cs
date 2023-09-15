using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string contents = "";
            try
            {
                string path = @"Files/Words.txt";

                string filename = Path.GetFileName(path);

                using (var sr = new StreamReader(path))
                {
                    contents = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


            //Text file must use spaces instead of new lines, as bug was causgin options to disappear
            string[] array = contents.Split(' ');//, (char)StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();
            int number = rnd.Next(1, array.Length);

            string word = array[number];
            bool gameLost = false;
            int lives = 6;


            string[] characters = word.Select(x => new string(x, 1)).ToArray();
            string[] guesses = characters;


            for (int i = 0 ; i < guesses.Length; i++)
            {
                guesses[i] = "_";
            }


            
            characters = word.Select(x => new string(x, 1)).ToArray();

            while (gameLost == false)
            {
                bool letterGuessed = false;

                for (int i = 0; i < guesses.Length; i++)
                {
                    Console.Write(guesses[i]);
                }
                Console.WriteLine();

                Console.Write("Please input a letter: ");
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
