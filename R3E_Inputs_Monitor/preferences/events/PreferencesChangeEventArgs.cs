using da2mvc.core.events;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.events
{
    class PreferencesChangeEventArgs : BaseEventArgs
    {
        public PreferencesChangeEventArgs(int eventId, GaugeType showGauges, bool alwaysOnTop) : base(eventId)
        {
            ShowGauges = showGauges;
            AlwaysOnTop = alwaysOnTop;
        }

        public GaugeType ShowGauges { get; }
        public bool AlwaysOnTop { get; }
    }
}
