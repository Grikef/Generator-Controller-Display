using System.Runtime.InteropServices;

namespace Monitor;

public partial class ProtocolHandler
{
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiInit")]
    private static extern string ChannelInitialize();

    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiOpen")]
    private static extern string ChannelOpen(byte channel, byte flags);
    
    [DllImport("chai.dll", CharSet = CharSet.Unicode, EntryPoint = "CiClose")]
    private static extern string ChannelClose(byte channel);
}