using Avalonia;
using Avalonia.Markup.Xaml;

namespace MonPingApp
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}