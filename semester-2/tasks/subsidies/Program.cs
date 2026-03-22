using System;

// Структура ребенка
public struct Child
{
    public string FullName;
    public DateTime BirthDay;
    public string ID;
    public bool Gender;
    public int Age
    {
        get
        {
            TimeSpan ts = DateTime.Now - BirthDay;
            DateTime res = DateTime.MinValue.Add(ts);
            return res.Year - 1;
        }
    }
}


// Структура родителя
public struct Parent
{
    public string FullName;
    public DateTime BirthDay;
    public bool Gender;
    public int Age;
    public string ID;
    public Child[] Children;
    public int CountOfChildren;
}

class Program
{
    public static void Main(string[] args)
    {
        // Дети
        Child child1 = new Child
        {
            FullName = "Иванов Иван Иванович",
            BirthDay = new DateTime(2015, 5, 10),
            ID = "123456",
            Gender = true
        };

        Child child2 = new Child
        {
            FullName = "Иванов Петр Иванович",
            BirthDay = new DateTime(2018, 3, 15),
            ID = "123457",
            Gender = true
        };

        Child child3 = new Child
        {
            FullName = "Петрова Мария Ивановна",
            BirthDay = new DateTime(2010, 8, 20),
            ID = "123458",
            Gender = false
        };

        Child child4 = new Child
        {
            FullName = "Петров Николай Иванович",
            BirthDay = new DateTime(2007, 04, 25),
            ID = "123459",
            Gender = true
        };

        // Родители
        Parent parent1 = new Parent
        {
            FullName = "Иванов Петр Иванович",
            BirthDay = new DateTime(1980, 1, 1),
            Gender = true,
            Age = 44,
            ID = "1234 567890",
            Children = new Child[] { child1, child2 },
            CountOfChildren = 2
        };

        Parent parent2 = new Parent
        {
            FullName = "Петров Иван Петрович",
            BirthDay = new DateTime(1980, 1, 1),
            Gender = true,
            Age = 44,
            ID = "1234 567891",
            Children = new Child[] { child3, child4 },
            CountOfChildren = 2
        };

        Parent parent3 = new Parent
        {
            FullName = "Максимова Мария Максимовна",
            BirthDay = new DateTime(1980, 1, 1),
            Gender = false,
            Age = 44,
            ID = "1234 567892",
            Children = new Child[] { },
            CountOfChildren = 0
        };

        // Массив родителей
        Parent[] Parents = new Parent[] { parent1, parent2, parent3 };

        int total = 100000;

        double[] subsidies = GetSubsidies(Parents, total);

        foreach (int i in subsidies)
        {
            Console.Write($"{i} ");
        }

        Console.ReadKey();
    }

    public static double[] GetSubsidies(Parent[] Parents, int total)
    {
        double[] subsidies = new double[Parents.Length];
        double totalCoefficient = 0;

        // Массив для хранения суммы коэффициентов каждого родителя
        double[] parentCoefficients = new double[Parents.Length];
        // Массив для хранения количества подходящих детей у каждого родителя
        int[] eligibleChildrenCount = new int[Parents.Length];

        // Вычисляем коэффициенты для всех подходящих детей
        for (int i = 0; i < Parents.Length; i++)
        {
            Parent parent = Parents[i];
            double parentCoefficient = 0;
            int eligibleCount = 0;

            if (parent.CountOfChildren >= 2)
            {
                // Перебираем всех детей родителя
                for (int j = 0; j < parent.Children.Length; j++)
                {
                    Child child = parent.Children[j];

                    if (child.Age <= 16)
                    {
                        // Добавляем коэффициент для этого ребенка
                        double childCoefficient = 1 + j * 0.1;
                        parentCoefficient += childCoefficient;
                        eligibleCount++;
                    }
                }
            }

            // Сохраняем результаты для этого родителя
            parentCoefficients[i] = parentCoefficient;
            eligibleChildrenCount[i] = eligibleCount;
            totalCoefficient += parentCoefficient;
        }

        // Вычисляем базовую ставку
        double baseRate = total / totalCoefficient;

        // Вычисляем субсидии для каждого родителя
        for (int i = 0; i < Parents.Length; i++)
        {
            if (eligibleChildrenCount[i] > 0)
            {
                subsidies[i] = parentCoefficients[i] * baseRate;
            }
            else
            {
                subsidies[i] = 0;
            }
        }

        return subsidies;
    }
}