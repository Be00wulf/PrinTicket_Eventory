using System;
using System.Threading.Tasks;
using ReactiveUI;
using Avalonia;
using Avalonia.Controls;
using PrinTicket.Views;
using PrinTicket.Data;
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

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.CreateFromTask(
                ExecuteLoginAsync,
                outputScheduler: RxApp.MainThreadScheduler
            );
        }


        //test
        private async Task ExecuteLoginAsync()
        {
            try
            {
                bool validUser = await Database.ValidateUserAsync(Username, Password);

                if (validUser)
                {
                    await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        LoginStatus = "Inicio de sesión exitoso.";

                        var lifetime = Avalonia.Application.Current?.ApplicationLifetime
                            as Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;

                        if (lifetime != null)
                        {
                            var dashboard = new DashboardWindow();
                            dashboard.Show();
                            lifetime.MainWindow?.Close();
                            lifetime.MainWindow = dashboard;
                        }
                    });
                }
                else
                {
                    await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        LoginStatus = "Credenciales incorrectas.";
                    });
                }
            }
            catch (Exception ex)
            {
                await Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    LoginStatus = $"Error al iniciar sesión: {ex.Message}";
                });
            }
        }

        

    }//fin
}
