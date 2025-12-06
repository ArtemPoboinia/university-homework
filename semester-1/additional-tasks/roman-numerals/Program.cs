using System;

class Program
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        string result = "";

        if (num >= 100)
        {
            result += "C";
            num -= 100;
        }

        if (num >= 90)
        {
            result += "XC";
            num -= 90;
        }
        else if (num >= 50)
        {
            result += "L";
            num -= 50;
            if (num >= 40)
            {
                result += "XL";
                num -= 40;
            }
            else if (num >= 30)
            {
                result += "XXX";
                num -= 30;
            }
            else if (num >= 20)
            {
                result += "XX";
                num -= 20;
            }
            else if (num >= 10)
            {
                result += "X";
                num -= 10;
            }
        }
        else if (num >= 40)
        {
            result += "XL";
            num -= 40;
        }
        else if (num >= 10)
        {
            int tens = num / 10;
            switch (tens)
            {
                case 3: result += "XXX";
                    num -= 30;
                    break;
                case 2: result += "XX";
                    num -= 20;
                    break;
                case 1: result += "X";
                    num -= 10;
                    break;
            }
        }

        if (num >= 9)
        {
            result += "IX";
            num -= 9;
        }
        else if (num >= 5)
        {
            result += "V";
            num -= 5;
            if (num >= 4)
            {
                result += "IV";
                num -= 4;
            }
            else if (num >= 3)
            {
                result += "III";
                num -= 3;
            }
            else if (num >= 2)
            {
                result += "II";
                num -= 2;
            }
            else if (num >= 1)
            {
                result += "I";
                num -= 1;
            }
        }
        else if (num >= 4)
        {
            result += "IV";
            num -= 4;
        }
        else if (num >= 1)
        {
            switch (num)
            {
                case 3:
                    result += "III";
                    break;
                case 2:
                    result += "II";
                    break;
                case 1:
                    result += "I";
                    break;
            }
        }

        Console.WriteLine(result);

        Console.ReadLine();
    }
}