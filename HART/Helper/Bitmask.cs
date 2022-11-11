using System.Collections;

namespace HART.Helper
{
    /// <summary>
    /// Реализует модель битовой макси.
    /// </summary>
    public class Bitmask
    {
        private readonly bool[] _mask;
        private readonly int _byteCount;

        /// <summary>
        /// Создать новый экземпляр класса <see cref="Bitmask"/>
        /// </summary>
        /// <param name="byteCount">Количество байт</param>
        public Bitmask(int byteCount)
        {
            if (byteCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(byteCount), "Количество байт должно быть больше 0");

            _byteCount = byteCount;
            _mask = new bool[_byteCount * 8];
        }

        /// <summary>
        /// Установить флаг по указанному индексу.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="index">Индекс.</param>
        public void SetFlag(bool value, int index)
        {
            if (index < 0 || index >= _mask.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс за пределами диапазона");

            _mask[index] = value;
        }

        /// <summary>
        /// Получить битовую маску.
        /// </summary>
        /// <returns></returns>
        public byte[] Get()
        {
            var d = new BitArray(_mask);
            var result = new byte[_byteCount];
            d.CopyTo(result, 0);

            return result;
        }
    }
}
