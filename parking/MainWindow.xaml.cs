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
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace parking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region field
        private queue entrance ;
        private stack p1;
        private stack p2;
        private stack pTemp;
        public static int i = 0;
        public static Queue<animationa> animq = new Queue<animationa>();
        public static Canvas c ;
        public static Grid g;
        
        //DoubleAnimation carAnimation = new DoubleAnimation();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            entrance = new queue(20);
            p1 = new stack(10);
            p2 = new stack(10);
            pTemp = new stack(10);
            c = AnimationBoard;
            g = g_parking;
        }
        
        public bool addCarToEntrance(Brush c,string n)
        {
            node temp = entrance.start;
            Car newcar = new Car(c, n);
            entrance.addq(newcar);
            animationa a = new animationa(ref entrance.end.car, 0);
            a.play();
            if (entrance.isfull())
                {
                    b_enter.Content = "صف پر شد";
                    b_enter.IsEnabled = false;
                    return false;
                }
            return true;
        }

        public bool addCarToParking()
        {
            Car c;
            while (!(p1.isfull()) & !(entrance.isempty()))
            { 
                c = entrance.delq();
                animq.Enqueue(new animationa(ref c,1));
                p1.push(ref c);
                animq.Enqueue(new animationa(ref c, 2));
                if (entrance.isempty())
                {
                    return true;
                }
            }
            while (!(p2.isfull()) & !(entrance.isempty()))
            {
                c = entrance.delq();
                animq.Enqueue(new animationa(ref c, 1));
                p2.push(ref c);
                animq.Enqueue(new animationa(ref c, 3));
                if (entrance.isempty())
                {
                    return true;
                }
            }
            return false;
        }

        public int deleteCar(string s)
        {
            Car temp;
            Car a = new Car(Brushes.White, "null");
            int i, j;
            i = p1.search(s);
            j = p2.search(s);
            new animationa(ref a, 10).play();
            if ((i > -1))
            {
                for (int k = 0; k < i - 1; k++)
                {
                    temp = p1.pop();
                    pTemp.push(ref temp);
                    animq.Enqueue(new animationa(ref temp, 4));
                }
                temp = p1.pop();
                animq.Enqueue(new animationa(ref temp, 8));
                for (int q = 0; q < i - 1; q++)
                {
                    temp = pTemp.pop();
                    p1.push(ref temp);
                    animq.Enqueue(new animationa(ref temp, 6));
                }
                return i;
            }
            else if ((j > -1))
            {
                for (int k = 0; k < j - 1; k++)
                {
                    temp = p2.pop();
                    pTemp.push(ref temp);
                    animq.Enqueue(new animationa(ref temp, 5));
                }
                temp = p2.pop();
                animq.Enqueue(new animationa(ref temp, 9));
                for (int q = 0; q < j - 1; q++)
                {
                    temp = pTemp.pop();
                    p2.push(ref temp);
                    animq.Enqueue(new animationa(ref temp, 7));
                }
                return j;
            }
            else
                return -1;
        }
        private void b_enter_Click(object sender, RoutedEventArgs e)
        {
            addCarToEntrance(new SolidColorBrush(color_picker.SelectedColor), t_enter_p.Text);
            addCarToParking();
        }
        private void b_exit_Click(object sender, RoutedEventArgs e)
        {

            int a= deleteCar(t_exit_p.Text.ToString());
            if(a>=0)
            {
                addCarToParking();
                if (!entrance.isempty())
                {
                    node temp =entrance.start;
                        for (int i = 0; i < entrance.capacity; i++)
                        {
                        animq.Enqueue(new animationa(ref temp.car, 1));
                        temp = temp.next;
                        }
                }
                b_enter.Content = "ورود";
                b_enter.IsEnabled = true;
            }
            
        }
    }
}

