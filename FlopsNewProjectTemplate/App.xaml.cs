using FlopsNewProjectTemplate.Config;
using FlopsNewProjectTemplate.Factory;
using FlopsNewProjectTemplate.Services;
using FlopsNewProjectTemplate.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Windows;

namespace FlopsNewProjectTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IHost _appHost { get; }

        public App()
        {
            try {
                _appHost = Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton<AppConfig>();
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
            }
            catch (System.Exception e) {
                Debug.Print("err:"+e.ToString());
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
