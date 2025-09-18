using System;
using System.Data.SqlClient;
using System.Data;

namespace sqlconn20
{
    internal class storedprocedure
    {
        SqlConnection con = new SqlConnection();

        storedprocedure()
        {
            // ✅ Your connection string
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true";
        }

        static void Main(string[] args)
        {
            storedprocedure sp = new storedprocedure();
            sp.listofemp();   // call stored procedure
            Console.ReadLine();
        }

        void listofemp()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "listofemp3"; // ✅ stored procedure name
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int c = 0; c < dr.FieldCount; c++)
                    {
                        Console.Write(dr[c] + "\t");  // print each column
                    }
                    Console.WriteLine("\n------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No records found");
            }

            con.Close();
        }
    }
}
