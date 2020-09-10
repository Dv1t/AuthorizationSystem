using System;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CustomControls
{
    public class WheelControl : Button
    {
        private DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private RotateTransform _rotationAngle;
        private Ellipse _wheel;
        public static DependencyProperty WheelValueProperty = DependencyProperty.Register("WheelValue", typeof(double), typeof(WheelControl),
            new PropertyMetadata(0.0));
        public double WheelValue
        {
            get => (double)GetValue(WheelValueProperty);
            set => SetValue(WheelValueProperty,value);
        }

        public RoutedEvent WheelRotatedEvent = EventManager.RegisterRoutedEvent("WheelRotated", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<double>), typeof(WheelControl));
        public event RoutedPropertyChangedEventHandler<double> WheelRotated
        {
            add
            {
                AddHandler(WheelRotatedEvent, value);
            }
            remove
            {
                RemoveHandler(WheelRotatedEvent, value);
            }
        }
        static WheelControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WheelControl), new FrameworkPropertyMetadata(typeof(WheelControl)));
        }

        public override void OnApplyTemplate()
        {
            _rotationAngle = Template.FindName("RotationAngle",this) as RotateTransform;
            _wheel = Template.FindName("Center", this) as Ellipse;
            _dispatcherTimer.Interval = new TimeSpan(1);
            _dispatcherTimer.Tick += (s, d) => UpdateWheelValue();
            base.OnApplyTemplate();
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            _dispatcherTimer.Start();
            UpdateRotation();
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            _dispatcherTimer.Stop();
            base.OnMouseUp(e);
        }
        private void UpdateWheelValue()
        {
            _rotationAngle.Angle = Math.Atan2(Mouse.GetPosition(_wheel).Y, Mouse.GetPosition(_wheel).X) * 57.2958 +90;               
            WheelValue = ((_rotationAngle.Angle>0)? _rotationAngle.Angle:360+_rotationAngle.Angle)/3.6;      
            RaiseEvent(new RoutedPropertyChangedEventArgs<double>(0, WheelValue,WheelRotatedEvent));
        }

        private void UpdateRotation()
        {
            //_rotationAngle.Angle = WheelValue * 3.6 + 90;
        }

    }
}
