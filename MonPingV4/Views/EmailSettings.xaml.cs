using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MonPingV4.Views
{
    public class EmailSettings : Window
    {
        public EmailSettings()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.CanResize = false;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
