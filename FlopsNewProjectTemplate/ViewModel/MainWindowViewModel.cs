using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Interfaces;
using FlopsNewProjectTemplate.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class MainWindowViewModel:ObservableObject
    {
        private readonly NavigationService _navService;

        private INavigationable _currentViewModel;
        public INavigationable CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel,value); }
        }
        public RelayCommand<NavigationViews> NewViewIsClicked { get; set; }
        public MainWindowViewModel(NavigationService navService)
        {
            _navService = navService;
            CurrentViewModel = _navService.GoToHomePage(); //set start page
            NewViewIsClicked = new RelayCommand<NavigationViews>(ClickedMe);
        }

        private void ClickedMe(NavigationViews view)
        {
            CurrentViewModel = _navService.GetSelectedView(view);
        }
    }
}
