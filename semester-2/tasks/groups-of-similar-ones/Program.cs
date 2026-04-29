using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace PCFindSimilar
{
    class Program
    {
        public struct SHuman
        {
            public string Surname;
            public string Firstname;
            public string Patronymic;
            public int Year;
            public SHuman(string surname, string firstname, string patronymic, int year)
            {
                Surname = surname;
                Firstname = firstname;
                Patronymic = patronymic;
                Year = year;
            }
        }

        static Random rnd = new Random();

        static SHuman[] CreateNewSHumanArray(int size)
        {
            List<string> surnames = new List<string>();
            List<string> names = new List<string>();
            List<string> patronymics =  new List<string>();

            for (int i = 0; i < size; i++)
            {
                surnames.Add($"s{i}");
                names.Add($"n{i}");
                patronymics.Add($"p{i}");
            }

            SHuman[] humans = new SHuman[size];
            for (int i = 0; i < size; i++)
            {
                humans[i] = new SHuman(surnames[rnd.Next(size)], names[rnd.Next(size)], patronymics[rnd.Next(size)], rnd.Next(1500, 1950));
            }
            return humans;
        }

        static bool HaveCommonField(SHuman a, SHuman b)
        {
            return a.Surname == b.Surname ||
                   a.Firstname == b.Firstname ||
                   a.Patronymic == b.Patronymic ||
                   a.Year == b.Year;
        }

        static List<List<SHuman>> GroupHumans(SHuman[] humans)
        {
            var groups = humans.Select(h => new List<SHuman> { h }).ToList();
            bool merged;
            do
            {
                merged = false;
                for (int i = 0; i < groups.Count; i++)
                {
                    for (int j = i + 1; j < groups.Count; j++)
                    {
                        if (groups[i].Any(x => groups[j].Any(y => HaveCommonField(x, y))))
                        {
                            groups[i].AddRange(groups[j]);
                            groups.RemoveAt(j);
                            merged = true;
                            break;
                        }
                    }
                    if (merged) break;
                }
            } while (merged);
            return groups;
        }

        static void SaveResultsToFile(List<List<SHuman>> groups, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < groups.Count; i++)
                {
                    writer.WriteLine($"Группа {i + 1}:");
                    foreach (var person in groups[i])
                        writer.WriteLine($"{person.Surname} {person.Firstname} {person.Patronymic}, {person.Year}");
                    writer.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            int[] sizes = {10, 50, 100, 200, 500, 1000};

            foreach (int size in sizes)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"--- Тестирование производительности (N={size}) ---");
                
                    SHuman[] group = CreateNewSHumanArray(size);
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    var result = GroupHumans(group);
                    sw.Stop();
                    long groupTime = sw.ElapsedMilliseconds;

                    sw.Restart();
                    SaveResultsToFile(result, $"result_{size}.txt");
                    sw.Stop();
                    long saveTime = sw.ElapsedMilliseconds;

                    Console.WriteLine($"Групп сформировано: {result.Count}");
                    Console.WriteLine($"Время группировки: {groupTime} ms");
                    Console.WriteLine($"Время записи в файл: {saveTime} ms");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Тесты завершены. Файлы созданы.");
        }
    }
}