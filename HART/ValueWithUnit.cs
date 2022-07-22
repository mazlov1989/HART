using HART.Helper;
using HART.Reference;

namespace HART
{
    /// <summary>
    /// Реализует значение с единицей измерения.
    /// </summary>
    public struct ValueWithUnit<T>
    {
        /// <summary>
        /// Величина.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Единицы измерения.
        /// </summary>
        public UnitСodes Unit { get; set; }

        /// <summary>
        /// Создать новое значение
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="unit">Единицы измерения.</param>
        public ValueWithUnit(T value, UnitСodes unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Получить полное наименование единицы измерения.
        /// </summary>
        /// <returns></returns>
        public string GetUnitsFullName() => Unit.GetFullName();

        /// <summary>
        /// Получить сокращенное наименование единицы измерения.
        /// </summary>
        /// <returns></returns>
        public string GetUnitsShortName() => Unit.GetShortName();

        /// <summary>
        /// Получить наименование категории единицы измерения.
        /// </summary>
        /// <returns></returns>
        public string GetUnitGroupName() => Unit.GetGroupName();

        /// <inheritdoc/>
        public override string ToString() => $"{Value} {Unit.GetShortName()}";
    }
}
