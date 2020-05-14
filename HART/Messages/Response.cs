using System;

namespace HART.Messages
{
    /// <summary>
    /// Реализует сообщение-ответ, направляемое от slave-устройства к master-устройству.
    /// </summary>
    public class Response : MessageBase
    {
        /// <summary>
        /// Код отклика.
        /// </summary>
        public int ResponseCode { get; private set; }

        /// <summary>
        /// Описание ошибки связи.
        /// </summary>
        public string CommunicationError { get; private set; }

        /// <summary>
        /// <see langword="true"/>, если устройство находится в пакетном режиме передачи данных.
        /// </summary>
        public bool IsBatchMode { get; private set; }

        /// <summary>
        /// Создать новое сообщение-ответ.
        /// </summary>
        /// <param name="address">Адрес master-устройства.</param>
        private Response(byte[] address) : base(address)
        {
        }

        /// <summary>
        /// Десериализовать ответ.
        /// </summary>
        /// <param name="buffer">Данный для десериализации.</param>
        /// <exception cref="ArgumentException">Данные не прошли проверку на нечетность. Контрольная сумма не совпадает.</exception>
        public static Response Deserialize(byte[] buffer)
        {
            var offset = 0;

            var preamble = SetPreamble(buffer);
            offset += preamble;

            if (!OddCheck(buffer, offset))
                throw new ArgumentException("Данные не прошли проверку на нечетность. Контрольная сумма не совпадает.");

            var limiter = SetLimiter(buffer, offset);
            var frameFormat = SetFrameFormat(limiter);
            var isBatchMode = SetIsBatchMode(limiter);
            offset++;

            var address = SetAddress(buffer, offset, frameFormat);
            offset += address.Length;

            var command = SetCommand(buffer, offset);
            offset += command.Length;

            //var counter = buffer[offset];
            offset++;

            var code = SetCode(buffer, offset);
            offset += code.Length;

            var data = SetData(buffer, offset);

            return new Response(address)
            {
                Preamble = preamble,
                Limiter = limiter,
                FrameFormat = frameFormat,
                IsBatchMode = isBatchMode,
                Command = Convert.FromByte<int>(command),
                CommunicationError = CommunicationErrorList.GetErrorDescription(code[0]),
                ResponseCode = Convert.FromByte<int>(code),
                Data = data
            };
        }

        #region private
        
        /// <summary>
        /// Получить количество символов в преамбуле.
        /// </summary>
        /// <param name="data">Данный для десериализации.</param>
        /// <returns>Количество символов в преамбуле.</returns>
        private static int SetPreamble(byte[] data)
        {
            var count = 0;
            var isStart = false;

            foreach (var item in data)
            {
                if (item == PreambleSymbol)
                {
                    isStart = true;
                    count++;
                }

                else if (isStart) break;
            }

            return count;
        }

        /// <summary>
        /// Проверить полученные данные. 
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns><see langword="true"/>, в случае успешной проверки.</returns>
        private static bool OddCheck(byte[] data, int offset)
        {
            var expected = data[data.Length - 1];
            byte actual = 0;

            for (var i = offset; i < data.Length - 2; i++)
                actual ^= data[i];

            return expected == actual;
        }

        /// <summary>
        /// Получить ограничитель.
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns></returns>
        private static byte SetLimiter(byte[] data, int offset)
            => data[offset];

        /// <summary>
        /// Получить формат фрейма.
        /// </summary>
        /// <param name="limiter">Ограничитель.</param>
        /// <returns></returns>
        private static FrameFormats SetFrameFormat(byte limiter)
        {
            switch (limiter)
            {
                case 0x81:
                case 0x82:
                case 0x86: return FrameFormats.Long;

                case 0x01:
                case 0x02:
                case 0x06: return FrameFormats.Short;

                default: throw new ArgumentException("Не удалось распознать формат кадра.");
            }
        }

        /// <summary>
        /// Получить текущий режим передачи данных устройства.
        /// </summary>
        /// <param name="limiter">Ограничитель.</param>
        /// <returns><see langword="true"/>, если устройство находится в пакетном режиме передачи данных.</returns>
        private static bool SetIsBatchMode(byte limiter) =>
            limiter == 0x01 || limiter == 0x81;

        /// <summary>
        /// Получить адрес slave-устройства, отправившего ответ..
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <param name="frameFormat">Формат фрейма.</param>
        /// <returns></returns>
        private static byte[] SetAddress(byte[] data, int offset, FrameFormats frameFormat)
        {
            byte[] result = null;

            switch (frameFormat)
            {
                case FrameFormats.Short:
                    result = new byte[1];
                    result[0] = data[offset];
                    break;
                case FrameFormats.Long:
                    result = new byte[5];
                    for (var i = 0; i < 5; i++)
                        result[i] = data[i + offset];
                    break;
            }

            return result;
        }

        /// <summary>
        /// Получить номер переданной команды.
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns></returns>
        private static byte[] SetCommand(byte[] data, int offset)
        {
            byte[] result;

            if (data[offset] == 254)
                result = new[]
                {
                    data[offset],
                    data[offset + 1]
                };
            else
                result = new[]
                {
                    data[offset]
                };

            return result;
        }

        /// <summary>
        /// Получить код отклика.
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns></returns>
        private static byte[] SetCode(byte[] data, int offset) => new[]
            {
                data[offset],
                data[offset + 1]
            };

        /// <summary>
        /// Получить данные из ответа slave-устройства.
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns></returns>
        private static byte[] SetData(byte[] data, int offset)
        {
            var count = data.Length - offset - 1;
            var result = new byte[count];

            for (var i = 0; i < count; i++)
                result[i] = data[offset + i];

            return result;
        }

        #endregion
    }
}
