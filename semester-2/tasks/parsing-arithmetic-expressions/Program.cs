using System;
using System.Globalization;
using System.Text;

namespace RutishauserAssignment
{
    public struct Element
    {
        public string Value; // Значение (число или оператор)
        public int Weight;   // Вес (уровень вложенности)
        public int Next;     // Курсор (индекс следующего элемента в массиве)
    }

    // Класс для работы со списком на базе массива и курсоров
    public class CursorList
    {
        private Element[] _data;
        private int _head;
        private int _count;

        public int Head => _head;
        public Element[] Data => _data;

        public CursorList(int capacity)
        {
            _data = new Element[capacity];
            _head = -1;
            _count = 0;
        }

        // Добавление элемента в конец списка
        public void Add(string value, int weight)
        {
            if (_count >= _data.Length) return;

            int newIndex = _count;
            _data[newIndex] = new Element { Value = value, Weight = weight, Next = -1 };

            if (_head == -1)
            {
                _head = newIndex;
            }
            else
            {
                int curr = _head;
                while (_data[curr].Next != -1)
                    curr = _data[curr].Next;
                _data[curr].Next = newIndex;
            }
            _count++;
        }

        // Замена триады (операнд - оператор - операнд) одним значением
        public void ReplaceTriad(int prevIdx, int startIdx, string newValue, int newWeight)
        {
            int opIdx = _data[startIdx].Next;
            int secondOperandIdx = _data[opIdx].Next;
            int afterTriadIdx = _data[secondOperandIdx].Next;

            // Обновляем первый элемент триады — теперь это результат
            _data[startIdx].Value = newValue;
            _data[startIdx].Weight = newWeight;
            _data[startIdx].Next = afterTriadIdx;

            // Специальный случай: если мы заменили элементы в самом начале списка
            if (startIdx == _head)
            {
                // Head остается тем же, так как мы изменили содержимое data[startIdx]
            }
            else if (prevIdx != -1)
            {
                _data[prevIdx].Next = startIdx;
            }
        }
    }

    // 3. Основная логика алгоритма
    public class RutishauserProgram
    {
        public static void Main()
        {
            // Настройка культуры для корректного чтения чисел с запятой (10,5)
            CultureInfo culture = new CultureInfo("ru-RU");

            string[] expressions = { "((2-11)/(10-8))", "(11-((5+10,5)*2))" };

            foreach (var expr in expressions)
            {
                try
                {
                    double result = Evaluate(expr, culture);
                    Console.WriteLine($"{expr} = {result.ToString(culture)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при вычислении {expr}: {ex.Message}");
                }
            }
        }

        public static double Evaluate(string input, CultureInfo culture)
        {
            // Парсинг и расстановка весов
            CursorList list = Parse(input);

            while (true)
            {
                // Находим максимальный вес среди операторов
                int maxWeight = -1;
                int current = list.Head;
                while (current != -1)
                {
                    if (IsOperator(list.Data[current].Value))
                    {
                        if (list.Data[current].Weight > maxWeight)
                            maxWeight = list.Data[current].Weight;
                    }
                    current = list.Data[current].Next;
                }

                // Если операторов больше нет — мы закончили
                if (maxWeight == -1) break;

                // Ищем первую триаду с максимальным весом и вычисляем её
                int prev = -1;
                int curr = list.Head;
                bool simplified = false;

                while (curr != -1)
                {
                    int opIdx = list.Data[curr].Next;
                    if (opIdx != -1 && IsOperator(list.Data[opIdx].Value) && list.Data[opIdx].Weight == maxWeight)
                    {
                        int rightIdx = list.Data[opIdx].Next;
                        if (rightIdx != -1)
                        {
                            double leftVal = double.Parse(list.Data[curr].Value, culture);
                            double rightVal = double.Parse(list.Data[rightIdx].Value, culture);
                            string op = list.Data[opIdx].Value;

                            double res = ApplyOp(leftVal, rightVal, op);
                            
                            list.ReplaceTriad(prev, curr, res.ToString(culture), maxWeight - 1);
                            simplified = true;
                            break;
                        }
                    }
                    prev = curr;
                    curr = list.Data[curr].Next;
                }
                if (!simplified) break;
            }
            return double.Parse(list.Data[list.Head].Value, culture);
        }

        private static CursorList Parse(string input)
        {
            CursorList list = new CursorList(input.Length);
            int weight = 0;
            int i = 0;

            while (i < input.Length)
            {
                char c = input[i];

                if (c == '(')
                {
                    weight++;
                    i++;
                }
                else if (c == ')')
                {
                    weight--;
                    i++;
                }
                else if (char.IsDigit(c))
                {
                    StringBuilder sb = new StringBuilder();
                    while (i < input.Length && (char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'))
                    {
                        sb.Append(input[i] == '.' ? ',' : input[i]);
                        i++;
                    }
                    list.Add(sb.ToString(), weight);
                }
                else if (IsOperator(c.ToString()))
                {
                    list.Add(c.ToString(), weight);
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return list;
        }

        private static bool IsOperator(string s) => s == "+" || s == "-" || s == "*" || s == "/";

        private static double ApplyOp(double a, double b, string op)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                _ => 0
            };
        }
    }
}