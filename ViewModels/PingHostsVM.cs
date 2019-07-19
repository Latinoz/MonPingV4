using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MonPingV4.Models;

namespace MonPingV4.ViewModels
{
    public class PingHostsVM : ViewModelBase
    {
              
        //public PingHostsVM(IEnumerable<HostsItem> items)
        //{
           //Items = new ObservableCollection<HostsItem>(items);

           //Items.Add()
        //}

        //public ObservableCollection<HostsItem> Items { get; }

        string Iphost;

        public string iphost
        {
            get
            {
                
                return Iphost;
            }

            set
            {
                //value = Iphost;
                Iphost = value;
            }
        }

        public void OnClickCommand()
        {
            // do something
        }

    }
}