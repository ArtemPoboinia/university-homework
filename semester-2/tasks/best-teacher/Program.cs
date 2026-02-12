// Побойня Артём 5130903-50002

using System;

class Program
{
    public static void Main(string[] args)
    {
        double[,] arrMarks = {
            {3.6, 3.1, 2.8, 1, 4, 3.3, 3.2, 3},
            {3.5, 3.6, 4.1, 3.9, 3.5, 5, 4, 5},
            {2.2, 2.7, 3.1, 3, 4.5, 2.2, 3.1, 3.7},
            {4.2, 3.4, 3, 4.3, 4.1, 4.6, 4.4, 4.5},
            {4.7, 4.1, 3.6, 2.1, 2.7, 2, 2.5, 2.7}
        };

        (int index, double average) result = FindBestTeacher(arrMarks);

        Console.WriteLine($"Индекс лучшего преподавателя: {result.index}");
        Console.WriteLine($"Средний балл: {result.average}");

        Console.ReadKey();

    }

    // Функция поиска лучшего преподавателя
    static (int bestTeacherIndex, double bestAverage) FindBestTeacher(double[,] marks)
    {
        // Получение количества преподавателей и оценок
        int rows = marks.GetLength(0);
        int cols = marks.GetLength(1);

        double bestAverage = 0;
        int bestTeacherIndex = 0;

        // Цикл, который проходит по всему массиву
        for (int i = 0; i < rows; i++)
        {
            // Объявление вспомогательных переменных
            double min = marks[i, 0];
            double max = marks[i, 0];
            double sum = 0;

            //Цикл, который проходит по определённому преподавателю
            for (int j = 0; j < cols; j++)
            {
                double value = marks[i, j];

                if (value < min) min = value;
                if (value > max) max = value;

                sum += value;
            }

            sum = sum - min - max;
            int count = cols - 2;

            if (count <= 0)
            {
                Console.WriteLine($"Строка {i + 1}: недостаточно оценок для расчета");
                continue;
            }

            // Вычесление среднего арифметического
            double average = Math.Round(sum / count, 2);

            // Проверка, является ли данный преподаватель лучше прошлого лучшего
            if (average > bestAverage)
            {
                bestAverage = average;
                bestTeacherIndex = i;
            }
        }

        return (bestTeacherIndex, bestAverage);
    }
}