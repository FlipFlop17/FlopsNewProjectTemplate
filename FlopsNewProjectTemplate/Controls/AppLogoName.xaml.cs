using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace FlopsNewProjectTemplate.Controls
{
    /// <summary>
    /// Interaction logic for AppLogoName.xaml
    /// </summary>
    public partial class AppLogoName : UserControl
    {
        public AppLogoName()
        {
            DataContext = this;
            InitializeComponent();
        }

        public string AppName
        {
            get { return (string)GetValue(AppNameProperty); }
            set { SetValue(AppNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppNameProperty =
            DependencyProperty.Register("AppName", typeof(string), typeof(UserControl), new PropertyMetadata("MyApp"));


        public string PackIconName
        {
            get { return (string)GetValue(PackIconNameProperty); }
            set { SetValue(PackIconNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PackIconNameProperty =
            DependencyProperty.Register("PackIconName", typeof(string), typeof(UserControl), new PropertyMetadata("AppBadge"));



    }
}
