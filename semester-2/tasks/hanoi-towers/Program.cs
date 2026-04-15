using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int moveCount = 0; // Счётчик ходов

    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ИГРА Ханойские башни");
        Console.ResetColor();

        // Ввод данных
        Console.Write("Введите количество колец: ");
        int rings;
        while (!int.TryParse(Console.ReadLine(), out rings) || rings <= 0)
        {
            Console.WriteLine("Ошибка: введите положительное целое число.\n");
            Console.Write("Введите количество колец: ");
        }

        // Создаём три стека для башен
        Stack<int>[] towers = new Stack<int>[3];
        for (int i = 0; i < 3; i++)
        {
            towers[i] = new Stack<int>();
        }

        for (int i = rings; i >= 1; i--)
        {
            towers[0].Push(i);
        }

        PrintTowers(towers, rings);

        // Запускаем рекурсивное решение
        // from=0 (первая башня), to=1 (вторая башня), temp=2 (третья башня как временная)
        Move(rings, 0, 1, 2, towers, rings);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("ИГРА ОКОНЧЕНА!");
        Console.ResetColor();

        Console.ReadKey();
    }

    public static void Move(int n, int from, int to, int temp, Stack<int>[] towers, int rings)
    {
        if (n == 1)
        {
            // Перемещаем один диск
            int disk = towers[from].Pop();
            towers[to].Push(disk);
            moveCount++;

            PrintTowers(towers, rings);
        }
        else
        {
            // Перемещаем n-1 дисков с from на temp (используя to как временную)
            Move(n - 1, from, temp, to, towers, rings);

            // Перемещаем самый большой диск с from на to
            Move(1, from, to, temp, towers, rings);

            // Перемещаем n-1 дисков с temp на to (используя from как временную)
            Move(n - 1, temp, to, from, towers, rings);
        }
    }

    // Вывод в консоль
    public static void PrintTowers(Stack<int>[] towers, int rings)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Шаг №{moveCount}");
        Console.ResetColor();

        for (int level = rings - 1; level >= 0; level--)
        {
            for (int tower = 0; tower < 3; tower++)
            {
                int[] tempArray = towers[tower].ToArray();
                Array.Reverse(tempArray);

                if (level < tempArray.Length)
                    Console.Write($"{tempArray[level]}  ");
                else
                    Console.Write("0  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}