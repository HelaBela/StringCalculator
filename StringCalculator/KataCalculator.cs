using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Sources;

namespace StringCalculator
{
    public class KataCalculator
    {
        public int Add(string userInput)
        {
            if (userInput == String.Empty) return 0;

            var negatvieDigitsFound = GetNegativeDigits(userInput);

            if (negatvieDigitsFound.Any())
            {
                throw new Exception(GetExceptionMessageString(negatvieDigitsFound));
            }


            var customDelimiters = GetCustomDelimiter(userInput);

            if (customDelimiters.Any())
            {
                userInput = GetInputWithoutCustomDelimiter(userInput, customDelimiters);
            }

            var inputDigits = GetStringDigits(userInput);


            return GetMatchCollectionSumTotal(inputDigits);
        }

        private string GetInputWithoutCustomDelimiter(string userInput, MatchCollection customDelimiter)
        {
            var delimitersAsStrings = customDelimiter.Select(d => d.ToString());

            foreach (var delimiter in delimitersAsStrings)
            {
                userInput = userInput.Replace(delimiter, " ");
            }


            return userInput;
        }

        private MatchCollection GetCustomDelimiter(string userInput)
        {
            var delimiter = new Regex(@"(?<=\[)(.{3})(?=\])");

            return delimiter.Matches(userInput);
        }

        private string GetExceptionMessageString(MatchCollection negativeDigits)
        {
            return string.Join(", ", negativeDigits.Select(m => m.ToString()));
        }

        private MatchCollection GetNegativeDigits(string input)
        {
            var negativeDigits = new Regex(@"(-\d+)");

            return negativeDigits.Matches(input);
        }

        private MatchCollection GetStringDigits(string input)
        {
            var digits = new Regex(@"\d+");

            return digits.Matches(input);
        }

        private int GetMatchCollectionSumTotal(IEnumerable extractedDigits)
        {
            var sum = 0;
            foreach (var number in extractedDigits)
            {
                var parsedNumber = int.Parse(number.ToString());

                if (parsedNumber < 1000)
                {
                    sum += parsedNumber;
                }
            }

            return sum;
        }
    }
}