using System;
using System.Data;
using System.Data.SqlClient;

namespace sqlconn20
{
    internal class Parastoredpro
    {
        SqlConnection con;

        public Parastoredpro()
        {
            // Connection to companyDB
            con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true";
        }

        static void Main(string[] args)
        {
            Parastoredpro sp1 = new Parastoredpro();
            sp1.ListOfEmp();
            Console.ReadLine();
        }

        void ListOfEmp()
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("listofemp1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                Console.Write("Enter the department: ");
                SqlParameter pdept = new SqlParameter("@dept", SqlDbType.VarChar, 50);
                pdept.Value = Console.ReadLine();

                Console.Write("Enter the salary: ");
                SqlParameter psal = new SqlParameter("@sal", SqlDbType.Money);
                psal.Value = Convert.ToDecimal(Console.ReadLine());

                cmd.Parameters.Add(pdept);
                cmd.Parameters.Add(psal);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Console.WriteLine("\nEmployee Details:");
                    Console.WriteLine("------------------------------------------------------");
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.FieldCount; c++)
                        {
                            Console.Write(dr[c] + "\t");
                        }
                        Console.WriteLine();
                        Console.WriteLine("------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("No records found for this department and salary range.");
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
