using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Extension_Static;

internal static class Extension
{
    public static bool IsOdd(this int num)
    {
        if (num % 2 == 0) return false;

        return true;
    }

    public static bool IsEven(this int num)
    {
        if (num % 2 == 0) return true;

        return false;
    }

    public static bool HasDigit(this string sourceStr)
    {
        char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        foreach (char c in sourceStr)
        {
            foreach (char d in digits)
            {
                if (c == d)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool CheckPassword(this string sourceStr)
    {
        bool isUpper = false;
        bool isLower = false;
        bool isDigit = sourceStr.HasDigit();
        foreach (char c in sourceStr)
        {
            if (c >= 65 && c <= 90) isUpper = true;
            else if (c >= 97 && c <= 122) isLower = true;
        }

        if (isUpper && isUpper && isDigit) return true;
        return false;
    }

    public static string Capitalize(this string sourceStr)
    {
        return Char.ToUpper(sourceStr[0]) + sourceStr.Substring(1).ToLower();
    }
}
