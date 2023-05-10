using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlopsNewProjectTemplate.Config;
using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Interfaces;
using FlopsNewProjectTemplate.Services;
using MaterialDesignThemes.Wpf;
using Serilog;
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
        private readonly ISnackbarMessageQueue _mainMsgqueue;
        private readonly MainProgressBarService _mainProgressBar;
        private INavigationable _currentViewModel;
        public INavigationable CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel,value); }
        }
        public RelayCommand<NavigationViews> NewViewIsClicked { get; set; }
        public bool UatLabelVisibility { get; set; }

        public ISnackbarMessageQueue MainSnackBarQueue => _mainMsgqueue;

        private bool _isRailProgressBarVisible;
        public bool IsRailProgressBarVisible
        {
            get { return _isRailProgressBarVisible; }
            set { SetProperty(ref _isRailProgressBarVisible, value); }
        }

        public MainWindowViewModel(NavigationService navService,AppConfig config,ISnackbarMessageQueue mainMsgqueue,MainProgressBarService mainProgressBar)
        {
            _navService = navService;
            _mainMsgqueue = mainMsgqueue;
            _mainProgressBar = mainProgressBar;
            CurrentViewModel = _navService.GoToHomePage(); //set start page
            NewViewIsClicked = new RelayCommand<NavigationViews>(ClickedMe);
            UatLabelVisibility = !config.IsRunningOnProduction();
            _mainProgressBar.ProgressBarVisibilityChanged += MainProgressBar_ProgressBarVisibilityChanged;
        }

        private void MainProgressBar_ProgressBarVisibilityChanged(object sender, EventArgs e)
        {
            IsRailProgressBarVisible = _mainProgressBar.IsVisible;
        }

        private void ClickedMe(NavigationViews view)
        {
            CurrentViewModel = _navService.GetSelectedView(view);
        }
        //TODO Dialogs
    }
}
