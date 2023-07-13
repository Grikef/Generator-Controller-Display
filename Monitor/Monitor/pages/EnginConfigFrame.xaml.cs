using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                item.PreviewTextInput += IsAllow;

            ////
            //Max_TBox.TextChanged += ;
            //Min_TBox.TextChanged += ;
            Normal_TBox.TextChanged += NormalTBox_Checker;
            UpDispersion_TBox.TextChanged += UpDispersionTBox_Checker;
            DownDispersion_TBox.TextChanged += DownDispersionTBox_Checker;
            UpLimit_TBox.TextChanged += UpLimitTBox_Checker;
            DownLimit_TBox.TextChanged += DownLimitTBox_Checker;

            Normal_Radio.IsChecked = true;
        }

        private void NormalTBox_Checker(object sender, RoutedEventArgs e)
        {
            if (!IsDouble(sender))
            {
                return;
            }

            if(!InRange(sender, Max_TBox, Min_TBox))
            {
                return;
            }
        }

        private void UpDispersionTBox_Checker(object sender, RoutedEventArgs e)
        {
            if (!IsDouble(sender))
            {
                return;
            }

            TextBox upDisp = sender as TextBox;
            double max = double.Parse(Max_TBox.Text);
            double normal = double.Parse(Normal_TBox.Text);
            double disp = double.Parse(upDisp!.Text);

            if (normal + disp > max)
            {
                Max_TBox.Background = Brushes.Yellow;
                UpDispersion_TBox.Background = Brushes.Yellow;
            }
            else
            {
                Max_TBox.Background = Brushes.White;
                UpDispersion_TBox.Background = Brushes.White;
            }
        }

        private void DownDispersionTBox_Checker(object sender, RoutedEventArgs e)
        {
            if (!IsDouble(sender))
            {
                return;
            }

            TextBox downDisp = sender as TextBox;
            double min = double.Parse(Min_TBox.Text);
            double normal = double.Parse(Normal_TBox.Text);
            double disp = double.Parse(downDisp!.Text);

            if (normal - disp < min)
            {
                Max_TBox.Background = Brushes.Yellow;
                UpDispersion_TBox.Background = Brushes.Yellow;
            }
            else
            {
                Max_TBox.Background = Brushes.White;
                UpDispersion_TBox.Background = Brushes.White;
            }
        }

        private void UpLimitTBox_Checker(object sender, RoutedEventArgs e)
        {
            if (!IsDouble(sender))
            {
                return;
            }

            if (!InRange(sender, Max_TBox, Min_TBox))
            {
                return;
            }
        }

        private void DownLimitTBox_Checker(object sender, RoutedEventArgs e)
        {
            if (!IsDouble(sender))
            {
                return;
            }

            if (!InRange(sender, Max_TBox, Min_TBox))
            {
                return;
            }
        }

        private void RadioGroup_Checked(object sender, RoutedEventArgs e)
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
                    //item.Text += "";
                }
            }
        }

        private bool IsDouble(object sender)
        {
            string isDouble = @"^-?\d{1,4}([\.\,]\d{1,2})?$";
            TextBox tBox = sender as TextBox;

            if (Regex.IsMatch(tBox!.Text, isDouble))
            {
                WrongInputCounter--;
            }
            else
            {
                if (tBox.Background != Brushes.Red)
                {
                    tBox.Background = Brushes.Red;
                    WrongInputCounter++;
                }

                return false;
            }

            return true;
        }

        private void IsAllow(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[-\.\,[0-9]]*";
            if (!Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private bool InRange(object sender, object maxBox, object minBox)
        {
            TextBox Max = maxBox as TextBox, Min = minBox as TextBox;
            double max = double.Parse(Max!.Text);
            double min = double.Parse(Min!.Text);

            TextBox tBox = sender as TextBox;
            double value = double.Parse(tBox!.Text);

            if(value >= max)
            {
                tBox.Background = Brushes.Yellow;
                Max.Background = Brushes.Yellow;
                WrongInputCounter++;
                return false;
            }
            else
            {
                tBox.Background = Brushes.White;
                Max.Background = Brushes.White;
                WrongInputCounter--;
            }

            if(value <= min)
            {
                tBox.Background = Brushes.Yellow;
                Min.Background = Brushes.Yellow;
                WrongInputCounter++;
                return false;
            }
            else
            {
                tBox.Background = Brushes.White;
                Min.Background = Brushes.White;
                WrongInputCounter--;
            }

            return true;
        }
    }
}
