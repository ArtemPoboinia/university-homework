// Побойня Артём 5130903-50002

using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите максимальное число: ");
        int n = int.Parse(Console.ReadLine());

        List<int> primeNumbers = AlgorithmEratostenes(n);

        Console.WriteLine($"\nПростые числа до {n}:");
        foreach (int prime in primeNumbers)
        {
            Console.Write($"{prime} ");
        }

        Console.ReadKey();
    }

    public static List<int> AlgorithmEratostenes(int max)
    {
        List<int> numbers = new List<int>();
        for (int i = 2; i <= max; i++)
        {
            numbers.Add(i);
        }

        // Решето Эратосфена
        for (int i = 2; i <= Math.Sqrt(max); i++)
        {
            // Удаляем все кратные i, кроме самого i
            numbers.RemoveAll(num => num != i && num % i == 0);
        }

        return numbers;
    }
}