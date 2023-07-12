using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private short wrongInputCounter = 0;
        private short WrongInputCounter
        {
            get { return wrongInputCounter; }
            set
            {
                wrongInputCounter = value;
                if (wrongInputCounter < 0)
                    wrongInputCounter = 0;
            }
        }

        public EnginConfigFrame(string parameter, double max, double min, 
            double normal, double upDispersion, double downDispersion,
            double upLimit, double downLimit)
        {
            InitializeComponent();

            groupBox.Header = parameter;
            Max_TBox.Text = max.ToString();
            Min_TBox.Text = min.ToString();
            Normal_TBox.Text = normal.ToString();
            UpDispersion_TBox.Text = upDispersion.ToString();
            DownDispersion_TBox.Text = downDispersion.ToString();
            UpLimit_TBox.Text = upLimit.ToString();
            DownLimit_TBox.Text = downLimit.ToString();

            TextBox[] elements = { Max_TBox, Min_TBox, 
                Normal_TBox, UpDispersion_TBox, DownDispersion_TBox,
                UpLimit_TBox, DownLimit_TBox };
            foreach (var item in elements)
                item.TextChanged += IsDouble;

            //TODO сделать checker для проверки диапозона чисел
        }

        public void RadioGroup_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            TextBox[] Normal = { Normal_TBox, UpDispersion_TBox, DownDispersion_TBox };
            TextBox[] DownLimit = { DownLimit_TBox };
            TextBox[] UpLimit = { UpLimit_TBox };

            if (radioButton!.Name == "Normal_Radio")
            {
                SetEnableToTextBox(DownLimit, false);
                SetEnableToTextBox(UpLimit, false);

                SetEnableToTextBox(Normal, true);
            }
            else if (radioButton.Name == "UpLimit_Radio")
            {
                SetEnableToTextBox(Normal, false);
                SetEnableToTextBox(DownLimit, false);

                SetEnableToTextBox(UpLimit, true);
            }
            else if (radioButton.Name == "DownLimit_Radio")
            {
                SetEnableToTextBox(Normal, false);
                SetEnableToTextBox(UpLimit, false);

                SetEnableToTextBox(DownLimit, true);
            }
            else
            {
                MessageBox.Show("Опа, а группа-то не та!");
            }
        }

        private void SetEnableToTextBox(TextBox[] senders, bool value)
        {
            if (value == false)
            {
                foreach (var item in senders)
                {
                    item.IsEnabled = value;
                    item.Background = Brushes.White;
                }
            }
            else
            {
                foreach (var item in senders)
                {
                    item.IsEnabled = value;
                    IsDouble(item, new RoutedEventArgs());
                }
            }
        }

        private void IsDouble(object sender, RoutedEventArgs e)
        {
            TextBox tBox = sender as TextBox;
            string isDouble = @"^-?\d{1,4}([\.\,]\d{1,2})?$";


            if (Regex.IsMatch(tBox!.Text, isDouble))
            {
                tBox.Background = Brushes.LightGreen;
                WrongInputCounter--;
            }
            else
            {
                if (tBox.Background != Brushes.Red)
                {
                    tBox.Background = Brushes.Red;
                    WrongInputCounter++;
                }
            }
        }
    }
}
