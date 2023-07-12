using System;
using System.Runtime.InteropServices;

namespace Monitor
{
    [StructLayout(LayoutKind.Sequential)]
    public class canmsg_t
    {
        public UInt32 id;
        public byte[] data = new byte[8];
        public byte length;
        public UInt16 flags;
        public UInt32 timeStamp;

        public canmsg_t()
        {
            id = 0;
            length = 0;
            flags = 0;
            timeStamp = 0;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct canErrors
    {
        public UInt16 ewl;
        public UInt16 boff;
        public UInt16 hwovr;
        public UInt16 swovr;
        public UInt16 wtout;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct CanWait
    {
        public byte channel;
        public byte wflags;
        public byte rflags;
    }

    [StructLayout(LayoutKind.Sequential)]

    public struct ChipStatus
    {
        public int type;
        public int brdnum;

        public int irq;

        public ulong baddr;

        public ulong hovr_cnt;

        public ulong sovr_cnt;

        public char[] _pad = new char[32];

        public ChipStatus()
        {
            type = 0;
            brdnum = 0;
            irq = 0;
            baddr = 0;
            hovr_cnt = 0;
            sovr_cnt = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ChipStatusSJA1000
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

        public ChipStatusSJA1000()
        {
            type = 0;
            brdnum = 0;
            irq = 0;
            baddr = 0;
            hovr_cnt = 0;
            sovr_cnt = 0;
            mode = '\0';
            stat = '\0';
            inten = '\0';
            clkdiv = '\0';
            ecc = '\0';
            ewl = '\0';
            rxec = '\0';
            txec = '\0';
            rxmc = '\0';
            acode = 0;
            amask = 0;
            btr0 = '\0';
            btr1 = '\0';
            outctl = '\0';
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct ChipStatusDescription 
    {
        public char[,] name = new char[Variables.CI_CHSTAT_STRNUM, Variables.CI_CHSTAT_MAXLEN];
        public char[,] val = new char[Variables.CI_CHSTAT_STRNUM, Variables.CI_CHSTAT_MAXLEN];

        public ChipStatusDescription()
        { }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct CanBoard
    {
        public byte brdnum;
        
        public int hwver;
        
        public short[] chip = new short[4];

        public char[] name = new char[64];

        public char[] manufact = new char[64];

        public CanBoard()
        {
            brdnum = 0;
            hwver = 0;
        }
    }
}