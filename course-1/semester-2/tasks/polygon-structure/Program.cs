// Побойня Артём 5130903-50002

using System;

// Структура точки
public struct Point
{
    public double X { get; }
    public double Y { get; }

    // Инициализация точек
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Метод вычисления вектора
    public Point Vector(Point other)
    {
        return new Point(other.X - X, other.Y - Y);
    }

    // Метод вычисления длинны вектора
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Метод вычисления скалярного произведения
    public double Scallar(Point other)
    {
        return (X * other.X + Y * other.Y);
    }
}

// Структура многоугольника
public struct Polygon
{
    // Свойства условию задачи
    public Point[] Vertices;
    public int LineThickness;
    public ConsoleColor LineColor;
    public bool HasFill;

    // Инициализация
    public Polygon(Point[] vertices, int thickness, ConsoleColor color, bool fill)
    {
        Vertices = vertices;
        LineThickness = thickness;
        LineColor = color;
        HasFill = fill;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        // Прямоугольник площадью 12
        Point[] rect1Points = new Point[]
        {
            new Point(0, 0),
            new Point(4, 0),
            new Point(4, 3),
            new Point(0, 3)
        };
        Polygon rect1 = new Polygon(rect1Points, 2, ConsoleColor.Red, true);

        // Треугольник
        Point[] trianglePoints = new Point[]
        {
            new Point(0, 0),
            new Point(2, 2),
            new Point(4, 0)
        };
        Polygon triangle = new Polygon(trianglePoints, 1, ConsoleColor.Green, false);

        // Прямоугольник площадью 5
        Point[] rect2Points = new Point[]
        {
            new Point(1, 1),
            new Point(1, 6),
            new Point(2, 6),
            new Point(2, 1)
        };
        Polygon rect2 = new Polygon(rect2Points, 3, ConsoleColor.Blue, true);

        // Прямоугольник площадью 20
        Point[] rect3Points = new Point[]
        {
            new Point(0, 0),
            new Point(5, 0),
            new Point(5, 4),
            new Point(0, 4)
        };
        Polygon rect3 = new Polygon(rect3Points, 1, ConsoleColor.Yellow, false);

        // Массив многоугольников
        Polygon[] polygons = { rect1, triangle, rect2, rect3 };

        double minSquare = 10.0;
        int result = GetCountTargetRectengle(polygons, minSquare);

        Console.WriteLine($"Количество прямоугольников с площадью больше {minSquare}: {result}");
        Console.ReadKey();
    }

    // Функция проверки является ли многоугольник прямоугольником
    static bool IsRectengle(Point[] vertices, out double area)
    {
        area = 0;

        // Проверка количества вершин
        if (vertices == null || vertices.Length != 4)
            return false;

        // Инициализация вершин
        Point v0 = vertices[0];
        Point v1 = vertices[1];
        Point v2 = vertices[2];
        Point v3 = vertices[3];

        // Векторы
        Point e0 = v0.Vector(v1);
        Point e1 = v1.Vector(v2);
        Point e2 = v2.Vector(v3);
        Point e3 = v3.Vector(v0);

        // Длины сторон
        double len0 = e0.Length();
        double len1 = e1.Length();
        double len2 = e2.Length();
        double len3 = e3.Length();

        // Противоположные стороны должны быть равны
        if (Math.Abs(len0 - len2) > 0 || Math.Abs(len1 - len3) > 0)
            return false;

        // Скалярное произведение должно быть равно 0
        if (Math.Abs(e0.Scallar(e1)) > 0 || Math.Abs(e1.Scallar(e2)) > 0)
            return false;

        area = len0 * len1;
        return true;
    }

    // Функция считает количество нужных прямоуголфьников 
    static int GetCountTargetRectengle(Polygon[] polygons, double minSquare)
    {
        int count = 0;
        foreach (Polygon poly in polygons)
        {
            if (IsRectengle(poly.Vertices, out double area) && area > minSquare)
            {
                count++;
            }
        }
        return count;
    }
}