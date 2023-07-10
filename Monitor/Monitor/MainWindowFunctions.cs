using System;
using System.Text.Json;
using System.Windows.Controls;

namespace Monitor
{
    public partial class MainWindow
    {
        public static byte ChannelOpenMode = 2; // 11/29 bit


        /*public void Start()
        {
            protocol = new ProtocolHandler();
            InitializeComponent();
            protocol.Initialize();
            
            protocol.Open(0, OpenMode());
        }*/
        private byte OpenMode()
        {
            
            return ChannelOpenMode switch
            {
                0 => Variables.CIO_CAN11,
                1 => Variables.CIO_CAN29,
                _ => Variables.CIO_CAN11 | Variables.CIO_CAN29
            };
        }
    }
}