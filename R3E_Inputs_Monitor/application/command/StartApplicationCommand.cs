using da2mvc.core.command;
using da2mvc.core.injection;
using R3E_Inputs_Monitor.r3e.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.application.command
{
    class StartApplicationCommand : ICommand
    {
        public void Execute()
        {
            Injector.ExecuteCommand<StartSocketCommand>();
        }
    }
}
