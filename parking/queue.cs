using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace parking
{
    class queue
    {
        #region fiead
        public node start { private set; get; }
        public node end { private set; get; }
        public int size { private set; get; }
        public int capacity { private set; get; }
        #endregion

        public queue(int s = 20)
        {
            start = null;
            end = null;
            size = s;
            capacity = 0;
        }

        public bool addq(Car c)
        {
            if (isfull())
            {
                return false;
            }
            else
            {
                node newnode = new node(); // creat a new node
                newnode.car = c; // creat a new car in node
                newnode.next = null; // set 
                if (isempty())
                {
                    start = newnode;
                    end = newnode;
                }
                else
                {
                    end.next = newnode;
                    end = end.next;
                }
                capacity++;
                return true;
            }
        }

        public Car delq()
        {
            if (isempty())
            {
                return new Car(Brushes.White, "nocar");
            }
            else
            {
                node ntemp = start; // ????
                //  Car ctemp = new Car(start.car.colorCar.Fill, start.car.number);
                Car ctemp = start.car;
                start = start.next;
                ntemp.next = null; //  ????
                ntemp = null;      //   ???

                if (capacity == 1)
                {
                    end = null;
                }
                capacity = capacity - 1;
                return ctemp;
            }
        }



        public bool isfull()
        {
            if (capacity == size)
            {
                return true;
            }
            else
                return false;
        }
        public bool isempty()
        {
            if (capacity == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
