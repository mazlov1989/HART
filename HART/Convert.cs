using System.Collections;
using System.Text;

namespace HART
{
    /// <summary>
    /// Содержит метода преобразование данных, передаваемых по протоколу HART, в массив байтов и обратно.
    /// </summary>
    public static class Convert
    {
        /// <summary>
        /// Преобразовать входные данные в массив байтов.
        /// <para>Поддерживаются следующие типы входных данных:</para>
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
        /// <typeparam name="T">Тип входных данных.</typeparam>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов.</returns>
        /// <exception cref="ArgumentException">Преобразование типа входных данных не поддерживается.</exception>
        public static byte[] ToByte<T>(T value) => value == null
                ? null
                : value switch
                {
                    byte by => new[] { by },
                    byte[] ba => ba,
                    string s => ToByte(s),
                    float f => ToByte(f),
                    double d => ToByte(d),
                    ushort us => ToByte(us),
                    uint ui => ToByte(ui),
                    int i => ToByte(i),
                    DateTime da => ToByte(da),
                    BitArray b => ToByte(b),
                    _ => throw new ArgumentException($"Преобразование из {typeof(T)} не поддерживается.")
                };

        /// <summary>
        /// Преобразовать массив байтов в тип данных <typeparamref name="T"/>.
        /// <para>Поддерживаются следующие типы выходных данных:</para>
        /// <list type="bullet">
        /// <item><see cref="string"/></item>
        /// <item><see cref="float"/></item>
        /// <item><see cref="double"/></item>
        /// <item><see cref="short"/></item>
        /// <item><see cref="ushort"/></item>
        /// <item><see cref="int"/></item>
        /// <item><see cref="uint"/></item>
        /// <item><see cref="DateTime"/></item>
        /// <item><see cref="BitArray"/></item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Тип выходных данных.</typeparam>
        /// <param name="value">Массив байтов исходных данных.</param>
        /// <returns>Данные типа <typeparamref name="T"/>.</returns>
        /// /// <exception cref="ArgumentException">Преобразование в заданный тип данных не поддерживается.</exception>
        /// /// <exception cref="ArgumentNullException"><paramref name="value"/> равен <see langword="null"/>.</exception>
        public static T FromByte<T>(byte[] value) => value == null
                ? throw new ArgumentNullException(nameof(value))
                : typeof(T).Name switch
                {
                    "String" => (T)(object)FromByteToString(value),
                    "Single" => (T)(object)FromByteToFloat(value),
                    "Double" => (T)(object)FromByteToDouble(value),
                    "UInt16" => (T)(object)FromByteToUInt16(value),
                    "Int16" => (T)(object)FromByteToInt16(value),
                    "UInt32" => (T)(object)FromByteToUInt32(value),
                    "Int32" => (T)(object)FromByteToInt32(value),
                    "DateTime" => (T)(object)FromByteToDate(value),
                    "BitArray" => (T)(object)FromByteToBitArray(value),
                    _ => throw new ArgumentException($"Преобразование в {typeof(T)} не поддерживается.")
                };


        /// <summary>
        /// Преобразовать <see cref="string"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данный для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(string value) => Encoding.ASCII.GetBytes(value);

        /// <summary>
        /// Преобразовать массив байтов в <see cref="string"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static string FromByteToString(IReadOnlyList<byte> value)
        {
            var result = string.Empty;
            var buffer = new ushort[4];
            var index = 0;
            var count = (ushort)(value.Count / 3);

            for (var step = 0; step < count; step++)
            {
                buffer[0] = (ushort)(value[index] >> 2);
                buffer[1] = (ushort)(((value[index] << 4) & 0x30) | (value[index + 1] >> 4));
                buffer[2] = (ushort)(((value[index + 1] << 2) & 0x3C) | (value[index + 2] >> 6));
                buffer[3] = (ushort)(value[index + 2] & 0x3F);
                index += 3;

                for (var i = 0; i < 4; i++)
                    result += (char)(buffer[i] | (ushort)(((buffer[i] & 0x20) << 1) ^ 0x40));
            }

            return result.Trim(' ');
        }

