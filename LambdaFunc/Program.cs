namespace LambdaFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int,int> o1 = (a, b) => a + b;
            Console.WriteLine(o1(3,4));

            
        }
    }
   
}