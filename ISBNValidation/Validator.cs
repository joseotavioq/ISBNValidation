using BenchmarkDotNet.Attributes;

namespace ISBNValidation
{
    [MemoryDiagnoser]
    public class Validator
    {
        private const string VALID_ISBN = "0-306-40615-2";
        private const string INVALID_ISBN = "0-306-40615-4";
        private const string LARGE_INPUT = "1111-111111111111111111111111111111111111111111111111111111111111-111111111111111111111111111111111111111111111111111-1111111111111111111111";

        private ValidatorBaseline baseline = new ValidatorBaseline();
        private ValidatorFirstTry firstTry = new ValidatorFirstTry();
        private ValidatorSecondTry secondTry = new ValidatorSecondTry();

        //For Unit Test Only
        public bool IsValidIsbn(string isbn)
        {
            bool first = baseline.IsValidIsbn(isbn);
            bool second = firstTry.IsValidIsbn(isbn);
            bool third = secondTry.IsValidIsbn(isbn);

            return first && second && third;
        }

        [Benchmark(Baseline = true)]
        [Arguments(VALID_ISBN)]
        [Arguments(INVALID_ISBN)]
        [Arguments(LARGE_INPUT)]
        public void Baseline(string isbn)
        {
            baseline.IsValidIsbn(isbn);
        }

        [Benchmark]
        [Arguments(VALID_ISBN)]
        [Arguments(INVALID_ISBN)]
        [Arguments(LARGE_INPUT)]
        public void ValidatorFirstTry(string isbn)
        {
            firstTry.IsValidIsbn(isbn);
        }

        [Benchmark]
        [Arguments(VALID_ISBN)]
        [Arguments(INVALID_ISBN)]
        [Arguments(LARGE_INPUT)]
        public void ValidatorSecondTry(string isbn)
        {
            secondTry.IsValidIsbn(isbn);
        }
    }
}