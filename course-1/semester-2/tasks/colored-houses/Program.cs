using System;

class Program
{
    public static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());
        int colors = int.Parse(Console.ReadLine());

        GetCountColors(height, width, colors);
    }

    static void GetCountColors(int height, int width, int colors)
    {
        int[] colorCount = new int[colors];

        // Заполняем массив цветов
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                // Вычисляем цвет для текущей ячейки
                // Цвета нумеруются слева направо по строке, начиная с 0
                int colorNumber = (i * width + j) % colors;
                colorCount[colorNumber]++;
            }
        }

        // Выводим результаты
        for (int i = 0; i < colors; i++)
        {
            Console.WriteLine(colorCount[i]);
        }
    }
}