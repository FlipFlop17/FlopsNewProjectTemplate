using FlopsNewProjectTemplate.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlopsNewProjectTemplate.Controls
{
    /// <summary>
    /// Available pages/views. New pages must be added to the list
    /// </summary>
    public enum NavigationViews
    {
        Home,Settings
    }
    public partial class NavigationMenu : UserControl
    {
        public NavigationMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ICommand for when the new view is clicked. Implement the Binding for this command in the parentviewmodel where the navmenu is inserted.
        /// </summary>
        public ICommand NewViewIsClicked
        {
            get { return (ICommand)GetValue(NewViewIsClickedProperty); }
            set { SetValue(NewViewIsClickedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewViewIsClicked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewViewIsClickedProperty =
            DependencyProperty.Register("NewViewIsClicked", typeof(ICommand), typeof(NavigationMenu), new PropertyMetadata(null));
    }
}
