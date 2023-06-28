using Microsoft.Data.SqlClient;
using System.Data;
namespace DatabaseCode
{
    internal class Program
    {
       
        static void Main()
        {
            //Connect();
            //Insert1();

            Employee obj = new Employee { EmpNo = 7, Name = "Alfred D'Mello", DeptNo = 10, Basic = 12345 };
            //Insert2(obj);  //string concatenation
            //Insert3(obj);  //parameters
            //Insert4(obj);  //stored proc

            //GetSingleValue();
            //DataReader1();
            //DataReader2();
            MARS();
        }
        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data Source=NameOfSqlServer;Initial Catalog=DatabaseName;User Id=sa;Password=pwd";
            //cn.ConnectionString = "Data Source=NameOfSqlServer;Initial Catalog=DatabaseName;Integrated Security=true";
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            Console.WriteLine("open");
            cn.Close();
        }

        static void Insert1()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employees values(4,'Anshu',12345,30)";

                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        //string concatenation
        static void Insert2(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"Insert into Employees values({obj.EmpNo},'{obj.Name}',{obj.Basic},{obj.DeptNo})";
                Console.WriteLine(cmd.CommandText);
                Console.ReadLine();
                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        //parameters
        static void Insert3(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);


                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //stored procedure
        static void Insert4(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        static void GetSingleValue()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "select * from Employees";
                //cmd.CommandText = "select Name from Employees where EmpNo=1";

                cmd.CommandText = "select count(*) from Employees";

                //first row, first col
                object retval = cmd.ExecuteScalar();
                Console.WriteLine(retval);

                Console.WriteLine("okay");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void DataReader1()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr["EmpNo"]);

                    int empno1 = (int)dr[0];
                    int empno2 = (int)dr["EmpNo"];

                    int empno3 = dr.GetInt32(0);
                    int empno4 = dr.GetInt32("EmpNo");


                }
                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void DataReader2()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees;select * from Departments";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                }

                Console.WriteLine();
                Console.WriteLine();

                dr.NextResult();
                while (dr.Read())
                {
                    Console.WriteLine(dr["DeptName"]);
                }



                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void MARS()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                Console.WriteLine((drDepts["DeptName"]));

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    Console.WriteLine(("    " + drEmps["Name"]));
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        static Employee GetSingleEmployee(int EmpNo)
        {
            return null;
        }

        static List<Employee> GetAllEmployees()
        {
            return null;
        }



    }

    class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }

        public int DeptNo { get; set; }
    }
}
