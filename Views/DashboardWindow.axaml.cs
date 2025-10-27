using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PrinTicket.Views
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void OnGenerateClicked(object? sender, RoutedEventArgs e)
        {
            var win = new GenerateTicketsWindow();
            win.Show();
        }

        private void OnReportsClicked(object? sender, RoutedEventArgs e)
        {
            var win = new ReportsWindow();
            win.Show();
        }

        private void OnSettingsClicked(object? sender, RoutedEventArgs e)
        {
            var win = new SettingsWindow();
            win.Show();
        }

        private void OnCloseClicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Close();
        }
    }
}
