using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Factory;
using FlopsNewProjectTemplate.Interfaces;
using FlopsNewProjectTemplate.ViewModel;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Services
{
    /// <summary>
    /// Navigation services that takes care of navigating the available views
    /// </summary>
    public class NavigationService
    {
        private readonly ViewModelFactory _viewFactory;

        public NavigationService(ViewModelFactory viewFactory)
        {
            _viewFactory = viewFactory;
        } 

        /// <summary>
        /// Gives info about the current view model the user is on
        /// </summary>
        public NavigationViews CurrentViewModel { get; private set; }
        public INavigationable GoToHomePage()
        {
            CurrentViewModel = NavigationViews.Home;
            return _viewFactory.GetRequestedViewModel(NavigationViews.Home);

        }
        public INavigationable GetSelectedView(NavigationViews view)
        {
            CurrentViewModel = view;
            return _viewFactory.GetRequestedViewModel(view);
        }
    }
}
