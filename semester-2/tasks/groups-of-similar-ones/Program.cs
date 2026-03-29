using System;
using System.Collections.Generic;
using System.Linq;

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
                        bool shouldMerge = groups[i].Any(x => groups[j].Any(y => HaveCommonField(x, y)));
                        if (shouldMerge)
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

        static void Main(string[] args)
        {
            SHuman[] group = {
                new SHuman("Пушкин", "Александр", "Сергеевич", 1799),
                new SHuman("Ломоносов", "Михаил", "Васильевич", 1711),
                new SHuman("Тютчев", "Фёдор", "Иванович", 1803),
                new SHuman("Суворов", "Александр", "Васильевич", 1729),
                new SHuman("Менделеев", "Дмитрий", "Иванович", 1834),
                new SHuman("Ахматова", "Анна", "Андреевна", 1889),
                new SHuman("Володин", "Александр", "Моисеевич", 1919),
                new SHuman("Мухина", "Вера", "Игнатьевна", 1889),
                new SHuman("Верещагин", "Пётр", "Петрович", 1834)
            };

            var result = GroupHumans(group);

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine($"Группа {i + 1}:");
                foreach (var person in result[i])
                    Console.WriteLine($"{person.Surname} {person.Firstname} {person.Patronymic}, {person.Year}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}