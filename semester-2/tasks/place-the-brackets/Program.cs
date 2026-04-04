// Побойня Артём 5130903-50002

using System;
using System.Collections.Generic;

class Program
{
    // Функция для определения приоритета операций
    static int GetPriority(string op)
    {
        switch (op)
        {
            case "+":
            case "-":
                return 1;
            case "*":
            case "/":
                return 2;
            default:
                return 0;
        }
    }

    // Функция для сворачивания операции
    static void Reduce(Stack<string> operators, Stack<string> operands)
    {
        string op = operators.Pop();
        string right = operands.Pop();
        string left = operands.Pop();
        string result = $"( {left} {op} {right} )";
        operands.Push(result);
    }

    // Функция разбора строки на лексемы
    static List<string> Tokenize(string input)
    {
        var tokens = new List<string>();
        string currentNumber = "";

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (c == ' ')
                continue;

            if (char.IsDigit(c) || c == ',')
            {
                currentNumber += c;
            }
            else
            {
                if (currentNumber != "")
                {
                    tokens.Add(currentNumber);
                    currentNumber = "";
                }

                tokens.Add(c.ToString());
            }
        }

        if (currentNumber != "")
        {
            tokens.Add(currentNumber);
        }

        return tokens;
    }

    // Алгоритм Рутисхаузера
    static List<string> AddFullBrackets(List<string> tokens)
    {
        var operators = new Stack<string>();
        var operands = new Stack<string>();

        for (int i = 0; i < tokens.Count; i++)
        {
            string token = tokens[i];

            if (char.IsDigit(token[0]) || (token.Length > 1 && char.IsDigit(token[0]) && token.Contains(',')))
            {
                operands.Push(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    Reduce(operators, operands);
                }
                if (operators.Count > 0 && operators.Peek() == "(")
                {
                    operators.Pop();
                }
            }
            else if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                if (token == "-" && (i == 0 || tokens[i - 1] == "("))
                {
                    operands.Push("0");
                }

                while (operators.Count > 0 && operators.Peek() != "(" &&
                       GetPriority(operators.Peek()) >= GetPriority(token))
                {
                    Reduce(operators, operands);
                }

                operators.Push(token);
            }
        }

        while (operators.Count > 0)
        {
            Reduce(operators, operands);
        }

        string result = operands.Pop();
        var finalTokens = new List<string>(result.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        return finalTokens;
    }

    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        
        List<string> tokens = Tokenize(input);
        
        List<string> result = AddFullBrackets(tokens);
        
        Console.WriteLine(string.Join(" ", result));
        Console.ReadKey();
    }
}