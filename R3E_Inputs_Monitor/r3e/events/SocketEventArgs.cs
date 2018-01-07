using da2mvc.core.events;
using R3E_Inputs_Monitor.r3e.socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.r3e.events
{
    class SocketEventArgs : BaseEventArgs
    {
        public SocketEventArgs(int eventId, R3eApiSocket socket) : base(eventId)
        {
            Socket = socket;
        }

        public R3eApiSocket Socket { get; }
    }
}
