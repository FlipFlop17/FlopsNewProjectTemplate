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
        private readonly ISnackbarMessageQueue _mainMsgqueueService;
        private readonly MainProgressBarService _mainProgressBarService;
        private readonly InfoBoxFooterService _footerMsgService;
        private INavigationable _currentViewModel;
        public INavigationable CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel,value); }
        }
        public RelayCommand<NavigationViews> NewViewIsClicked { get; set; }
        public bool UatLabelVisibility { get; set; }

        public ISnackbarMessageQueue MainSnackBarQueue => _mainMsgqueueService;

        private bool _isRailProgressBarVisible;
        public bool IsRailProgressBarVisible
        {
            get { return _isRailProgressBarVisible; }
            set { SetProperty(ref _isRailProgressBarVisible, value); }
        }
        private string _footerInfoMessage;
        public string FooterInfoMessage
        {
            get { return _footerInfoMessage; }
            set { SetProperty(ref _footerInfoMessage, value); }
        }
        private MessageType _footerInfoMessageType;
        public MessageType FooterInfoMessageType
        {
            get { return _footerInfoMessageType; }
            set { SetProperty(ref _footerInfoMessageType, value); }
        }
        private Visibility _footerVisibility=Visibility.Hidden;
        public Visibility FooterVisibility
        {
            get => _footerVisibility;
            set { SetProperty(ref _footerVisibility, value); } 
        }

        public MainWindowViewModel(NavigationService navService,
            AppConfig config,
            ISnackbarMessageQueue mainMsgqueue,
            MainProgressBarService mainProgressBar,
            InfoBoxFooterService footerMsg)
        {
            _navService = navService;
            _mainMsgqueueService = mainMsgqueue;
            _mainProgressBarService = mainProgressBar;
            _footerMsgService = footerMsg;
            CurrentViewModel = _navService.GoToHomePage(); //set start page
            NewViewIsClicked = new RelayCommand<NavigationViews>(ClickedMe);
            UatLabelVisibility = !config.IsRunningOnProduction();
            _mainProgressBarService.ProgressBarVisibilityChanged += MainProgressBar_ProgressBarVisibilityChanged;
            _footerMsgService.MessageInfoChanged += _footerMsgService_MessageInfoChanged;
        }

        private void _footerMsgService_MessageInfoChanged(object sender, EventArgs e)
        {
            FooterInfoMessage = _footerMsgService.MessageToShow;
            FooterInfoMessageType = _footerMsgService.MessageType;
            FooterVisibility = _footerMsgService.MessageBoxVisibility;
        }

        private void MainProgressBar_ProgressBarVisibilityChanged(object sender, EventArgs e)
        {
            IsRailProgressBarVisible = _mainProgressBarService.IsVisible;
        }

        private void ClickedMe(NavigationViews view)
        {
            CurrentViewModel = _navService.GetSelectedView(view);
        }
    }
}
