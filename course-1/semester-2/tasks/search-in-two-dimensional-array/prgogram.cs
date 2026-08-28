// Побойня Артём 5130903-50002

using System;

class Program
{
    public static void Main(string[] args)
    {
        int[,] arr = { { 2, 6, 7, 9, 9, 14 }, { 18, 20, 26, 26, 29, 40 }, { 44, 47, 50, 51, 55, 62 } };
        int num = 18;
        (int row, int col) = Search(arr, num);
        if (row == -1 && col == -1)
        {
            Console.WriteLine("Данного элемента в массиве не существует");
        }
        else
        {
            Console.WriteLine($"Индексы найденной ячейки: [{row}, {col}]");
        }

        arr = new int[,] { { 2, 6, 7, 9, 9, 14 }, { 18, 20, 26, 26, 40, 40 }, { 44, 47, 50, 51, 55, 62 } };
        num = 40;
        (row, col) = Search(arr, num);
        if (row == -1 && col == -1)
        {
            Console.WriteLine("Данного элемента в массиве не существует");
        }
        else
        {
            Console.WriteLine($"Индексы найденной ячейки: [{row}, {col}]");
        }

        Console.ReadKey();
    }

    // Функция поиска элемента в двумерном массиве
    static (int row, int col) Search(int[,] array, int num)
    {
        // Получение длинн массивов
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        // Бинарный поиск строки
        // Переменные начала и конца
        int top = 0;
        int bottom = rows - 1;

        while (top <= bottom)
        {
            // Вычисление середины
            int midRow = top + (bottom - top) / 2;

            // Сдвиг середины
            if (num < array[midRow, 0])
            {
                bottom = midRow - 1;
            }
            else if (num > array[midRow, cols - 1])
            {
                top = midRow + 1;
            }
            // else выполняется только тогда, когда искомый элемент находится в найденной строке под индексом (midRow)
            else
            {
                // Бинарный поиск в столбце
                // Переменные начала и конца
                int left = 0;
                int right = cols - 1;

                while (left <= right)
                {
                    // Вычисление середины
                    int mid = left + (right - left) / 2;

                    // Возвращает индексы искомого элемента
                    if (array[midRow, mid] == num)
                        return (midRow, mid);

                    // Сдвиг середины
                    if (array[midRow, mid] < num)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                break;
            }
        }

        // Если элемента нет в массиве
        return (-1, -1);
    }
}