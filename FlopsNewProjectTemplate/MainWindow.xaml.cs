using System.Diagnostics;
using System.Windows;

namespace FlopsNewProjectTemplate
{
    /// <summary>
    /// Interaction logic for MainShell.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void WindowHeader_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
            
        }
    }
}
