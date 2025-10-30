using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using PrinTicket.Data;
using Avalonia.Threading;
using static PrinTicket.Data.Database;

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
        private readonly ObservableCollection<TicketReporte> _tickets = new();
        public ObservableCollection<TicketReporte> Tickets => _tickets; 

        private readonly ObservableCollection<EventoReporte> _eventos = new();
        public ObservableCollection<EventoReporte> Eventos => _eventos;
        
        private readonly ObservableCollection<UsuarioReporte> _usuarios = new();
        public ObservableCollection<UsuarioReporte> Usuarios => _usuarios;

        private int _selectedReportIndex;
        public int SelectedReportIndex
        {
            get => _selectedReportIndex;
            set => this.RaiseAndSetIfChanged(ref _selectedReportIndex, value);
        }

        public ReactiveCommand<Unit, Unit> LoadReportsCommand { get; }

        public ReportsViewModel()
        {
            LoadReportsCommand = ReactiveCommand.CreateFromTask(LoadReportsAsync);
            Task.Run(() => LoadReportsCommand.Execute().Subscribe());
        }

        private async Task LoadReportsAsync()
        {
            try
            {
                var ticketsTask = Database.ObtenerTicketsAsync();
                var eventosTask = Database.ObtenerReporteEventosAsync();
                var usuariosTask = Database.ObtenerReporteUsuariosAsync();

                await Task.WhenAll(ticketsTask, eventosTask, usuariosTask);

                var ticketsData = ticketsTask.Result;
                var eventosData = eventosTask.Result;
                var usuariosData = usuariosTask.Result;

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _tickets.Clear();
                    foreach (var (nombre, usuario, fecha) in ticketsData)
                    {
                        _tickets.Add(new TicketReporte { EventoNombre = nombre, Usuario = usuario, FechaEmision = fecha });
                    }
                    
                    _eventos.Clear();
                    foreach (var e in eventosData)
                    {
                        _eventos.Add(e);
                    }
                    
                    _usuarios.Clear();
                    foreach (var u in usuariosData)
                    {
                        _usuarios.Add(u);
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