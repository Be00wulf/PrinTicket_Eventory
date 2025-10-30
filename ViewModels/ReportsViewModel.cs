using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using PrinTicket.Data;
using Avalonia.Threading;

namespace PrinTicket.ViewModels
{
    public class TicketReporte
    {
        public string EventoNombre { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
    }

    public class ReportsViewModel : ReactiveObject
    {
        public ObservableCollection<TicketReporte> Tickets { get; } = new();

        public ReactiveCommand<Unit, Unit> LoadTicketsCommand { get; }

        public ReportsViewModel()
        {
            LoadTicketsCommand = ReactiveCommand.CreateFromTask(LoadTicketsAsync);

            Task.Run(() => LoadTicketsCommand.Execute().Subscribe());
        }


        private async Task LoadTicketsAsync()
        {
            try
            {
                var ticketsData = await Database.ObtenerTicketsAsync();

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    Tickets.Clear();

                    foreach (var (nombre, usuario, fecha) in ticketsData)
                    {
                        Tickets.Add(new TicketReporte
                        {
                            EventoNombre = nombre,
                            Usuario = usuario,
                            FechaEmision = fecha
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar reportes: {ex.Message}");
            }
        }

        
    }   //fin
}