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
        bool ischecked_1;
        bool ischecked_2;
        TextOutAnswer answer;

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

        public bool IsChecked_1
        {
            get
            {
                return ischecked_1;
            }

            set
            {
                ischecked_1 = value;
                OnPropertyChanged("IsChecked_1");
            }
        }

        public bool IsChecked_2        {
            get
            {
                return ischecked_2;
            }

            set
            {
                ischecked_2 = value;
                OnPropertyChanged("IsChecked_2");
            }
        }

        public void OnClickCommand_0()
        {           
            DoIT(iphost);
            ischecked_1 = true;
            ischecked_2 = false;
            OnPropertyChanged("IsChecked_1");
            OnPropertyChanged("IsChecked_2");
        }

        public void OnClickCommand_1()
        {
            outputAnswer = "STOP";
            ischecked_1 = false;
            ischecked_2 = true;
            OnPropertyChanged("OutputAnswer");
            OnPropertyChanged("IsChecked_1");
            OnPropertyChanged("IsChecked_2");
        }

        private async void DoIT(string iphost)
        {
            PingClass obj = new PingClass();

            answer = await obj.DoPingThreadAsync(iphost);

            if (answer == TextOutAnswer.Success)
            {
                outputAnswer = "ICMP answer received";
            }
            else if (answer == TextOutAnswer.Warning)
            {
                outputAnswer = "Host is not available!";
            }
            else if (answer == TextOutAnswer.Error)
            {
                outputAnswer = "Invalid ip address!";
            }
            OnPropertyChanged("OutputAnswer");
        }


        public void OnClickCommand_Add()
        {
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
