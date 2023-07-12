using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Monitor
{
    public partial class MainWindow
    {
        public byte ChannelOpenMode = 2; // 11/29 bit
        
        private void Message(canmsg_t cadre)
        {
            if (cadre.id != 0)
              MessageBox.Show("YES YES YES");
        }
        private byte OpenMode()
        {
            
            return ChannelOpenMode switch
            {
                0 => Variables.CIO_CAN11,
                1 => Variables.CIO_CAN29,
                _ => (Variables.CIO_CAN11 | Variables.CIO_CAN29)
            };
            
        }
    }
}