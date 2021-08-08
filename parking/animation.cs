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

namespace parking
{
    public class animationa
    {
        static int i = 0;
        static int s1 = 0;
        static int s2 = 0;
        static int st = 0;
        int type;
        Grid grid;
        Canvas can;
        Car car;
        
        public animationa(ref Car c,int t)
        {
            car = c;
            grid = parking.MainWindow.g;
            can = parking.MainWindow.c;
            type =t;

        }


        public void play()
        {
            switch (type)
            {
                case 0: 
                    gAddCarToEntrance();
                    break;
                case 1:
                    gEntranceUpdate();
                    break;
                case 2:
                    gEntranceToStak1();
                    break;
                case 3:
                    gEntranceToStak2();
                    break;
                case 4:
                    gStak1ToStaktemp();
                    break;
                case 5:
                    gStak2ToStaktemp();
                    break;
                case 6:
                    gStaktempToStak1();
                    break;
                case 7:
                    gStaktempToStak2();
                    break;
                case 8:
                    gStak1ToOut();
                    break;
                case 9:
                    gStak2ToOut();
                    break;
                case 10:
                    start();
                    break;
                default:
                    break;
            }
        }


        public void start()
        {
            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            can.Children.Add(car);
            car.Visibility = Visibility.Hidden;
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(1000, 1000);
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(1000, 1001) };


            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);

            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);

        }

        public void gAddCarToEntrance()
        {
            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            can.Children.Add(car);
            //Point relativePoint = car.TransformToAncestor(grid)
            //               .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(20, 15);
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(610 - i, 15) };


            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);
            i = i + 30;

            //Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);

            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);

        }//1
        public void gEntranceUpdate()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(relativePoint.X + 30, 15) };

            i = i - 30;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);

           
        }//1
        public void gEntranceToStak1()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(relativePoint.X+30, 15),
                          new Point(relativePoint.X+30, 230),
                          new Point(relativePoint.X, 230),
                          new Point(400, 242),
                          new Point(380, 262),
                          new Point(380, 262),
                          new Point(597-s1, 473-s1),
            };

            s1 = s1 + 23;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }//1
        public void gEntranceToStak2()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(relativePoint.X+30, 15),
                          new Point(relativePoint.X+30, 230),
                          new Point(relativePoint.X, 230),
                          new Point(400, 242),
                          new Point(380, 262),
                          new Point(333, 270),
                          new Point(107+s2, 483-s2)
            };

            s2 = s2 + 22;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }//1

        public void gStak1ToStaktemp()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] {
               new Point(380, 270),
                 new Point(353, 280),
                 new Point(353, 550-st),
            };

            s1 = s1 - 23;
            st = st + 32;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }//1

        public void gStak2ToStaktemp()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] {
                 new Point(333, 270),
                 new Point(353, 280),
                 new Point(353, 550-st),

            };

            s2 = s2 - 22;
            st = st + 30;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }//1

        public void gStaktempToStak1()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { 
               new Point(353, 280),
               new Point(380, 270),
                new Point(380, 262),
                new Point(597-s1, 473-s1),
            };

            s1 = s1 + 22;
            st = st - 30;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }

        public void gStaktempToStak2()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] {
             
                 new Point(333, 270),
                 new Point(107+s2, 483-s2)
            };

            s2 = s2 + 22;
            st = st - 30;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }

        public void gStak1ToOut()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;
            
            polyLinePointArray =
            new Point[] {

                 new Point(380, 270),
                 new Point(350, 280),
                 new Point(320, 270),
                 new Point(320, 240),
                 new Point(100, 240),
                 new Point(75, 215),
                 new Point(50, 190),
                 new Point(30, 190),
                 new Point(30, 70),

            };

            s1 = s1 - 22;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }

        public void gStak2ToOut()
        {

            MatrixTransform carMatrixTransform = new MatrixTransform();
            car.RenderTransform = carMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = car.TransformToAncestor(grid)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] {
                 new Point(320, 270),
                 new Point(320, 240),
                 new Point(100, 240),
                 new Point(75, 215),
                 new Point(50, 190),
                 new Point(30, 190),
                 new Point(30, 70),

            };

            s2 = s2 - 23;
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;
            matrixAnimation.FillBehavior = FillBehavior.HoldEnd;
            matrixAnimation.Completed += new EventHandler(Complete);
            carMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);


        }

        public void gEntranceTostak(ref Car c,Grid g,int s)
        {
            MatrixTransform carMatrixTransform = new MatrixTransform();
            c.RenderTransform = carMatrixTransform;
            Point relativePoint = c.TransformToAncestor(g)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;
            if (s == 1)
            {
                polyLinePointArray =
            new Point[] { relativePoint };
            }
            if (s == 2)
            {
                polyLinePointArray =
           new Point[] { new Point(relativePoint.X, 200) };
            }
            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure2);
            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;

            //buttonMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);
            matrixAnimation.Completed += new EventHandler(Complete);
        }


        public void gEntranceUpdate(ref Car c,ref Grid g)
        {

            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            c.RenderTransform = buttonMatrixTransform;
            //AnamationBoard.Children.Add(temp.car);
            Point relativePoint = c.TransformToAncestor(g)
                           .Transform(new Point(0, 0));

            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = relativePoint;
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(relativePoint.X + 30, 15) };


            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure2);

            //Freeze the PathGeometry for performance benefits.
            //animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;

            //buttonMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);
            matrixAnimation.Completed += new EventHandler(Complete);
        }

        public void gAddCarToEntrance(ref Car c,ref Canvas g)
        {
            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            c.RenderTransform = buttonMatrixTransform;
            g.Children.Add(c);
            // Create another figure.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pathFigure2 = new PathFigure();
            pathFigure2.StartPoint = new Point(20, 15);
            Point[] polyLinePointArray = null;

            polyLinePointArray =
            new Point[] { new Point(610 - i, 15) };


            PolyLineSegment myPolyLineSegment = new PolyLineSegment();
            myPolyLineSegment.Points =
                new PointCollection(polyLinePointArray);
            pathFigure2.Segments.Add(myPolyLineSegment);

            animationPath.Figures.Add(pathFigure2);
            i = i + 30;

            //Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;
            matrixAnimation.Duration = TimeSpan.FromSeconds(1);

            matrixAnimation.DoesRotateWithTangent = true;

            //buttonMatrixTransform.BeginAnimation(MatrixTransform.MatrixProperty, matrixAnimation);
            matrixAnimation.Completed += new EventHandler(Complete);
        }

       
        void Complete(object sender, EventArgs e)
        {
            if (parking.MainWindow.animq.Count() != 0)
            {
                parking.MainWindow.animq.Dequeue().play();
                if (parking.MainWindow.animq.Count() == 0)
                {

                }
            }
        }
    }
}
