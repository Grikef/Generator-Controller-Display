﻿using System;
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
    /// Логика взаимодействия для EnginConfigFrame.xaml
    /// </summary>
    public partial class EnginConfigFrame : Page
    {
        public EnginConfigFrame(string parameter, double max, double min, 
            double normal, double upDispersion, double downDispersion,
            double upLimit, double downLimit)
        {
            InitializeComponent();

            groupBox.Header = parameter;
        }
    }
}
