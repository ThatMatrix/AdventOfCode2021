using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input");
            int lineIndex = 0;
            
            string[] roundNumbersStrings = lines[lineIndex].Split(',');
            int[] roundNumbers = new int[roundNumbersStrings.Length];
            for (int i = 0; i < roundNumbersStrings.Length; i++)
            {
                roundNumbers[i] = int.Parse(roundNumbersStrings[i]);
            }
            
            lineIndex++;//go to 1
            List<Bingo> bingos = new List<Bingo>();
            int numberBingoGrids = (lines.Length - 1) / 6;

            for (int i = 0; i < numberBingoGrids; i++)
            {
                lineIndex++;
                int[][] bingoTable = new int[5][];
                for (int j = 0; j < 5; j++)
                {
                    string[] linetest = lines[lineIndex].Split(' ');
                    linetest = LineClean(linetest);
                    bingoTable[j] = new int[5];
                    for (int k = 0; k < 5; k++)
                    {
                        bingoTable[j][k] = int.Parse(linetest[k]);
                    }

                    lineIndex++;
                }

                Bingo bingo = new Bingo(bingoTable);
                bingos.Add(bingo);
            }
            
            Part1(roundNumbers, bingos);
            Part2(roundNumbers, bingos);

        }

        static void Part2(int[] roundNumbers, List<Bingo> bingos)
        {
            bool found = false;
            int round = 0;
            Bingo won = null;
            while (round < roundNumbers.Length && !found)
            {
                int nbBingo = 0;
                while (nbBingo < bingos.Count && !found)
                {
                    found = bingos[nbBingo].DrawingNumber(roundNumbers[round]);
                    if (found && bingos.Count < 2)
                    {
                        won = bingos[nbBingo];
                    }
                    else if (found && bingos.Count >= 2)
                    {
                        bingos.Remove(bingos[nbBingo]);
                        found = false;
                    }
                    else
                    {
                        nbBingo++;
                    }
                }
                round++;
            }

            if (won == null || round < 1)
            {
                Console.Error.WriteLine("Part 2: did not find winning bingo");    
            }
            else
            {
                Console.WriteLine("Part 2: Won Sum = {0}, lastRound = {1}, finalNumber = {2}",
                    won.SumOfNonSelectedValues(), roundNumbers[round - 1], won.SumOfNonSelectedValues() * roundNumbers[round - 1]);
            }
        }

        static void Part1(int[] roundNumbers, List<Bingo> bingos)
        {
            bool not_found = false;
            int round = 0;
            Bingo won = null;
            while (round < roundNumbers.Length && !not_found)
            {
                int nbBingo = 0;
                while (nbBingo < bingos.Count && !not_found)
                {
                    not_found = bingos[nbBingo].DrawingNumber(roundNumbers[round]);
                    if (not_found)
                    {
                        won = bingos[nbBingo];
                    }

                    nbBingo++;
                }

                round++;
            }

            if (won == null || round < 1)
            {
                Console.Error.WriteLine("did not find winning bingo");    
            }
            else
            {
                Console.WriteLine("Part 1: Won Sum = {0}, lastRound = {1}, finalNumber = {2}",
                    won.SumOfNonSelectedValues(), roundNumbers[round - 1], won.SumOfNonSelectedValues() * roundNumbers[round - 1]);
            }
        }

        static string[] LineClean(string[] line)
        {
            string[] finalLine = new string[5];
            int index = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != string.Empty)
                {
                    finalLine[index] = line[i];
                    index++;
                }
            }

            return finalLine;
        }
    }
}