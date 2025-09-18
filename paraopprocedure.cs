using System;
using System.Data;
using System.Data.SqlClient;

namespace sqlconn20
{
    internal class paraopprocedure
    {
        SqlConnection con;

        public paraopprocedure()
        {
            con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true";
        }

        static void Main(string[] args)
        {
            paraopprocedure sp2 = new paraopprocedure();
            sp2.listofemp();
            Console.ReadLine();
        }

        void listofemp()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("listofemp2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                Console.Write("Enter Department: ");
                SqlParameter pdept = new SqlParameter("@dept", SqlDbType.VarChar, 50);
                pdept.Value = Console.ReadLine();

                Console.Write("Enter Salary: ");
                SqlParameter psal = new SqlParameter("@sal", SqlDbType.Money);
                psal.Value = Convert.ToDecimal(Console.ReadLine());

                // Output parameter
                SqlParameter pcount = new SqlParameter("@count", SqlDbType.Int);
                pcount.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(pdept);
                cmd.Parameters.Add(psal);
                cmd.Parameters.Add(pcount);

                cmd.ExecuteNonQuery();

                int numofemp = Convert.ToInt32(pcount.Value);
                Console.WriteLine($"Number of employees from {pdept.Value} department whose salary is above {psal.Value} are: {numofemp}");
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
