using System;
using System.Globalization;

public class Program
{
    public static double FindMaxNumber(string input)
    {
        double max = 0;
        string current = "";

        foreach (char c in input)
        {
            if (char.IsDigit(c) || c == ',')
            {
                current += c;
            }
            else if (current != "")
            {
                double num;
                if (double.TryParse(current.Trim(','), NumberStyles.Any, new CultureInfo("ru-RU"), out num))
                {
                    if (num > max) max = num;
                }
                current = "";
            }
        }

        if (current != "")
        {
            double num;
            if (double.TryParse(current.Trim(','), NumberStyles.Any, new CultureInfo("ru-RU"), out num))
            {
                if (num > max) max = num;
            }
        }

        return max;
    }

    public static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(FindMaxNumber(input));
    }
}