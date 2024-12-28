using System;
using System.IO;

namespace Day3AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Administrator\\Documents\\GitHub\\AdventOfCode\\Day5\\arr.txt";

            int[,] arrayFromFile = Read2DArrayFromFile(filePath);

           
        }

        public static int[,] Read2DArrayFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int rows = lines.Length;
            int cols = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

            int[,] array = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = int.Parse(values[j]);
                }
            }

            return array;
        }
    }
}
