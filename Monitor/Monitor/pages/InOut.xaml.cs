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
    /// Логика взаимодействия для InOut.xaml
    /// </summary>
    public partial class InOut : Page
    {
        public InOut()
        {
            InitializeComponent();

            InFrame.Content = new pages.Input();
            OutFrame.Content = new pages.Output();
        }

        //public void RefreshAll()
        //{
        //    pages.Input? InPage = InFrame.Content as pages.Input;
        //    if( InPage != null )
        //    {
        //        InPage.RefreshAll();
        //    }

        //    pages.Output? OutPage = InFrame.Content as pages.Output;
        //    if ( OutPage != null )
        //    {
        //        OutPage.RefreshAll();
        //    }
        //}
    }
}
