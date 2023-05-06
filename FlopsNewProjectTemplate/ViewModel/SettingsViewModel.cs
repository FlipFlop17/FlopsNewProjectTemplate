using FlopsNewProjectTemplate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class SettingsViewModel : INavigationable
    {
        public string Name => "Settings";
        public INavigationable ViewModel => this;
    }
}
