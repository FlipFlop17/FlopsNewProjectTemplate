using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Services
{
    public class MainProgressBarService
    {
        public MainProgressBarService() { }
        public bool IsVisible { get; private set; }
        public void ShowProgressBar()
        {
            IsVisible = true;
        }
        public void HideProgressBar()
        {
            IsVisible = false;
        }
    }
}
