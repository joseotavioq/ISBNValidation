using BenchmarkDotNet.Attributes;

namespace ISBNValidation
{
    [MemoryDiagnoser]
    public class Validator
    {
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
        public void Baseline()
        {
            baseline.IsValidIsbn("0-306-40615-2");
        }

        [Benchmark]
        public void ValidatorFirstTry()
        {
            firstTry.IsValidIsbn("0-306-40615-2");
        }

        [Benchmark]
        public void ValidatorSecondTry()
        {
            secondTry.IsValidIsbn("0-306-40615-2");
        }
    }
}