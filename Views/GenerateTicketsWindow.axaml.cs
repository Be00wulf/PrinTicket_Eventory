using Avalonia.Controls;
using Avalonia.Interactivity;
using PrinTicket.Data;
using System;
using System.Threading.Tasks;

namespace PrinTicket.Views
{
    public partial class GenerateTicketsWindow : Window
    {
        private readonly string _usuario;

        public GenerateTicketsWindow(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            CargarEventosAsync();
        }

        public GenerateTicketsWindow() 
        {
            InitializeComponent();
        }

        private async Task CargarEventosAsync()
        {
            try
            {
                var eventos = await Database.ObtenerEventosAsync();
                EventoComboBox.ItemsSource = eventos;
                EventoComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                EstadoText.Text = $"Error cargando eventos: {ex.Message}";
            }
        }

        private async void OnGenerarTicketClicked(object? sender, RoutedEventArgs e)
        {
            if (EventoComboBox.SelectedItem is not Database.Evento evento)
            {
                EstadoText.Text = "Por favor selecciona un evento.";
                return;
            }

            try
            {
                bool exito = await Database.InsertarTicketAsync(evento.Id, _usuario);
                EstadoText.Text = exito
                    ? $"Ticket generado para '{evento.Nombre}'"
                    : "No se pudo generar el ticket.";
            }
            catch (Exception ex)
            {
                EstadoText.Text = $"Error: {ex.Message}";
            }
        }

        private void OnCerrarClicked(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
