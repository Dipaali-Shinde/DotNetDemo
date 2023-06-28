using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Net;
using System.Reflection;

namespace CustomerDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Insert data into customers table");
                Console.WriteLine("2. Retrieve list of all customers");
                Console.WriteLine("3. Update data in customers table");
                Console.WriteLine("4. Delete data from customers table");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertData();
                        break;
                    case 2:
                        RetrieveData();
                        break;
                    case 3:
                        UpdateData();
                        break;
                    case 4:
                        DeleteData();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
     
        static void InsertData()
        {
            Console.WriteLine("Enter customer id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter customer address:");
            string address = Console.ReadLine();

            Console.WriteLine("Enter customer email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter customer mobile:");
            int mobile = Convert.ToInt32(Console.ReadLine());

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
             
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Customers (CustId,Name, Address, Email, Mobile) VALUES (@CustId, @Name, @Address, @Email, @Mobile)";
                cmd.Parameters.AddWithValue("@CustId", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
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
        static void RetrieveData()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Customers";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    string email = dr["Email"].ToString();
    
                    Console.WriteLine("Name: " + name + ", Email: " + email);

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
        static void UpdateData()
        {
            Console.WriteLine("Enter customer ID:");
            int custID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter updated name:");
            string name = Console.ReadLine();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Customers set Name=@Name WHERE CustID = @CustID";
                cmd.Parameters.AddWithValue("@CustId", custID);
                cmd.Parameters.AddWithValue("@Name", name);
                
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
        static void DeleteData()
        {
            Console.WriteLine("Enter customer ID:");
            int custID = Convert.ToInt32(Console.ReadLine());


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Customers WHERE CustID = @CustID";
                
                cmd.Parameters.AddWithValue("@CustID", custID);

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
        
    }
}