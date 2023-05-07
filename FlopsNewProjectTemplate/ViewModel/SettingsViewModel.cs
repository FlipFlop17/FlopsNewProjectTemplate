using FlopsNewProjectTemplate.Interfaces;

namespace FlopsNewProjectTemplate.ViewModel
{
    public class SettingsViewModel : INavigationable
    {
        public string Name => "Settings";
        public INavigationable ViewModel => this;
    }
}
