using System;
using HoleCounterV1;

namespace HoleCounterV1Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();

            var text = Console.ReadLine();

            Console.WriteLine($"text \"{text}\" has {counter.Count(text)} holes.");
        }
    }
}