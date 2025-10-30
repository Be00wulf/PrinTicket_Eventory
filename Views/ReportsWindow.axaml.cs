using Avalonia.Controls;
using PrinTicket.ViewModels;

namespace PrinTicket.Views
{
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
            this.DataContext = new ReportsViewModel();
        }
    }
}