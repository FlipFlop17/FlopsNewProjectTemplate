using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlopsNewProjectTemplate.Controls
{
    /// <summary>
    /// Interaction logic for DialogYesCancel.xaml
    /// </summary>
    public partial class DialogYesCancel : UserControl
    {
        public string DialogText { get; set; }
        public DialogYesCancel()
        {
            DialogText = "I have a dialog service which you can call and use. Sounds good?";
            DataContext = this;
            InitializeComponent();

        }
    }
}
