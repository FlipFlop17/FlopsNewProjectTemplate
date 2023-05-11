using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlopsNewProjectTemplate.Interfaces;
using FlopsNewProjectTemplate.Services;
using MaterialDesignThemes.Wpf;
using System;
using System.Diagnostics;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class SettingsViewModel :ObservableObject, INavigationable
    {
        private readonly IDialogService _dialogService;
        private readonly ISnackbarMessageQueue _snackBarQu;
        private readonly MainProgressBarService _mainProgressBar;
        private readonly InfoBoxFooterService _infoService;

        public string Name => "Settings";
        public INavigationable ViewModel => this;
        public RelayCommand OpenDialogCommand { get; }
        public RelayCommand OpenSnackBarCommand { get; }

        private bool _isCheckedProgress;

        public bool IsCheckedProgress
        {
            get { return _isCheckedProgress; }
            set {
                SetProperty(ref _isCheckedProgress, value);
                if (IsCheckedProgress) { 
                    _mainProgressBar.ShowProgressBar();
                } else {
                    _mainProgressBar.HideProgressBar();
                }
            }
        }
        private bool _isCheckedInfo;

        public bool IsCheckedInfo
        {
            get { return _isCheckedInfo; }
            set
            {
                SetProperty(ref _isCheckedInfo, value);
                if (IsCheckedInfo) {
                    _infoService.ShowMessage("Showing my msg info",MessageType.Positive);
                }
            }
        }

        public SettingsViewModel(IDialogService dialogService,ISnackbarMessageQueue snackBarQu,MainProgressBarService mainProgressBar,InfoBoxFooterService infoService)
        {
            _dialogService = dialogService;
            _snackBarQu = snackBarQu;
            _mainProgressBar = mainProgressBar;
            _infoService = infoService;
            OpenDialogCommand = new RelayCommand(OpenDialog);
            OpenSnackBarCommand = new RelayCommand(OpenSnackBar);
        }
        private void OpenSnackBar()
        {
            _snackBarQu.Enqueue("Showing my snackbar");
        }

        private async void OpenDialog()
        {
            if ( await _dialogService.PromptYesCancelDialog()) {
                Debug.Print("I accepted this dialog");
            } else {
                Debug.Print("I choose to cancel");
            }
        }
    }
}
