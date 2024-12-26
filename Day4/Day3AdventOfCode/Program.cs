using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day3AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "C:\\Users\\Administrator\\Documents\\GitHub\\AdventOfCode\\Day4\\arr.txt"; 
            string test = " xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))don't()mul(8,5)do()mul(8222,5222)";


            string input = File.ReadAllText(filePath);
            //MatchCollection matches = Regex.Matches(test, pattern);

            //string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

            string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            // Regex to match conditional statements
            string conditionPattern = @"do\(\)|don't\(\)";

            int sum = 0; // Final result
            bool isEnabled = true; // Tracks whether mul instructions are enabled

            // Use regex to parse the input sequentially
            Regex regex = new Regex($"{mulPattern}|{conditionPattern}");
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                if (match.Value.StartsWith("do()"))
                {
                    isEnabled = true; // Enable future mul instructions
                }
                else if (match.Value.StartsWith("don't()"))
                {
                    isEnabled = false; // Disable future mul instructions
                }
                else if (match.Groups[1].Success && match.Groups[2].Success) // Valid mul(X, Y)
                {
                    if (isEnabled)
                    {
                        int x = int.Parse(match.Groups[1].Value);
                        int y = int.Parse(match.Groups[2].Value);
                        sum += x * y; // Add product if enabled
                    }
                }
            }

            // Output the final sum
            Console.WriteLine($"Final Sum: {sum}");
        }
    


    //    string pattern = @"mul\((\d+),(\d+)\)";
    //    //string patternFirst = @"don't\(\).*";
    //    //string Sec = @"do\(\).*";
    //    string testpat = @"don't\(\).+?do\(\)";

    //    int Total = 0;
    //    int sumDont = 0;


    //    MatchCollection matches = Regex.Matches(test, pattern);
    //    foreach (Match match in matches)
    //    {

    //        int x = int.Parse(match.Groups[1].Value);
    //        int y = int.Parse(match.Groups[2].Value);
    //        if (x > 999 || y > 999)
    //        {
    //            Console.WriteLine(x);
    //            Console.WriteLine(y);
    //        }
    //        else
    //        {
    //            Total += x * y;
    //        }
    //    }
    //    Console.WriteLine(Total);



    //    MatchCollection matchess = Regex.Matches(test, testpat);
    //    foreach (Match match in matchess)
    //    {
    //        Console.WriteLine(match.Value);
    //        Console.WriteLine("================================");
    //        MatchCollection matchesDont = Regex.Matches(match.Value, pattern);
    //        foreach (Match matchDontMatch in matchesDont)
    //        {
    //            int x = int.Parse(matchDontMatch.Groups[1].Value);
    //            int y = int.Parse(matchDontMatch.Groups[2].Value);
    //            if (x > 999 || y > 999)
    //            {
    //                Console.WriteLine(x);
    //                Console.WriteLine(y);
    //            }
    //            else
    //            {
    //                sumDont += x * y;
    //                Console.WriteLine(sumDont);
    //            }
    //        }
    //    }

    //    Console.WriteLine("Final Total: " + (Total - sumDont));
    //}



    //Match matchesDo = Regex.Match(input, Sec);
    //string val1 = matchesDo.Value;
    //Console.WriteLine(val1);

    //MatchCollection matches1 = Regex.Matches(val1, pattern);
    //foreach (Match match in matches1)
    //{
    //    int x = int.Parse(match.Groups[1].Value);
    //    int y = int.Parse(match.Groups[2].Value);
    //    sumDo += x * y;
    //}
    //Console.WriteLine(sumDo);


    //Match matchesDont = Regex.Match(input, patternFirst);
    //string val2 = matchesDont.Value;
    //Console.WriteLine(val2);

    //MatchCollection matches2 = Regex.Matches(val2, pattern);
    //foreach (Match match in matches2)
    //{
    //    int x = int.Parse(match.Groups[1].Value);
    //    int y = int.Parse(match.Groups[2].Value);
    //    sumDont += x * y;
    //}
    //Console.WriteLine(sumDont);

    //Console.WriteLine(Total - sumDont + sumDo);

}
    }




