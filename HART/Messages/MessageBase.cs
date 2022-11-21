using System.Collections;

namespace HART.Messages
{
    /// <summary>
    /// Базовый абстрактный класс описывающий сообщения передаваемые по протоколу HART. 
    /// </summary>
    public abstract class MessageBase
    {
        /// <summary>
        /// Символ преамбулы.
        /// </summary>
        public const byte PreambleSymbol = 0xFF;
        
        /// <summary>
        /// Количество символов в преамбуле.
        /// </summary>
        public int Preamble { get; set; } = 8;

        /// <summary>
        /// Адрес устройства.
        /// </summary>
        protected readonly byte[] Address;
        
        /// <summary>
        /// Формат кадра.
        /// </summary>
        protected FrameFormats FrameFormat { get; init; }

        /// <summary>
        /// Команда.
        /// </summary>
        public int Command { get; set; }
        
        /// <summary>
        /// Данные.
        /// </summary>
        protected byte[] Data;

        /// <summary>
        /// Создать сообщение.
        /// </summary>
        /// <param name="address">Адрес slave-устройства.</param>
        protected MessageBase(byte[] address)
        {
            Address = address;
        }

        /// <summary>
        /// Добавить данные для отправки.
        /// </summary>
        public void AddDate(byte[] value) => Data = value;

        /// <summary>
        /// Преобразовать передаваемые данные в массив байтов.
        /// <para>Поддерживаются следующие типы выходных данных:</para>
        /// <list type="bullet">
        /// <item><see cref="string"/></item>
        /// <item><see cref="float"/></item>
        /// <item><see cref="double"/></item>
        /// <item><see cref="ushort"/></item>
        /// <item><see cref="uint"/></item>
        /// <item><see cref="DateTime"/></item>
        /// <item><see cref="BitArray"/></item>
        /// </list>
        /// </summary>
        public void AddDate<T>(T value) => Data = Convert.ToByte(value);

        /// <summary>
        /// Получить данные в формате <typeparamref name="T"/>.
        /// <para>Поддерживаются следующие типы выходных данных:</para>
        /// <list type="bullet">
        /// <item><see cref="string"/></item>
        /// <item><see cref="float"/></item>
        /// <item><see cref="double"/></item>
        /// <item><see cref="ushort"/></item>
        /// <item><see cref="uint"/></item>
        /// <item><see cref="DateTime"/></item>
        /// <item><see cref="BitArray"/></item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Тип выходных данных.</typeparam>
        public T GetDate<T>() => typeof(T).Name switch
        {
            "String" => (T)(object)Convert.FromByte<string>(Data),
            "Single" => (T)(object)Convert.FromByte<float>(Data),
            "Double" => (T)(object)Convert.FromByte<double>(Data),
            "UInt16" => (T)(object)Convert.FromByte<ushort>(Data),
            "UInt32" => (T)(object)Convert.FromByte<uint>(Data),
            "DateTime" => (T)(object)Convert.FromByte<DateTime>(Data),
            "BitArray" => (T)(object)Convert.FromByte<BitArray>(Data),
            _ => (T)(object)Data
        };

        /// <summary>
        /// Получить данные.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<byte> GetDate() => Data;

        /// <summary>
        /// Получить адрес устройства.
        /// </summary>
        /// <returns></returns>
        public byte[] GetAddress() => Address;
    }
}
