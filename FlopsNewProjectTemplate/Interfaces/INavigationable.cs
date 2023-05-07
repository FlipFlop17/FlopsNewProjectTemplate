using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Interfaces
{
    public interface INavigationable
    {
        /// <summary>
        /// The name of the view. Optional
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The viewmodel instance
        /// </summary>
        INavigationable ViewModel { get; }
    }
}
