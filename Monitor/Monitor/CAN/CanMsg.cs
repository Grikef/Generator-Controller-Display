namespace MatadorInitialSetup.CAN
{
    public class CanMsg
    {
        //#define FRAME_RTR     0x01
        //#define FRAME_EFF     0x04
        //#define FRAME_TRDELAY 0x10
        public CanMsg()
        {
            _id = 0;
            _data = new byte[8]{0, 0, 0, 0, 0, 0, 0, 0};
            _length = 8;
            _flags = 0x04;  // FRAME_EFF
        }

        /*
         * идентификатор кадра
         * (uint32)
         */
        private uint _id;

        /*
         * данные
         * (4 элемента, uint8)
         */
        private byte[] _data;

        /*
         * фактическая длина поля данных
         * (uint8)
         * (от 0 до 8)
         */
        private byte _length;

        /*
         * фактическая длина поля данных
         * (uint16)
         * (bit 0 - RTR, bit 2 – EFF)
         */
        private ushort _flags;

        /*
         * отметка времени получения(timestamp) в микросекундах
         * (uint32)
         */
        private uint _timestamp;

        public uint Id
        {
            get => _id;
            set => _id = value;
        }

        public byte[] Data
        {
            get => _data;
            set => _data = value;
        }

        public byte Length
        {
            get => _length;
            set => _length = value;
        }

        public uint Timestamp
        {
            get => _timestamp;
            set => _timestamp = value;
        }
    }
}