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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Generator: Page
    {
        public Generator()
        {
            InitializeComponent();

            page1.Content = new tabl1("L1-N", "L2-N", "L3-N", "V");
            page2.Content = new tabl1("L1-2", "L2-3", "L3-1", "V");
            page3.Content = new tabl1("L1", "L2", "L3", "A");
            page4.Content = new tabl3("Частота", "Ток Нейтрали", "Hz", "A");

            page11.Content = new tabl2("L1","L2", "L3", "Всего", "kW", "kW", "kW", "kW");
            page12.Content = new tabl2("L1", "L2", "L3", "Всего", "kVAr", "kVAr", "kVAr", "kVAr");
            page13.Content = new tabl2("L1", "L2", "L3", "Всего", "kVA", "kVA", "kVA", "kVA");
            page14.Content = new tabl2("L1", "L2", "L3", "Всего"," ", " ", " ", " ");
        }
    }
}
