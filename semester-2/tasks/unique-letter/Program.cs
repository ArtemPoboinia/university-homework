using System;
using System.Collections.Generic;

public class FirstUniqueLetterFinder
{
    public static char FindFirstUniqueLetter(string input)
    {
        if (string.IsNullOrEmpty(input))
            return '.';

        // Словарь для подсчета вхождений каждой буквы (нижний регистр)
        Dictionary<char, int> letterCount = new Dictionary<char, int>();
        
        // Список для сохранения порядка букв и их исходного регистра
        List<Tuple<char, char>> lettersOrder = new List<Tuple<char, char>>();

        // Первый проход: считаем буквы и сохраняем порядок
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char lowerChar = char.ToLower(c);
                
                if (!letterCount.ContainsKey(lowerChar))
                {
                    letterCount[lowerChar] = 0;
                    lettersOrder.Add(new Tuple<char, char>(lowerChar, c));
                }
                
                letterCount[lowerChar]++;
            }
        }

        // Второй проход: ищем первую букву с количеством 1
        foreach (var tuple in lettersOrder)
        {
            if (letterCount[tuple.Item1] == 1)
            {
                return tuple.Item2; // Возвращаем в исходном регистре
            }
        }

        return '.';
    }

    public static void Main(string[] args)
    {
        string testString = Console.ReadLine();
        char result = FindFirstUniqueLetter(testString);
        
        Console.WriteLine(result);
    }
}