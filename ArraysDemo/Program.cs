namespace ArraysDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Institute :");
            string insti = Console.ReadLine();
            Console.WriteLine(insti);

            Console.Write("Enter number of batches : ");
            int batch=int.Parse(Console.ReadLine());
            Console.WriteLine(batch);

            int[][] marks = new int[batch][];

            for(int i=0; i<batch; i++)
            {
                Console.Write($"Enter the number of students in batch {i + 1}: ");
                int numStudents = int.Parse(Console.ReadLine());
                marks[i] = new int[numStudents];

                for (int j = 0; j < numStudents; j++)
                {
                    Console.Write($"Enter the marks for student {j + 1}: ");
                    marks[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\nMarks for each student:");

            for (int i = 0; i < batch; i++)
            {
                Console.WriteLine($"Batch {i + 1}:");

                for (int j = 0; j < marks[i].Length; j++)
                {
                    Console.WriteLine($"Student {j + 1}: {marks[i][j]}");
                }

                Console.WriteLine();
            }
        }
    }
}