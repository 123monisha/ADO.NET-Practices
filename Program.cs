using System;
using System.Data;
using System.Data.SqlClient;

namespace sqlconn20
{
    internal class disarch
    {
        static void Main(string[] args)
        {
            // 1. Create connection to companyDB
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true";

            try
            {
                // 2. Create data adapter with correct table name
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employii", con);
                DataSet ds = new DataSet();

                // 3. Fill dataset
                da.Fill(ds, "emp");

                // 4. Display data
                display(ds);

                Console.WriteLine("----------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        // Method to display all data from the dataset
        static void display(DataSet ds)
        {
            // Check if table exists and has rows
            if (ds.Tables["emp"] != null && ds.Tables["emp"].Rows.Count > 0)
            {
                // Print column headers
                foreach (DataColumn col in ds.Tables["emp"].Columns)
                {
                    Console.Write(col.ColumnName + "\t");
                }
                Console.WriteLine("\n----------------------------------------------------");

                // Print each row
                foreach (DataRow r in ds.Tables["emp"].Rows)
                {
                    foreach (DataColumn c in ds.Tables["emp"].Columns)
                    {
                        Console.Write(r[c].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No data found in employe table.");
            }
        }
    }
}
