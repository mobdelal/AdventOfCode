using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day3AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "C:\\Users\\Administrator\\Documents\\GitHub\\AdventOfCode\\Day4\\arr.txt"; 
            string test = " xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))don't()";


            //string input = File.ReadAllText(filePath);
            //MatchCollection matches = Regex.Matches(test, pattern);

            string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";



            string pattern = @"mul\((\d+),(\d+)\)";
            string patternFirst = @"don't\(\).*";
            string Sec = @"do\(\).*";



            int Total = 0;
            int sumDo = 0;
            int sumDont = 0;


            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                Total += x * y;

            }
            Console.WriteLine(Total);

            Match matchesDo = Regex.Match(input, Sec);
            string val1 = matchesDo.Value;
            Console.WriteLine(val1);

            MatchCollection matches1 = Regex.Matches(val1, pattern);
            foreach (Match match in matches1)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sumDo += x * y;
            }
            Console.WriteLine(sumDo);


            Match matchesDont = Regex.Match(input, patternFirst);
            string val2 = matchesDo.Value;
            Console.WriteLine(val2);

            MatchCollection matches2 = Regex.Matches(val2, pattern);
            foreach (Match match in matches2)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sumDont += x * y;
            }
            Console.WriteLine(sumDont);

            Console.WriteLine(Total - sumDont + sumDo);

        }
    }


}

