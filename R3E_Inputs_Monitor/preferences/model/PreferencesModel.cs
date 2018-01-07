using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3E_Inputs_Monitor.preferences.model
{
    public class PreferencesModel
    {
        private int gaugeThickness = 10;
        private GaugeType showGauges = GaugeType.CLUTCH | GaugeType.BRAKE | GaugeType.THROTTLE;
        private bool showWheel = true;
        private WheelPositionType wheelPosition = WheelPositionType.CENTER;
        private int wheelSize = 30;

        public int GaugeThickness { get => gaugeThickness; set => gaugeThickness = value; }
        public GaugeType ShowGauges { get => showGauges; set => showGauges = value; }
        public bool ShowWheel { get => showWheel; set => showWheel = value; }
        public WheelPositionType WheelPosition { get => wheelPosition; set => wheelPosition = value; }
        public int WheelSize { get => wheelSize; set => wheelSize = value; }
    }
}
