using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace ManagerProject
{
    internal class DataAccess
    {
        
        public int insertCategory(string connectionString)
        {
            string query = "INSERT INTO Categories(Name)" + "VALUES (@Name)";
            int rowsEffected = 0;

            while (true)
            {
                Console.WriteLine("Please enter a new category name");
                string name = Console.ReadLine();

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;

                    cn.Open();
                    rowsEffected+=cmd.ExecuteNonQuery();
                    cn.Close(); 
                }

                Console.WriteLine("did you want to continue? y/n ");
                string ans = Console.ReadLine();
                if (ans == "n") break;
            }

            Console.WriteLine(rowsEffected + " rows were inserted successfuly");
            return rowsEffected;
        }

        public int insertProduct(string connectionString)
        {
            string query = "INSERT INTO Products(categoryId, name, price, description, image)" + "VALUES (@categoryId, @name, @price, @description, @image)";
            int rowsEffected = 0;

            while (true)
            {
                Console.WriteLine("Please enter a category id");
                string categoryId = Console.ReadLine();
                Console.WriteLine("Please enter the new product name");
                string name = Console.ReadLine();
                Console.WriteLine("Please enter the product price");
                string price = Console.ReadLine();
                Console.WriteLine("Please enter a description for the product");
                string description = Console.ReadLine();
                Console.WriteLine("Please enter image of the product");
                string image = Console.ReadLine();

                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@categoryId", SqlDbType.VarChar, 50).Value = categoryId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                    cmd.Parameters.Add("@price", SqlDbType.VarChar, 50).Value = price;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Value = description;
                    cmd.Parameters.Add("@image", SqlDbType.VarChar, 50).Value = image;

                    cn.Open();
                    rowsEffected += cmd.ExecuteNonQuery();
                    cn.Close();
                }

                Console.WriteLine("did you want to continue? y/n ");
                string ans = Console.ReadLine();
                if (ans == "n") break;
            }

            Console.WriteLine(rowsEffected + " rows were inserted successfuly");
            return rowsEffected;
        }

        public void readCategory(string connectionString)
        {
            string queryString = "SELECT * FROM Categories";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, cn);

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("category table:\n\tid\tname");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        public void readProducts(string connectionString)
        {
            string queryString = "SELECT * FROM Products";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, cn);

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("products table:\n\tid\tcategory-id\tname\tprice\tdescription\timage");
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
}