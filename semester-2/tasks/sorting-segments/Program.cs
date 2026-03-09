using System;

namespace LineSorting
{
    // Структура, описывающая отрезок на плоскости
    struct LineSegment
    {
        public double X1;
        public double Y1;
        public double X2;
        public double Y2;
        public string Color;
        public int Thickness;

        // Инициализация
        public LineSegment(double x1, double y1, double x2, double y2, string color, int thickness)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Color = color;
            Thickness = thickness;
        }

        // Метод для вычисления длины отрезка
        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования
            LineSegment[] segments = new LineSegment[]
            {
                new LineSegment(0, 0, 3, 4, "Красный", 2),     
                new LineSegment(1, 1, 4, 5, "Синий", 1),       
                new LineSegment(0, 0, 0, 10, "Зеленый", 3),    
                new LineSegment(2, 2, 2, 3, "Желтый", 2),      
                new LineSegment(0, 0, 1, 1, "Черный", 1)       
            };

            Console.WriteLine("Исходный массив:");
            PrintSegments(segments);

            QuickSortByLength(segments, 0, segments.Length - 1);

            Console.WriteLine("\nОтсортированный массив по длине:");
            PrintSegments(segments);

            Console.ReadKey();
        }

        // Функция быстрой сортировки
        static void QuickSortByLength(LineSegment[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSortByLength(array, left, pivotIndex - 1);
                QuickSortByLength(array, pivotIndex + 1, right);
            }
        }

        // Функция разделения массива
        static int Partition(LineSegment[] array, int left, int right)
        {
            // Выбираем опорный элемент (в середине)
            int middle = left + (right - left) / 2;

            // Меняем опорный элемент с последним
            Swap(array, middle, right);

            // Опорный элемент - последний в текущем подмассиве
            double pivotLength = array[right].GetLength();

            int i = left - 1; // индекс меньшего элемента

            for (int j = left; j < right; j++)
            {
                // Если текущий элемент меньше или равен опорному
                if (array[j].GetLength() <= pivotLength)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            // Ставим опорный элемент на правильную позицию
            Swap(array, i + 1, right);

            return i + 1; // возвращаем индекс опорного элемента
        }

        // Функция для обмена элементов
        static void Swap(LineSegment[] array, int i, int j)
        {
            if (i != j)
            {
                LineSegment temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Функция для вывода отрезков
        static void PrintSegments(LineSegment[] segments)
        {
            foreach (var segment in segments)
            {
                Console.WriteLine($"Отрезок: ({segment.X1}, {segment.Y1}) -> ({segment.X2}, {segment.Y2}), " +
                                  $"Цвет: {segment.Color}, Толщина: {segment.Thickness}, " +
                                  $"Длина: {segment.GetLength():F2}");
            }
        }
    }
}