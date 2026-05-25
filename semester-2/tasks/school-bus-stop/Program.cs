// Побойня Артём 5130903-50002

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "data.bin";
        (long bestValue, int bestHouse) = SearchBestSchoolBusStops(fileName);
        Console.WriteLine(bestValue);
        Console.WriteLine(bestHouse);

        fileName = "data2.bin";
        (bestValue, bestHouse) = SearchBestSchoolBusStops(fileName);
        Console.WriteLine(bestValue);
        Console.WriteLine(bestHouse);
    }

    public static (long, int) SearchBestSchoolBusStops(string fileName)
    {
        using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
        {
            int n = br.ReadInt32(); // Количество домов
            int[] children = new int[n];

            for (int i = 0; i < n; i++)
                children[i] = br.ReadInt32();

            long bestValue = long.MaxValue;
            int bestHouse = -1;

            for (int stop = 0; stop < n; stop++)
            {
                long sum = 0;

                for (int house = 0; house < n; house++)
                {
                    int dist = Math.Abs(house - stop);
                    dist = Math.Min(dist, n - dist); // Расстояние по кольцу

                    sum += (long)children[house] * dist;
                }

                if (sum < bestValue)
                {
                    bestValue = sum;
                    bestHouse = stop;
                }
            }

            return (bestValue, bestHouse);
        }
    }
}