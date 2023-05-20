using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlopsNewProjectTemplate.Controls
{
    /// <summary>
    /// Interaction logic for WindowControlButtons.xaml
    /// </summary>
    public partial class WindowControlButtons : UserControl
    {
        public WindowControlButtons()
        {
            InitializeComponent();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            var myWindow=Window.GetWindow(this);
            myWindow.Close();
        }
        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.WindowState = WindowState.Minimized;
        }
        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.WindowState = WindowState.Maximized;
        }
    }
}
