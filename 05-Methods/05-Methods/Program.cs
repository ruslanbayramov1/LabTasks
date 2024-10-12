using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 30, 50 };
            int index = IndexOf(arr, 30);
            Console.WriteLine(index);

            string str = "saLaM doStlaR! neCesiNiz?";
            string upperText = ToUpper(str);
            string lowerText = ToLower(str);
            string cleanText = CleanString(str);
            Console.WriteLine($"Upper Case: {upperText}\nLower Case: {lowerText}\nClean String: {cleanText}");
        }

        static int IndexOf(int[] array, int num)
        {
            int indexOfNum = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == num)
                {
                    indexOfNum = i;
                }
            }

            return indexOfNum;
        }

        static string ToLower(string word)
        {
            string newWord = "";

            foreach (char c in word)
            {
                if (c >= 65 && c <= 90) // checking ASCII upper case integral
                {
                    char a = (char)(c + 32);  // convert to lower case +32 integral (97-122)
                    newWord += a;
                }
                else  // if it is not upper case just add it to string
                {
                    newWord += c;
                }
            }

            return newWord;
        }

        static string ToUpper(string word)
        {
            string newWord = "";

            foreach (char c in word)
            {
                if (c >= 97 && c <= 122)  // checking ASCII lower case integral (97-122)
                {
                    char ltr = (char)(c - 32);  // convert to upper case -32 integral (65-90)
                    newWord += ltr;
                }
                else // if it is not lower case just add it to string
                { 
                    newWord += c;
                }
            }

            return newWord;
        }

        static string CleanString(string word)
        {
            string newWord = "";

            foreach (char c in word)
            { 
                if ((c >= 65 && c<= 90) || (c >= 97 && c <= 122) || c == ' ')
                {
                    newWord += c;
                }
            }

            return newWord;
        }
    }
}
