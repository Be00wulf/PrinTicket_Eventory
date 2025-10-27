using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PrinTicket.Views
{
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void OnCloseClicked(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
