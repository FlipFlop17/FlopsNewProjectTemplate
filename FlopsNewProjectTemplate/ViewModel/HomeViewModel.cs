using FlopsNewProjectTemplate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class HomeViewModel : INavigationable
    {
        public string Name => "Home";

        public INavigationable ViewModel => this;
    }
}
