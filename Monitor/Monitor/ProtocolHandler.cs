using System;
using System.Runtime.InteropServices;

namespace Monitor
{
    public partial class ProtocolHandler
    {
        public void Initialize()
        {
            CanInitialize();
        }
        public void Open(byte channel, byte flags)
        {
            CanOpen(channel, flags);
        }
        public void Close(byte channel)
        {
            CanClose(channel);
        }
        
    }
}

