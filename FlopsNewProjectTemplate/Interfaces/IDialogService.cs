using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Interfaces
{
    public interface IDialogService
    {
        /// <summary>
        /// Returns True if dialog is responded with 'Yes' false otherwise
        /// </summary>
        /// <returns></returns>
         Task<bool> PromptYesCancelDialog();
    }
}
