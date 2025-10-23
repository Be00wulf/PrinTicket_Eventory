using System;
using System.Threading.Tasks;
using ReactiveUI;
using Avalonia;
using Avalonia.Controls;
using PrinTicket.Views;
using System.Reactive;

namespace PrinTicket.ViewModels
{
    public class LoginViewModel : ReactiveObject
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _loginStatus = string.Empty;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string LoginStatus
        {
            get => _loginStatus;
            set => this.RaiseAndSetIfChanged(ref _loginStatus, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        // 🔹 Constructor — aquí va la inicialización del comando
        public LoginViewModel()
        {
            // Forzamos la ejecución del comando en el hilo principal (UI Thread)
            LoginCommand = ReactiveCommand.CreateFromTask(ExecuteLoginAsync, outputScheduler: RxApp.MainThreadScheduler);
        }

        private async Task ExecuteLoginAsync()
        {
            if (Username == "majo" && Password == "1234")
            {
                LoginStatus = "Inicio de sesión exitoso.";

                var lifetime = Application.Current?.ApplicationLifetime as Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;

                if (lifetime != null)
                {
                    var dashboard = new DashboardWindow();
                    dashboard.Show();
                    lifetime.MainWindow?.Close();
                    lifetime.MainWindow = dashboard;
                }
            }
            else
            {
                LoginStatus = "Credenciales incorrectas.";
            }

            await Task.CompletedTask;
        }
    }
}
