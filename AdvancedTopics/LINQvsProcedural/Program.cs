using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LINQvsProcedural
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var primes = PrimesUpTo(1_000_000);
            sw.Stop();
            Console.WriteLine($"With LINQ: {sw.ElapsedMilliseconds}");

            sw.Restart();
            primes = ProceduralPrimesUpTo(1_000_000);
            sw.Stop();
            Console.WriteLine($"With procedural: {sw.ElapsedMilliseconds}");

            Console.Read();
        }

        static List<int> PrimesUpTo(int n)
        {
            return Enumerable
                .Range(1, n)
                .Where(IsPrime)
                .ToList();
        }

        private static bool IsPrime(int i)
        {
            if (i == 0 || i == 1)
                return false;

            for (int j = 2; j < i; j++)
                if (i % j == 0)
                    return false;

            return true;
        }

        static List<int> ProceduralPrimesUpTo(int n)
        {
            var primes = new List<int>();

            for(int i = 2; i < n; i++)
                if (IsPrime(i))
                    primes.Add(i);

            return primes;
        }
    }
}
