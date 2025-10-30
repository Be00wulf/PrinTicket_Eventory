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
            var generateWindow = new GenerateTicketsWindow("majo");
            generateWindow.ShowDialog(this);
        }

        private void OnReportsClicked(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var reportsWindow = new ReportsWindow();
            reportsWindow.Show();
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
