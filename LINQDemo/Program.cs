namespace LINQDemo
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    internal class Program
    {

        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main(string[] args)
        {
            AddRecs();

            var emps = from emp in lstEmp select emp.Name;
            foreach(var item in emps)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var emps1 = from emp in lstEmp select emp.EmpNo;
            foreach(var item in emps1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var emps2 = from emp in lstEmp where emp.Basic > 10500 select emp;
            foreach (var item in emps2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            var emps3 = from emp in lstEmp
                   where emp.Basic > 10000 && emp.Basic < 12000
                 select emp;
            foreach (var emp in emps3)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();

            var emps4 = from emp in lstEmp
                      where emp.Name.StartsWith("V")
                     select emp;
            foreach (var emp in emps4)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();


            var emps5 = from emp in lstEmp
                           where emp.Basic > 10000
                       orderby emp.Name
                       select emp;
            foreach (var emp in emps5)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();

            var emps6 = from emp in lstEmp
                      orderby emp.Name descending
                      select emp;
            foreach (var emp in emps6)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();

            var emps7 = from emp in lstEmp
                 orderby emp.DeptNo ascending, emp.Name descending
                     select emp;

            foreach (var emp in emps7)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();

            var emps8 = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select emp;

            var emps9 = from emp in lstEmp
                        join dept in lstDept
                              on emp.DeptNo equals dept.DeptNo
                        select dept;

            var emps10 = from emp in lstEmp
                        join dept in lstDept
                              on emp.DeptNo equals dept.DeptNo
                        select new { emp, dept };

            var emps11 = from emp in lstEmp
                        join dept in lstDept
                              on emp.DeptNo equals dept.DeptNo
                        select new { emp.Name, dept.DeptName };

            foreach (var item in emps10)
            {
                Console.WriteLine(item.emp.EmpNo);
                Console.WriteLine(item.emp.Name);

                Console.WriteLine(item.dept.DeptName);
            }
            Console.WriteLine();

            foreach (var item in emps11)
            {
                Console.WriteLine(item.DeptName);
                Console.WriteLine(item.Name);
            }
        }
    }
}