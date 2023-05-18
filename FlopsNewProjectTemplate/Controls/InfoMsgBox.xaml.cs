using FlopsNewProjectTemplate.Services;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlopsNewProjectTemplate.Controls
{
    /// <summary>
    /// Interaction logic for InfoMsgBox.xaml
    /// </summary>
    public partial class InfoMsgBox : UserControl
    {
        public SolidColorBrush InfoBoxBackgroundColor { get; set; }
        public SolidColorBrush TextBoxFontColor { get; set; }
        public InfoMsgBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        /// <summary>
        /// Type of a message that is displayed. positive, neutral etc.Found in InfoBoxFooterService class
        /// </summary>
        public MessageType MessageType
        {
            get { return (MessageType)GetValue(MessageTypeProperty); }
            set { SetValue(MessageTypeProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageTypeProperty =
            DependencyProperty.Register("MessageType", typeof(MessageType), typeof(UserControl), new PropertyMetadata(null));

        /// <summary>
        /// Message to be show on the usercontrol
        /// </summary>
        public string MessageToShow
        {
            get { return (string)GetValue(MessageToShowProperty); }
            set { 
                SetValue(MessageToShowProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for MessageToShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageToShowProperty =
            DependencyProperty.Register("MessageToShow", typeof(string), typeof(UserControl), new PropertyMetadata(string.Empty));



        public Visibility IsMessageBoxVisible
        {
            get { return (Visibility)GetValue(IsMessageBoxVisibleProperty); }
            set { SetValue(IsMessageBoxVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMessageBoxVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMessageBoxVisibleProperty =
            DependencyProperty.Register("IsMessageBoxVisible", typeof(Visibility), typeof(UserControl), new PropertyMetadata(Visibility.Hidden));

    }
}
