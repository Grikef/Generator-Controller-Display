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

namespace Monitor.pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class tabl2 : Page
    {
        public tabl2(string l1, string l2, string l3, string l4, string s1, string s2, string s3, string s4)
        {
            InitializeComponent();
            print(l1, 0, 0);
            print(l2, 0, 1);
            print(l3, 0, 2);
            print(l4, 0, 3);
            string a1 = GetRandom().ToString() + "," + GetRandomDouble().ToString();
            string b1 = GetRandom().ToString() + "," + GetRandomDouble().ToString();
            string c1 = GetRandom().ToString() + "," + GetRandomDouble().ToString();
            print(a1 + " " + s1, 1, 0);
            print(b1 + " " + s2, 1, 1);
            print(c1 + " " + s3, 1, 2);

            double a11 = Convert.ToDouble(a1);
            double b11 = Convert.ToDouble(b1);
            double c11 = Convert.ToDouble(c1);

            print(Sum(a11, b11, c11).ToString() + " " + s4, 1, 3);
        }
        private int GetRandom()
        {
            Random random = new Random();
            return random.Next(0, 1000);         
        }
        private int GetRandomDouble()
        {
            Random random = new Random();
            return random.Next(0,100);
        }
        private double Sum(double a, double b, double c)
        {
            return Math.Round(a + b + c, 2);
        }
        private void print(string text, int row, int column)
        {
            Label label1 = new Label();
            label1.Content = text;
            label1.HorizontalAlignment = HorizontalAlignment.Center;
            label1.VerticalAlignment = VerticalAlignment.Center;
            label1.FontSize = 14;
            
            Grid.SetRow(label1, row);
            Grid.SetColumn(label1, column);
            grid.Children.Add(label1);
        }
    }
}
