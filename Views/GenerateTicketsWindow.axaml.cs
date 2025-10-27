using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PrinTicket.Views
{
    public partial class GenerateTicketsWindow : Window
    {
        public GenerateTicketsWindow()
        {
            InitializeComponent();
        }

        private void OnGenerateClicked(object? sender, RoutedEventArgs e)
        {
            //en construccion
        }

        private void OnCloseClicked(object? sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
