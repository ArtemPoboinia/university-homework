// Побойня Артём 5130903-50002

using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string word = Console.ReadLine();

        bool result = MakeUpWord(text, word);

        Console.WriteLine(result);
    }

    public static bool MakeUpWord(string text, string word)
    {
        Dictionary<char, int> textLetterCount = new Dictionary<char, int>();
        Dictionary<char, int> wordLetterCount = new Dictionary<char, int>();

        foreach (char i in text)
        {
            if (char.IsLetter(i))
            {
                char lowerChar = char.ToLower(i);
                
                if (!textLetterCount.ContainsKey(lowerChar))
                {
                    textLetterCount[lowerChar] = 0;
                }
                textLetterCount[lowerChar]++;
            }
        }

        foreach (char i in word)
        {
            if (char.IsLetter(i))
            {
                char lowerChar = char.ToLower(i);
                
                if (!wordLetterCount.ContainsKey(lowerChar))
                {
                    wordLetterCount[lowerChar] = 0;
                }
                wordLetterCount[lowerChar]++;
            }
        }

        bool canFormWord = true;

        foreach (char key in wordLetterCount.Keys)
        {
            if (!textLetterCount.ContainsKey(key) || textLetterCount[key] < wordLetterCount[key])
            {
                canFormWord = false;
                break;
            }
        }

        return canFormWord;
    }
}