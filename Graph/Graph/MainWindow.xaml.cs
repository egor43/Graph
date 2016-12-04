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

namespace Graph
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public struct Points
        {
            public double x;
            public double y;

            public Points (double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public enum TypePoint
        {
            One,
            Two,
            Three,
        }

        public double Gx=50, Gy=50;
        public double GGG = 0;
        public List<Points> list_of_points = new List<Points>();

        public MainWindow()
        {
            InitializeComponent();
            Print(Gx, Gy);
            PrintLine(list_of_points);
        }

        public void Print(double x, double y, int count=0, double z=400, TypePoint point_type=TypePoint.One)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.HorizontalAlignment = HorizontalAlignment.Left;
            ellipse.VerticalAlignment = VerticalAlignment.Top;
            ellipse.Margin=new Thickness(x,y,0,0);
            ellipse.Height = 15;
            ellipse.Width = 15;
            ellipse.Fill = Brushes.Red;
            list_of_points.Add(new Points(x+7,y+7));
            Grid.Children.Add(ellipse);
            if(count<GGG)
            {
                switch (point_type)
                {
                    case TypePoint.One:
                        point_type = TypePoint.Two;
                        count++;
                        Gx = x;
                        Gy = y;
                        Print(x, y+z, count,z, point_type);
                        break;

                    case TypePoint.Two:
                        point_type = TypePoint.Three;
                        count++;
                        Print(x+z, y - z/2, count,z, point_type);
                        break;

                    case TypePoint.Three:
                        point_type = TypePoint.One;
                        x =Gx+Gx*0.8;//0.4
                        y = Gy+Gy*(3.4/count++);//1.7
                        z = z / 1.8;//1.8
                        Print(x, y, count,z, point_type);
                        break;
                }
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(GGG != (int)slider.Value)
            {
                GGG = (int)slider.Value;
                Grid.Children.Clear();
                list_of_points.Clear();
                Gx = 50;
                Gy = 50;
                Print(Gx, Gy);
                PrintLine(list_of_points);
            }
        }

        public void PrintLine(List<Points> lst)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    if(j!=i)
                    {
                        Line line = new Line();
                        line.X1 = lst[i].x;
                        line.Y1 = lst[i].y;
                        line.X2 = lst[j].x;
                        line.Y2 = lst[j].y;
                        line.Stroke = Brushes.Black;
                        Grid.Children.Add(line);
                    }
                }
            }
        }

    }
}
