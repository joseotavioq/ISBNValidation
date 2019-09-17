using System.Collections.Generic;
using System.Linq;

namespace ISBNValidation
{
    public class ValidatorSecondTry
    {
        //O(n) - time complexity
        public bool IsValidIsbn(string isbn)
        {
            int[] numbers = new int[isbn.Length];
            int indexOfNumbers = 0;
            int numberOfDashes = 0;
            int lastDashFound = -1;
            int checksum = 0;

            //O(n)
            for (int i = 0; i < isbn.Length; i++)
            {
                char currentChar = isbn[i];

                if (currentChar == 45) //45 = '-'
                {
                    numberOfDashes++;

                    if (i == 0 || i == isbn.Length - 1)
                        return false;

                    if (i - lastDashFound == 1)
                        return false;

                    lastDashFound = i;
                }
                else
                {
                    if (currentChar == 88 || currentChar == 120) // X or x
                        numbers[indexOfNumbers++] = 10;
                    else if (currentChar >= 48 && currentChar <= 57)  //if is number
                        numbers[indexOfNumbers++] = currentChar - 48; //48 = '0'

                    if (indexOfNumbers < 10)
                        checksum += indexOfNumbers * numbers[indexOfNumbers - 1]; //O(1)
                    else if (indexOfNumbers > 10)
                        return false;
                }
            }

            checksum %= 11;

            if (!(numberOfDashes == 0 || numberOfDashes == 3))
                return false;

            int lastDigit = numbers[indexOfNumbers - 1];

            return (checksum == lastDigit);
        }
    }
}