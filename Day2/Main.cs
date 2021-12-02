using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../input");

            int result = FollowPath(lines);
            if (result ==  -1)
            {
                Console.Error.WriteLine("One String had not the appropriate format");
                return;
            }
            
            Console.WriteLine("The Depth multiplied by the horizontal position is: {0}", result);
        }

        static int FollowPath(string[] lines)
        {
            int aim = 0;
            int horizontal = 0;
            int depth = 0;
            
            foreach (var line in lines)
            {
                string[] separated = line.Split(' ');
                if (separated.Length != 2)
                {
                    return -1;
                }
                
                string direction = separated[0];
                switch (direction[0])
                {
                    case 'f':
                        horizontal += int.Parse(separated[1]);
                        depth += aim * int.Parse(separated[1]);
                        break;
                    case 'd':
                        aim += int.Parse(separated[1]);
                        break;
                    case 'u':
                        aim -= int.Parse(separated[1]);
                        break;
                    default:
                        return -1;
                }
            }

            return horizontal * depth;
        }
    }
}