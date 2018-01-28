using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public static string ValidateInput ()
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

        public static string[] Print(string[] x)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            for (int i = 0; i < x.Length; i++)
            {
                if (Regex.IsMatch(x[i], "^[a-zA-Z\'\"\\!\\.\\?\\,]+$"))
                {
                    if (x[i].IndexOfAny(vowels) == 0)
                    {
                        x[i] = ContainsPunctuation(StartsWithVowel(x[i]));
                    }
                    else if (string.IsNullOrWhiteSpace(x[i]) == true)
                    {
                        x[i] = x[i].Replace(" ", String.Empty);
                    }
                    else
                    {
                        x[i] = ContainsPunctuation(StartsWithConsonant(x[i], vowels));
                    }

                }
            }
            return x;
        }

        public static string ContainsPunctuation(string x)
        {
            char[] punct = { '!', '"', '.', '?', ':', ';', ',' };
            if (Regex.IsMatch(x, @"([\!\,\.\?\:\;])"))
            {
                int punctIndex = x.IndexOfAny(punct);
                string addPunct = x.Substring(punctIndex, length: 1);
                string final = $"{x.Remove(punctIndex, 1)}{addPunct}";
                return final;
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

        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                string[] Test = ValidateInput().Split(' ');
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
