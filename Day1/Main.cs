using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input");
            
            int length = lines.Length;
            int[] parsed = new int[length];
            int count = 0;
            
            for (int i = 0; i < length; i++)
            {
                parsed[i] = int.Parse(lines[i]);
                if (i > 0 && parsed[i - 1] < parsed[i])
                {
                    count++;
                }
            }

            Console.WriteLine("Decreased {0} times", count);
        }
    }
}