﻿using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using MonPingV4.ViewModels;
using MonPingV4.Views;
using MonPingV4.Services;
using MonPingV4.Models;
using System.Collections.ObjectModel;

namespace MonPingV4
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug()
                .UseReactiveUI();

        // Your application's entry point. Here you can initialize your MVVM framework, DI
        // container, etc.
        private static void AppMain(Application app, string[] args)
        {
            //var db = new Database(); 

            var window = new MainWindow
            {
                //DataContext = new MainWindowViewModel(db),

                DataContext = new PingHostsVM()

            };

            app.Run(window);
        }
    }
}
