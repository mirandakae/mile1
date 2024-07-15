using Milestone.Models;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Milestone.Services
{
    public class SecurityDAO
    {

       
 string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MIle1;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public bool FindUserByNameAndPassword(UserModel user)
        {

            //assume nothing is found
            bool success = false;

            //uses prepared statement for security. Define username and password below
            string sqlStatement = "SELECT * FROM dbo.UsersM WHERE USERNAME = @USERNAME and PASSWORD = @PASSWORD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //define values of the placeholders in the sql statement string
                command.Parameters.Add("@USERNAME", System.Data.SqlDbType.NVarChar, 40).Value = user.UserName;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.NVarChar, 40).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };
                return success;
            }
        }
    }
}
