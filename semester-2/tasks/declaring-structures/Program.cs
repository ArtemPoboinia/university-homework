using System;

// Структура для описания объекта загородной недвижимости
public struct CountryEstate
{
    // Уникальный кадастровый номер объекта
    public string CadastralNumber;

    // Площадь участка в сотках
    public double LandArea;

    // Массив строений на участке
    public string[] Buildings;

    // Наличие центрального водоснабжения
    public bool HasWaterSupply;

    // Наличие электричества
    public bool HasElectricity;

    // Стоимость объекта в рублях
    public decimal MarketValue;

    // Координаты участка на карте (широта, долгота)
    public GeographicCoordinates Coordinates;
}

// Вспомогательная структура для координат
public struct GeographicCoordinates
{
    // Широта в градусах
    public double Latitude;

    // Долгота в градусах
    public double Longitude;
}

// Структура для описания акта нарушения пожарной безопасности
public struct FireSafetyViolationAct
{
    // Уникальный номер акта
    public string ActNumber;

    // Дата составления акта
    public DateTime InspectionDate;

    // Название проверяемой организации или ФИО частного лица
    public string InspectedEntity;

    // Массив выявленных нарушений
    public string[] Violations;

    // Информация о инспекторе, составившем акт
    public Inspector InspectorInfo;

    // Сумма наложенного штрафа
    public decimal FineAmount;

    // Срок устранения нарушений в днях
    public int DeadlineDays;
}

// Вложенная структура для информации об инспекторе
public struct Inspector
{
    // ФИО инспектора
    public string FullName;

    // Должность инспектора
    public string Position;

    // Номер удостоверения
    public string BadgeNumber;
}

// Структура для описания музыкального коллектива
public struct MusicBand
{
    // Название музыкального коллектива
    public string BandName;

    // Музыкальный жанр
    public string Genre;

    // Год основания группы
    public int FoundedYear;

    // Массив участников группы
    public Musician[] Members;

    // Количество выпущенных студийных альбомов
    public int AlbumsCount;

    // Массив названий самых популярных песен
    public string[] PopularSongs;

    // Страна происхождения группы
    public string Country;
}

// Вложенная структура для информации о музыканте
public struct Musician
{
    // Сценический псевдоним или имя
    public string StageName;

    // Реальное имя (если известно)
    public string RealName;

    // Инструмент, на котором играет музыкант
    public string Instrument;

    // Возраст музыканта
    public int Age;
}

// Пример использования структур
class Program
{
    static void Main()
    {
        // Пример использования структуры CountryEstate
        CountryEstate estate = new CountryEstate
        {
            CadastralNumber = "77:01:0001234:5678",
            LandArea = 12.5,
            Buildings = new string[] { "Жилой дом", "Баня", "Гараж", "Беседка" },
            HasWaterSupply = false,
            HasElectricity = true,
            MarketValue = 4500000m,
            Coordinates = new GeographicCoordinates
            {
                Latitude = 12.3456,
                Longitude = 12.3456
            }
        };

        // Пример использования структуры FireSafetyViolationAct
        FireSafetyViolationAct act = new FireSafetyViolationAct
        {
            ActNumber = "FS-2026-1111",
            InspectionDate = new DateTime(2026, 11, 11),
            InspectedEntity = "ООО 'Дача богача'",
            Violations = new string[]
            {
                "Отсутствие огнетушителей",
                "Захламление эвакуационных путей",
                "Неисправность пожарной сигнализации"
            },
            InspectorInfo = new Inspector
            {
                FullName = "Петров Иван Сидорович",
                Position = "Старший инспектор",
                BadgeNumber = "IN-789"
            },
            FineAmount = 150000m,
            DeadlineDays = 30
        };

        // Пример использования структуры MusicBand
        MusicBand band = new MusicBand
        {
            BandName = "Завитушки",
            Genre = "Рок",
            FoundedYear = 2015,
            Members = new Musician[]
            {
                new Musician { StageName = "DJ Shadow", RealName = "Алексей Петров", Instrument = "Вокал", Age = 35 },
                new Musician { StageName = "Strummer", RealName = "Иван Иванов", Instrument = "Гитара", Age = 32 },
                new Musician { StageName = "Beats", RealName = "Максим Сидоров", Instrument = "Барабаны", Age = 28 }
            },
            AlbumsCount = 3,
            PopularSongs = new string[] { "Ночной полет", "Звезда", "Дождь" },
            Country = "Россия"
        };

        // Вывод информации для проверки
        Console.WriteLine($"Объект недвижимости: {estate.CadastralNumber}, строения: {string.Join(", ", estate.Buildings)}");
        Console.WriteLine($"Акт нарушения: {act.ActNumber}, нарушений: {act.Violations.Length}");
        Console.WriteLine($"Группа: {band.BandName}, участники: {band.Members.Length}");
        Console.ReadKey();
    }
}
