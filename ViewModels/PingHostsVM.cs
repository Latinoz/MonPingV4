using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MonPingV4.Models;
using MonPingV4.Services;

namespace MonPingV4.ViewModels
{
    public class PingHostsVM : INotifyPropertyChanged
    {       

        public TextOutAnswer answer;    
        
        public PingHostsVM()
        {
            Items = new ObservableCollection<HostsItem>
            {
                new HostsItem {Iphost = "127.0.0.1", OutputAnswer = "Test 111", IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.2", OutputAnswer = "Test 222", IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.3", OutputAnswer = "Test 333", IsChecked_1 = false, IsChecked_2 = true}
            }; 

            
        }

        public ObservableCollection<HostsItem> Items { get; set; }

        //private async void DoIT(string iphost)
        //{
        //    PingClass obj = new PingClass();

        //    answer = await obj.DoPingThreadAsync(iphost);

        //    if (answer == TextOutAnswer.Success)
        //    {
        //        //outputAnswer = "ICMP answer received";
        //    }
        //    else if (answer == TextOutAnswer.Warning)
        //    {
        //        //outputAnswer = "Host is not available!";
        //    }
        //    else if (answer == TextOutAnswer.Error)
        //    {
        //        //outputAnswer = "Invalid ip address!";
        //    }
        //        //OnPropertyChanged("OutputAnswer");
        //}



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}