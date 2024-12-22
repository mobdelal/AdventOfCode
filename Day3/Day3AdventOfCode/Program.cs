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
            }

            return safeCount;
        }
    }
}

