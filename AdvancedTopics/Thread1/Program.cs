using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithThreads();

            Console.Read();
        }

        private static void PlayWithThreads()
        {
            var threads = Enumerable
                            .Range(1, 10)
                            .Select(i => new Thread(() =>
                            {
                                Thread.Sleep(i * 300);
                                Console.WriteLine($"I'm Thread 1, id {Thread.CurrentThread.ManagedThreadId}!");
                            }))
                            .ToList();

            foreach (var t in threads)
                t.Start();

            foreach (var t in threads)
                t.Join();

            var t2 = new Thread(() =>
                Console.WriteLine($"I'm Thread 2, id {Thread.CurrentThread.ManagedThreadId}"));
            t2.Start();

            Console.WriteLine($"I'm the Main Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static List<int> PrimesUpTo(int start, int end)
        {
            return Enumerable
                .Range(start, end - start)
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
    }
}
