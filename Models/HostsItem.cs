using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MonPingV4.Models
{
    public class HostsItem : INotifyPropertyChanged
    {
        string iphost;
        string outputAnswer;
        bool ischecked;

        public string Iphost
        {
            get
            {
                return iphost;
            }

            set
            {
                iphost = value;
                OnPropertyChanged("Iphost");
            }
        }        

        public string OutputAnswer
        {
            get
            {
                return outputAnswer;
            }

            set
            {
                outputAnswer = value;
                OnPropertyChanged("OutputAnswer");
            }
        }        

        public bool IsChecked
        {
            get
            {
                return ischecked;
            }

            set
            {
                ischecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
