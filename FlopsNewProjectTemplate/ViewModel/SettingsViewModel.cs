using CommunityToolkit.Mvvm.Input;
using FlopsNewProjectTemplate.Interfaces;
using System;

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

        private void OpenDialog()
        {
            _dialogService.PromptYesCancelDialog();
        }
    }
}
