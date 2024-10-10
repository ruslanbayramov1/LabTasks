#region Task 1: Verilmis stringi tersine yazin
/*string text = "given text";
string reverseText = "";

for (int i = 0; i < text.Length; i++)
{
    reverseText += text[text.Length - i - 1];
}

Console.WriteLine(reverseText);*/
#endregion

#region Task 2: Verilen ededin perfect olub olmadigini tapin
/*int num = 8;
int sum = 0;
for (int i = 1; i < num; i++)
{
    if (num % i == 0)
    {
        sum += i;
    }
}

if (sum == num) Console.WriteLine("perfect");
else if (sum != num) Console.WriteLine("not perfect");*/
#endregion

#region Task 3: Guess vowels console mini app
/*int totalTrue = 0;
bool isFinished = false;
string[] strArr = { "hello", "how", "what", "good" };
char[] strVowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
int countVowel = 0;
Console.WriteLine($"Hi user! Please try to guess the numbers of vowels in the given words. We have {strArr.Length} words. Good luck :)");
for (int i = 0; i < strArr.Length; i++)
{
    Console.Write($"Here you are try to guess the number of vowels in the word '{strArr[i]}': ");
    int userInp = Convert.ToInt32(Console.ReadLine());
    foreach (char letter in strArr[i])
    {
        foreach (char vowels in strVowels)
            if (letter == vowels)
            {
                countVowel++;
            }
    }
    if (countVowel == userInp)
    {
        Console.WriteLine("Yes, you are right! :)\n");
        totalTrue++;
    }
    else Console.WriteLine("Your was wrong. Try another!\n");
    if (i == strArr.Length - 1) isFinished = true;
    countVowel = 0;
};
if (isFinished) Console.WriteLine($"The words are finished! You guess {totalTrue} right answers.");*/
#endregion

#region Task 4: Merge 2 arrays
/*int[] arrNum1 = { 1, 3, 5, 7, 9 };
int[] arrNum2 = { 2, 4, 6, 8 }; 
int[] mergedArr = new int[arrNum1.Length + arrNum2.Length];

for (int i = 0; i < arrNum1.Length; i++)
{
    mergedArr[i] = arrNum1[i];
}

for (int i = 0; i < arrNum2.Length; i++)
{
    mergedArr[mergedArr.Length - arrNum2.Length + i] = arrNum2[i];
}

foreach (int i in mergedArr)
{
    Console.WriteLine(i);
}*/
#endregion

#region Task 5: Verilmis arrayin sirali olub olmamasini yoxlayin
/*int[] arr = { 1, 5, 4, 5, 9 };
bool isSorted = true;

for (int i = 0; i < arr.Length; i++)
{
    for (int j = i + 1; j < arr.Length; j++)
    {
        if (arr[i] > arr[j])
        {
            isSorted = false;
            break;
        }
    }

    if (!isSorted)
    {
        break;
    }
}

if (!isSorted)
{
    Console.WriteLine("Bu array sirali array deyil!");
}
else
{
    Console.WriteLine("Bu array sirali arraydir");
}*/
#endregion