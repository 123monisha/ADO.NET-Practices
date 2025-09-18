using System;
using System.Data.SqlClient;

namespace sqlconn20
{
    class delete
    {
        public int deleteemp(int empid)
        {
            int recorddeleted = 0;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true";
                con.Open();

                SqlCommand cmddel = new SqlCommand();
                cmddel.Connection = con;

                // Use parameter to avoid SQL injection
                cmddel.CommandText = "DELETE FROM employii WHERE emp_id = @id";
                cmddel.Parameters.AddWithValue("@id", empid);

                recorddeleted = cmddel.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return recorddeleted;
        }

        static void Main(string[] args)
        {
            delete del = new delete();
            Console.Write("Enter Employee ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int deleted = del.deleteemp(id);

            if (deleted > 0)
                Console.WriteLine("Employee deleted successfully!");
            else
                Console.WriteLine("No employee found with that ID.");

            Console.ReadLine();
        }
    }
}
