using System;
using System.Runtime.InteropServices;

namespace Monitor
{
    public partial class ProtocolHandler
    {
        public void Launch()
        {
            ChannelInitialize();
        }
        public void Open(byte channel, byte flags)
        {
            ChannelOpen(channel, flags);
        }
        public void Close(byte channel)
        {
            ChannelClose(channel);
        }
    }
}

