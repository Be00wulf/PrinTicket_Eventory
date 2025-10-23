using Avalonia.Controls;
using PrinTicket.ViewModels;

namespace PrinTicket.Views
{
    public partial class DashboardView : Window
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }
    }
}
