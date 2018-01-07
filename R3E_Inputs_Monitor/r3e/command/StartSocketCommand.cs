using da2mvc.core.command;
using R3E_Inputs_Monitor.r3e.socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.r3e.command
{
    class StartSocketCommand : ICommand
    {
        private readonly R3eApiSocket socket;

        public StartSocketCommand(R3eApiSocket socket)
        {
            this.socket = socket;
        }

        public void Execute()
        {
            socket.Connect();
        }
    }
}
