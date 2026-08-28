// Побойня Артём 5130903-50002

using System;

class Program
{
    static char[,] board = new char[8, 8];

    public static void Main()
    {
        // Заполняем доску пустыми клетками
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                board[i, j] = ' ';

        if (SolveQueens(0))
            OutputBoard();
        else
            Console.WriteLine("Решение не найдено");
    }

    // Рекурсивная расстановка ферзей
    public static bool SolveQueens(int row)
    {
        if (row == 8)
            return true; // все ферзи поставлены

        for (int col = 0; col < 8; col++)
        {
            if (IsSafe(row, col))
            {
                board[row, col] = 'Q';

                if (SolveQueens(row + 1))
                    return true;

                board[row, col] = ' '; // откат
            }
        }

        return false;
    }

    // Проверка безопасности позиции
    public static bool IsSafe(int row, int col)
    {
        // Проверка столбца
        for (int i = 0; i < row; i++)
            if (board[i, col] == 'Q')
                return false;

        // Левая верхняя диагональ
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 'Q')
                return false;

        // Правая верхняя диагональ
        for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
            if (board[i, j] == 'Q')
                return false;

        return true;
    }

    public static void OutputBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            Console.Write(8 - i + " ");

            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write($" {board[i, j]} ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.WriteLine("   a  b  c  d  e  f  g  h");
    }
}