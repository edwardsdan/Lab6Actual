using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6
{
    class Validation
    {
        public static string ValidateInput()
        {
            bool loop = true;
            Console.WriteLine("Enter a word or phrase you want to translate!");
            string x = Console.ReadLine();
            while (loop == true)
            {
                if (x.Length >= 1 && Regex.Match(x, @"\w").Success)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Sorry! Try again!");
                    x = Console.ReadLine();
                }
            }
            return x;
        }
    }

    class EditString
    {
        public static string ContainsPunctuation(string x)
        {
            char[] punct = { '!', '"', '.', '?', ':', ';', ',' };
            if (Regex.IsMatch(x, @"([\!\,\.\?\:\;])"))
            {
                int punctIndex = x.IndexOfAny(punct); // similar to line 77
                string addPunct = x.Substring(punctIndex, length: 1);
                x = $"{x.Remove(punctIndex, 1)}{addPunct}";
                return x;
            }
            else
            {
                return x;
            }
        }

        public static string StartsWithVowel(string x)
        {
            string toReturn = x + "way";
            return toReturn;
        }

        public static string StartsWithConsonant(string x, char[] y)
        {

            int vowelIndex = x.IndexOfAny(y);
            string toAppend = x.Substring(0, vowelIndex);
            string toReturn = x.Remove(0, vowelIndex) + toAppend + "ay";
            return toReturn;
        }
    }

    class Program
    {
        public static string[] Print(string[] x)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' }; // see line 77

            for (int i = 0; i < x.Length; i++)
            {
                if (Regex.IsMatch(x[i], "^[a-zA-Z\'\"\\!\\.\\?\\,]+$"))
                {
                    if (x[i].IndexOfAny(vowels) == 0) // can probably use regex here, work in progress
                    {
                        x[i] = EditString.ContainsPunctuation(EditString.StartsWithVowel(x[i]));
                    }
                    else if (string.IsNullOrWhiteSpace(x[i]) == true)
                    {
                        x[i] = x[i].Replace(" ", String.Empty);
                    }
                    else
                    {
                        x[i] = EditString.ContainsPunctuation(EditString.StartsWithConsonant(x[i], vowels));
                    }

                }
            }
            return x;
        }

        

        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                string[] Test = Validation.ValidateInput().Split(' ');
                Console.WriteLine(string.Join(" ", Print(Test)));

                Console.WriteLine();

                Console.WriteLine("Translate another word or phrase? (y/n)");
                if (string.Compare(Console.ReadLine(), "y", true) == 0)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    loop = false;
                }
            }

        }
    }
}
