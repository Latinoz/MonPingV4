// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Diagnostics.ViewModels;
using DynamicData.Annotations;
using MonPingV4.ViewModels;

namespace MonPingV4
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            var name = data.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        internal class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected bool RaiseAndSetIfChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            {
                if (!EqualityComparer<T>.Default.Equals(field, value))
                {
                    field = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                    return true;
                }

                return false;
            }

            [NotifyPropertyChangedInvocator]
            protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;            
        }
        
    }
}