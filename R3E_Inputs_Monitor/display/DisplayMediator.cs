using da2mvc.core.view;
using R3E_Inputs_Monitor.r3e.events;
using R3E_Inputs_Monitor.r3e.socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.display
{
    class DisplayMediator : BaseMediator<DisplayView>
    {
        public DisplayMediator()
        {
            HandleEvent<R3eApiSocket, SocketEventArgs>(R3eApiSocket.EVENT_DATA_UPDATED, SocketDataUpdated);
        }

        private void SocketDataUpdated(SocketEventArgs args)
        {
            View.SetValues(args.Socket.Data.ClutchPedal,
                args.Socket.Data.BrakePedal,
                args.Socket.Data.ThrottlePedal);
        }
    }
}
