using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ShowMessage(string msgToShow,MessageType msgType=MessageType.Neutral) {
            MessageToShow = msgToShow;
            MessageType = msgType;
            MessageInfoChanged?.Invoke(this,EventArgs.Empty);
        }
    }

}
