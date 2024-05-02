using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace lb2_2sem
{
    public static class AdditionalLogic
    {
        //Перевіряє, чи можна додати оператор до рядка введення
        public static bool CanAddOperator(string inputText, string newOperator)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return false;
            }
            return true;
        }
        //Нормалізує оператори в рядку введення, замінюючи подвійні оператори на одинарні.
        public static string NormalizeOperators(string inputText)
        {

            string pattern = @"([+\-×\÷])\1+";
            string normalizedText = Regex.Replace(inputText, pattern, "$1");
            normalizedText = Regex.Replace(normalizedText, @"[+\-×\÷/]+", match =>
            {
                return match.Value[0].ToString();
            });

            return normalizedText;

        }
        //Перевіряє, чи можна додати "0" до рядка введення.
        public static bool CanAddZero(string inputText, string[] operands)
        {
            Regex regex = new Regex(@"\d*[1-9]\d*");
            bool flag = false;
            foreach (var operand in operands)
            {
                flag = false;
                if (regex.IsMatch(operand))
                {
                    flag = true;
                }
            }
            return string.IsNullOrEmpty(inputText) || flag || inputText.Last() == '×' || inputText.Last() == '+' || inputText.Last() == '-';
        }
        //Перевіряє, чи можна додати "00" до рядка введення.
        public static bool CanAddDoubleZero(string inputText, string[] operands)
        {
            Regex regex = new Regex(@"\d*[1-9]\d*");
            bool flag = false;
            foreach (var operand in operands)
            {
                flag = false;
                if (regex.IsMatch(operand))
                {
                    flag = true;
                }
            }
            if (!string.IsNullOrEmpty(inputText))
                return flag;
            return false;
        }
        // Перевіряє, чи можна додати "0" після десяткової крапки.
        public static bool CanAddZeroAfterDecimalPoint(string inputText)
        {
            return inputText.Contains(".");
        }
        //Перевіряє, чи можна додати десяткову крапку до рядка введення.
        public static bool CanAddDecimalPoint(string inputText)
        {
            return !string.IsNullOrEmpty(inputText);
        }
        //Нормалізує крапки в рядку введення, замінюючи послідовності точок на одну точку.
        public static string NormalizeDots(string inputText)
        {
            return Regex.Replace(inputText, @"(?<=\d)\.+([0-9])", ".$1");
        }
        //Перевіряє, чи є символ оператором (+, -, *, /).
        public static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        //Перевіряє, чи допустимий символ введений користувачем. 
        public static bool IsAllowedInput(string input)
        {

            return char.IsDigit(input[0]) || IsOperator(input[0]) || input == ".";
        }
        // Переміщує курсор до кінця текстового поля.
        public static void MoveCursorToEnd(TextBox textBox)
        {
            textBox.Select(textBox.Text.Length, 0);
        }
        //Налаштовує розмір шрифту текстового поля в залежності від довжини тексту.
        public static void AdjustFontSize(TextBox textBox)
        {
            if (textBox.Text.Length > 30)
            {
                textBox.FontSize = 14;
            }
            else if (textBox.Text.Length > 15)
            {
                textBox.FontSize = 18;
            }
            else
            {
                textBox.FontSize = 22;
            }
        }

    }

}
