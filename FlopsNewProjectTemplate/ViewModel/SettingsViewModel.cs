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

        public string Name => "Settings";
        public INavigationable ViewModel => this;
        public RelayCommand OpenDialogCommand { get; }
        public RelayCommand OpenSnackBarCommand { get; }

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set {
                SetProperty(ref _isChecked, value);
                if (IsChecked) { 
                    _mainProgressBar.ShowProgressBar();
                } else {
                    _mainProgressBar.HideProgressBar();
                }
            }
        }

        public SettingsViewModel(IDialogService dialogService,ISnackbarMessageQueue snackBarQu,MainProgressBarService mainProgressBar)
        {
            _dialogService = dialogService;
            _snackBarQu = snackBarQu;
            _mainProgressBar = mainProgressBar;
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
