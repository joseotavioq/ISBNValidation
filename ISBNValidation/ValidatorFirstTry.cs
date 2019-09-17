using System.Collections.Generic;
using System.Linq;

namespace ISBNValidation
{
    public class ValidatorFirstTry
    {
        //O(n) - time complexity
        public bool IsValidIsbn(string isbn)
        {
            //O(n)
            if (isbn.Contains("--") || isbn.StartsWith("-") || isbn.EndsWith("-"))
                return false;

            int numberOfDashes = CountTheNumberOfDashes(isbn);

            //O(1)
            if (!(numberOfDashes == 0 || numberOfDashes == 3))
                return false;

            var cleanIsbn = ReduceToNumbers(isbn);

            //O(1)
            if (cleanIsbn.Count != 10)
                return false;

            int checksum = CalculateChecksum(cleanIsbn);

            //O(1)
            int lastDigit = cleanIsbn[cleanIsbn.Count - 1];

            return (checksum == lastDigit);
        }

        private int CountTheNumberOfDashes(string isbn)
        {
            //O(n)
            int count = 0;
            for (var i = 0; i < isbn.Length; i++)
                if (isbn[i] == 45) //45 = '-'
                    count++;

            return count;
        }

        private IList<int> ReduceToNumbers(string isbn)
        {
            List<int> numbers = new List<int>();

            //O(n)
            for (var i = 0; i < isbn.Length; i++)
            {
                char currentChar = isbn[i];

                if (currentChar != 45)
                {
                    if (currentChar == 88 || currentChar == 120) // X or x
                        numbers.Add(10);
                    else if (currentChar >= 48 && currentChar <= 57)  //if is number
                        numbers.Add(currentChar - 48); //48 = '0'
                }
            }

            return numbers;
        }

        private int CalculateChecksum(IList<int> cleanIsbn)
        {
            //O(9)
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (i + 1) * cleanIsbn[i]; //O(1)

            return sum % 11;
        }
    }
}