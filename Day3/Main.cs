using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            string[] lines = File.ReadAllLines("../../../input");
            int gamma = 0;
            int epsilon = 0;
            
            for (int i = 0; i < lines[0].Length; i++)
            {
                int countOnes = 0;

                for (int j = 0; j < lines.Length; j++)
                {
                    string line = lines[j];
                    if (line[i] == '1')
                    {
                        countOnes += 1;
                    }
                }

                if (countOnes > lines.Length/2)
                {
                    gamma = gamma * 2 + 1;
                    
                    epsilon = epsilon * 2;
                }
                else
                {
                    gamma = gamma * 2;
                    epsilon = epsilon * 2 + 1;
                }
            }

            Console.WriteLine("Part1: The value of epsilon multiplied by gamma is: {0}", gamma * epsilon);
        }
    }
}