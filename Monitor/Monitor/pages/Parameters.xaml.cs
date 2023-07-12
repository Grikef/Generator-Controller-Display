using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Monitor.pages
{
    /// <summary>
    /// Логика взаимодействия для Parameters.xaml
    /// </summary>
    public partial class Parameters : Page
    {
        public Parameters()
        {
            InitializeComponent();

            graphic1.Content = new PageWithGraphic("Скорость двигателя",6, 10, 8, 0);
            graphic2.Content = new PageWithGraphic("Давление масла", -100, 200, 150, 1);
            graphic3.Content = new PageWithGraphic("Давление масла", 100, 200, 150, 1);
            graphic4.Content = new PageWithGraphic("Давление масла", 100, 200, 150,1);
            graphic5.Content = new PageWithGraphic("Давление масла", -10, 200, 150, 0);
            graphic6.Content = new PageWithGraphic("Давление масла", -170, 200, 150, 0);
            graphic7.Content = new PageWithGraphic("Давление масла", 100, 200, 150, 1);
            graphic8.Content = new PageWithGraphic("Давление масла", -50, 200, 150, 50, 30, 2);
        }
    }
}
