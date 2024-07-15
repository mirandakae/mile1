using Milestone.Models;
using NuGet.Protocol;
using System.Data.SqlClient;

namespace Milestone.Services
{
    public class RegistrationDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MIle1;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public bool RegisterUser(RegistrationModel user)
        {
            bool success = false;
            string sqlstatement = "INSERT INTO dbo.UsersM (FIRSTNAME, LASTNAME, SEX, AGE, STATE, EMAIL, USERNAME, PASSWORD)" + "VALUES (@FIRSTNAME, @LASTNAME, @SEX, @AGE, @STATE, @EMAIL, @USERNAME, @PASSWORD)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlstatement, connection);

                command.Parameters.AddWithValue("@FIRSTNAME", user.FirstName);
                command.Parameters.AddWithValue("@LASTNAME", user.LastName);
                command.Parameters.AddWithValue("@SEX", user.Sex);
                command.Parameters.AddWithValue("@AGE", user.Age);
                command.Parameters.AddWithValue("@STATE", user.State);
                command.Parameters.AddWithValue("@EMAIL", user.Email);
                command.Parameters.AddWithValue("@USERNAME", user.Username);
                command.Parameters.AddWithValue("@PASSWORD", user.Password);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
    }
}
