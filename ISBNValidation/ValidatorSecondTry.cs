using System.Collections.Generic;
using System.Linq;

namespace ISBNValidation
{
    public class ValidatorSecondTry
    {
        //O(1) - space complexity
        //O(n) - time complexity
        public bool IsValidIsbn(string isbn)
        {
            int indexOfNumbers = 0;
            int numberOfDashes = 0;
            int lastDashFound = -1;
            int lastDigit = 0;
            int checksum = 0;

            //O(n)
            for (int i = 0; i < isbn.Length; i++)
            {
                int currentChar = isbn[i]; //O(1)

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
                    int currentValue = -1;

                    if (currentChar == 88 || currentChar == 120) // X or x
                        currentValue = 10;
                    else if (currentChar >= 48 && currentChar <= 57) //if is number
                        currentValue = currentChar - 48; //48 = '0'

                    if (currentValue > -1)
                    {
                        indexOfNumbers++;
                        lastDigit = currentValue;
                        if (indexOfNumbers < 10)
                            checksum += indexOfNumbers * currentValue; //O(1)
                        else if (indexOfNumbers > 10)
                            return false;
                    }
                }
            }

            if (!(numberOfDashes == 0 || numberOfDashes == 3))
                return false;

            return ((checksum % 11) == lastDigit);
        }
    }
}