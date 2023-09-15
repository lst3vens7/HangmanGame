using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace StringManipulation
{
    public class positionOfCharacter
    {
        public string? nameOfWord { get; set; }
        public string? c { get; set; }
        public int pos { get; set; }

    }
    internal class Program
    {
        static void Main()
        {
            string contents = "";
            List<positionOfCharacter> list = new List<positionOfCharacter>();
            try
            {
                // Get file name.
                string path = @"Files/Words.txt";
                // Get path name.
                string filename = Path.GetFileName(path);
                // Open the text file using a stream reader. Read into a string
                using (var sr = new StreamReader(path))
                {
                    // Read the stream as a string, and write the string to the console.
                    contents = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("---------");
            //Store each word into an array using split on '\n'
            var array = contents.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            string letterToSearch = "o";

            //Iterate through array printing out each word.
            foreach (var word in array)
            {
                //Console.WriteLine($"{word} : number of chars: {word.Length}  ");
                //Console.WriteLine($"occurence of letterToSearch: {word.Count(f => f == 'e')}");
                //Console.WriteLine($"Element at 0: {word.ElementAt(0)}");
                //Console.WriteLine($"index of letterToSearch : {word.IndexOf('e')}");
                //Console.WriteLine("---------");

                string letter = letterToSearch.ToLower();

                string wordToSearch = word.ToLower();
                int index = 0;
                if (wordToSearch.Contains(letter))
                {
                    // Find index where letter is
                    if (wordToSearch.IndexOf(letter) != -1)
                    {
                        while ((index = wordToSearch.IndexOf(letter, index)) != -1)
                        {
                            Console.WriteLine("word: " + wordToSearch + "  " + letter + " found at position " + "  " + index);
                            index++;
                            list.Add(new positionOfCharacter() { nameOfWord = wordToSearch, c = letter, pos = index });

                        }
                    }
                }
                Console.WriteLine("");


            }
            foreach (var li in list)
            {
                // Console.WriteLine($"word: {li.nameOfWord}  letter: {li.c}   position: {li.pos}");
            }

            Console.ReadLine();
        }
    }
}
