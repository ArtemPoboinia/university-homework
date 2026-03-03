using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        int[][] arrTaxi = new int[10][];

        arrTaxi[0] = new int[] { 100, 289, 200, 101, 90, 230 };
        arrTaxi[1] = new int[] { 290, 300, 303, 120, 150 };
        arrTaxi[2] = new int[] { 80 };
        arrTaxi[3] = new int[] { 300, 60, 120, 400, 410 };
        arrTaxi[4] = new int[] { 60, 100, 40 };
        arrTaxi[5] = new int[] { 60, 160, 165, 120, 110, 230, 200, 30 };
        arrTaxi[6] = new int[] { 230, 200, 250, 100 };
        arrTaxi[7] = new int[] { 100, 209, 175, 100 };
        arrTaxi[8] = new int[] { 70, 120, 290 };
        arrTaxi[9] = new int[] { 90, 80, 105, 140, 120 };

        (arrTaxi, int count) = GetSortedArray(arrTaxi);

        for (int i = 0; i < arrTaxi.Length; i++)
        {
            for (int j = 0; j < arrTaxi[i].Length; j++)
            {
                Console.Write($"{arrTaxi[i][j]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\n{count}");

        Console.ReadKey();
    }

    static (int[][] arrTaxi, int count) GetSortedArray(int[][] array)
    {
        int count = 0;

        // Вычисляем суммы один раз
        int[] sums = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            sums[i] = array[i].Sum();
        }

        // Пузырьковая сортировка
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int k = 0; k < array.Length - 1 - i; k++)
            {
                if (array[k].Length < array[k + 1].Length)
                {
                    Swap(ref array[k], ref array[k + 1]);
                    // Меняем местами соответствующие суммы
                    int tempSum = sums[k];
                    sums[k] = sums[k + 1];
                    sums[k + 1] = tempSum;
                    count++;
                }
                else if (array[k].Length == array[k + 1].Length)
                {
                    if (sums[k] > sums[k + 1])
                    {
                        Swap(ref array[k], ref array[k + 1]);
                        // Меняем местами соответствующие суммы
                        int tempSum = sums[k];
                        sums[k] = sums[k + 1];
                        sums[k + 1] = tempSum;
                        count++;
                    }
                }
            }
        }
        return (array, count);
    }

    static void Swap(ref int[] a, ref int[] b)
    {
        int[] temp = a;
        a = b;
        b = temp;
    }
}