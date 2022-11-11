using System.Collections;

namespace HART.Messages
{
    /// <summary>
    /// Реализует сообщение-запрос, направляемое от master-устройства к slave-устройству.
    /// </summary>
    public class Request : MessageBase
    {
        /// <summary>
        /// <see langword="true"/>, если запрос передает вторичный мастер.
        /// </summary>
        public bool IsSecondaryMaster { get; }

        /// <summary>
        /// <see langword="true"/>, если запрос должен передаваться по широковещательному адресу.
        /// </summary>
        public bool IsBroadcastAddress { get; set; }

        /// <summary>
        /// Создать запрос для передачи по широковещательному адресу.
        /// </summary>
        /// <param name="isSecondaryMaster"><see langword="true"/>, если запрос передает вторичный мастер.</param>
        public Request(bool isSecondaryMaster)
            : base(SetAddress(isSecondaryMaster))
        {
            IsSecondaryMaster = isSecondaryMaster;
        }

        /// <summary>
        /// Создать запрос для передачи адресу в формате короткого фрейма.
        /// <para>Допускаются адреса из диапазона 0..15.</para>
        /// </summary>
        /// <param name="isSecondaryMaster"><see langword="true"/>, если запрос передает вторичный мастер.</param>
        /// <param name="deviceAddress">Адрес устройства.</param>
        public Request(bool isSecondaryMaster, int deviceAddress)
            : base(SetAddress(isSecondaryMaster, deviceAddress))
        {
            IsSecondaryMaster = isSecondaryMaster;
            FrameFormat = FrameFormats.Short;
        }

        /// <summary>
        /// Создать запрос для передачи адресу в формате длинного фрейма.
        /// </summary>
        /// <param name="isSecondaryMaster"><see langword="true"/>, если запрос передает вторичный мастер.</param>
        /// <param name="manufacturerId">HART ID производителя.</param>
        /// <param name="deviceTypeCode">Код типа устройства.</param>
        /// <param name="deviceSerialNumber">Серийный номер устройства.</param>
        public Request(bool isSecondaryMaster, int manufacturerId, int deviceTypeCode, int deviceSerialNumber)
            : base(SetAddress(isSecondaryMaster, manufacturerId, deviceTypeCode, deviceSerialNumber))
        {
            IsSecondaryMaster = isSecondaryMaster;
            FrameFormat = FrameFormats.Long;
        }

        /// <summary>
        /// Сериализовать запрос.
        /// </summary>
        /// <returns>Массив байтов, готовый для отправки по протоколу HART.</returns>
        public byte[] Serialize()
        {
            var result = new List<byte>();

            result.AddRange(GetPreamble());
            result.Add(GetLimiter());
            result.AddRange(Address);
            result.AddRange(GetCommand());
            result.Add(GetByteCounter(Data));

            if (Data != null)
                result.AddRange(Data);

            result.Add(GetCheckSum(result));

            return result.ToArray();
        }

        /// <summary>
        /// Сформировтаь преамбулу (<see cref="MessageBase.Preamble"/>) сообщения.
        /// </summary>
        /// <returns>Преамбула в формате массива байтов.</returns>
        private IEnumerable<byte> GetPreamble()
        {
            if (Preamble <= 0)
                throw new ArgumentException("Количество символов в преамбуле должно быть большее нуля.");

            var res = new byte[Preamble];

            for (var i = 0; i < Preamble; i++)
                res[i] = PreambleSymbol;

            return res;
        }

        /// <summary>
        /// Заполнить ограничитель (<see cref="MessageBase.Limiter"/>) сообщения.
        /// </summary>
        /// <returns>Ограния=читель в формате массива байтов.</returns>
        private byte GetLimiter()
        {
            Limiter = FrameFormat == FrameFormats.Short ? (byte)0x2 : (byte)0x82;
            return Limiter;
        }

        /// <summary>
        /// Установить в качестве адреса устройства широковещательный адрес и преобразовать его в массив байтов.
        /// </summary>
        private static byte[] SetAddress(bool isSecondaryMaster) =>
            isSecondaryMaster ? BitConverter.GetBytes(0x80000) : BitConverter.GetBytes(0x00000);

