using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrinTicket.Data
{
    public static class Database
    {
        private const string ConnectionString =
            "server=localhost;user=prinuser;password=1234;database=PrinticketDB;";

        public static async Task<bool> ValidateUserAsync(string username, string password)
        {
            await using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM usuarios WHERE username=@username AND password=@password",
                connection
            );
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            var result = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return result > 0;
        }

        public static async Task ProbarConexionAsync()
        {
            try
            {
                await using var connection = new MySqlConnection(ConnectionString);
                await connection.OpenAsync();

                Console.WriteLine("Conexión exitosa a la base de datos!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
        }
    }
}
