using HART.Reference;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HART.Helper
{
    /// <summary>
    /// Сожержит методы расширения для данных типа <see cref="UnitСodes"/>.
    /// </summary>
    public static class UnitСodesExt
    {
        /// <summary>
        /// Получить поле <see cref="DisplayAttribute.ShortName"/>
        /// </summary>
        /// <param name="item">Проверяемы элемент.</param>
        /// <returns></returns>
        public static string GetShortName(this UnitСodes item) => item
            .GetDisplayAttribute()?
            .FirstOrDefault(x => x.MemberName == "ShortName")
            .TypedValue.Value?.ToString() ?? string.Empty;

        /// <summary>
        /// Получить поле <see cref="DisplayAttribute.GroupName"/>
        /// </summary>
        /// <param name="item">Проверяемы элемент.</param>
        /// <returns></returns>
        public static string GetGroupName(this UnitСodes item) => item
            .GetDisplayAttribute()?
            .FirstOrDefault(x => x.MemberName == "GroupName")
            .TypedValue.Value?.ToString() ?? string.Empty;

        /// <summary>
        /// Получить поле <see cref="DisplayAttribute.Name"/>
        /// </summary>
        /// <param name="item">Проверяемы элемент.</param>
        /// <returns></returns>
        public static string GetFullName(this UnitСodes item) => item
            .GetDisplayAttribute()?
            .FirstOrDefault(x => x.MemberName == "Name")
            .TypedValue.Value?.ToString() ?? string.Empty;

        /// <summary>
        /// Получить атрибут типа <see cref="DisplayAttribute"/>.
        /// </summary>
        /// <param name="item">Проверяемы элемент.</param>
        /// <returns></returns>
        public static IList<CustomAttributeNamedArgument> GetDisplayAttribute(this UnitСodes item) => typeof(UnitСodes)
                .GetField($"{item}")?
                .CustomAttributes
                .FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute")?.NamedArguments;
    }
}
