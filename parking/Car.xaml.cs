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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace parking
{
    /// <summary>
    /// Interaction logic for Car.xaml
    /// </summary>
    public partial class Car : UserControl
    {
        public string number { private set; get; }
        public Car()
        {

        }
        public Car(Brush c, string n)
        {
            InitializeComponent();

            this.colorCar.Fill = c;
            this.number = n;
        }

        private void pelak_MouseEnter(object sender, MouseEventArgs e)
        {
            System.Windows.Shapes.Path path = (System.Windows.Shapes.Path)System.Windows.Markup.XamlReader.Parse("<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'  Fill='#FFF4F4F5'   Stretch='Fill' Stroke='Black'   Data='M80,160 C79.499746,159.5 79.5,139.5 99.5,139.5 119.5,139.5 159.50042,139.5 159.50042,139.5 159.50042,139.5 179.50057,139.5 179.50057,159.5 179.50057,179.5 159.50042,179.5 159.50042,179.5 L119.50014,179.5 109.50007,199.5 99.500001,179.5 C99.500001,179.5 80.50014,180.5 80,160 z' />");
            path.Width = 50;
            path.Height = 30;
            Canvas.SetBottom(path, 0);
            Canvas.SetLeft(path, -2);
            pelak.Children.Add(path);
            TextBlock p = new TextBlock();
            p.Text = number;
            Canvas.SetBottom(p, 13);
            Canvas.SetLeft(p, 11);
            p.FontSize = 12;
            pelak.Children.Add(p);


        }

        private void pelak_MouseLeave(object sender, MouseEventArgs e)
        {
            pelak.Children.RemoveRange(2, 2);
        }

    }
}
