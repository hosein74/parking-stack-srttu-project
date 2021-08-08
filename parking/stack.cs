using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace parking
{
    class stack
    {
        #region fiead
        public node top { private set; get; }
        private int size;
        public int capacity { private set; get; }
        #endregion

        public stack(int s = 10)
        {
            top = null;
            size = s;
            capacity = 0;
        }

        public bool push(ref Car c)
        {
            if (isfull())
            {
                return false;
            }
            else
            {
                node newnode = new node(); // creat a new node
                newnode.car = c; // push car in node no creat it its created in queue
                newnode.next = top; // set 
                top = newnode; // set end of queue
                capacity++;
                return true;
            }
        }

        public Car pop()
        {
            if (isempty())
            {
                return new Car(Brushes.White, "nocar");
            }
            else
            {
                node ntemp = top; // ????
                //  Car ctemp = new Car(start.car.colorCar.Fill, start.car.number);
                Car ctemp = top.car;
                top = top.next;
                ntemp.next = null; //  ????
                ntemp = null;      //   ???
                capacity --;
                return ctemp;
            }
        }


        public int search(string s)
        {
            int i = 0;
            for (node p = top; p != null; p = p.next, i++)
            {
                if (p.car.number == s)
                {
                    return i+1;
                }
            }
            return -1;
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
