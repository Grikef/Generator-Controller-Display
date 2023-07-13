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
    /// Логика взаимодействия для Input.xaml
    /// </summary>
    public partial class Input : Page
    {
        private short[] inputs = new short[8];
        public Input()
        {
            InitializeComponent();
            SetAllInputs(2, 2, 2, 2, 2, 2, 2, 2);
        }
        public string GetStatusPerCode(int indexOfTable)
        {
            if (inputs[indexOfTable] == 0)
            {
                return "0";
            }
            if (inputs[indexOfTable] == 1)
            {
                return "1";
            }
            return "N/A";
        }
        public void SetAllInputs(short first, short second, short third, short fourth,
                                short fifth, short sixth, short seventh, short eighth)
        {
            SetFirstInput(first);
            SetSecondInput(second);
            SetThirdInput(third);
            SetFourthInput(fourth);
            SetFifthInput(fifth);
            SetSixthInput(sixth);
            SetSeventhInput(seventh);
            SetEighthInput(eighth);
        }

        public void SetFirstInput(short value) 
        {
            inputs[0] = value;
            this.FirstValue.Text = GetStatusPerCode(0);
        }

        public void SetSecondInput(short value)
        {
            inputs[1] = value;
            this.SecondValue.Text = GetStatusPerCode(1);
        }
        public void SetThirdInput(short value)
        {
            inputs[2] = value;
            this.ThirdValue.Text = GetStatusPerCode(2);
        }
        public void SetFourthInput(short value)
        {
            inputs[3] = value;
            this.FourthValue.Text = GetStatusPerCode(3);
        }
        public void SetFifthInput(short value)
        {
            inputs[4] = value;
            this.FifthValue.Text = GetStatusPerCode(4);
        }
        public void SetSixthInput(short value)
        {
            inputs[5] = value;
            this.SixthValue.Text = GetStatusPerCode(5);
        }
        public void SetSeventhInput(short value)
        {
            inputs[6] = value;
            this.SeventhValue.Text = GetStatusPerCode(6);
        }
        public void SetEighthInput(short value)
        {
            inputs[7] = value;
            this.EighthValue.Text = GetStatusPerCode(7);
        }
    }
}
