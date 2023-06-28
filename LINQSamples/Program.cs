using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Diagnostics;

namespace LINQSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Aggregate simple
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var result = numbers.Aggregate((a, b) => a * b);
            Console.WriteLine("Aggregated numbers by multiplication:");
            Console.WriteLine(result);
            Console.WriteLine();
            //o/p : 120

            //Aggregate Seed
            var arr = new int[]{ 10, 20, 30 };
            var res=arr.Aggregate(1,(a, b) => a + b);
            Console.WriteLine("Aggregated numbers by Adding seed 10:");
            Console.WriteLine(res);
            Console.WriteLine();
            //o/p : 61

            //Average
            var avg = new int[] { 1, 2, 3, 4, 5 };
            var avgres = avg.Average();
            Console.WriteLine("Average of numbers is:");
            Console.WriteLine(avgres);
            Console.WriteLine();
            //o/p : 3

            //Count
            var countno = new int[] { 5, 6, 7, 8 };
            var countnores = countno.Count();
            Console.WriteLine("Count of numbers : ");
            Console.WriteLine(countnores);
            Console.WriteLine();
            //o/p : 4 returns no of elements 

            //LongCount: Returns the number of elements in collections larger than Int32.MaxValue.
            //var largeArr = Enumerable.Range(0, Int32.MaxValue).Concat(Enumerable.Range(0, 5));
            //Int64 result1 = largeArr.LongCount();
            //Console.WriteLine("Counting largeArr elements:");
            //Console.WriteLine(result1);

            //Max
            int[] maxnum = { 10, 50, 30 };
            var num=maxnum.Max();
            Console.WriteLine("Max number is : ");
            Console.WriteLine(num);
            Console.WriteLine();
            //o/p : 50

            //Min
            int[] minnum = { 10, 50, 30 };
            var minnum1 = minnum.Min();
            Console.WriteLine("Minimum number is : ");
            Console.WriteLine(minnum1);
            Console.WriteLine();
            //o/p : 10

            //Sum
            int[] sum = { 20, 40, 50 };
            var sumres = sum.Sum();
            Console.WriteLine("Sum is : ");
            Console.WriteLine(sumres);
            Console.ReadLine();

            //AsEnumerable: casts a collection to IEnumerable of same type.
            string[] names = { "John", "Suzy", "Dave" };
            var result23 = names.AsEnumerable();
            Console.WriteLine("Iterating over IEnumerable collection:");
            foreach(var name in result23)
            Console.WriteLine(name);





        }
    }
}