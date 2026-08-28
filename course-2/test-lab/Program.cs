// Побойня Артём 5130903-50002

using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        await Countdown();
        Explosion();
    }

    static async Task Countdown()
    {
        for (int i = 10; i >= 0; i--)
        {
            Console.WriteLine(i);
            await Task.Delay(1000);
        }
    }

    static void Explosion()
    {
        Console.WriteLine("ВЗРЫВ!");
    }
}

