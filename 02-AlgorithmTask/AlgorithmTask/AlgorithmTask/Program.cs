#region Task 1: Ededin musbet ve ya menfi olmasi
int a = 12;

if (a < 0) Console.WriteLine("negative");
else if (a > 0) Console.WriteLine("positive");
else
{
    Console.WriteLine("zero");
}
#endregion

#region Task 2: Ededin tek ve ya cut olmasi
//int b = 7;
//if (b % 2 == 0) Console.WriteLine("even");
//else
//{
//    Console.WriteLine("odd");
//}
#endregion

#region Task 3: Ededin reqemleri cemi
//int num = 123;
//int digit;
//int sumDigit = 0;

//do
//{
//    digit = num % 10;
//    num = (num - digit) / 10;
//    sumDigit += digit;
//}
//while (num > 0);
//Console.WriteLine(sumDigit);
#endregion

#region Task 4: Ededin sade ve ya murekkeb olmasi
//int number = 21;
//bool isComplex = false;

//if (number <= 0) Console.WriteLine("invalid number");
//else if (number == 1) Console.WriteLine("neither complex nor simple number");
//else if (number == 2) Console.WriteLine("simple number");
//else
//{
//    for (int i = 2; i < number; i++)
//    {
//        if (number % i == 0)
//        {
//            isComplex = true;
//            break;
//        }
//    }

//    if (isComplex) Console.WriteLine("complex number");
//    else Console.WriteLine("simple number");
//}
#endregion

#region Task 5: Ededin polindrome olub olmamasi 
//int num = 121;
//int numCopy = num;
//int digit;
//int reverseNum = 0;

//do
//{
//    digit = num % 10;
//    num = (num - digit) / 10;

//    reverseNum *= 10;
//    reverseNum += digit;
//}
//while (num > 0);

//if (reverseNum == numCopy) Console.WriteLine($"{numCopy} is polindrome");
//else Console.WriteLine($"{numCopy} is NOT polindrome");
#endregion