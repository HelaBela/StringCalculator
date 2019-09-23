using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static string Add(String input, int indexLookingAt = 0, string indexes = "")
        {

            if (input.Length == 0)
            {
                return indexes; // base case
            }

            var charachterIAmLookigAt = input[0];

            if (charachterIAmLookigAt is '-')
            {
                indexes += indexLookingAt;
            }

            var updatedStringToLookAt = input.Substring(1, input.Length -1);

            return Add(updatedStringToLookAt, indexLookingAt +1 , indexes);
            
            
        }
    }
}

/*else if (i<0)
{
throw new Exception($"Negatives not allowed: {i} ");
}*/


/*var result = 0;


List<string> inputNumbersAsString = input.Split("," ).ToList();

foreach (var numberAsString in inputNumbersAsString)
{
    int number = 0;
    try
    {
        number = Int32.Parse(numberAsString);
    }
    catch (FormatException)
    {
        return number;
    }

    result += number;
}

return result;*/