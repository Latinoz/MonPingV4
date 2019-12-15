using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MonPingApp
{
    public class ListView : UserControl
    {
        public ListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}