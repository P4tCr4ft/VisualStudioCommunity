using System;
using System.Collections.Generic;

namespace list_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // List of string
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (string name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
            names.Add("Fred");
            names.Add("Wilma");
            names.Remove("<name>");

            // search for index, returns an int, returns -1 for not found
            names.IndexOf("Wilma");

            // sort, default comparer for string is sort alphabetially
            names.Sort();

            // or another slightly more clunky way, showing some indexing
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"Hello {names[i].ToUpper()}!");
            }




            // List of integers
            var fibonacciNumbers = new List<int> { 1, 1 };
            Console.WriteLine($"fibonacci number 1 is 1");
            Console.WriteLine($"fibonacci number 2 is 1");

            var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
            var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

            //fibonacciNumbers.Add(previous2 + previous);

            foreach (var item in fibonacciNumbers)
                Console.WriteLine(item);

            for (int i = 1; i < 19; i++)
            {
                fibonacciNumbers.Add(previous + previous2);
                previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                Console.WriteLine($"fibonacci number {i + 2} is {fibonacciNumbers[i + 1]}");
            }
            //foreach (var item in fibonacciNumbers)
            //    Console.WriteLine($"fibonacci sequence number is {item}");



        }
    }
}
