using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Services
{
    public class MainProgressBarService
    {
        public event EventHandler ProgressBarVisibilityChanged;
        public bool IsVisible { get; private set; }
        public MainProgressBarService() {  }
        public void ShowProgressBar()
        {
            IsVisible = true;
            ProgressBarVisibilityChanged?.Invoke(this, EventArgs.Empty);  
        }
        public void HideProgressBar()
        {
            IsVisible = false;
            ProgressBarVisibilityChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
