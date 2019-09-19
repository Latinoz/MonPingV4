using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;

namespace MonPingV4.Models
{
    public class HostsItem 
        : INotifyPropertyChanged
    {

       

        string iphost;
        public string Iphost
        {
            get
            {
                return iphost;
            }

            set
            {
                iphost = value;
                OnPropertyChanged(nameof(Iphost));
            }
        }

        string outputAnswer;
        public string OutputAnswer
        {
            get
            {
                return outputAnswer;
            }

            set
            {
                outputAnswer = value;
                OnPropertyChanged(nameof(OutputAnswer));
            }
        }

        bool ischecked_1;
        public bool IsChecked_1
        {
            get
            {
                return ischecked_1;
            }

            set
            {
                ischecked_1 = value;
                OnPropertyChanged(nameof(IsChecked_1));
            }
        }

        bool ischecked_2;
        public bool IsChecked_2        {
            get
            {
                return ischecked_2;
            }

            set
            {
                ischecked_2 = value;
                OnPropertyChanged(nameof(IsChecked_2));
            }
        }

        bool _stop = false;

        TextOutAnswer answer;                 

        public async void OnClickCommand_Start()
        {
            _stop = false;
            ischecked_1 = true;
            ischecked_2 = false;
            OnPropertyChanged(nameof(IsChecked_1));
            OnPropertyChanged(nameof(IsChecked_2));

            PingClass obj = new PingClass();

            while (true)
            {
                if (_stop == true)
                {
                    outputAnswer = string.Empty;
                    OnPropertyChanged(nameof(OutputAnswer));
                    break;
                    
                }
                else
                {
                    
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
                    OnPropertyChanged(nameof(OutputAnswer));

                    Debug.WriteLine(outputAnswer);
                }
            }         
               
            
        }

        public void OnClickCommand_Stop()
        {
            _stop = true;            
            ischecked_1 = false;
            ischecked_2 = true;            
            OnPropertyChanged(nameof(IsChecked_1));
            OnPropertyChanged(nameof(IsChecked_2));
        }
               

        //private async void DoIT(string iphost)
        //{
            
        //    PingClass obj = new PingClass();

            
        //        answer = await obj.DoPingThreadAsync(iphost);

        //        if (answer == TextOutAnswer.Success)
        //        {
        //            outputAnswer = "ICMP answer received";
        //        }
        //        else if (answer == TextOutAnswer.Warning)
        //        {
        //            outputAnswer = "Host is not available!";
        //        }
        //        else if (answer == TextOutAnswer.Error)
        //        {
        //            outputAnswer = "Invalid ip address!";
        //        }
        //        OnPropertyChanged("OutputAnswer");              

        //}               


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
