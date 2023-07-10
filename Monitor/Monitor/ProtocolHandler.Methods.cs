namespace Monitor;

public partial class ProtocolHandler
{
    //statements
    private bool[] openedChannels = { false, false };
    private bool[] startedChannels = { false, false };
    public bool isInitialized = false;

    public bool isOpened(byte channel)
    {
        return channel < openedChannels.Length && openedChannels[channel];
    }

    public bool isStarted(byte channel)
    {
        return channel < startedChannels.Length && startedChannels[channel];
    }
    
    
}