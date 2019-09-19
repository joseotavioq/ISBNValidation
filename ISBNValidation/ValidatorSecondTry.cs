using System.Collections.Generic;
using System.Linq;

namespace ISBNValidation {
    public class ValidatorSecondTry {
        //O(1) - space complexity
        //O(n) - time complexity
        public bool IsValidIsbn(string isbn) {
            int countOfDigits = 1;
            int countOfDashes = 0;
            int lastDigit = 0;
            int checksum = 0;

            char currentChar = isbn[isbn.Length - 1];

            if (isbn[0] == '-' || currentChar == '-') {
                return false;
            }

            if (char.IsDigit(currentChar)) {
                lastDigit = (currentChar - 48);
            } else if (currentChar == 'X' || currentChar == 'x') {
                lastDigit = 10;
            } else {
                return false;
            }

            for (int i = 0; i < isbn.Length - 1; i++) {
                currentChar = isbn[i];

                if (currentChar == '-') {
                    if (currentChar == isbn[i + 1]) {
                        return false;
                    }
                    countOfDashes++;
                } else if (char.IsDigit(currentChar)) {
                    checksum += countOfDigits++ * (currentChar - 48);
                    if (countOfDigits > 10) {
                        return false;
                    }
                } else {
                    return false;
                }
            }
            return ((countOfDashes == 0 || countOfDashes == 3) && (checksum % 11) == lastDigit);
        }
    }
}