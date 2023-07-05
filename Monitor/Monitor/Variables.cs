namespace Monitor;

public record Variables
{
    public const byte CI_CHSTAT_MAXLEN = 16;
    public const byte CI_CHSTAT_STRNUM = 32;
    
    public const byte CI_BRD_NUMS = 8;
    public const byte CI_CHAN_NUMS = 8;
    public const byte CIQUE_RC = 0;
    public const byte CIQUE_TR = 1;
    public const short CIQUE_DEFSIZE_RC = 4096;
    public const byte CIQUE_DEFSIZE_TR = 64;

    enum CIQUE_THRESHOLD_DEF
    {
        CIQUE_RC_THRESHOLD_DEF = 1,
        CIQUE_TR_THRESHOLD_DEF = CIQUE_DEFSIZE_TR
    }

    public const byte CI_WRITE_TIMEOUT_DEF = 20;
    public const short CI_WRITE_TIMEOUT_MAX = 500;
    public const byte CAN_INIT = 0;
    public const byte CAN_RUNNING = 1;
    public const byte BCI_1M_bt0 = 0x00;
    public const byte BCI_1M_bt1 = 0x14;
    public const byte BCI_800K_bt0 = 0x00;
    public const byte BCI_800K_bt1 = 0x16;
    public const byte BCI_500K_bt0 = 0x00;
    public const byte BCI_500K_bt1 = 0x1c;
    public const byte BCI_250K_bt0 = 0x01;
    public const byte BCI_250K_bt1 = 0x1c;
    public const byte BCI_125K_bt0 = 0x03;
    public const byte BCI_125K_bt1 = 0x1c;
    public const byte BCI_100K_bt0 = 0x04;
    public const byte BCI_100K_bt1 = 0x1c;
    public const byte BCI_50K_bt0  = 0x09;
    public const byte BCI_50K_bt1  = 0x1c;
    public const byte BCI_20K_bt0  = 0x18;
    public const byte BCI_20K_bt1  = 0x1c;
    public const byte BCI_10K_bt0  = 0x31;
    public const byte BCI_10K_bt1   =0x1c;

};