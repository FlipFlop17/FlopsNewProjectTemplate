using FlopsNewProjectTemplate.Config;
using FlopsNewProjectTemplate.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class HomeViewModel : INavigationable
    {
        private readonly AppConfig _config;

        public string Name => "Home view";

        public INavigationable ViewModel => this;

        public HomeViewModel()
        {
        }
    }
}
