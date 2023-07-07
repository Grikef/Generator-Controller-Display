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
    /// Логика взаимодействия для Output.xaml
    /// </summary>
    public partial class Output : Page
    {
        private short[] outputs = new short[8];
        public Output()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;

            if (btn == null)
                return;

            TextBlock? textBlock = btn.Content as TextBlock;

            if(textBlock!.Text == "OFF")
            {
                btn.Background = Brushes.LightGreen;
                btn.Content = new string("ON");
            }
            else if(textBlock!.Text == "ON")
            {
                btn.Background = Brushes.Red;
                btn.Content = new string("OFF");
            }
            else
            {
                MessageBox.Show("Ошибка!", "Что-то явно пошло не так, напишите разработчику");
            }
        }

        public string GetStatusPerCode(int indexOfTable)
        {
            if (outputs[indexOfTable] == 0)
            {
                return "0";
            }

            if (outputs[indexOfTable] == 1)
            {
                return "1";
            }

            return "N/A";
        }

        public void SetAllInputs(short first, short second, short third, short fourth)
        {
            SetFirstInput(first);
            SetSecondInput(second);
            SetThirdInput(third);
            SetFourthInput(fourth);
        }

        public void SetFirstInput(short value)
        {
            outputs[0] = value;
            this.FirstValue.Text = GetStatusPerCode(0);
        }

        public void SetSecondInput(short value)
        {
            outputs[1] = value;
            this.SecondValue.Text = GetStatusPerCode(1);
        }
        public void SetThirdInput(short value)
        {
            outputs[2] = value;
            this.ThirdValue.Text = GetStatusPerCode(2);
        }
        public void SetFourthInput(short value)
        {
            outputs[3] = value;
            this.FourthValue.Text = GetStatusPerCode(3);
        }
    }
}
