using da2mvc.core.events;
using da2mvc.framework.application.view;
using R3E_Inputs_Monitor.preferences.events;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace R3E_Inputs_Monitor.preferences.view
{
    /// <summary>
    /// Logique d'interaction pour PreferencesView.xaml
    /// </summary>
    public partial class PreferencesView : ModalWindow, IEventDispatcher
    {
        public event EventHandler MvcEventHandler;
        public static readonly int EVENT_PREFERENCES_CHANGED = EventId.New();

        public PreferencesView(PreferencesModel model)
        {
            InitializeComponent();
            InitializeUI(model);
        }

        private void InitializeUI(PreferencesModel model)
        {
            //foreach (WheelPositionType enumValue in Enum.GetValues(typeof(WheelPositionType)))
            //{
            //    ComboBoxItem item = new ComboBoxItem()
            //    {
            //        Content = Enum.GetName(typeof(WheelPositionType), enumValue),
            //        Tag = enumValue,
            //        IsSelected = model.WheelPosition == enumValue,
            //    };
            //    wheelPosition.Items.Add(item);
            //}
            //wheelPosition.UpdateLayout();
            showClutch.IsChecked = model.ShowGauges.HasFlag(GaugeType.CLUTCH);
            showBrake.IsChecked = model.ShowGauges.HasFlag(GaugeType.BRAKE);
            showThrottle.IsChecked = model.ShowGauges.HasFlag(GaugeType.THROTTLE);

            //showWheel.IsChecked = model.ShowWheel;

            //gaugeThickness.Value = model.GaugeThickness;
            //wheelSize.Value = model.WheelSize;

            okButton.Click += OkClickHandler;
        }

        private void OkClickHandler(object sender, RoutedEventArgs e)
        {
            GaugeType gauges = (showClutch.IsChecked == true ? GaugeType.CLUTCH : 0)
                | (showBrake.IsChecked == true ? GaugeType.BRAKE : 0)
                | (showThrottle.IsChecked == true ? GaugeType.THROTTLE : 0);

            //WheelPositionType wheelPositionType = (WheelPositionType)(wheelPosition.SelectedItem as ComboBoxItem).Tag;

            var args = new PreferencesChangeEventArgs(EVENT_PREFERENCES_CHANGED,gauges/*, showWheel.IsChecked == true, wheelPositionType, (int)wheelSize.Value*/);

            DispatchEvent(args);
            DialogResult = true;
        }

        public void DispatchEvent(BaseEventArgs args)
        {
            MvcEventHandler?.Invoke(this, args);
        }
    }
}
