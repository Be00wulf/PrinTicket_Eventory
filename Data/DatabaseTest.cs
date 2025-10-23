using System;
using MySql.Data.MySqlClient;

namespace PrinTicket.Data
{
    public static class DatabaseTest
    {
        public static void ProbarConexion()
        {
            string connectionString = "server=localhost;user=prinuser;password=1234;database=PrinticketDB;";

            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
        }
    }
}
