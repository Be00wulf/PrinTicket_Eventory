using Avalonia.Controls;
using System.Threading.Tasks;

namespace PrinTicket.Utils
{
    public static class UIHelper
    {
        public static async Task ShowMessage(Window parent, string title, string message)
        {
            var dialog = new Window
            {
                Title = title,
                Width = 300,
                Height = 150,
                Content = new TextBlock
                {
                    Text = message,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
                }
            };

            await dialog.ShowDialog(parent);
        }
    }
}
