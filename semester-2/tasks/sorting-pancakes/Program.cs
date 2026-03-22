// Побойня Артём 5130903-50002

using System;

class Program
{
    public static void Main(string[] args)
    {
        Test(new List<int> { 4, 1, 7, 3, 2, 4, 8, 5, 6 });
        Test(new List<int> { 1, 2, 3, 4, 4, 5, 6, 7, 8 });
        Test(new List<int> { 8, 7, 6, 5, 4, 4, 3, 2, 1 });
        Console.ReadKey();
    }

    private static void Test(List<int> pancakes)
    {
        Console.WriteLine($"Исходная стопка: {string.Join(", ", pancakes)}");
        SortingPancakes(pancakes);
        Console.WriteLine($"Отсортированная: {string.Join(", ", pancakes)}\n");
    }

    // Функция сортировки блинов
    public static void SortingPancakes(List<int> pancakes)
    {
        int n = pancakes.Count;

        for (int currSize = n; currSize > 1; currSize--)
        {
            // Находим индекс самого большого блина в неотсортированной части
            int maxIndex = FindMaxIndex(pancakes, currSize);

            if (maxIndex != currSize - 1)
            {
                // Если самый большой не на вершине, переворачиваем до него
                if (maxIndex > 0)
                {
                    FlipTheStack(pancakes, maxIndex + 1);
                }
                // Переворачиваем всю текущую стопку, чтобы максимум оказался внизу
                FlipTheStack(pancakes, currSize);
            }
        }
    }

    // Функция нахождения индекса максимального элемента
    private static int FindMaxIndex(List<int> stack, int size)
    {
        int maxIndex = 0;
        for (int i = 1; i < size; i++)
        {
            if (stack[i] > stack[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }

    // Функция переворачивает первые k элементов списка
    public static void FlipTheStack(List<int> stack, int k)
    {
        stack.Reverse(0, k);
    }
}