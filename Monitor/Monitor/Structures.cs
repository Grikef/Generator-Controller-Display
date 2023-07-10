using System;

namespace Monitor
{
    public class canMessage
    {
        public UInt32 id;
        public byte[] data = new byte[8];
        public byte length;
        public UInt16 flags;
        public UInt32 timeStamp;
    }

    public class canErrors
    {
        public UInt16 ewl;
        public UInt16 boff;
        public UInt16 hwovr;
        public UInt16 swovr;
        public UInt16 wtout;
    }

    public class CanWait
    {
        public byte channel;
        public byte wflags;
        public byte rflags;
    }

    public class ChipStatus
    {
        public int type;
        public int brdnum;

        public int irq;

        public ulong baddr;

        public ulong hovr_cnt;

        public ulong sovr_cnt;

        public char[] _pad = new char[32];
    }

    public class ChipStatusSJA1000
    {
        public int type;
        public int brdnum;
        public int irq;
        public ulong baddr;
        public ulong hovr_cnt;
        public ulong sovr_cnt;

        /* this registers are readable in all mode */
        public char mode;
        public char stat;
        public char inten;
        public char clkdiv;
        public char ecc;
        public char ewl;
        public char rxec;
        public char txec;
        public char rxmc;
        /* this registers are readable in init(reset) mode
       only */
        public int acode;
        public int amask;
        public char btr0;
        public char btr1;
        public char outctl;
        char[] _pad = new char[8];

    }
    public class ChipStatusDescription 
    {
        public char[,] name = new char[Variables.CI_CHSTAT_STRNUM, Variables.CI_CHSTAT_MAXLEN];
        public char[,] val = new char[Variables.CI_CHSTAT_STRNUM, Variables.CI_CHSTAT_MAXLEN];

    }
    
    public class CanBoard
    {
        public byte brdnum;
        
        public int hwver;
        
        public short[] chip = new short[4];

        public char[] name = new char[64];

        public char[] manufact = new char[64];
    }
}