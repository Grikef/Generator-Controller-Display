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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class tabl1 : Page
    {
        public tabl1(string l1, string l2, string l3, string s)
        {
            InitializeComponent();

            a(l1, 0, 0);
            a(l2, 0, 1);
            a(l3, 0, 2);
            
            a(GetRandom().ToString()+","+ GetRandomDouble().ToString() +" "+s, 1, 0);
            a(GetRandom().ToString() + "," + GetRandomDouble().ToString() + " " + s , 1, 1);
            a(GetRandom().ToString() + "," + GetRandomDouble().ToString() + " " + s, 1, 2);
        }
        private int GetRandom()
        {
            Random random = new Random();
            return random.Next(0,1000);
        }
        private int GetRandomDouble()
        {
            Random random = new Random();
            return random.Next(0, 100);
        }
        private void a(string text, int row, int column)
        {
            Label label1 = new Label();
            label1.Content = text;
            label1.HorizontalAlignment = HorizontalAlignment.Center;
            label1.VerticalAlignment = VerticalAlignment.Center;
            label1.HorizontalContentAlignment = HorizontalAlignment.Center;
            label1.FontSize = 14;
            Grid.SetRow(label1, row);
            Grid.SetColumn(label1, column);
            grid.Children.Add(label1);
        }
    }
}


