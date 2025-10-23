using ReactiveUI;
using System.Reactive;
using Avalonia.Controls;
using PrinTicket.Views;
using PrinTicket.Utils;
using System.Threading.Tasks;

namespace PrinTicket.ViewModels
{
    public class DashboardViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> BuscarEventoCommand { get; }
        public ReactiveCommand<Unit, Unit> GenerarTicketsCommand { get; }
        public ReactiveCommand<Unit, Unit> VerReportesCommand { get; }
        public ReactiveCommand<Unit, Unit> LogoutCommand { get; }

        public DashboardViewModel()
        {
            BuscarEventoCommand = ReactiveCommand.CreateFromTask(BuscarEvento);
            GenerarTicketsCommand = ReactiveCommand.CreateFromTask(GenerarTickets);
            VerReportesCommand = ReactiveCommand.CreateFromTask(VerReportes);
            LogoutCommand = ReactiveCommand.CreateFromTask(CerrarSesion);
        }

        private async Task BuscarEvento()
        {
            await UIHelper.ShowMessage(GetActiveWindow(), "Buscar Evento", "Aquí se abriría el buscador de eventos.");
        }

        private async Task GenerarTickets()
        {
            await UIHelper.ShowMessage(GetActiveWindow(), "Generar Tickets", "Aquí se generarían los tickets del evento seleccionado.");
        }

        private async Task VerReportes()
        {
            await UIHelper.ShowMessage(GetActiveWindow(), "Reportes", "Aquí podrás ver las estadísticas o reportes.");
        }

        private async Task CerrarSesion()
        {
            var currentWindow = GetActiveWindow();

            await UIHelper.ShowMessage(currentWindow, "Cerrar Sesión", "Volviendo al login...");

            var loginWindow = new MainWindow(); 
            loginWindow.Show();

            currentWindow?.Close();
        }

        private Window? GetActiveWindow()
        {
            if (Avalonia.Application.Current?.ApplicationLifetime is Avalonia.Controls.ApplicationLifetimes.ClassicDesktopStyleApplicationLifetime desktop)
                return desktop.MainWindow;

            return null;
        }
    }
}
