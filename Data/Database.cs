using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrinTicket.Data
{
    public class Database
    {
        private const string ConnectionString =
            "server=localhost;user=prinuser;password=1234;database=PrinticketDB;";

        public static async Task<List<(string EventoNombre, string Usuario, DateTime FechaEmision)>> ObtenerTicketsAsync()
        {
            var lista = new List<(string, string, DateTime)>();
            await using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand(
                @"SELECT e.nombre AS EventoNombre, t.usuario, t.fecha_emision
                FROM tickets t
                JOIN events e ON t.event_id = e.id",
                connection);

            var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lista.Add((
                    reader.GetString("EventoNombre"),
                    reader.GetString("usuario"),
                    reader.GetDateTime("fecha_emision")
                ));
            }

            return lista;
        }


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



        public class Evento
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public override string ToString()
            {
                return Nombre; 
            }
        }

        public static async Task<List<Evento>> ObtenerEventosAsync()
        {
            var lista = new List<Evento>();

            await using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand("SELECT id, nombre FROM events", connection);
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(new Evento
                {
                    Id = reader.GetInt32("id"),
                    Nombre = reader.GetString("nombre")
                });
            }

            return lista;
        }

        public static async Task<bool> InsertarTicketAsync(int eventId, string usuario)
        {
            await using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand(
                "INSERT INTO tickets (event_id, usuario) VALUES (@event_id, @usuario)",
                connection
            );
            cmd.Parameters.AddWithValue("@event_id", eventId);
            cmd.Parameters.AddWithValue("@usuario", usuario);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }   














       
    }//fin
}
