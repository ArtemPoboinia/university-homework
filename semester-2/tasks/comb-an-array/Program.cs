// Побойня Артём 5130903-50002

using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());

        List<int> list = new List<int>(6);

        for (int i  = 0; i < len; i++) {
            int j = int.Parse(Console.ReadLine());
            list.Add(j);
        }

        int len1 = 0;


        while (len != len1)
        {
            len = list.Count;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < list[i - 1])
                {
                    list.RemoveAt(i);
                }
            }

            len1 = list.Count;
        }

        Console.WriteLine();

        foreach (int i in list)
        {
            Console.WriteLine(i);
        }
        
        Console.ReadLine();
    }
}