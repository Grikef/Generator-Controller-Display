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
using Monitor.pages;

namespace Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, string> errors = new Dictionary<int, string>();
        public MainWindow()
        {
            InitializeComponent();

            InfoFrame.Content = new Parameters();
            defaultTVItem.IsSelected = true;

            errors.Add(000, "12:46:35 -Пример ошибки, пришедшей от устройства");
            errors.Add(001, "14:02:54 -Другой пример ошибки, пришедшей от устройства");

            foreach (var item in errors.Values.Reverse())
                ErrorBox.Text += item + '\n';
        }

        public void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Тут должно быть описание программы", "О программе");
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void TreeViewMain_Selected(object sender, RoutedEventArgs e)
        {
            if (InfoFrame.Content is not pages.Parameters)
            {
                InfoFrame.Content = new pages.Parameters();
            }
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

        public void AddError(int id, string error)
        {
            if (!errors.ContainsKey(id))
            {
                errors.Add(id, '\n' + error);
            }
            else
            {
                errors.Remove(id);
                errors.Add(id, error);
            }

            foreach(var item in errors.Values.Reverse())
                ErrorBox.Text += item + '\n';
        }

        public void ClearErrors()
        {
            errors.Clear();
            ErrorBox.Text = "";
        }

        private void InfoFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
