using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Interfaces
{
    public interface INavigationable
    {
        string Name { get; }
        INavigationable ViewModel { get; }
    }
}
