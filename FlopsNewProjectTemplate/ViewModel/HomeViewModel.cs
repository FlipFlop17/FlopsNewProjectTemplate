using FlopsNewProjectTemplate.Config;
using FlopsNewProjectTemplate.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class HomeViewModel : INavigationable
    {
        private readonly AppConfig _config;

        public string Name { get; }

        public INavigationable ViewModel => this;

        public HomeViewModel(AppConfig config)
        {
            _config = config;
            Name=_config.MainDirectoryPath;
        }
    }
}
