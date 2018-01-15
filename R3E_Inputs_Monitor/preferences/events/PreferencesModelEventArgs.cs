using da2mvc.core.events;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.events
{
    class PreferencesModelEventArgs : BaseEventArgs
    {
        public PreferencesModelEventArgs(int eventId, PreferencesModel preferences) : base(eventId)
        {
            Preferences = preferences;
        }

        public PreferencesModel Preferences { get; }
    }
}
