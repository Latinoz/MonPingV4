using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MonPingV4.Models;
using MonPingV4.Services;
using System.Linq;
using System.Windows.Input;
using DynamicData;

namespace MonPingV4.ViewModels
{
    public class PingHostsVM : INotifyPropertyChanged
    {       

        public TextOutAnswer answer;

        public ObservableCollection<HostsItem> Items { get; set; }

        public PingHostsVM()
        {
            Items = new ObservableCollection<HostsItem>
            {
                new HostsItem {Iphost = "127.0.0.1", OutputAnswer = "", IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.2", OutputAnswer = "", IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.3", OutputAnswer = "", IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.4", OutputAnswer = "", IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.5", OutputAnswer = "", IsChecked_1 = false, IsChecked_2 = true}
            }; 
            
        }
                     


        public void OnClickCommand_Add()
        {
            Items.Add(new HostsItem() { Iphost = "127.0.0.10", OutputAnswer = "", IsChecked_1 = false, IsChecked_2 = true });
        }

        public void OnClickCommand_Del()
        {
            Items.RemoveAt(Items.Count - 1);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}