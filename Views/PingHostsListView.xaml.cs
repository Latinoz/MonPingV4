using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MonPingV4.Views
{
    public class PingHostsListView : UserControl
    {
        public PingHostsListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
       
    }
}