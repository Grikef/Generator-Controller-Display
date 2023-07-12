using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Monitor.windows
{
    /// <summary>
    /// Логика взаимодействия для EngineConfig.xaml
    /// </summary>
    public partial class EngineConfig : Window
    {
        public EngineConfig()
        {
            InitializeComponent();

            //TODO Load values from Store

        }

        public void Accept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
