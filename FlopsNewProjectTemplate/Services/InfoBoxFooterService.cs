using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlopsNewProjectTemplate.Services
{
    public enum FooterMsgType
    {
        Positive,
        Error,
        Neutral,
        Warning
    }
    public class InfoBoxFooterService
    {
        public string MessageToShow { get; set; }

    }
}
