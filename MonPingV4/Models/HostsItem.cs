using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using ConsoleToast;
using Avalonia.Media;
using MonPingV4.Services;

namespace MonPingV4.Models
{
    public class HostsItem 
        : INotifyPropertyChanged
    {

        //Чтобы использовать VM нужно использовать ICommand вместо методов void OnClickCommand_Start()
        //И добавить DataContext = new PingHostVM() в код бихаинд PingHostsListView.xaml.cs

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

        IBrush outputAnswerColor;
        public IBrush OutputAnswerColor
        {
            get
            {
                return outputAnswerColor;                
            }

            set
            {
                outputAnswerColor = value;
                OnPropertyChanged(nameof(OutputAnswerColor));
            }
        }

        IBrush logTextColor = Brushes.DarkBlue;
        public IBrush LogTextColor
        {
            get
            {
                return logTextColor;
            }

            set
            {
                logTextColor = value;
                OnPropertyChanged(nameof(LogTextColor));
            }
        }

        IBrush logBackColor = Brushes.White;
        public IBrush LogBackColor
        {
            get
            {
                return logBackColor;
            }

            set
            {
                logBackColor = value;
                OnPropertyChanged(nameof(LogBackColor));
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
        public bool IsChecked_2
        {
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

        static bool _logtray;
        public bool _Logtray
        {
            get
            {
                return _logtray;
            }

            set
            {
                _logtray = value;

                //OnPropertyChanged(nameof(_logtray));
            }
        }
       

        bool _stop = false;

        bool logWrite = false;
        public bool _LogWrite
        {
            get
            {
                return logWrite;
            }

            set
            {
                logWrite = value;

                //OnPropertyChanged(nameof(_Logging));
            }
        }


        TextOutAnswer answer;                 

        public async void OnClickCommand_Start()     
        {
            _stop = false;
            ischecked_1 = true;
            ischecked_2 = false;
            outputAnswer = String.Empty;
            outputAnswerColor = Brushes.Black;
            OnPropertyChanged(nameof(OutputAnswer));
            OnPropertyChanged(nameof(OutputAnswerColor));
            OnPropertyChanged(nameof(IsChecked_1));
            OnPropertyChanged(nameof(IsChecked_2));


            PingClass obj = new PingClass();

            while (true)
            {
                if (_stop == true)
                {
                    outputAnswerColor = Brushes.White;
                    outputAnswer = "Stopped!";
                    OnPropertyChanged(nameof(OutputAnswer));
                    OnPropertyChanged(nameof(OutputAnswerColor));
                    break;                    
                }
                else
                {                    
                    answer = await obj.DoPingThreadAsync(iphost);

                    if (answer == TextOutAnswer.Success)
                    {
                        outputAnswerColor = Brushes.Green;
                        outputAnswer = "ICMP answer received";

                        if (logWrite == true)
                        {
                            Logging.DoLog(iphost, outputAnswer);
                        }
                    }
                    else if (answer == TextOutAnswer.Warning)
                    {
                        outputAnswerColor = Brushes.Red;
                        outputAnswer = $"Host is not available!";
                        if(_logtray == true)
                        {
                            ProgramClass.ShowTextToast("MonPing", "Warning!", $"Host {Iphost} is not available!");
                        }                        
                        
                        if(logWrite == true)
                        {
                            Logging.DoLog(iphost, outputAnswer);
                        }                        

                    }
                    else if (answer == TextOutAnswer.Error)
                    {
                        outputAnswerColor = Brushes.OrangeRed;
                        outputAnswer = "Invalid ip address!";

                        if (logWrite == true)
                        {
                            Logging.DoLog(iphost, outputAnswer);
                        }
                    }
                    OnPropertyChanged(nameof(OutputAnswer));
                    OnPropertyChanged(nameof(OutputAnswerColor));

                    //Debug.WriteLine(outputAnswer);
                }
            }                    
            
        }

        public void OnClickCommand_Stop()
        {
            _stop = true;
            logWrite = false;            
            ischecked_1 = false;
            ischecked_2 = true;            
            OnPropertyChanged(nameof(IsChecked_1));
            OnPropertyChanged(nameof(IsChecked_2));
            OnPropertyChanged(nameof(logWrite));
        }

        public void OnClickCommand_Log()
        {
            if(logWrite == false)
            {
                logWrite = true;
            }
            else
            {
                
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
