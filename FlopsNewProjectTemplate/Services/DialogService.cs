using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Interfaces;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Services
{
    public class DialogService:IDialogService
    {
        public DialogService() { }

        public async void PromptYesCancelDialog()
        {
            var cancelYes = new DialogYesCancel();
            var result=await DialogHost.Show(cancelYes, "RootDialogHost");
            Debug.Print(result.ToString());
        }
    }
}
