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
        public PreferencesChangeEventArgs(int eventId, int gaugeThickness, GaugeType showGauges, bool showWheel, WheelPositionType wheelPosition, int wheelSize) : base(eventId)
        {
            GaugeThickness = gaugeThickness;
            ShowGauges = showGauges;
            ShowWheel = showWheel;
            WheelPosition = wheelPosition;
            WheelSize = wheelSize;
        }

        public int GaugeThickness { get; }
        public GaugeType ShowGauges { get; }
        public bool ShowWheel { get; }
        public WheelPositionType WheelPosition { get; }
        public int WheelSize { get; }
    }
}
