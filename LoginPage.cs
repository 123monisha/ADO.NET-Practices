/*using System.Data;
using System.Data.SqlClient;

namespace sqlconn20
{
    internal class LoginPage
    {
        SqlConnection con;

        public LoginPage()
        {
            con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog=companyDB; integrated security=true");
        }

        static void Main(string[] args)
        {
            LoginPage app = new LoginPage();

            // Login part
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string pwd = Console.ReadLine();

            if (app.IsLoggedIn(email, pwd))
            {
                Console.WriteLine("Login successful!");

                // Count employees part
                app.CountEmployees();
            }
            else
            {
                Console.WriteLine("Invalid email or password!");
            }

            Console.ReadLine();
        }

        bool IsLoggedIn(string email, string pwd)
        {
            bool loggedIn = false;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name, password FROM employii WHERE email_id=@email", con);
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["password"].ToString().Trim() == pwd.Trim())
                    {
                        Console.WriteLine("Welcome, " + dr["name"].ToString());
                        loggedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid password!");
                    }
                }
                else
                {
                    Console.WriteLine("Email not found!");
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

            return loggedIn;
        }

        void CountEmployees()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("listofemp2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Enter department: ");
                string dept = Console.ReadLine();

                Console.Write("Enter salary: ");
                decimal sal = Convert.ToDecimal(Console.ReadLine());

                SqlParameter pdept = new SqlParameter("@dept", SqlDbType.VarChar, 50) { Value = dept };
                SqlParameter psal = new SqlParameter("@sal", SqlDbType.Money) { Value = sal };
                SqlParameter pcount = new SqlParameter("@count", SqlDbType.Int) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(pdept);
                cmd.Parameters.Add(psal);
                cmd.Parameters.Add(pcount);

                cmd.ExecuteNonQuery();

                int numOfEmp = Convert.ToInt32(pcount.Value);
                Console.WriteLine($"Number of employees from {dept} department whose salary is above {sal} are: {numOfEmp}");
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
*/