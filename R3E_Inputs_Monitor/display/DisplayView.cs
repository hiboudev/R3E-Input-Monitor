using da2mvc.core.view;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace R3E_Inputs_Monitor.display
{
    public class DisplayView : FrameworkElement, IView
    {
        private SolidColorBrush throttleBrush;
        private SolidColorBrush brakeBrush;
        private SolidColorBrush clutchBrush;
        private float clutch;
        private float brake;
        private float throttle;
        private Size previousSize;
        private int previousFullWidth = 0;
        private readonly PreferencesModel preferences;

        public event EventHandler Disposed;

        public DisplayView(PreferencesModel preferences)
        {
            this.preferences = preferences;
            InitBrushes();
        }

        public void SetValues(Single clutch, Single brake, Single throttle)
        {
            this.clutch = clutch == -1 ? 0 : clutch;
            this.brake = brake == -1 ? 0 : brake;
            this.throttle = throttle == -1 ? 0 : throttle;
            InvalidateVisual();
        }

        private void InitBrushes()
        {
            clutchBrush = new SolidColorBrush(Colors.Blue);
            brakeBrush = new SolidColorBrush(Colors.Red);
            throttleBrush = new SolidColorBrush(Colors.Green);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(new SolidColorBrush(Colors.Black), null, new Rect(0, 0, 30 * 3, RenderSize.Height)); // TODO dessiner à la bonne dimension

            double clutchHeight = clutch * RenderSize.Height;
            double brakeHeight = brake * RenderSize.Height;
            double throttleHeight = throttle * RenderSize.Height;

            int fullWidth = 0;

            if (preferences.ShowGauges.HasFlag(GaugeType.CLUTCH))
            {
                drawingContext.DrawRectangle(clutchBrush, null, new Rect(fullWidth, RenderSize.Height - clutchHeight, preferences.GaugeThickness, clutchHeight));
                fullWidth += preferences.GaugeThickness;
            }

            if (preferences.ShowGauges.HasFlag(GaugeType.BRAKE))
            {
                drawingContext.DrawRectangle(brakeBrush, null, new Rect(fullWidth, RenderSize.Height - brakeHeight, preferences.GaugeThickness, brakeHeight));
                fullWidth += preferences.GaugeThickness;
            }

            if (preferences.ShowGauges.HasFlag(GaugeType.THROTTLE))
            {
                drawingContext.DrawRectangle(throttleBrush, null, new Rect(fullWidth, RenderSize.Height - throttleHeight, preferences.GaugeThickness, throttleHeight));
                fullWidth += preferences.GaugeThickness;
            }

            if(fullWidth != previousFullWidth)
                InvalidateMeasure();
            previousFullWidth = fullWidth;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(previousFullWidth, RenderSize.Height);
        }

        public void Dispose()
        {
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }
}
