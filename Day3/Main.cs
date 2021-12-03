using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input");
            
            //Part1(lines);
            Part2(lines);
        }

        static int MostPresentBit(List<string> lines, int index)
        {
            int countOnes = 0;
            int zeros = 0;
            if (index >= lines[0].Length)
            {
                Console.Error.WriteLine("index > nb of char on a line");
            }

            foreach (var line in lines)
            {
                if (line[index] == '1')
                {
                    countOnes += 1;
                }
                else
                {
                    zeros++;
                }
            }

            if (countOnes >= zeros)
            {
                return 1;
            }

            return 0;
        }

        static int LeastPresentBit(List<string> lines, int index)
        {
            if (MostPresentBit(lines, index) == 1)
            {
                return 0;
            }

            return 1;
        }

        static void ThresholdList(List<string> list, int msb, int index)
        {
            for (int i = 0; i < list.Count;)
            {
                if (list[i][index] != msb + '0')
                {
                    list.Remove(list[i]);
                }
                else
                {
                    i++;
                }
            }
        }

        static void Part2(string[] lines)
        {
            List<string> oxygen = new List<string>();
            List<string> carbon = new List<string>();

            int mostPresentBitS = MostPresentBit(lines.ToList(), 0);
            foreach (var line in lines)
            {
                if (line[0] == mostPresentBitS + '0')
                {
                    oxygen.Add(line);
                }
                else
                {
                    carbon.Add(line);
                }
            }

            
            int index = 1;
            while (index < lines[0].Length && oxygen.Count > 1)
            {
                int mostPresentBit = MostPresentBit(oxygen, index);
                ThresholdList(oxygen, mostPresentBit, index);
                index++;
            }
            
            int oxygenFinal = Convert.ToInt32(oxygen[0], 2);

            index = 1;
            while (index < lines[0].Length && carbon.Count > 1)
            {
                int leastPresentBit = LeastPresentBit(carbon, index);
                ThresholdList(carbon, leastPresentBit, index);
                index++;
            }

            int carbonFinal = 0;
            foreach (var element in carbon)
            {
                foreach (var c in element)
                {
                    if (c == '0')
                    {
                        carbonFinal *= 2;
                    }
                    else if (c == '1')
                    {
                        carbonFinal *= 2;
                        carbonFinal += 1;
                    }
                }
                
            }

            Console.WriteLine("Oxygen = {0}, Carbon = {1}, Final Result = {2}",oxygenFinal, carbonFinal, oxygenFinal * carbonFinal);
        }

        static void Part1(string[] lines)
        {
            
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