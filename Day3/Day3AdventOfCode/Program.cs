using System.Collections.Generic;

namespace Day3AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string filePath = "C:\\Users\\Administrator\\Documents\\GitHub\\AdventOfCode\\Day3\\arr.txt";

            int[][] jaggedArrayFromFile = ReadJaggedArrayFromFile(filePath);


            int safeRowsFromFile = Safe(jaggedArrayFromFile);
            Console.WriteLine($"Safe rows from file: {safeRowsFromFile}");

            //int[][] jaggedArray = new int[][]
            //{
            //    new int[] { 7, 6, 4, 2, 1 },
            //    new int[] { 1, 2, 7, 8, 9 },
            //    new int[] { 9, 7, 6, 2, 1 },
            //    new int[] { 1, 3, 2, 4, 5 },
            //    new int[] { 8, 6, 4, 4, 1 },
            //    new int[] { 1, 3, 6, 7, 9 }
            //};

            //int safeRowsFromFile = Safe(jaggedArray);
            //Console.WriteLine($"Safe rows from file: {safeRowsFromFile}");




        }

        public static int[][] ReadJaggedArrayFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int[][] jaggedArray = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                jaggedArray[i] = Array.ConvertAll(values, int.Parse);
            }

            return jaggedArray;
        }
        public static bool IsRowSafe(int[] arr)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int difference = arr[i + 1] - arr[i];

                if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
                {
                    return false;
                }
                if (difference <= 0)
                {
                    isIncreasing = false;
                }

                if (difference >= 0)
                {
                    isDecreasing = false;
                }

            }
            return isIncreasing || isDecreasing;

        }
        public static int Safe(int[][] jaggedArray)
        {
            int safeCount = 0;
            int safeCount2 = 0;

            foreach (int[] row in jaggedArray)
            {
                if (row.Length < 2)
                {
                    continue;
                }
                if (IsRowSafe(row))
                {
                    safeCount++;
                }
                else
                {
                    List<int[]> arr = Reformater(row);
                    foreach (int[] row2 in arr)
                    {

                        if (IsRowSafe(row2))
                        {
                            safeCount2++;
                        }
                    }
                    if (safeCount2 != 0)
                    {
                        safeCount++;
                    }
                    safeCount2 = 0;
                }
            }
            
            return safeCount;
        }
        public static List<int[]> Reformater(int[] arr)
        {
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
                int[] subArray = new int[arr.Length - 1];

                Array.Copy(arr, 0, subArray, 0, i);

                Array.Copy(arr, i + 1, subArray, i, arr.Length - i - 1);

                result.Add(subArray);
            }


            return result;
        }

    }
}

