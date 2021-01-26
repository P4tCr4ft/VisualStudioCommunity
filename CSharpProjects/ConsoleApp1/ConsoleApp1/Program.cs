using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumnum = 0;
            for (int counter = 1; counter < 21; counter++)
            {
                if (counter % 3 == 0)
                {
                    sumnum += counter;
                }
            }
            Console.WriteLine($"Sum of numbers up to 21 divisible by 3 is {sumnum}");
        }
    }
}
