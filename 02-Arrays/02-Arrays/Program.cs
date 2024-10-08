#region Task 1: Verilmiş natural ədədlərdən ibarət olan array daxilində cüt elementlərin sayının tapılması.
/*int[] arr = { 1, 3, 4, 5, 6, 8 };
int count = 0;

foreach (int i in arr)
{
    if (i % 2 == 0) count++;
}
Console.WriteLine(count);*/
#endregion

#region Task 2: Verilmiş natural ədədlərdən ibarət olan array daxilində ən böyük tək elementin tapılması.
/*int[] arr = { 1, 3, 4, 5, 6, 8, 7 };
int max = arr[0];
foreach (int i in arr)
{
    if (i % 2 == 1 && max < i) max = i;
}
Console.WriteLine(max);*/
#endregion

#region Task 3: Verilmiş array-ın elementlərinin tərsinə çevrilməsi.
/*int[] arr = { 2, 4, 6, 8, 9 };
int[] reverseArr = new int[arr.Length];

for (int i = 0; i < arr.Length; i++)
{
    reverseArr[arr.Length - 1 - i] = arr[i];
}
foreach (int i in reverseArr)
{
    Console.WriteLine(i);
}*/
#endregion

#region Task 4: Verilmiş array-ın elementlərinin sayının tapılması.
/*int[] arr = { 1, 3, 4, 5, 6, 8 };
int count = 0;
foreach (int i in arr)
{
    count++;
}
Console.WriteLine(count);*/
#endregion

#region Task 5: Verilmiş elementin array-in daxilində yer alıb-almaması məlumatının əldə edilməsi.
/*int[] arr = { 1, 3, 4, 5, 6, 8 };
int search = 4;

foreach (int i in arr)
{
    if (i == search)
    {
        Console.WriteLine(i);
        break;
    }
}*/
#endregion

#region Task 6: Verilmiş element array daxilində yer alırsa neçə dəfə təkrarlandığı məlumatının əldə edilməsi.
/*int[] arr = { 1, 3, 4, 5, 6, 8, 4 };
int search = 4;
int repeat = 0;

foreach (int i in arr)
{
    if (i == search)
    {
        repeat++;
    }
}
Console.WriteLine(repeat);*/
#endregion

#region Task 7: Verilmiş 2 integer array-dən birincisində yer alıb digərində yer almayan elementləri ekrana çıxarın
/*int[] arrFirst = { 2, 4, 5, 6, 9, 1 };
int[] arrSecond = { 3, 4, 7, 8, 9, 10, 12 };

foreach (int i in arrFirst)
{
    int count = 0;
    foreach (int j in arrSecond)
    {
        if (i == j)
        {
            break;
        }
        else
        {
            count++;
        }
    }
    if (count == arrSecond.Length)
    {
        Console.WriteLine("Number " + i + " does not exist in second array");
    }
}*/
#endregion

#region Task 8: Verilmiş integer array-in tək indexdə duran elementləri ilə cüt indexdə duran elementləri müqayisə edin
int[] arr = { 3, 1, 2, 5, 5, 6, 4, 8, 9 };
int lengthOdd, lengthEven;
if (arr.Length % 2 == 1)
{
    lengthOdd = arr.Length / 2 + 1;
    lengthEven = arr.Length / 2;
}
else
{
    lengthOdd = arr.Length / 2;
    lengthEven = arr.Length / 2;
}

int[] arrOdd = new int[lengthOdd];
int[] arrEven = new int[lengthEven];
int indexOdd = 0;
int indexEven = 0;

for (int i = 0; i < arr.Length - 1; i++)
{
    if (i % 2 == 0)
    {
        arrEven[indexEven] = arr[i];
        indexEven++;
    }
    else
    {
        arrOdd[indexOdd] = arr[i];
        indexOdd++;
    }
}

Console.Write("Odd index numbers: ");
foreach (int i in arrOdd)
{
    Console.Write(i + " ");
}

Console.Write("\nEven index numbers: ");
foreach (int i in arrEven)
{ 
    Console.Write(i + " ");
}


Console.WriteLine("\n---------------");

foreach (int odd in arrOdd)
{
    foreach (int even in arrEven)
    {
        if (odd > even)
        {
            Console.WriteLine($"Odd number {odd} is greater than even number {even}");
        }
        else if (even > odd)
        {
            Console.WriteLine($"Odd number {odd} is less than even number {even}");
        }
        else
        {
            Console.WriteLine($"Odd number {odd} is equal to even number {even}");
        }
    }
}
#endregion