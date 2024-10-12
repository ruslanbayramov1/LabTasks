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
            int[] arr = { 10, 30, 50, 30, 40 ,80, 120 };
            int num = 120;
            int index = IndexOf(arr, num);
            if (index >= 0) Console.WriteLine($"Index of number {num} is {index}\n");
            else Console.WriteLine($"The number {num} is not in array\n");

            string str = "Hello GUYS! How are YOU?";
            string upperText = ToUpper(str);
            string lowerText = ToLower(str);
            string cleanText = CleanString(str);
            Console.WriteLine($"Original text: {str}\nUpper Case: {upperText}\nLower Case: {lowerText}\nClean String: {cleanText}\n");

            // oz elave yazdigim trim method (labtaskda yox idi)
            string str2 = "  How are? ";
            string trimText = TrimString(str2);
            Console.WriteLine($"Before trim: {str2}, {str2.Length}\nAfter trim: {trimText}, {trimText.Length}");
        }

        static int IndexOf(int[] array, int num)
        {
            int indexOfNum = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == num)
                {
                    indexOfNum = i;
                    break;
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
                if ((c >= 65 && c<= 90) || (c >= 97 && c <= 122) || c == ' ') // if only contains letters and ' ' add it to string;
                {
                    newWord += c;
                }
            }

            return newWord;
        }

        static string TrimString(string word)
        {
            string newWord = "";
            int startIndex = 0;
            int endIndex = word.Length - 1;

            // if there is no ' ' at the end or start of the sentence or word, this means there is no ' ' to trim
            // thats why we immediately return from function and be aware of extra actions :)
            if (word[startIndex] != ' ' && word[endIndex] != ' ') return word;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[0] == ' ' && word[i] != ' ') // if word[0] is ' ' and check for next ones and if its different than ' '
                {
                    startIndex = i; // when first character different than ' ' founded, set it as startIndex and break the loop 
                    break;
                }
            }

            for (int i = word.Length - 1; i > startIndex; i--) 
            {
                if (word[word.Length - 1] == ' ' && word[i] != ' ') // if end is ' ' and check for previus ones and if its different ' '
                {
                    endIndex = i; // when first character different than ' ' founded, set it as endIndex and break the loop 
                    break;
                }
            }

            for(int i = startIndex; i <= endIndex; i++) // loop the input word again, with indexes from startIndex to the endIndex
            {
                newWord += word[i];
            }
            
            return newWord;
        }
    }
}
