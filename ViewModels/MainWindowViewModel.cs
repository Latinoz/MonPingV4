using System;
using System.Collections.Generic;
using System.Text;
using MonPingV4.Services;

namespace MonPingV4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel(Database db)
        {
            //List = new PingHostsVM(db.GetItems());
        }

        public PingHostsVM List { get; }
        
    }
}
