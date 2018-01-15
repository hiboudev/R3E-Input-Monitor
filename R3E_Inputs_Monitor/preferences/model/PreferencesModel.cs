using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.model
{
    public class PreferencesModel
    {
        public GaugeType ShowGauges { get; set; } = GaugeType.CLUTCH | GaugeType.BRAKE | GaugeType.THROTTLE;
        public bool AlwaysOnTop { get; set; } = false;
    }
}
