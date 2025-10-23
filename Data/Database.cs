using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrinTicket.Data
{
    public class Database
    {
        private const string ConnectionString =
            "Server=localhost;Database=PrinticketDB;User ID=root;Password=tu_password;";

        public static async Task<bool> ValidateUserAsync(string username, string password)
        {
            await using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password",
                connection
            );
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            var result = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return result > 0;
        }
    }
}
