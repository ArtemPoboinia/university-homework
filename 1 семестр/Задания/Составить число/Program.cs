//Побойня Артём 5130903-50002

using System;

class Program
{
    public static void Main(string[] args)
    {
        // Ввод данных
        Console.WriteLine("Введите желаемый результат: ");
        uint num = uint.Parse(Console.ReadLine());
        Console.WriteLine("Введите число a: ");
        uint a = uint.Parse(Console.ReadLine());
        Console.WriteLine("Введите число b: ");
        uint b = uint.Parse(Console.ReadLine());
        string operations = "";
        
        // Вывод результата
        if (FindPath(num, a, b, ref operations))
        {
            Console.WriteLine($"{operations}");
        }
        else
        {
            Console.WriteLine("Путь не найден");
        }
        Console.ReadLine();
    }

    // Функция нахождения пути
    public static bool FindPath(uint num, uint a, uint b, ref string operations)
    {
        if (num == 1)
        {
            return true;
        }

        if (num < 1)
        {
            return false;
        }

        // К операциям добавить b если f(num / 2, ...) = true
        if (b > 1 && num % b == 0)
        {
            if (FindPath(num / b, a, b, ref operations))
            {
                operations += $"*{b} ";
                return true;
            }
        }

        // К операциям добавить ф если f(num - a, ...) = true
        if (a > 0 && num > a)
        {
            if (FindPath(num - a, a, b, ref operations))
            {
                operations += $"+{a} ";
                return true;
            }
        }

        return false;
    }
}