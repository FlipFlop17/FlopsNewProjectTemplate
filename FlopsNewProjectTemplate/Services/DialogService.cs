using FlopsNewProjectTemplate.Controls;
using FlopsNewProjectTemplate.Interfaces;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Services
{
    public class DialogService:IDialogService
    {
        private string _dialogHostIdentifier => "RootDialogHost";
        public DialogService() { }

        public async Task<bool> PromptYesCancelDialog()
        {
            var cancelYes = new DialogYesCancel();
            var result=await DialogHost.Show(cancelYes, _dialogHostIdentifier);
            if(result==null | result.ToString() == "Cancel") {
                return false;
            } else {
                return true;
            }
        }
    }
}
