// Побойня Артём 5130903-50002

using System;
using System.Collections.Generic;
using System.Linq;

// Структура для описания квартиры
public struct Apartment
{
    // Количество комнат
    public int Rooms { get; set; }

    // Цена квартиры
    public decimal Price { get; set; }

    // Площади помещений
    public decimal KitchenSquare { get; set; }
    public decimal OtherSquare { get; set; }

    // Список площадей комнат
    public List<decimal> RoomsSquares { get; set; }

    // Свойство для вычисления общей площади
    public decimal TotalSquare
    {
        get
        {
            return RoomsSquares.Sum() + KitchenSquare + OtherSquare;
        }
    }
    public Apartment(int rooms, decimal price, List<decimal> roomsSquares, decimal kitchenSquare, decimal otherSquare)
    {
        Rooms = rooms;
        Price = price;
        RoomsSquares = roomsSquares;
        KitchenSquare = kitchenSquare;
        OtherSquare = otherSquare;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Apartment> apartments = new List<Apartment>
        {
            new Apartment(2, 5_500_000, new List<decimal>{12m, 10m}, 8m, 5m),
            new Apartment(3, 8_000_000, new List<decimal>{15m, 14m, 10m}, 12m, 8m),
            new Apartment(2, 6_200_000, new List<decimal>{13m, 9m}, 9m, 6m),
            new Apartment(3, 7_500_000, new List<decimal>{16m, 12m, 9m}, 11m, 7m),
            new Apartment(2, 4_800_000, new List<decimal>{11m, 9m}, 7m, 4m)
        };

        // Ищем медиану цен для 2-комнатных квартир площадью более 35 кв.м.
        decimal? median = CalculateMedianPrice(apartments, rooms: 2, totalSquare: 35);

        if (median.HasValue)
            Console.WriteLine($"Медиана: {median.Value:N0} руб.");
        else
            Console.WriteLine("Квартир с такими параметрами не найдено.");

        Console.ReadKey();
    }

    public static decimal? CalculateMedianPrice(List<Apartment> apartments, int rooms, decimal totalSquare)
    {
        // Фильтрация по количеству комнат и площади
        var filtered = apartments.Where(a => a.Rooms == rooms && a.TotalSquare > totalSquare).ToList();

        if (!filtered.Any())
            return null;

        // Сортировка по цене (по возрастанию)
        var sortedByPrice = filtered.OrderBy(a => a.Price).ToList();

        int count = sortedByPrice.Count;
        int midIndex = count / 2;

        // Вычисление медианы
        if (count % 2 == 1)
        {
            return sortedByPrice[midIndex].Price;
        }
        else
        {
            return (sortedByPrice[midIndex - 1].Price + sortedByPrice[midIndex].Price) / 2;
        }
    }
}