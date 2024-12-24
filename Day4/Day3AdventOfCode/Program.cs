using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day3AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "C:\\Users\\Administrator\\Documents\\GitHub\\AdventOfCode\\Day4\\arr.txt"; 

      
            string input = File.ReadAllText(filePath);

            string pattern = @"mul\((\d+),(\d+)\)"; 

            MatchCollection matches = Regex.Matches(input, pattern);

            int sum = 0;
            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sum += x*y;

            }
            Console.WriteLine(sum);


        }
       

    }
}

