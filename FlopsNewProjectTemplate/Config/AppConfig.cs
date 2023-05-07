using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace FlopsNewProjectTemplate.Config
{
    /// <summary>
    /// Class that holds the same properties as the App.config.json so it can be mapped inside dependency injection.
    /// </summary>
    public class AppConfig
    {
        private string _mainDirectoryPath;
        public string MainDirectoryPath
        {
            get { return _mainDirectoryPath; }
            set { //only update value once, on class init.
                if (_mainDirectoryPath==null) {
                    _mainDirectoryPath = value;
                } 
            }
        }
        private string _environment;
        public string Environment
        {
            get { return _environment; }
            set
            { //only update value once, on class init.
                if (_environment == null) {
                    _environment = value;
                }
            }
        }
        public bool IsRunningOnProduction()
        {
            return Environment == "Production"?true:false;
        }
        //any new keys inside App.config.json file should be added as a property of this class
        //...
    }
}
