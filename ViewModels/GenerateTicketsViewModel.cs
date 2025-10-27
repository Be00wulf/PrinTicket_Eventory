using ReactiveUI;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Reactive;
using PrinTicket.Data;

namespace PrinTicket.ViewModels
{
    public class GenerateTicketsViewModel : ReactiveObject
    {
        private readonly string _usuario;

        public ObservableCollection<Database.Evento> Eventos { get; } = new();
        private Database.Evento? _eventoSeleccionado;
        public Database.Evento? EventoSeleccionado
        {
            get => _eventoSeleccionado;
            set => this.RaiseAndSetIfChanged(ref _eventoSeleccionado, value);
        }

        private string _estado = string.Empty;
        public string Estado
        {
            get => _estado;
            set => this.RaiseAndSetIfChanged(ref _estado, value);
        }

        public ReactiveCommand<Unit, Unit> GenerarTicketCommand { get; }
        public ReactiveCommand<Unit, Unit> CerrarCommand { get; }

        public GenerateTicketsViewModel(string usuario)
        {
            _usuario = usuario;

            GenerarTicketCommand = ReactiveCommand.CreateFromTask(GenerarTicketAsync);
            CerrarCommand = ReactiveCommand.Create(CerrarVentana);

            _ = CargarEventosAsync();
        }

        private async Task CargarEventosAsync()
        {
            var lista = await Database.ObtenerEventosAsync();
            foreach (var e in lista)
                Eventos.Add(e);
        }

        private async Task GenerarTicketAsync()
        {
            if (EventoSeleccionado == null)
            {
                Estado = "Selecciona un evento antes de generar el ticket";
                return;
            }

            var exito = await Database.InsertarTicketAsync(EventoSeleccionado.Id, _usuario);

            Estado = exito
                ? $"Ticket generado correctamente para {EventoSeleccionado.Nombre}."
                : "No se pudo generar el ticket";
        }

        private void CerrarVentana()
        {
            
        }
    }
}
