using da2mvc.core.command;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.command
{
    class LoadPreferencesCommand : ICommand
    {
        private readonly PreferencesModel preferences;

        public LoadPreferencesCommand(PreferencesModel preferences)
        {
            this.preferences = preferences;
        }

        public void Execute()
        {
            preferences.ShowGauges = (GaugeType)Properties.Settings.Default.showGauges;
        }
    }
}
