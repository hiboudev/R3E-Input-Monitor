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
    class LoadPreferencesCommand : ICommand, IEventDispatcher
    {
        public event EventHandler MvcEventHandler;
        public static readonly int EVENT_PREFERENCES_LOADED = EventId.New();
        private readonly PreferencesModel preferences;

        public LoadPreferencesCommand(PreferencesModel preferences)
        {
            this.preferences = preferences;
        }

        public void Execute()
        {
            preferences.ShowGauges = (GaugeType)Properties.Settings.Default.showGauges;
            preferences.AlwaysOnTop = Properties.Settings.Default.alwaysOnTop;
            preferences.Opacity = Properties.Settings.Default.opacity;

            DispatchEvent(new PreferencesModelEventArgs(EVENT_PREFERENCES_LOADED, preferences));
        }

        public void DispatchEvent(BaseEventArgs args)
        {
            MvcEventHandler?.Invoke(this, args);
        }
    }
}
