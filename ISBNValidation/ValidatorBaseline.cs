using System.Collections.Generic;
using System.Linq;

namespace ISBNValidation
{
    public class ValidatorBaseline
    {
        //O(n) - time complexity
        public bool IsValidIsbn(string isbn)
        {
            //O(n)
            if (isbn.Contains("--") || isbn.StartsWith("-") || isbn.EndsWith("-"))
                return false;

            //O(n)
            if (!(isbn.Count(c => c == 45) == 0 || isbn.Count(c => c == 45) == 3)) //45 = '-'
                return false;

            var cleanIsbn = ReduceToNumbers(isbn);

            //O(1)
            if (cleanIsbn.Count() != 10)
                return false;

            int checksum = CalculateChecksum(cleanIsbn);

            //O(n)
            int lastDigit = cleanIsbn.Last();

            return (checksum == lastDigit);
        }

        private IEnumerable<int> ReduceToNumbers(string isbn)
        {
            //O(n) + O(n)
            return isbn.Where(c => c != 45).Select(c =>
            {
                int number = 0;

                if (c == 88 || c == 120) // X or x
                    number = 10;
                else
                    int.TryParse(c.ToString(), out number);

                return number;
            });
        }

        private int CalculateChecksum(IEnumerable<int> cleanIsbn)
        {
            //O(9)
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (i + 1) * cleanIsbn.ElementAt(i); //O(n)

            return sum % 11;
        }
    }
}