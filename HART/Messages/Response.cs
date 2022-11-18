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
        public int ResponseCode { get; private init; }

        /// <summary>
        /// Описание ошибки связи.
        /// </summary>
        public string CommunicationError { get; private init; }

        /// <summary>
        /// <see langword="true"/>, если устройство находится в пакетном режиме передачи данных.
        /// </summary>
        public bool IsBatchMode { get; private init; }

        /// <summary>
        /// Создать новое сообщение-ответ.
        /// </summary>
        /// <param name="address">Адрес master-устройства.</param>
        private Response(byte[] address) : base(address)
        {
        }

        /// <summary>
        /// Создать новое сообщение-ответ об ошибке.
        /// </summary>
        /// <param name="error">Текст ошибки.</param>
        private Response(string error) : base(null)
        {
            CommunicationError = error;
        }

        /// <summary>
        /// Десериализовать ответ.
        /// </summary>
        /// <param name="buffer">Данный для десериализации.</param>
        /// <exception cref="ArgumentException">Данные не прошли проверку на нечетность. Контрольная сумма не совпадает.</exception>
        public static Response Deserialize(IReadOnlyList<byte> buffer)
        {
            var offset = 0;

            var preamble = SetPreamble(buffer);
            offset += preamble;

            if (!OddCheck(buffer, offset))
                return new Response(CommunicationErrorList.GetErrorDescription(192));

            var limiter = SetLimiter(buffer, offset);
            var frameFormat = SetFrameFormat(limiter);
            var isBatchMode = SetIsBatchMode(limiter);
            offset++;

            var address = SetAddress(buffer, offset, frameFormat);
            offset += address.Length;

            var command = SetCommand(buffer, offset);
            offset += command.Length + 1;

            var code = SetCode(buffer, offset);
            offset += code.Length;

            var data = SetData(buffer, offset);

            return new Response(address)
            {
                Preamble = preamble,
                FrameFormat = frameFormat,
                IsBatchMode = isBatchMode,
                Command = (int)Convert.FromByte<uint>(command),
                CommunicationError = CommunicationErrorList.GetErrorDescription(code[0]),
                ResponseCode = (int)Convert.FromByte<uint>(code),
                Data = data
            };
        }

        #region private

        /// <summary>
        /// Получить количество символов в преамбуле.
        /// </summary>
        /// <param name="data">Данный для десериализации.</param>
        /// <returns>Количество символов в преамбуле.</returns>
        private static int SetPreamble(IEnumerable<byte> data)
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

                else if (isStart)
                    break;
            }

            return count;
        }

        /// <summary>
        /// Проверить полученные данные. 
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns><see langword="true"/>, в случае успешной проверки.</returns>
        private static bool OddCheck(IReadOnlyList<byte> data, int offset)
        {
            var expected = data[^1];
            byte actual = 0;

            for (var i = offset; i < data.Count - 1; i++)
                actual ^= data[i];

            return expected == actual;
        }

        /// <summary>
        /// Получить ограничитель.
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <returns></returns>
        private static byte SetLimiter(IReadOnlyList<byte> data, int offset)
            => data[offset];

        /// <summary>
        /// Получить формат фрейма.
        /// </summary>
        /// <param name="limiter">Ограничитель.</param>
        /// <returns></returns>
        private static FrameFormats SetFrameFormat(byte limiter) => limiter switch
        {
            0x81 => FrameFormats.Long,
            0x82 => FrameFormats.Long,
            0x86 => FrameFormats.Long,
            0x01 => FrameFormats.Short,
            0x02 => FrameFormats.Short,
            0x06 => FrameFormats.Short,
            _ => throw new ArgumentException("Не удалось распознать формат кадра.")
        };

        /// <summary>
        /// Получить текущий режим передачи данных устройства.
        /// </summary>
        /// <param name="limiter">Ограничитель.</param>
        /// <returns><see langword="true"/>, если устройство находится в пакетном режиме передачи данных.</returns>
        private static bool SetIsBatchMode(byte limiter) =>
            limiter is 0x01 or 0x81;

        /// <summary>
        /// Получить адрес slave-устройства, отправившего ответ..
        /// </summary>
        /// <param name="data">Данные для десериализации.</param>
        /// <param name="offset">Смещение в массиве <paramref name="data"/>, с которого начинается чтение данных.</param>
        /// <param name="frameFormat">Формат фрейма.</param>
        /// <returns></returns>
        private static byte[] SetAddress(IReadOnlyList<byte> data, int offset, FrameFormats frameFormat)
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
        private static byte[] SetCommand(IReadOnlyList<byte> data, int offset)
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
        private static byte[] SetCode(IReadOnlyList<byte> data, int offset) => new[]
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
        private static byte[] SetData(IReadOnlyList<byte> data, int offset)
        {
            var count = data.Count - offset - 1;
            var result = new byte[count];

            for (var i = 0; i < count; i++)
                result[i] = data[offset + i];

            return result;
        }

        #endregion
    }
}
