using System.ComponentModel.DataAnnotations;

namespace HART
{
    /// <summary>
    /// Варианты формата фрейма.
    /// </summary>
    public enum FrameFormats
    {
        /// <summary>
        /// Короткий.
        /// </summary>
        [Display(Name = "Короткий", Description = "Короткий формат кадра", Order = 1)]
        Short,

        /// <summary>
        /// Длинный.
        /// </summary>
        [Display(Name = "Длинный", Description = "Длинный формат кадра", Order = 2)]
        Long
    }
}
