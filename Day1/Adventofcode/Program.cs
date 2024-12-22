namespace Adventofcode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr1 = { 3, 4, 2, 1, 3, 3 };
            int[] arr2 = { 4, 3, 5, 3, 9, 3 };
            int Dis = DistanceCalc(arr1, arr2);
            Console.WriteLine("Distance :"+Dis);

            string filePath = "C:\\Users\\Administrator\\source\\repos\\Adventofcode\\arr.txt"; 

            string[] lines = File.ReadAllLines(filePath);

            int[] leftSide = new int[lines.Length];
            int[] rightSide = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                leftSide[i] = int.Parse(parts[0]);
                rightSide[i] = int.Parse(parts[1]);
            }
            int Dis1 = DistanceCalc(leftSide, rightSide);
            Console.WriteLine("Distance :" + Dis1);

        }

        public static int DistanceCalc(int[] x, int[] y)
        {
            Array.Sort(x);
            Array.Sort(y);

            int totalDistance = 0;

            for (int i = 0; i < x.Length; i++)
            {
                int distance = Math.Abs(x[i] - y[i]);
                totalDistance += distance;
            }

            return totalDistance;
        }
    }
}
