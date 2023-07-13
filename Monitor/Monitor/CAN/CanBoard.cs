namespace Monitor
{
    public class CanBoard
    {
        public CanBoard()
        {
            _brdNum = 0;
            _hwVer = 0;
            _name = "";
            _manufact = "";
            _chip = new short[4];
        }

        /*
         * номер платы
         * (uint8)
         * (от 0 до CI_BRD_NUMS-1)
         */
        private byte _brdNum;

        /*
         * номер версии железа
         * (uint32)
         * (аналогичен по структуре номеру версии библиотеки
         */
        private uint _hwVer;

        /*
         * массив номеров каналов
         * (4 элемента, int16)
         * (например chip[0] содержит номер канала к которому привязан
         * первый чип платы, если номер <0 - чип отсутствует)
         */
        private short[] _chip;

        /*
         * текстовая строка названия платы
         * (64 элемента, uint8/char)
         */
        private string _name;

        /*
         * текстовая строка - имя производителя
         * (64 элемента, uint8/char)
         */
        private string _manufact;

        public byte BrdNum
        {
            get => _brdNum;
            set => _brdNum = value;
        }

        public uint HwVer
        {
            get => _hwVer;
            set => _hwVer = value;
        }

        public short[] Chip
        {
            get => _chip;
            set => _chip = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Manufact
        {
            get => _manufact;
            set => _manufact = value;
        }
    }
}