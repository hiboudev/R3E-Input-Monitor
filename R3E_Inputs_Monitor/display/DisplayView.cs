using da2mvc.core.view;
using R3E_Inputs_Monitor.preferences.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace R3E_Inputs_Monitor.display
{
    public class DisplayView : FrameworkElement, IView
    {
        private SolidColorBrush throttleBrush;
        private SolidColorBrush brakeBrush;
        private SolidColorBrush clutchBrush;
        private float clutch = .5f;
        private float brake = .5f;
        private float throttle = .5f;
        //private BitmapSource wheel;
        private readonly PreferencesModel preferences;

        public event EventHandler Disposed;

        public DisplayView(PreferencesModel preferences)
        {
            this.preferences = preferences;
            InitBrushes();
            //PrepareWheelBitmap();
        }

        //private void PrepareWheelBitmap()
        //{
        //    Debug.WriteLine("Preparing wheel bitmap");

        //    BitmapImage source = new BitmapImage(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"_graphical_assets\wheel.png")));

        //    double sourceRatio = (double)source.PixelWidth / source.PixelHeight;
        //    Size newSize = new Size(preferences.WheelSize, (int)(preferences.WheelSize / sourceRatio));

        //    var group = new DrawingGroup();
        //    RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
        //    group.Children.Add(new ImageDrawing(source, new Rect(new Point(), newSize)));

        //    var drawingVisual = new DrawingVisual();
        //    using (var drawingContext = drawingVisual.RenderOpen())
        //    {
        //        drawingContext.DrawDrawing(group);
        //    }

        //    var resizedImage = new RenderTargetBitmap(
        //        (int)newSize.Width, (int)newSize.Height,
        //        source.DpiX, source.DpiY, PixelFormats.Default);

        //    resizedImage.Render(drawingVisual);

        //    wheel = resizedImage;
        //}

        public void SetValues(Single clutch, Single brake, Single throttle)
        {
            this.clutch = clutch == -1 ? 0 : clutch;
            this.brake = brake == -1 ? 0 : brake;
            this.throttle = throttle == -1 ? 0 : throttle;

            //if (preferences.WheelSize != wheel.PixelWidth)
            //    PrepareWheelBitmap();

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

            double clutchHeight = clutch * RenderSize.Height;
            double brakeHeight = brake * RenderSize.Height;
            double throttleHeight = throttle * RenderSize.Height;
            double gaugeX = 0;
            int numGauges = 0;

            foreach (GaugeType enumValue in Enum.GetValues(typeof(GaugeType)))
            {
                if (preferences.ShowGauges.HasFlag(enumValue))
                    numGauges++;
            }

            double gaugeThickness = numGauges == 0 ? numGauges : RenderSize.Width / numGauges;

            drawingContext.DrawRectangle(new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)), null, new Rect(0, 0, RenderSize.Width, RenderSize.Height));
            
            if (preferences.ShowGauges.HasFlag(GaugeType.CLUTCH))
            {
                drawingContext.DrawRectangle(clutchBrush, null, new Rect(gaugeX, RenderSize.Height - clutchHeight, gaugeThickness, clutchHeight));
                gaugeX += gaugeThickness;
            }

            if (preferences.ShowGauges.HasFlag(GaugeType.BRAKE))
            {
                drawingContext.DrawRectangle(brakeBrush, null, new Rect(gaugeX, RenderSize.Height - brakeHeight, gaugeThickness, brakeHeight));
                gaugeX += gaugeThickness;
            }

            if (preferences.ShowGauges.HasFlag(GaugeType.THROTTLE))
            {
                drawingContext.DrawRectangle(throttleBrush, null, new Rect(gaugeX, RenderSize.Height - throttleHeight, gaugeThickness, throttleHeight));
            }
            
            //drawingContext.DrawImage(wheel, new Rect(0, 0, wheel.PixelWidth, wheel.PixelHeight));
        }

        public void Dispose()
        {
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }
}
