namespace HART.Messages
{
    /// <summary>
    /// Содержит описания возможных ошибок связи.
    /// </summary>
    internal static class CommunicationErrorList
    {
        private const string NoError = "Ошибки нет.";

        private const string VerticalParityError = "Ошибка четности по вертикали – Проверка четности одного или нескольких байт, полученных от устройства, некорректна.";

        private const string OverflowError = "Ошибка переполнения – По крайней мере один байт данных в буфере универсального асинхронного приемника/передатчика был переписан до того, как был прочитан.";

        private const string FrameError = "Ошибка формирования кадра – Стоп-бит одного или более байт, полученных устройством, не совпадает  с байтом продольной четности в конце сообщения.";

        private const string HorizontalParityError = "Ошибка четности по горизонтали – Продольный контроль четности, выполненный устройством, не совпадает с байтом продольной четности в конце сообщения.";

        private const string ReceiverBufferOverflow = "Переполнение буфера приемника – Сообщение было слишком длинным для буфера устройства.";

        private const string Undefined = "Не определено – непредвиденная ошибка.";

        /// <summary>
        /// Получить описание ошибки связи.
        /// </summary>
        /// <param name="errorCode">Первый байт полученного кода отклика.</param>
        /// <returns>Описание ошибки связи.</returns>
        internal static string GetErrorDescription(byte errorCode)
        {
            switch (errorCode)
            {
                case 0b0:
                    return NoError;
                case 0b11000000:
                    return VerticalParityError;
                case 0b10100000:
                    return OverflowError;
                case 0b10010000:
                    return FrameError;
                case 0b10001000:
                    return HorizontalParityError;
                case 0b10000010:
                    return ReceiverBufferOverflow;
                case 0b10000001:
                    return Undefined;
            }

            return Undefined;
        }
    }
}
