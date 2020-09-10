using System;
using System.Collections.Generic;
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
    public class CustomControl1 : Control
    {
        private Line _hourHand;
        private Line _minuteHand;
        private Line _secondHand;

        public static DependencyProperty ShowSecondsProperty = DependencyProperty.Register("ShowSeconds",typeof(bool),typeof(CustomControl1),new PropertyMetadata(true)); 
        public bool ShowSeconds
        {
            get => (bool)GetValue(ShowSecondsProperty);
            set => SetValue(ShowSecondsProperty,value);
        }

        //public delegate void TimeChangeEventHandler(object sender, TimeChangedEventArgs args);
        public RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent("TimeChanged", RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<DateTime>), typeof(CustomControl1));
        public event RoutedPropertyChangedEventHandler<DateTime> TimeChanged
        {
            add
            {
                AddHandler(TimeChangedEvent,value);
            }
            remove
            {
                RemoveHandler(TimeChangedEvent,value);
            }
        }

        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
        public override void OnApplyTemplate()
        {
            _hourHand = Template.FindName("PartHourHand", this) as Line;
            _minuteHand = Template.FindName("PartMinuteHand", this) as Line;
            _secondHand = Template.FindName("PartSecondHand",this) as Line;

            //Binding showSecondsBinding = new Binding{
            //Path = new PropertyPath(nameof(ShowSeconds)),
            //Source = this,
            //Converter = new BooleanToVisibilityConverter()
            //};

            //_secondHand.SetBinding(VisibilityProperty,showSecondsBinding);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval=new TimeSpan(0,0,1);
            timer.Tick +=(s,e)=> OnTimeChange(DateTime.Now);
            timer.Start();

            base.OnApplyTemplate();
        }

        protected virtual void OnTimeChange(DateTime time)
        {
            UpdateHandAngles(time);
            RaiseEvent(new RoutedPropertyChangedEventArgs<DateTime>(DateTime.MinValue, time,TimeChangedEvent));
        }

        private void UpdateHandAngles(DateTime time)
        {
            _hourHand.RenderTransform = new RotateTransform((time.Hour / 12.0 )* 360, 0.5, 0.5);
            _minuteHand.RenderTransform = new RotateTransform((time.Minute / 60.0) * 360, 0.5, 0.5);
            _secondHand.RenderTransform = new RotateTransform((time.Second / 60.0) * 360, 0.5, 0.5);
        }
    }
   
}
