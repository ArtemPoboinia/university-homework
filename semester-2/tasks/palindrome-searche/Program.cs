// Побойня Артём 5130903-50002

using System;

class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string result = FindLongestPalindrome(input);
        Console.WriteLine(result);
    }

    public static bool IsPalindrome(string text)
    {
        int left = 0;
        int right = text.Length - 1;

        while (left < right)
        {
            if (text[left] != text[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    public static string FindLongestPalindrome(string text)
    {
        string longest = "";

        for (int i = 0; i < text.Length; i++) 
        {
            for (int j = i + 1; j < text.Length; j++)  // j = i + 1, т.к. длина >= 2
            {
                int length = j - i + 1;
                string substring = text.Substring(i, length);

                if (IsPalindrome(substring) && substring.Length > longest.Length)
                {
                    longest = substring;
                }
            }
        }

        return longest;
    }
}