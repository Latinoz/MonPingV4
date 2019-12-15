using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MonPingV4.Models;
using MonPingV4.Services;
using System.Linq;
using Avalonia.Media;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MonPingV4.Views;
using System.Reflection;

namespace MonPingV4.ViewModels
{
    public class PingHostsVM : INotifyPropertyChanged
    {
        string ip = "127.0.0.";

        public TextOutAnswer answer;

        bool _logCheck = true;
        public bool _LogCheck
        {
            get
            {
                
                return _logCheck;
            }

            set
            {
                _logCheck = value;

                var h = new HostsItem();                         

                if (_logCheck == true)
                {
                    h._Logtray = true;
                    
                    //OnPropertyChanged(nameof(_LogCheck));
                }
                else if(_logCheck == false)
                {
                    h._Logtray = false;
                }
                
                //OnPropertyChanged(nameof(_LogCheck));
            }
        }

        public ObservableCollection<HostsItem> Items { get; set; }

        public PingHostsVM()
        {
            Items = new ObservableCollection<HostsItem>
            {
                new HostsItem {Iphost = "127.0.0.1", OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.2", OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.3", OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.4", OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true},
                new HostsItem {Iphost = "127.0.0.5", OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true}
            }; 
            
        }

        public void OnClickCommand_Add()
        {
            var item = Items.Last();
            char last_char = item.Iphost[item.Iphost.Length - 1];
            var num_from_char = Char.GetNumericValue(last_char);
            Items.Add(new HostsItem() { Iphost = ip+(num_from_char + 1).ToString(), OutputAnswer = " ", OutputAnswerColor = Brushes.Black, IsChecked_1 = false, IsChecked_2 = true });
        }

        public void OnClickCommand_Del()   // Добавить - При удалении стопить пингование удаленных хостов
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