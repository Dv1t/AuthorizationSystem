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
using CustomControls;

namespace UserApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void WheelControl_WheelRotated(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlock.Text = e.NewValue.ToString();
        }

        //private void CustomControl1_OnTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime> e)
        //{
        //    TextBlock.Text = e.NewValue.ToString("hh:mm:ss");
        //}
    }
}
