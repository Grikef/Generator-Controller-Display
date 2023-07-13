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
    public const byte BCI_50K_bt0 = 0x09;
    public const byte BCI_50K_bt1 = 0x1c;
    public const byte BCI_20K_bt0 = 0x18;
    public const byte BCI_20K_bt1 = 0x1c;
    public const byte BCI_10K_bt0 = 0x31;
    public const byte BCI_10K_bt1 = 0x1c;


    /*
    Flags for CiOpen
    */
    public const byte CIO_BLOCK = 0x1;
    public const byte CIO_CAN11 = 0x2;
    public const byte CIO_CAN29 = 0x4;


    /*
        Error codes
    */
    public const byte ECIOK = 0; /* success */
    public const byte ECIGEN = 1; /* generic (not specified) error */
    public const byte ECIBUSY = 2; /* device or resourse busy */
    public const byte ECIMFAULT = 3; /* memory fault */
    public const byte ECISTATE = 4; /* function can't be called for chip in current state */
    public const byte ECIINCALL = 5; /* invalid call, function can't be called for this object */
    public const byte ECIINVAL = 6; /* invalid parameter */
    public const byte ECIACCES = 7; /* can not access resource */
    public const byte ECINOSYS = 8; /* function or feature not implemented */
    public const byte ECIIO = 9; /* input/output error */
    public const byte ECINODEV = 10; /* no such device or object */
    public const byte ECIINTR = 11; /* call was interrupted by event */
    public const byte ECINORES = 12; /* no resources */
    public const byte ECITOUT = 13; /* time out occured */


    /*
*  Flags for CiWaitEvent
*/
    public const byte CI_WAIT_RC = 0x1;
    public const byte CI_WAIT_TR = 0x2;

    public const byte CI_WAIT_ER = 0x4;

/*
*  Commands for CiSetLom
*/
    public const byte CI_LOM_OFF = 0x0;
    public const byte CI_LOM_ON = 0x1;

    enum CI_CMD
    {
        CI_CMD_GET = 0,
        CI_CMD_SET = 1
    }

    enum CI_MODE
    {
        CI_OFF = 0,
        CI_ON = 1
    }

    /*
*  Transmit status
*/
    public const byte CI_TR_COMPLETE_OK = 0x0;
    public const byte CI_TR_COMPLETE_ABORT =0x1;
    public const byte CI_TR_INCOMPLETE =0x2;
    public const byte CI_TR_DELAY =0x3;

/*
*  Transmit cancel status
*/
    public const byte CI_TRCANCEL_TRANSMITTED =0x0;
    public const byte CI_TRCANCEL_ABORTED =0x1;
    public const byte CI_TRCANCEL_NOTRANSMISSION= 0x2;
    public const byte CI_TRCANCEL_DELAYABORTED =0x3;

/*
* Bits in canmsg_t.flags field
*/
    public const byte MSG_RTR =0;
    public const byte MSG_FF =2; /* if set - extended frame format is used */
    public const byte FRAME_RTR =0x1;
    public const byte FRAME_EFF =0x4;
    public const byte FRAME_TRDELAY =0x10;

/*
*  CAN-controller types 
*/
    public const byte CHIP_UNKNOWN =0;
    public const byte SJA1000 =1;
    public const byte EMU =2;
    public const byte MSCAN =3;

/*
*  Manufacturers 
*/
    public const byte MANUF_UNKNOWN =0;
    public const byte MARATHON =1;
    public const byte SA =2;
    public const byte FREESCALE =3;

/*
*  CAN adapter types 
*/
    public const byte BRD_UNKNOWN = 0;
    public const byte CAN_BUS_ISA = 1;
    public const byte CAN_BUS_MICROPC = 2;
    public const byte CAN_BUS_PCI = 3;
    public const byte CAN_EMU = 4;
    public const byte CAN2_PCI_M = 5;
    public const byte MPC5200TQM = 6;
    public const byte CAN_BUS_USB = 7;
    public const byte CAN_BUS_PCI_E = 8;
    public const byte CAN_BUS_USB_NP = 9;
    public const byte CAN_BUS_USB_NPS = 10;

    public int CHAI_VER(byte maj, byte min, byte sub)
    {
        return ((maj) << 16) | ((min) << 8) | (sub);
    }

    public int UNICAN_VER(byte maj, byte min, byte sub)
    {
        return ((maj) << 16) | ((min) << 8) | (sub);
    }

    public int VERSUB(byte ver)
    {
        return ver & 0xff;
    }

    public int VERMIN(byte ver)
    {
        return ((ver) >> 8) & 0xff;
    }

    public int VERMAJ(byte ver)
    {
       return ((ver) >> 16) & 0xff;
    }
    // // // // // // // // // // // //
    public static byte OpenMode(Store.Net net)
    {
        return net.openedMode switch
        {
            0 => CIO_CAN11,
            1 => CIO_CAN29,
            _ => CIO_CAN11 | CIO_CAN29
        };
    }
};