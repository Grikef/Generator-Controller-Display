using System;
using System.IO;
using System.Threading;

namespace Monitor
{
    public partial class ProtocolHandler
    {
        //logging is not working
        private StreamWriter streamWriter = new StreamWriter(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\logs.txt", append:true);
        
        public void Initialize()
        {
            if (isInitialized)
                Environment.Exit(-19);
            
            isInitialized = true;
            var temp = CanInitialize();
            streamWriter.WriteLine(temp >= 0
                ? $"{DateTime.Now}: CAN successfully initialized"
                : $"{DateTime.Now}: Error occured. CAN not initialized");
        }
        public void Open(byte channel, byte flags)
        {
            if (!isInitialized)
                Environment.Exit(-1);
            openedChannels[channel] = true;
            var temp = CanOpen(channel, flags);
            streamWriter.WriteLine(temp >= 0
                ? $"{DateTime.Now}: channel successfully opened"
                : $"{DateTime.Now}: Error occured. Wrong channel number or controller not plugged in");
        }
        public void Close(byte channel)
        {
            if (!isInitialized || !isOpened(channel))
                Environment.Exit(-1);
            var temp = CanClose(channel);
            streamWriter.WriteLine(temp >= 0
                ? $"{DateTime.Now}: channel successfully closed"
                : $"{DateTime.Now}: Error occured. Wrong channel number");
        }

        public void Start(byte channel)
        {
            if (!(isInitialized && isOpened(channel)))
                Environment.Exit(-5);
            var temp = CanStart(channel);
            streamWriter.WriteLine(temp >= 0
                ? $"{DateTime.Now}: CAN is running"
                : $"{DateTime.Now}: Error occured. Wrong channel number");
        }

        public void Stop(byte channel)
        {
            var temp = CanStop(channel);
            streamWriter.WriteLine(temp >= 0
                ? $"{DateTime.Now}: CAN is not running anymore"
                : $"{DateTime.Now}: Error occured. Wrong channel number");
        }

        public void Write(byte channel, canMessage cadre, short count)
        {
            var temp = CanWrite(channel, cadre, channel);
        }

        public void Read(byte channel, canMessage cadre, short count)
        {
            var temp = CanRead(channel, cadre, count);
        }
        public void Transmit(byte channel,canMessage cadre)
        {

            var temp = CanTransmit(0, cadre);
        }

        public void SetLom(byte channel, byte mode)
        {
            var temp = CanSetLom(channel, mode);
            Console.WriteLine();
            //
        }
    }
}

