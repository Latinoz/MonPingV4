using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MonPingV4.Models;

namespace MonPingV4.ViewModels
{
    public class PingHostsVM : ViewModelBase, INotifyPropertyChanged
    {

        //public PingHostsVM(IEnumerable<HostsItem> items)
        //{
        //Items = new ObservableCollection<HostsItem>(items);

        //Items.Add()
        //}

        //public ObservableCollection<HostsItem> Items { get; }

        public TextOutAnswer answer;

        string iphost = "127.0.0.1";

        public string Iphost
        {
            get
            {
                
                return iphost;
            }

            set
            {
                iphost = value;
            }
        }

        string outputAnswer;

        public string OutputAnswer
        {
            get
            {
                return outputAnswer;
            }

            //set
            //{
            //    outputAnswer = value;
            //    OnPropertyChanged("OutputAnswer");
            //}
        }

        bool ischecked = false;

        public bool IsChecked
        {
            get
            {

                return ischecked;
            }

            set
            {
                ischecked = value;
            }
        }


        public async void OnClickCommand()
        {
            PingClass obj = new PingClass();

            //if (iphost == null)                   //Проверка на пустое поле
            //{
            //    outputAnswer = "Enter ip address";
            //    OnPropertyChanged("OutputAnswer");
            //}

            //else
            //{
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
            //}            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}