using System;

class Program
{
    public static void Main(string[] args)
    {
        // Ввод данных
        Console.WriteLine("Введите координаты треугольника:");
        double x1 = ReadCoordinate("x1: ");
        double y1 = ReadCoordinate("y1: ");
        double x2 = ReadCoordinate("x2: ");
        double y2 = ReadCoordinate("y2: ");
        double x3 = ReadCoordinate("x3: ");
        double y3 = ReadCoordinate("y3: ");

        Console.WriteLine("\nВведите координаты точки:");
        double px = ReadCoordinate("x точки: ");
        double py = ReadCoordinate("y точки: ");

        // Проверка правильности треугольника
        if (IsValidTriangle(x1, y1, x2, y2, x3, y3, out double areaABC))
        {
            // Вычесление площадей маленьких треугольников
            double areaPAB = TriangleArea(px, py, x1, y1, x2, y2);
            double areaPBC = TriangleArea(px, py, x2, y2, x3, y3);
            double areaPCA = TriangleArea(px, py, x3, y3, x1, y1);

            const double epsilon = 1e-10;

            // Проверка, лежил ли точка в треугольнике
            if (Math.Abs(areaABC - (areaPAB + areaPBC + areaPCA)) < epsilon)
            {
                Console.WriteLine("Точка лежит ВНУТРИ треугольника");
            }
            else
            {
                Console.WriteLine("Точка НЕ лежит в треугольнике");
            }
        }
        else
        {
            Console.WriteLine("Треугольник не существует");
        }

        Console.ReadLine();
    }

    // Функция чтения координат (пробует до тех пор, пока координаты не будут введены правильно)
    static double ReadCoordinate(string prompt)
    {
        double value;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Ошибка! Введите число: ");
        }
        return value;
    }

    // Функция проверки треугольника на правильность
    static bool IsValidTriangle(double x1, double y1, double x2, double y2, double x3, double y3, out double area)
    {
        double length1 = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        double length2 = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
        double length3 = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));

        area = TriangleArea(x1, y1, x2, y2, x3, y3);

        const double epsilon = 1e-10;

        return (length1 + length2 > length3 + epsilon) &&
               (length2 + length3 > length1 + epsilon) &&
               (length3 + length1 > length2 + epsilon) &&
               (area > epsilon);
    }

    // Функция вычисления площади треугольника
    static double TriangleArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        return Math.Abs((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3)) / 2.0;
    }
}