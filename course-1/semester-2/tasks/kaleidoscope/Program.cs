using System;

class KaleidoscopeGenerator
{
    private static readonly int[] Colors = { 0, 8, 7, 15, 14, 6, 12, 4, 5, 13, 11, 3, 9, 1, 2, 10 };
    private const int MinSize = 3;
    private const int MaxSize = 20;
    private const int ColorShiftMin = 1;
    private const int ColorShiftMax = 2;

    public static void Main(string[] args)
    {
        int halfSize = GetValidatedInput();
        int[,] kaleidoscope = GenerateKaleidoscope(halfSize);
        DisplayKaleidoscope(kaleidoscope);
        Console.ReadKey();
    }

    private static int GetValidatedInput()
    {
        int halfSize;
        do
        {
            Console.WriteLine($"Введите размер калейдоскопа (половина стороны) от {MinSize} до {MaxSize}:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out halfSize))
            {
                Console.WriteLine("Ошибка! Введите целое число.");
                continue;
            }

            if (halfSize < MinSize || halfSize > MaxSize)
            {
                Console.WriteLine($"Ошибка! Размер должен быть от {MinSize} до {MaxSize} включительно.");
                continue;
            }

            return halfSize; // Ввод корректен

        } while (true);
    }

    private static int[,] GenerateKaleidoscope(int halfSize)
    {
        Random random = new Random();
        int size = halfSize * 2;
        int[,] kaleidoscope = new int[size, size];

        // Генерация начального цвета
        int currentColorIndex = random.Next(Colors.Length);

        // Заполнение верхнего левого треугольника (1/8 часть)
        for (int i = 0; i < halfSize; i++)
        {
            // Для каждой строки начинаем с того же цвета, что и первый элемент предыдущей строки
            if (i > 0)
            {
                currentColorIndex = GetNextColorIndex(kaleidoscope[i - 1, 0], random);
            }

            for (int j = 0; j <= i; j++)
            {
                kaleidoscope[i, j] = Colors[currentColorIndex];

                // Генерируем следующий цвет для горизонтального соседа
                if (j < i) // Не генерируем для последнего элемента в строке
                {
                    currentColorIndex = GetNextColorIndex(Colors[currentColorIndex], random);
                }
            }
        }

        // Применяем все виды симметрии
        MirrorDiagonally(kaleidoscope, halfSize);
        MirrorVertically(kaleidoscope, halfSize);
        MirrorHorizontally(kaleidoscope, halfSize);

        return kaleidoscope;
    }

    private static int GetNextColorIndex(int currentColor, Random random)
    {
        // Находим индекс текущего цвета в массиве Colors
        int currentIndex = Array.IndexOf(Colors, currentColor);
        int newIndex;
        int attempts = 0;
        int maxAttempts = 50;

        do
        {
            // Выбираем случайное смещение от 1 до 2 в любом направлении
            int shift = random.Next(ColorShiftMin, ColorShiftMax + 1);
            bool moveRight = random.Next(2) == 0;

            if (moveRight)
            {
                newIndex = currentIndex + shift;
            }
            else
            {
                newIndex = currentIndex - shift;
            }

            // Коррекция (чтобы индекс не ушёл в меньшую или большую сторону)
            newIndex = (newIndex + Colors.Length) % Colors.Length;

            attempts++;

            // Проверяем, что новый цвет отличается от текущего
            if (Colors[newIndex] != currentColor)
                return newIndex;

        } while (attempts < maxAttempts);

        // Если не удалось найти отличающийся цвет, возвращаем соседний индекс
        return (currentIndex + 1) % Colors.Length;
    }

    private static void MirrorDiagonally(int[,] array, int halfSize)
    {
        // Отражение относительно главной диагонали
        for (int i = 0; i < halfSize; i++)
        {
            for (int j = i + 1; j < halfSize; j++)
            {
                array[i, j] = array[j, i];
            }
        }
    }

    private static void MirrorVertically(int[,] array, int halfSize)
    {
        int size = array.GetLength(0);

        // Отражение по вертикали
        for (int i = 0; i < halfSize; i++)
        {
            for (int j = 0; j < halfSize; j++)
            {
                array[i, size - 1 - j] = array[i, j];
            }
        }
    }

    private static void MirrorHorizontally(int[,] array, int halfSize)
    {
        int size = array.GetLength(0);

        // Отражение по горизонтали
        for (int i = halfSize; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                array[i, j] = array[size - 1 - i, j];
            }
        }
    }

    private static void DisplayKaleidoscope(int[,] kaleidoscope)
    {
        int size = kaleidoscope.GetLength(0);

        // Определяем размер блока для квадратного отображения
        int blockHeight = 1; // Высота блока в строках
        int blockWidth = 2;  // Ширина блока в символах

        for (int i = 0; i < size; i++)
        {
            // Выводим несколько строк для каждого ряда блоков
            for (int row = 0; row < blockHeight; row++)
            {
                for (int j = 0; j < size; j++)
                {
                    int colorValue = kaleidoscope[i, j];

                    Console.BackgroundColor = (ConsoleColor)colorValue;

                    Console.Write(new string(' ', blockWidth));
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}