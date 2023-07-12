using Monitor.pages;
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

            EnginePower.Content = new EnginConfigFrame("Скорость двигателя", 9999, 0, 1500, 500, 500, 0, 0);
            ChargingVoltage.Content = new EnginConfigFrame("Зарядное напряжение", 400, 0, 220, 40, 40, 0, 0);
            BatteryVoltage.Content = new EnginConfigFrame("Напряжение батареи", 120, 0, 24, 4, 4, 0, 0);
            OilPressure.Content = new EnginConfigFrame("Давление масла", 100, 0, 0, 0, 0, 70, 0);
            EngineTemperature.Content = new EnginConfigFrame("Температура двигателя", 200, -100, 100, 40, 70, 0, 0);
            OilTemperature.Content = new EnginConfigFrame("Температура масла", 200, -100, 100, 40, 70, 0, 0);
            CasingTemperature.Content = new EnginConfigFrame("Температура кожуха", 200, -100, 100, 40, 70, 0, 0);
            Fuel.Content = new EnginConfigFrame("Уровень топлива", 15, 0, 0, 0, 0, 0, 2);

            //TODO Load values from Store
        }

        public void Accept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
