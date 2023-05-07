using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Factory;
using FlopsNewProjectTemplate.Interfaces;

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

        /// <summary>
        /// Navigates to the home page
        /// </summary>
        /// <returns></returns>
        public INavigationable GoToHomePage()
        {
            CurrentViewModel = NavigationViews.Home;
            return _viewFactory.GetRequestedViewModel(NavigationViews.Home);

        }
        /// <summary>
        /// Returns the selected viewmodel
        /// </summary>
        /// <param name="view">ViewModel</param>
        /// <returns></returns>
        public INavigationable GetSelectedView(NavigationViews view)
        {
            CurrentViewModel = view;
            return _viewFactory.GetRequestedViewModel(view);
        }
    }
}
