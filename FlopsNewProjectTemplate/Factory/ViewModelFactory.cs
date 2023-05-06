using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Interfaces;
using FlopsNewProjectTemplate.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Factory
{
    public class ViewModelFactory
    {
        private readonly IServiceProvider _services;

        public ViewModelFactory(IServiceProvider services)
        {
            _services = services;
        }
        public INavigationable GetRequestedViewModel(NavigationViews view)
        {
            switch (view) {
                case NavigationViews.Home:
                    return _services.GetService<HomeViewModel>();
                case NavigationViews.Settings:
                    return _services.GetService<SettingsViewModel>();
                default:
                    return _services.GetService<HomeViewModel>();
            }
        }
    }
}
