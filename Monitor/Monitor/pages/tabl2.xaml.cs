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



            a(l1, 0, 0);
            a(l2, 0, 1);
            a(l3, 0, 2);
            a(l4, 0, 3);
            string a1 = GetRandomSpeed().ToString();
            string b1 = GetRandomSpeed().ToString();
            string c1 = GetRandomSpeed().ToString();
            a(a1 +" " + s1, 1, 0);
            a(b1+" "+ s2, 1, 1);
            a(c1+ " "+ s3, 1, 2);

            int a11 = Convert.ToInt32(a1);
            int b11 = Convert.ToInt32(b1);
            int c11 = Convert.ToInt32(c1);

            a(Sum(a11, b11, c11).ToString()+" "+s4, 1, 3);

        }
        private int GetRandomSpeed()
        {
            // Генерируем случайное значение скорости для демонстрации (правило нормального распределения)
            Random random = new Random();

            return random.Next(0, 300);
           
        }

    

            private int Sum(int a, int b, int c)
            {
                return a + b + c;
            }

            private void a(string text, int row, int column)
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
