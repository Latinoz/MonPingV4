using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MonPingV4.Models;
using MonPingV4.Services;
using MonPingV4.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MonPingV4.Views
{
    public class PingHostsListView : UserControl
    {
        public PingHostsListView()
        {
            InitializeComponent();

            //Когда переделаю из UserControl в Window ->
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            var data = DataContext as PingHostsVM;
            var sett = new Settings();
            var toLoad = sett.LoadHostsFromJson();

            data.Items.Clear();

            foreach (string str in toLoad)
            {
                data.Items.Add(new HostsItem() { Iphost = str, OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true });
            }

        }


        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            var data = DataContext as PingHostsVM;
            var items = data.Items.ToList();
            List<string> str = items.Select(x => x.Iphost).ToList();
            var sett = new Settings();
            sett.SaveHostsToJson(str);

        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            var getdot = new Settings();

            string netCoreVer = getdot.GetNetCoreVersion();

            string verSep = netCoreVer.Remove(3);

            string path = ($"../netcoreapp{verSep}/Assets/avalonia-logo.ico");

            var about = new About();
            about.Show();            
            about.Icon = new WindowIcon(path);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = (Window)this.Parent;
            parentWindow.Close();
        }

        private void EmailSettings_Click(object sender, RoutedEventArgs e)
        {
            var getdot = new Settings();

            string netCoreVer = getdot.GetNetCoreVersion();

            string verSep = netCoreVer.Remove(3);

            string path = ($"../netcoreapp{verSep}/Assets/avalonia-logo.ico");

            var emailSet = new EmailSettings();
            emailSet.Show();
            emailSet.Icon = new WindowIcon(path);
        }


    }

}