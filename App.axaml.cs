using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Avalonia.Threading;
using System.Reactive.Concurrency;
using Avalonia.ReactiveUI;

namespace PrinTicket
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();          
            }

            base.OnFrameworkInitializationCompleted();
        }







    }
}
