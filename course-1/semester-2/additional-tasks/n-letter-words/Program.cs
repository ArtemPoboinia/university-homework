using System;

class Program
{
    static void Main()
    {
        // Ввод данных
        Console.Write("Введите M (количество букв, M <= 33): ");
        int M = int.Parse(Console.ReadLine());

        Console.Write("Введите N (длина слова): ");
        int N = int.Parse(Console.ReadLine());

        // Проверка корректности ввода
        if (M <= 0 || M > 33 || N <= 0)
        {
            Console.WriteLine("Некорректный ввод!");
            return;
        }

        // Массив с первыми M буквами русского алфавита
        char[] alphabet = new char[M];
        string fullAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        for (int i = 0; i < M; i++)
        {
            alphabet[i] = fullAlphabet[i];
        }

        // Массив индексов текущего слова (все начинаются с 0 - буква 'А')
        int[] indices = new int[N];


        while (true)
        {
            // Вывод текущего слова
            for (int i = 0; i < N; i++)
            {
                Console.Write(alphabet[indices[i]]);
            }
            Console.Write(" "); // Пробел между словами для читаемости

            // Переход к следующему слову (увеличение "счетчика")
            int pos = N - 1; // Начинаем с последней позиции

            while (pos >= 0)
            {
                indices[pos]++; // Увеличиваем текущий разряд

                if (indices[pos] < M)
                {
                    // Если переполнения нет - выходим из внутреннего цикла
                    break;
                }
                else
                {
                    // Если переполнение - сбрасываем текущий и идем левее
                    indices[pos] = 0;
                    pos--;
                }
            }

            // Если дошли до pos = -1, значит все комбинации перебраны
            if (pos < 0)
            {
                break;
            }
        }

        Console.ReadKey();
    }
}