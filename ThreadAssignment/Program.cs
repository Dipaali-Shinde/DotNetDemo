namespace ThreadAssignment
{
    internal class Program
    {
        static void Main()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(Func2);
            //int a = 100;
            //int b = 200;


            //To Do : pass an array(ints/objects), ArrayList

            //to do 2 : create a class/struct. pass an object of class/struct

            //to do 3: use a local function / anonymous methos/ lambda to access variables declared in calling code

            //List<int> lstInts = new List<int>();
            //lstInts.Add(a);
            //lstInts.Add(b);
            string s1 = "Soham";
            int i1 = 100;

            //Arraylist
            //ArrayList arrlst = new ArrayList();
            //arrlst.Add(s1);
            //arrlst.Add(i1); 

            int[] arr = { 1, 10, 20 };

            t1.Start(arr);

            //t1.Start("aaa");
            // t1.Start(lstInts);
            //t1.Start(arrlst);
            t1.Start(arr);

            //t2.Start("bbb");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main : " + i);
            }
        }
        static void Func1(object arr)
        {
            //

            //List<int> lstInts = (List<int>)obj;
            //Console.WriteLine(lstInts[0]);
            //Console.WriteLine(lstInts[1]);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("First : " + i + obj.ToString());
            //}



            //Using Arraylist

            //ArrayList arrayList = (ArrayList)obj;

            //Console.WriteLine(arrayList[0]);
            //Console.WriteLine(arrayList[1]);

            //USing Array object

            //int[] arr1 = (int[])arr;
            //Console.WriteLine(arr1[0]);


            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("First : " + i + arr.ToString());
            }

        }
        static void Func2(object obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Second : " + i + obj.ToString());
            }

        }

    }
}