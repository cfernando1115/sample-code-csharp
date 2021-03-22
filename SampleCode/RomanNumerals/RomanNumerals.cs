using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SampleCode
{
    public class RomanNumerals
    {
        public Dictionary<int, string> romanNumerals { get; private set; }
        public RomanNumerals()
        {
            romanNumerals = new Dictionary<int, string>
            {

                {1,"I" },
                {5,"V" },
                {10,"X" },
                {50,"L" },
                {100,"C" },
                {500,"D" },
                {1000,"M" }

            };
        }

        public bool ValidateNumber(int number)
        {
            if (number > 3999 || number < 1)
            {
                return false;
            }
            return true;
        }

        public string ConvertToRomanNumerals(int number)
        {
            //Validate number
            if (ValidateNumber(number))
            {
                var romanNumeral = new StringBuilder();


                //Determine size of input

                var subNumber = number;
                var divisor = 1;
                while (number / (divisor * 10) != 0)
                {
                    divisor *= 10;
                }

                //Do Conversions

                while (subNumber > 0)
                {
                    var remainder = subNumber / divisor;
                    subNumber -= (divisor * remainder);
                    if (remainder == 9)
                    {
                        romanNumeral.Append(romanNumerals[divisor]);
                        romanNumeral.Append(romanNumerals[divisor * 10]);
                        remainder = 0;
                    }
                    if (remainder < 9 && remainder > 3)
                    {
                        if (remainder == 4)
                        {
                            romanNumeral.Append(romanNumerals[divisor]);
                            romanNumeral.Append(romanNumerals[divisor * 5]);
                            remainder -= 4;
                        }
                        else
                        {
                            romanNumeral.Append(romanNumerals[divisor * 5]);
                            remainder -= 5;
                        }
                    }
                    if (remainder < 4 && remainder > 0)
                    {
                        while (remainder > 0)
                        {
                            romanNumeral.Append(romanNumerals[divisor]);
                            remainder--;
                        }
                    }

                    //Adjust divisor according to subNumber

                    if (subNumber > 0)
                    {
                        while (subNumber / divisor == 0)
                        {
                            divisor /= 10;
                        }
                    }
                }
                return romanNumeral.ToString();
            }
            return "Number out of range";
        }
    }
}
