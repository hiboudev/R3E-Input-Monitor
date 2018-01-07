using da2mvc.core.command;
using R3E_Inputs_Monitor.preferences.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.command
{
    class OpenPreferencesCommand : ICommand
    {
        private readonly PreferencesView view;

        public OpenPreferencesCommand(PreferencesView view)
        {
            this.view = view;
        }

        public void Execute()
        {
            if (view.ShowDialog() == true)
            {

            }
        }
    }
}
