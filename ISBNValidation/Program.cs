using BenchmarkDotNet.Running;
using System;

namespace ISBNValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Validator>();
            //if (args.Length == 1 && (args[0].Length == 10 || args[0].Length == 13))
            //{
            //    var isValid = new Validator().IsValidIsbn(args[0]);

            //    Console.WriteLine($"ISBN is valid? {isValid}");
            //}
        }
    }
}