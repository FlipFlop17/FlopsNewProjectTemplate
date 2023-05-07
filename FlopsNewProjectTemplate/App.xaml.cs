using FlopsNewProjectTemplate.Config;
using FlopsNewProjectTemplate.Factory;
using FlopsNewProjectTemplate.Services;
using FlopsNewProjectTemplate.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

namespace FlopsNewProjectTemplate
{
    public partial class App : Application
    {
        private IHost _appHost { get; }
        public App()
        {
            try {
                Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

                var logFileFullPath = Path.Combine
                    (
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name + "_Logs",
                        "Log-.txt"
                    );

                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File(logFileFullPath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                _appHost = Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration((hostingcontext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("App.config.json", optional: false, reloadOnChange: true);
                    })
                    .ConfigureServices((context,services) =>
                    {
                        services.AddSingleton(context.Configuration.Get<AppConfig>()); //maps json config file to class to be used across the application
                        services.AddSingleton<NavigationService>();
                        services.AddTransient<HomeViewModel>();
                        services.AddTransient<SettingsViewModel>();
                        services.AddSingleton<MainWindowViewModel>();
                        services.AddSingleton<ViewModelFactory>();
                        services.AddSingleton(s => new MainWindow()
                        {
                            DataContext = s.GetService<MainWindowViewModel>()
                        });
                        
                    })
                    .Build();
                    //Log.Information("Environment: " + _appHost.Services.GetService<AppConfig>().Environment);
            }
            catch (Exception e) {
                Debug.Print("Host Error: "+e.ToString());
                Log.Error("Host error: "+e.ToString());
                throw;
            }
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _appHost.StartAsync();
            var startupForm = _appHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _appHost.StopAsync();
            base.OnExit(e);
        }
    }
}
