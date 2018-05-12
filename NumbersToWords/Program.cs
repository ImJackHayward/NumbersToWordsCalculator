using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace NumbersToWords
{
    class Program
    {

        static String finalString = "";

        static Dictionary<int, string> dict = new Dictionary<int, string>(){
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"},
            {100, "Hundred"},
            {1000, "Thousand"},
        };

        public static void Main(string[] args)
        {
            var originalNumber = 3200;
            var number = originalNumber.ToString();
            number.Select(c => (int)char.GetNumericValue(c)).ToArray();

            for (var i = 0; i < number.Length; i++)
            {
                var numberOfZeros = number.Length - i;
                var itemAsString = (number[i]).ToString().PadRight(numberOfZeros, '0');
                var itemAsNumber = Int32.Parse(itemAsString);

                if (originalNumber > 100 && i == number.Length - 2 && number[number.Length - 1] != '0')
                {
                    finalString += "and ";
                }

                if (itemAsNumber >= 20)
                {
                    finalString += convertNumbersToWords(itemAsNumber) + " ";
                }
                else if (itemAsNumber >= 10)
                {
                    var nextNumber = Int32.Parse(number[i + 1].ToString());
                    finalString += convertNumbersToWords(itemAsNumber + nextNumber) + " ";
                    i++;
                }
                else if (itemAsString.Length == 1)
                {
                    finalString += convertNumbersToWords(itemAsNumber) + " ";
                }
            }
            Console.WriteLine(finalString);
        }

        public static String convertNumbersToWords(int number)
        {
            var numberOfDigits = number.ToString().Length;

            if (numberOfDigits > 2)
            {

                var unit = Math.Pow(10, numberOfDigits - 1);
                var amountOfUnits = number / unit;

                return (dict[(int)amountOfUnits] + ' ' + dict[(int)unit]);

            }
            else if (numberOfDigits == 2)
            {
                return (dict[number]);
            }
            else if (number != 0)
            {
                return (dict[number]);
            }

            return "";
        }
    }
}