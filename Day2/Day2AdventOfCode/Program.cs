namespace Day2AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Administrator\\Documents\\GitHub\\AdventOfCode\\Day2\\arr.txt";

            string[] lines = File.ReadAllLines(filePath);

            int[] leftSide = new int[lines.Length];
            int[] rightSide = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                leftSide[i] = int.Parse(parts[0]);
                rightSide[i] = int.Parse(parts[1]);
            }
            int Dis1 = SimilarityCount(leftSide, rightSide);
            Console.WriteLine("Similar Test :" + Dis1);

            int[] arr1 = { 3, 4, 2, 1, 3, 3 };
            int[] arr2 = { 4, 3, 5, 3, 9, 3 };
            int Dis = SimilarityCount(arr1, arr2);
            Console.WriteLine("similarity :" + Dis);
        }
        public static int SimilarityCount(int[] leftSide, int[] rightSide)
        {
            int numberOfAppear = 0;
            int sum = 0;
            for (int i = 0; i < leftSide.Length; i++)
            {
                for (int j = 0; j < rightSide.Length; j++)
                {
                    if(leftSide[i] == rightSide[j])
                    {
                        numberOfAppear++;
                    }
                }
                sum += leftSide[i] * numberOfAppear;
                numberOfAppear = 0;
            }
            return sum;
        }
    }
}
