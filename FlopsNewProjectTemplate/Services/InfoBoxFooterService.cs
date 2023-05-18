using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlopsNewProjectTemplate.Services
{
    public enum MessageType
    {
        Neutral,
        Positive,
        Error,
        Warning
    }
    public class InfoBoxFooterService
    {
        public event EventHandler MessageInfoChanged;
        /// <summary>
        /// Message to be shown
        /// </summary>
        public string MessageToShow { get; private set; }
        /// <summary>
        /// If not set the default is Neutral
        /// </summary>
        public MessageType MessageType { get; private set; }
        public Visibility MessageBoxVisibility { get; private set; }
        public void ShowMessage(string msgToShow,MessageType msgType=MessageType.Neutral) {
            MessageBoxVisibility = Visibility.Visible;
            MessageToShow = msgToShow;
            MessageType = msgType;
            RaiseChanged();
        }
        public void HideMessageBox()
        {
            MessageBoxVisibility = Visibility.Hidden;
            RaiseChanged();
        }

        private void RaiseChanged()
        {
            MessageInfoChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
