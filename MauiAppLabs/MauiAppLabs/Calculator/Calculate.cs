using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLabs.Calculator
{
    static class Calculate
    {
        public static string operation { get; set; }
        public static bool error;

        public static string ChangeOperation(string str)
        {
            str = str.Substring(0, str.Length - 1);
            return str;
        }

        public static void DataOfOperation(out bool wasOperation, out int status, string oper)
        {
            wasOperation = true;
            status = -2;
            operation = oper;
        }

        public static double Equal(double firstNum, double secondNum)
        {
            switch (operation)
            {
                case "+":
                    firstNum = Sum(firstNum, secondNum);
                    break;
                case "-":
                    firstNum = Minus(firstNum, secondNum);
                    break;
                case "*":
                    firstNum = Multiply(firstNum, secondNum);
                    break;
                case "/":
                    firstNum = Del(firstNum, secondNum);
                    break;
                case "mod":
                    firstNum = Mod(firstNum, secondNum);
                    break;
                default:
                    break;
            }
            return firstNum;
        }

        public static double Sum(double first, double second)
        {
            Errors(first, second);

            if (error)
                return 0;

            return first + second;
        }

        public static double Minus(double first, double second)
        {
            Errors(first, second);

            if (error)
                return 0;

            return first - second;
        }

        public static double Multiply(double first, double second)
        {
            Errors(first, second);

            if (error)
                return 0;

            return first * second;
        }

        public static double Del(double first, double second)
        {
            Errors(first, second);

            if (error)
                return 0;

            return first / second;
        }

        public static double Mod(double first, double second)
        {
            Errors(first, second);

            if (error)
                return 0;

            return first % second;
        }

        public static double Reverse(double first, out int status)
        {
            status = -1;
            return 1 / first;
        }

        public static double Pow(double first, out int status)
        {
            status = -1;
            return Math.Pow(first, 2);
        }

        public static double Sqrt(double first, out int status)
        {
            status = -1;
            return Math.Sqrt(first);
        }

        public static double Percent(double first, out int status)
        {
            status = -1;
            return first * 0.01;
        }

        public static void Errors(double first, double second)
        {
            if (first * second >= double.MaxValue &&
                first - second <= double.MinValue)
            {
                error = true;
                return;
            }

            if (operation == "/" | operation == "mod")
            {
                if (second == 0)
                {
                    error = true;
                    return;
                }
            }
        }

        public static void Errors(double first)
        {
            if (first * first >= double.MaxValue)
            {
                error = true;
                return;
            }

            if (operation == "reverse" && first == 0)
            {
                error = true;
                return;
            }

            if (operation == "sqrt" && first < 0)
            {
                error = true;
                return;
            }
        }
    }
}
