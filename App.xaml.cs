using Avalonia;
using Avalonia.Markup.Xaml;

namespace MonPingV4
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}