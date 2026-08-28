// Побойня Артём 5130903-50002

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Хеш-таблица
    static List<string>[] hashTable;

    // Хеш-функция
    static byte GetHash(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        int sum = 0;
        foreach (char c in input)
        {
            sum += (int)c;
        }
        return (byte)(sum % 256);
    }

    // Построение хеш-таблицы
    static List<string>[] BuildHashTable(string rootPath)
    {
        List<string>[] table = new List<string>[256];
        for (int i = 0; i < 256; i++)
        {
            table[i] = new List<string>();
        }

        try
        {
            ProcessDirectory(rootPath, table);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при индексировании: {ex.Message}");
        }

        return table;
    }


    // Рекурсивный обход папок
    static void ProcessDirectory(string path, List<string>[] table)
    {
        try
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                try
                {
                    string fileName = Path.GetFileName(file);

                    byte hash = GetHash(fileName);

                    table[hash].Add(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обработке файла {file}: {ex.Message}");
                }
            }

            string[] subdirs = Directory.GetDirectories(path);

            foreach (string subdir in subdirs)
            {
                ProcessDirectory(subdir, table);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Нет доступа к папке {path}: {ex.Message}");
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Папка не найдена {path}: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке папки {path}: {ex.Message}");
        }
    }

    // Поиск файла
    static void SearchFile(string name, List<string>[] table)
    {
        try
        {
            byte hash = GetHash(name);

            List<string> files = table[hash];

            bool found = false;

            foreach (string fullPath in files)
            {
                string fileName = Path.GetFileName(fullPath);
                if (fileName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(fullPath);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Указанный файл не обнаружен в хеш-таблице");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при поиске: {ex.Message}");
        }
    }

    static void Main(string[] args)
    {
        string path;
        do
        {
            Console.Write("Введите имя папки: ");
            path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.Clear();
                Console.WriteLine("Указано имя несуществующей или недоступной папки!");
            }

        } while (!Directory.Exists(path));

        Console.Clear();
        Console.WriteLine($"Выполняется индексация папки: {path}");
        Console.WriteLine("Пожалуйста, подождите...");

        hashTable = BuildHashTable(path);

        Console.WriteLine();
        Console.WriteLine("Индексация завершена успешно!");
        Console.WriteLine("Для поиска файла введите его имя (для выхода введите пустую строку):");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Введите имя файла для поиска: ");
            string searchName = Console.ReadLine();

            if (string.IsNullOrEmpty(searchName))
            {
                Console.WriteLine("Программа завершена.");
                break;
            }

            SearchFile(searchName, hashTable);
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}