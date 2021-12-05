using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parsed = File.ReadAllLines("../../../input");
            char[] delimiterChars = new[] {' ', '-', '>', ','};
            int[,] Board = new int[1000, 1000];
            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 1000; b++)
                {
                    Board[a, b] = 0;
                }
            }
            
            foreach (var ex in parsed)
            {
                List<string> line = ex.Split(delimiterChars).ToList();
                line.RemoveAll(s => s == string.Empty);
                if (line.Count != 4)
                {
                    Console.Error.WriteLine("ParserInput Error");
                    return;
                }

                int x1 = int.Parse(line[0]);                
                int x2 = int.Parse(line[2]);
                int y1 = int.Parse(line[1]);
                int y2 = int.Parse(line[3]);

                
                if (x1 == x2 || y1 == y2)
                {
                    if (x1 > x2)
                    {
                        int temp = x1;
                        x1 = x2;
                        x2 = temp;
                    }

                    if (y1 > y2)
                    {
                        int temp = y1;
                        y1 = y2;
                        y2 = temp;
                    }
                    
                    foreach (var i in Enumerable.Range(x1, x2 - x1 + 1).ToList())
                    {
                        foreach (var j in Enumerable.Range(y1, y2 - y1 + 1).ToList())
                        {
                            Board[i,j] += 1;
                        }
                    }
                }
                else
                {
                    int decreasedX = x1 > x2 ? - 1 : 1;
                    int decreasedY = y1 > y2 ? -1 : 1;
                    while (x1 != x2 && y1 != y2)
                    {
                        Board[x1,y1] += 1;
                        x1 += decreasedX;
                        y1 += decreasedY;
                    }
                }
            }

            int tt = 0;
            foreach (var e in Board)
            {
                if (e > 1)
                {
                    tt++;
                }
            }
            Console.WriteLine($"{tt}");
            
            Main2.Part2();
          
        }
    }
}