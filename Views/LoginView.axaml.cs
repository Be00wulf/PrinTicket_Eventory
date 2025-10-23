using Avalonia.Controls;
using PrinTicket.ViewModels;

namespace PrinTicket.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
