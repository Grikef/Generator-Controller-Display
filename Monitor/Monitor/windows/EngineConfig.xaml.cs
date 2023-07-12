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
        private short wrongInputCounter = 0;
        private short WrongInputCounter
        {
            get { return wrongInputCounter; }
            set
            {
                wrongInputCounter = value;
                if (wrongInputCounter < 0)
                    wrongInputCounter = 0;

                if (wrongInputCounter <= 0)
                    AcceptBtn.IsEnabled = true;
                else
                    AcceptBtn.IsEnabled = false;
            }
        }

        public EngineConfig()
        {
            InitializeComponent();

            //TODO Load values from Store

        }

        private void IsDouble(object sender, RoutedEventArgs e)
        {
            TextBox tBox = sender as TextBox;
            string isDouble = @"^-?\d{1,4}([\.\,]\d{1,2})?$";


            if(Regex.IsMatch(tBox!.Text, isDouble))
            {
                tBox.Background = Brushes.LightGreen;
                WrongInputCounter--;
            }
            else
            {
                if(tBox.Background != Brushes.Red)
                {
                    tBox.Background = Brushes.Red;
                    WrongInputCounter++;
                }
            }
        }

        public void VoltageRadioGroup_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            
            TextBox[] Normal = { Voltage_Norm, Voltage_UpDispersion, Voltage_DownDispersion };
            TextBox[] DownLimit = { Voltage_DownLimit };
            TextBox[] UpLimit = { Voltage_UpLimit };

            if(radioButton!.Name == "Voltage_Normal_Radio")
            {
                SetEnableToTextBox(DownLimit, false);
                SetEnableToTextBox(UpLimit, false);

                SetEnableToTextBox(Normal, true);
            }
            else if(radioButton.Name == "Voltage_UpLimit_Radio")
            {
                SetEnableToTextBox(Normal, false);
                SetEnableToTextBox(DownLimit, false);
                
                SetEnableToTextBox(UpLimit, true);
            }
            else if(radioButton.Name == "Voltage_DownLimit_Radio")
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
            if(value == false)
            {
                foreach(var item in senders)
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

        public void Accept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