        /// <summary>
        /// Преобразовать адрес устройства в массив байтов.
        /// </summary>
        /// <param name="isSecondaryMaster"><see langword="true"/>, если данное master-устройство вторичное.</param>
        /// <param name="deviceAddress">Адрес устройства.</param>
        /// <returns>Адрес устройства в виде массива байтов.</returns>
        private static byte[] SetAddress(bool isSecondaryMaster, int deviceAddress)
        {
            if (deviceAddress < 0 || deviceAddress > 15)
                throw new ArgumentOutOfRangeException(nameof(deviceAddress), "В формате короткого кадра адрес прибора должен быть в диапазоне 0..15");

            var address = (byte)(deviceAddress & 0xF);

            if (!isSecondaryMaster)
                address |= 0x80;

            return new[] { address };
        }

        /// <summary>
        /// Преобразовать адрес устройства в массив байтов.
        /// <para>Только для длинного формата кадра (<see cref="FrameFormats.Long"/>).</para>
        /// </summary>
        /// <param name="isSecondaryMaster"><see langword="true"/>, если данное master-устройство вторичное.</param>
        /// <param name="manufacturerId">ID производитель.</param>
        /// <param name="deviceTypeCode">Код типа устройства.</param>
        /// <param name="deviceSerialNumber">Серийный номер устройства.</param>
        /// <returns>Адрес устройства в виде массива байтов.</returns>
        private static byte[] SetAddress(bool isSecondaryMaster, int manufacturerId, int deviceTypeCode, int deviceSerialNumber)
        {
            if (manufacturerId < 0)
                throw new ArgumentException("Значение ID производителя не должно быть меньше нуля.");

            if (deviceTypeCode < 0)
                throw new ArgumentException("Значение кода типа устройства не должно быть меньше нуля.");

            if (deviceSerialNumber < 0)
                throw new ArgumentException("Значение серийного номера устройства не должно быть меньше нуля.");

            var bManufacturerId = new BitArray(BitConverter.GetBytes(manufacturerId));
            var bDeviceTypeCode = new BitArray(BitConverter.GetBytes(deviceTypeCode));
            var bDeviceSerialNumber = new BitArray(BitConverter.GetBytes(deviceSerialNumber));
            var address = new BitArray(40);

            var index = 39;
            address.Set(index--, !isSecondaryMaster);
            address.Set(index--, false);

            for (var i = 6; i > 0; i--)
                address.Set(index--, bManufacturerId[i - 1]);

            for (var i = 8; i > 0; i--)
                address.Set(index--, bDeviceTypeCode[i - 1]);

            for (var i = 24; i > 0; i--)
                address.Set(index--, bDeviceSerialNumber[i - 1]);

            var result = new byte[5];
            address.CopyTo(result, 0);
            Array.Reverse(result);

            return result;
        }

        /// <summary>
        /// Заполнить команду сообщения.
        /// </summary>
        /// <returns>Команда в формате массива байтов.</returns>
        private IEnumerable<byte> GetCommand()
        {
            if (Command < 0 || Command > 65534)
                throw new ArgumentOutOfRangeException(nameof(Command), "Номер команды должен быть в диапазоне 0..65534");

            byte[] result;
            var bCommand = BitConverter.GetBytes(Command);

            if (Command <= 255)
            {
                result = new byte[1];
                result[0] = bCommand[0];
            }
            else
            {
                result = new byte[2];
                result[0] = bCommand[0];
                result[1] = bCommand[1];
            }

            return result;
        }

        /// <summary>
        /// Счетчик байт - количество байт, которые формируют код отклика и передаваемые/получаемые данные.
        /// </summary>
        /// <param name="data">Данные для подсчета.</param>
        /// <returns></returns>
        private static byte GetByteCounter(IReadOnlyCollection<byte> data) => data?.Count switch
        {
            <= 0 => 0,
            >= 255 => 255,
            _ => (byte) (data?.Count ?? 0)
        };

        /// <summary>
        /// Получить контрольную сумму.
        /// </summary>
        /// <param name="data">Данные для просчета.</param>
        private byte GetCheckSum(IReadOnlyList<byte> data)
        {
            byte result = 0;

            for (var i = Preamble; i < data.Count - 1; i++)
                result ^= data[i];

            return result;
        }
    }
}