        /// <summary>
        /// Преобразовать <see cref="float"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(float value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Преобразовать массив байтов в <see cref="float"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static float FromByteToFloat(byte[] value) => BitConverter.ToSingle(value.Reverse(), 0);

        /// <summary>
        /// Преобразовать <see cref="double"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(double value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Преобразовать массив байтов в <see cref="double"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static double FromByteToDouble(byte[] value) => BitConverter.ToDouble(value.Reverse(), 0);

        /// <summary>
        /// Преобразовать <see cref="ushort"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(ushort value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Преобразовать массив байтов в <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static ushort FromByteToUInt16(byte[] value) => BitConverter.ToUInt16(value.Reverse(), 0);

        /// <summary>
        /// Преобразовать массив байтов в <see cref="short"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static short FromByteToInt16(byte[] value) => System.Convert.ToInt16(FromByteToUInt16(value));

        /// <summary>
        /// Преобразовать <see cref="uint"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(uint value)
        {
            if (value > 16777215)
                throw new ArgumentOutOfRangeException(nameof(value), "Максимально допустимое значение равно 16777215");

            var b = BitConverter.GetBytes(value);
            var result = new byte[3];

            for (var i = 0; i < 3; i++)
                result[i] = b[i];

            return result;
        }

        /// <summary>
        /// Преобразовать массив байтов в <see cref="uint"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static uint FromByteToUInt32(byte[] value)
        {
            var nByte = new byte[4];
            value.Reverse().CopyTo(nByte, 0);

            return BitConverter.ToUInt32(nByte, 0);
        }

        /// <summary>
        /// Преобразовать <see cref="uint"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(int value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Преобразовать массив байтов в <see cref="int"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static int FromByteToInt32(byte[] value)
        {
            var nByte = new byte[4];
            value.Reverse().CopyTo(nByte, 0);
            return BitConverter.ToInt32(value);
        }

        /// <summary>
        /// Преобразовать <see cref="DateTime"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(DateTime value)
        {
            var bDay = BitConverter.GetBytes(value.Day);
            var bMonth = BitConverter.GetBytes(value.Month);
            var bYear = BitConverter.GetBytes(value.Year - 1900);

            return new[] { bDay[0], bMonth[0], bYear[0] };
        }

        /// <summary>
        /// Преобразовать массив байтов в <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static DateTime FromByteToDate(byte[] value)
        {
            var day = BitConverter.ToInt32(new byte[] { value[0], 0, 0, 0 }, 0);
            var month = BitConverter.ToInt32(new byte[] { value[1], 0, 0, 0 }, 0);
            var year = BitConverter.ToInt32(new byte[] { value[2], 0, 0, 0 }, 0);

            return new DateTime(year + 1900, month, day);
        }

        /// <summary>
        /// Преобразовать <see cref="BitArray"/> в массив байтов.
        /// </summary>
        /// <param name="value">Данные для преобразования.</param>
        /// <returns>Массив байтов</returns>
        private static byte[] ToByte(BitArray value)
        {
            if (value.Count > 8)
                throw new ArgumentOutOfRangeException(nameof(value), "Переполнение массива значение. Допускается только 8 элементов в массиве.");

            var result = new byte[1];

            value.CopyTo(result, 0);

            return result;
        }

        /// <summary>
        /// Преобразовать массив байтов в <see cref="BitArray"/>.
        /// </summary>
        /// <param name="value">Массив байтов для преобразования.</param>
        /// <returns></returns>
        private static BitArray FromByteToBitArray(byte[] value)
        {
            if (value.Length > 1)
                throw new ArgumentOutOfRangeException(nameof(value), "Переполнение массива значение. Допускается только 1 байт данных.");

            return new BitArray(value.Reverse());
        }

        /// <summary>
        /// Изменяет порядок элементов во всем массиве байт на обратный.
        /// </summary>
        /// <param name="source">Исходный массив</param>
        /// <returns></returns>
        private static byte[] Reverse(this byte[] source)
        {
            var reverse = new byte[source.Length];
            source.CopyTo(reverse, 0);
            Array.Reverse(reverse);

            return reverse;
        }
    }
}
