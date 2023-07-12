using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace MatadorInitialSetup.CAN
{
    public class CanBus
    {
        public CanBus()
        {
            binfo = default;

            binfo.brdnum = 0;
        }

        public short Open()
        {
            status = -100;
            do
            {
                status = CiInit();
                if (status < 0) break;

                status = CiBoardInfo(ref binfo);
                if (status < 0) break;

                _canChannel = Convert.ToByte(binfo.chip[0]);
                status = CiOpen(_canChannel, 0x06);
                if (status < 0) break;

                //status = CiSetBaud(_canChannel, 0x00, 0x14); // 1Mbs
                status = CiSetBaud(_canChannel, 0x00, 0x1c); // 500Kbs
                //status = CiSetBaud(_canChannel, 0x01, 0x1c); // 250Kbs
                if (status < 0) break;

                status = CiStart(_canChannel);
                if (status < 0) break;
            } while (false);

            showErrorCode(status);
            return status;
        }

        public short Close()
        {
            status = -100;
            do
            {
                status = CiStop(_canChannel);
                if (status < 0) break;

                status = CiClose(_canChannel);
                if (status < 0) break;

            } while (false);

            //showErrorCode(status);
            return status;
        }

        public short CheckErrors()
        {
            status = -100;
            status = CiErrsGetClear(_canChannel, ref canErrors);
            showErrorCode(status);
            return status;
        }

        public void TransmitCancel()
        {
            status = -100;
            ushort txCnt = 0;
            status = CiTrCancel(_canChannel, ref txCnt);
        }
        private void showErrorCode(short s)
        {
            if (status < 0)
            {
                if (status == -10)
                {
                    MessageBox.Show("Сначала подключите CAN-bus-USB\nили закройте другие окна приложения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(status.ToString(), "Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public CanMsg GetCanMsg()
        {
            status = -100;
            CanMsg canMsg = new CanMsg();

            do
            {
                status = CiRead(_canChannel, ref canRxMsg, 1);
                if (status < 0) break;
            } while (false);

            canMsg.Id = canRxMsg.id;
            canMsg.Length = canRxMsg.len;
            canMsg.Timestamp = canRxMsg.ts;

            canMsg.Data[0] = canRxMsg.data[0];
            canMsg.Data[1] = canRxMsg.data[1];
            canMsg.Data[2] = canRxMsg.data[2];
            canMsg.Data[3] = canRxMsg.data[3];
            canMsg.Data[4] = canRxMsg.data[4];
            canMsg.Data[5] = canRxMsg.data[5];
            canMsg.Data[6] = canRxMsg.data[6];
            canMsg.Data[7] = canRxMsg.data[7];

            return canMsg;
        }

        public ushort CanMessagesAvailable()
        {
            ushort canMessagesAvailable = 0;
            status = -100;

            status = CiRcQueGetCnt(_canChannel, ref canMessagesAvailable);

            if (status < 0)
            {
                canMessagesAvailable = 0;
            }

            return canMessagesAvailable;
        }

        public short CanMessageTransmit(CanMsg msg)
        {
            status = -100;

            canmsg_t canTxMsg = default;

            msg_zero(ref canTxMsg);
            msg_seteff(ref canTxMsg);

            canTxMsg.id = msg.Id;
            canTxMsg.len = 8;
            for (int i = 0; i < 8; i++)
            {
                canTxMsg.data[i] = msg.Data[i];
            }

            status = CiTransmit(_canChannel, ref canTxMsg);
            showErrorCode(status);

            return status;
        }

        private byte _canChannel = 0;
        private canboard_t binfo;
        private canmsg_t canRxMsg;
        private canerrs_t canErrors;
        private short status = -100;

        struct canmsg_t
        {
            [MarshalAs(UnmanagedType.U4)]
            public uint id; /* идентификатор кадра */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.U1)]
            public byte[] data; /* данные */
            [MarshalAs(UnmanagedType.U1)]
            public byte len; /* фактическая длина поля данных, от 0 до 8 байт */
            [MarshalAs(UnmanagedType.U2)]
            public ushort flags; /* bit 0 - RTR, bit 2 – EFF */
            [MarshalAs(UnmanagedType.U4)]
            public uint ts; /* отметка времени получения (timestamp) в микросекундах */
        };
        struct canboard_t
        {
            [MarshalAs(UnmanagedType.U1)]
            public byte brdnum; /* номер платы (от 0 до CI_BRD_NUMS-1)*/
            [MarshalAs(UnmanagedType.U4)]
            public uint hwver; /* номер версии железа (аналогичен по структуре номеру версии библиотеки */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I2)]
            public short[] chip; /* массив номеров каналов (например chip[0] содержит номер канала к которому привязан первый чип платы, если номер <0 - чип отсутствует)*/

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string name; /* текстовая строка названия платы */
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string manufact; /* текстовая строка - имя производителя */
        };

        struct canerrs_t
        {
            [MarshalAs(UnmanagedType.U2)]
            ushort ewl; // кол-во ошибок EWL
            [MarshalAs(UnmanagedType.U2)]
            ushort boff; // кол-во ошибок BOFF
            [MarshalAs(UnmanagedType.U2)]
            ushort hwovr; // кол-во ошибок HOVR
            [MarshalAs(UnmanagedType.U2)]
            ushort swovr; // кол-во ошибок SOVR
            [MarshalAs(UnmanagedType.U2)]
            ushort wtout; // кол-во ошибок WTOUT
        };

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiInit();

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiOpen(byte chan, byte flags);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiClose(byte chan);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiStart(byte chan);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiStop(byte chan);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiTransmit(byte chan, ref canmsg_t mbuf);


        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void msg_zero(ref canmsg_t mbuf);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short msg_isrtr(ref canmsg_t mbuf);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void msg_setrtr(ref canmsg_t mbuf);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short msg_iseff(ref canmsg_t mbuf);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void msg_seteff(ref canmsg_t mbuf);


        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiErrsGetClear(byte chan, ref canerrs_t errs);


        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiRcQueGetCnt(byte chan, ref ushort rcqcnt);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiRead(byte chan, ref canmsg_t mbuf, short cnt);


        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiTrCancel(byte chan, ref ushort trqcnt);


        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiBoardInfo(ref canboard_t binfo);

        [DllImport("chai.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern short CiSetBaud(byte chan, byte bt0, byte bt1);
    }
}