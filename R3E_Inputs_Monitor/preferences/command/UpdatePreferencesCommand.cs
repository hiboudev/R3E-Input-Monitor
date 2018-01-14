using da2mvc.core.command;
using da2mvc.core.events;
using R3E_Inputs_Monitor.preferences.events;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.command
{
    class UpdatePreferencesCommand : ICommand, IEventDispatcher
    {

        public event EventHandler MvcEventHandler;
        public static readonly int EVENT_PREFERENCES_UPDATED = EventId.New();
        private readonly PreferencesChangeEventArgs args;
        private readonly PreferencesModel preferences;

        public UpdatePreferencesCommand(PreferencesChangeEventArgs args, PreferencesModel preferences)
        {
            this.args = args;
            this.preferences = preferences;
        }

        public void Execute()
        {
            //preferences.GaugeThickness = args.GaugeThickness;
            preferences.ShowGauges = args.ShowGauges;
            Properties.Settings.Default.showGauges = (int)args.ShowGauges;
            Properties.Settings.Default.Save();
            //preferences.ShowWheel = args.ShowWheel;
            //preferences.WheelPosition = args.WheelPosition;
            //preferences.WheelSize = args.WheelSize;

            DispatchEvent(new BaseEventArgs(EVENT_PREFERENCES_UPDATED));
        }

        public void DispatchEvent(BaseEventArgs args)
        {
            MvcEventHandler?.Invoke(this, args);
        }
    }
}
