using da2mvc.core.command;
using R3E_Inputs_Monitor.preferences.events;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.command
{
    class UpdatePreferencesCommand : ICommand
    {
        private readonly PreferencesChangeEventArgs args;
        private readonly PreferencesModel preferences;

        public UpdatePreferencesCommand(PreferencesChangeEventArgs args, PreferencesModel preferences)
        {
            this.args = args;
            this.preferences = preferences;
        }

        public void Execute()
        {
            preferences.GaugeThickness = args.GaugeThickness;
            preferences.ShowGauges = args.ShowGauges;
            preferences.ShowWheel = args.ShowWheel;
            preferences.WheelPosition = args.WheelPosition;
            preferences.WheelSize = args.WheelSize;
        }
    }
}
