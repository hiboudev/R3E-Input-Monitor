using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.model
{
    [Flags]
    public enum GaugeType
    {
        CLUTCH = 1,
        BRAKE = 2,
        THROTTLE = 4,
    }
}
