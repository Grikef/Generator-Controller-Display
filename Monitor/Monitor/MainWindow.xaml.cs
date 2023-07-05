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
using Monitor.pages;

namespace Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InfoFrame.Content = new Parameters();
        }

        public void TreeViewMain_Selected(object sender, RoutedEventArgs e)
        {
            //if (InfoFrame.Content is not null)
            //{
            //    InfoFrame.Content = null;
            //}
        }

        public void TreeViewInOut_Selected(object sender, RoutedEventArgs e)
        {
            if (InfoFrame.Content is not pages.InOut)
            {
                InfoFrame.Content = new pages.InOut();
                e.Handled = true;
            }
        }

        public void TreeViewIn_Selected(object sender, RoutedEventArgs e)
        {
            if(InfoFrame.Content is not pages.Input)
            {
                InfoFrame.Content = new pages.Input();
                e.Handled = true;
            }
        }

        public void TreeViewOut_Selected(object sender, RoutedEventArgs e)
        {
            if (InfoFrame.Content is not pages.Output)
            {
                InfoFrame.Content = new pages.Output();
                e.Handled = true;
            }
        }
    }
}
