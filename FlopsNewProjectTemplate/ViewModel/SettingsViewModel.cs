using CommunityToolkit.Mvvm.Input;
using FlopsNewProjectTemplate.Interfaces;
using System;
using System.Diagnostics;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class SettingsViewModel : INavigationable
    {
        private readonly IDialogService _dialogService;

        public string Name => "Settings";
        public INavigationable ViewModel => this;
        public RelayCommand OpenDialogCommand { get; }
        public SettingsViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            OpenDialogCommand = new RelayCommand(OpenDialog);
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
