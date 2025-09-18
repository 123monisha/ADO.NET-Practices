using System;
using System.Data;
using System.Data.SqlClient;

namespace sqlconn20
{
    class ImprovedInsert
    {
        static void Main(string[] args)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true"))
                {
                    con.Open();

                    // Get next emp_id
                    SqlCommand cmdid = new SqlCommand("SELECT ISNULL(MAX(emp_id), 0) + 1 FROM employii", con);
                    int id = Convert.ToInt32(cmdid.ExecuteScalar());

                    // Insert new employee
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO employii(emp_id, name, dob, email_id, mob_num, gender, department, salary, yoj) " +
                        "VALUES(@id, @name, @dob, @email, @phnnum, @gender, @dept, @salary, @doj)", con);

                    // Create parameters
                    cmd.Parameters.AddWithValue("@id", id);

                    Console.Write("Enter employee name: ");
                    cmd.Parameters.AddWithValue("@name", Console.ReadLine());

                    Console.Write("Enter date of birth (yyyy-mm-dd): ");
                    cmd.Parameters.AddWithValue("@dob", Console.ReadLine());

                    Console.Write("Enter email: ");
                    cmd.Parameters.AddWithValue("@email", Console.ReadLine());

                    Console.Write("Enter phone number: ");
                    cmd.Parameters.AddWithValue("@phnnum", Convert.ToInt64(Console.ReadLine()));

                    Console.Write("Enter gender (M/F): ");
                    cmd.Parameters.AddWithValue("@gender", Console.ReadLine());

                    Console.Write("Enter department: ");
                    cmd.Parameters.AddWithValue("@dept", Console.ReadLine());

                    Console.Write("Enter salary: ");
                    cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(Console.ReadLine()));

                    Console.Write("Enter year of joining (yyyy-mm-dd): ");
                    cmd.Parameters.AddWithValue("@doj", Console.ReadLine());

                    // Execute insert
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        Console.WriteLine("Registration is successful!");
                    else
                        Console.WriteLine("Registration failed.");

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
