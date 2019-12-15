using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;

namespace MonPingV4.Views
{
    public class About : Window
    {
        public About()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.CanResize = false;

            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
