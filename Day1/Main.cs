using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input");
            
            int count = NormalMesurement(lines);
            int count2 = SlidingWindow(lines);
            Console.WriteLine("Decreased {0} times", count2);
        }

        static int NormalMesurement(string[] lines)
        {
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

            return count;
        }

        static int SlidingWindow(string[] lines)
        {
            int length = lines.Length;
            int[] parsed = new int[length];
            int[] sliding = new int[length - 2];
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                parsed[i] = int.Parse(lines[i]);
                if (i > 1)
                {
                    sliding[i - 2] = parsed[i] + parsed[i - 1] + parsed[i - 2];
                }

                if (i > 2 && sliding[i - 2] > sliding[i - 3])
                {
                    count++;
                }
            }

            return count;
        }
    }
}