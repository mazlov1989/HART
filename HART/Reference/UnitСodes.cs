using System.ComponentModel.DataAnnotations;

namespace HART.Reference
{
    /// <summary>
    /// Коды единиц измерения.
    /// </summary>
    public enum UnitСodes
    {
        [Display(ShortName = "", GroupName = "Давление", Name = "Дюймов воды при температуре 68°F")]
        InchesOfWaterAt68DegreesF = 1,

        [Display(ShortName = "inHg", GroupName = "Давление", Name = "Дюймов ртутного столба при 0°C")]
        InchesOfMercuryAt0DegreesC = 2,

        [Display(ShortName = "", GroupName = "Давление", Name = "Футов воды при температуре 68°F")]
        FeetOfWaterAt68DegreesF = 3,

        [Display(ShortName = "", GroupName = "Давление", Name = "Миллиметров воды при температуре 68°F")]
        MillimetersOfWaterAt68DegreesF = 4,

        [Display(ShortName = "мм рт.ст.", GroupName = "Давление", Name = "Миллиметров ртутного столба при 0°C")]
        MillimetersOfMercuryAt0DegreesC = 5,

        [Display(ShortName = "lb/oz²", GroupName = "Давление", Name = "Фунтов на квадратный дюйм")]
        PoundsPerSquareInch = 6,

        [Display(ShortName = "бар", GroupName = "Давление", Name = "Бары")]
        Bars = 7,

        [Display(ShortName = "мбар", GroupName = "Давление", Name = "Миллибары")]
        Millibars = 8,

        [Display(ShortName = "гс/см²", GroupName = "Давление", Name = "Грамм на квадратный сантиметр")]
        GramsPerSquareCentimeter = 9,

        [Display(ShortName = "кгс/см²", GroupName = "Давление", Name = " Килограмм на квадратный сантиметр")]
        KilogramsPerSquareCentimeter = 10,

        [Display(ShortName = "Па", GroupName = "Давление", Name = "Паскали")]
        Pascals = 11,

        [Display(ShortName = "кПа", GroupName = "Давление", Name = "Килопаскали")]
        Kilopascals = 12,

        [Display(ShortName = "торр", GroupName = "Давление", Name = "Торр")]
        Torr = 13,

        [Display(ShortName = "атм", GroupName = "Давление", Name = "Атмосферы")]
        Atmospheres = 14,

        [Display(ShortName = "lb³/мин", GroupName = "Объемный расход", Name = "Кубический фут в минуту")]
        CubicFeetPerMinute = 15,

        [Display(ShortName = "gl/мин", GroupName = "Объемный расход", Name = "Галлоны в минуту")]
        GallonsPerMinute = 16,

        [Display(ShortName = "л/мин", GroupName = "Объемный расход", Name = "Литры в минуту")]
        LitersPerMinute = 17,

        [Display(ShortName = "imp gal/мин", GroupName = "Объемный расход", Name = "Имперские галлоны в минуту")]
        ImperialGallonsPerMinute = 18,

        [Display(ShortName = "м³/ч", GroupName = "Объемный расход", Name = "Кубический метр в час")]
        CubicMeterPerHour = 19,

        [Display(ShortName = "lb/сек", GroupName = "Скорость", Name = "Футы в секунду")]
        FeetPerSecond = 20,

        [Display(ShortName = "м/с", GroupName = "Скорость", Name = "Метры в секунду")]
        MetersPerSecond = 21,

        [Display(ShortName = "gl/сек", GroupName = "Объемный расход", Name = "Галлоны в секунду")]
        GallonsPerSecond = 22,

        [Display(ShortName = "Imperial", GroupName = "Объемный расход", Name = "Миллион галлонов в день")]
        MillionGallonsPerDay = 23,

        [Display(ShortName = "л/с", GroupName = "Объемный расход", Name = "Литры в секунду")]
        LitersPerSecond = 24,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Миллион литров в день")]
        MillionLitersPerDay = 25,

        [Display(ShortName = "lb³/сек", GroupName = "Объемный расход", Name = "Кубические футы в секунду")]
        CubicFeetPerSecond = 26,

        [Display(ShortName = "lb³/дн", GroupName = "Объемный расход", Name = "Кубические футы в день")]
        CubicFeetPerDay = 27,

        [Display(ShortName = "м³/сек", GroupName = "Объемный расход", Name = "Кубические метры в секунду")]
        CubicMetersPerSecond = 28,

        [Display(ShortName = "м³/дн", GroupName = "Объемный расход", Name = "Кубические метры в день")]
        CubicMetersPerDay = 29,

        [Display(ShortName = "imp gal/ч", GroupName = "Объемный расход", Name = "Имперские галлоны в час")]
        ImperialGallonsPerHour = 30,

        [Display(ShortName = "imp gal/дн", GroupName = "Объемный расход", Name = "Имперские галлоны в день")]
        ImperialGallonsPerDay = 31,

        [Display(ShortName = "°C", GroupName = "Температура", Name = "Градусов Цельсия")]
        DegreesCelsius = 32,

        [Display(ShortName = "°F", GroupName = "Температура", Name = "Градусов по Фаренгейту")]
        DegreesFahrenheit = 33,

        [Display(ShortName = "", GroupName = "Температура", Name = "Степени Ренкина")]
        DegreesRankine = 34,

        [Display(ShortName = "K", GroupName = "Температура", Name = "Кельвин")]
        Kelvin = 35,

        [Display(ShortName = "мВ", GroupName = "ЭДС", Name = "Милливолты")]
        Millivolts = 36,

        [Display(ShortName = "Ом", GroupName = "Сопротивление", Name = "Ом")]
        Ohms = 37,

        [Display(ShortName = "Гц", GroupName = "Частота", Name = "Герц")]
        Hertz = 38,

        [Display(ShortName = "мА", GroupName = "Сила тока", Name = "Миллиампер")]
        Milliamperes = 39,

        [Display(ShortName = "gl", GroupName = "Объем", Name = "Галлоны")]
        Gallons = 40,

        [Display(ShortName = "л", GroupName = "Объем", Name = "Литры")]
        Liters = 41,

        [Display(ShortName = "imp gal", GroupName = "Объем", Name = "Имперские галлоны")]
        ImperialGallons = 42,

        [Display(ShortName = "м³", GroupName = "Объем", Name = "Кубические метры")]
        CubicMeters = 43,

        [Display(ShortName = "lb", GroupName = "Длина", Name = "Футы")]
        Feet = 44,

        [Display(ShortName = "м", GroupName = "Длина", Name = "Метры")]
        Meters = 45,

        [Display(ShortName = "br", GroupName = "Объем", Name = "Баррель")]
        Barrels = 46,

        [Display(ShortName = "oz", GroupName = "Длина", Name = "Дюймы")]
        Inches = 47,

        [Display(ShortName = "см", GroupName = "Длина", Name = "Сантиметры")]
        Centimeters = 48,

        [Display(ShortName = "мм", GroupName = "Длина", Name = "Миллиметры")]
        Millimeters = 49,

        [Display(ShortName = "мин", GroupName = "Время", Name = "Минуты")]
        Minutes = 50,

        [Display(ShortName = "сек", GroupName = "Время", Name = "Секунды")]
        Seconds = 51,

        [Display(ShortName = "ч", GroupName = "Время", Name = "Часы")]
        Hours = 52,

        [Display(ShortName = "дн", GroupName = "Время", Name = "Дни")]
        Days = 53,

        [Display(ShortName = "сСт", GroupName = "Вязкость", Name = "Сантистокс")]
        Centistokes = 54,

        [Display(ShortName = "сП", GroupName = "Вязкость", Name = "Сантипуза")]
        Centipoise = 55,

        [Display(ShortName = "мкСм", GroupName = "Проводимость", Name = "микросименс")]
        Microsiemens = 56,

        [Display(ShortName = "%", GroupName = "Аналитические", Name = "процент")]
        Percent = 57,

        [Display(ShortName = "В", GroupName = "ЭДС", Name = "Вольт")]
        Volts = 58,

        [Display(ShortName = "pH", GroupName = "Аналитические", Name = "pH")]
        Ph = 59,

        [Display(ShortName = "г", GroupName = "Масса", Name = "граммы")]
        Grams = 60,

        [Display(ShortName = "кг", GroupName = "Масса", Name = "килограммы")]
        Kilograms = 61,

        [Display(ShortName = "т", GroupName = "Масса", Name = "метрических тонн")]
        MetricTons = 62,

        [Display(ShortName = "lb", GroupName = "Масса", Name = "фунты")]
        Pounds = 63,

        [Display(ShortName = "short ton", GroupName = "Масса", Name = "короткие тонны")]
        ShortTons = 64,

        [Display(ShortName = "long ton", GroupName = "Масса", Name = "длинные тонны")]
        LongTons = 65,

        [Display(ShortName = "мСм/см", GroupName = "Проводимость", Name = "миллисименс на сантиметр")]
        MilliSiemensPerCentimeter = 66,

        [Display(ShortName = "мкСм/см", GroupName = "Проводимость", Name = "микросименс на сантиметр")]
        MicroSiemensPerCentimeter = 67,

        [Display(ShortName = "Н", GroupName = "Сила", Name = "Ньютон")]
        Newton = 68,

        [Display(ShortName = "Нм", GroupName = "Энергия (работа)", Name = "Ньютон Метр")]
        NewtonMeter = 69,

        [Display(ShortName = "г/сек", GroupName = "Массовый расход", Name = "граммы в секунду")]
        GramsPerSecond = 70,

        [Display(ShortName = "г/мин", GroupName = "Массовый расход", Name = "граммы в минуту")]
        GramsPerMinute = 71,

        [Display(ShortName = "г/ч", GroupName = "Массовый расход", Name = "граммы в час")]
        GramsPerHour = 72,

        [Display(ShortName = "кг/сек", GroupName = "Массовый расход", Name = "килограммы в секунду")]
        KilogramsPerSecond = 73,

        [Display(ShortName = "кг/мин", GroupName = "Массовый расход", Name = "килограммы в минуту")]
        KilogramsPerMinute = 74,

        [Display(ShortName = "кг/ч", GroupName = "Массовый расход", Name = "килограммы в час")]
        KilogramsPerHour = 75,

        [Display(ShortName = "кг/дн", GroupName = "Массовый расход", Name = "килограммы в день")]
        KilogramsPerDay = 76,

        [Display(ShortName = "т/м", GroupName = "Массовый расход", Name = "метрические тонны в минуту")]
        MetricTonsPerMinute = 77,

        [Display(ShortName = "т/ч", GroupName = "Массовый расход", Name = "метрические тонны в час")]
        MetricTonsPerHour = 78,

        [Display(ShortName = "т/дн", GroupName = "Массовый расход", Name = "метрические тонны в день")]
        MetricTonsPerDay = 79,

        [Display(ShortName = "lb/сек", GroupName = "Массовый расход", Name = "фунты в секунду")]
        PoundsPerSecond = 80,

        [Display(ShortName = "lb/мин", GroupName = "Массовый расход", Name = "фунты в минуту")]
        PoundsPerMinute = 81,

        [Display(ShortName = "lb/ч", GroupName = "Массовый расход", Name = "фунты в час")]
        PoundsPerHour = 82,

        [Display(ShortName = "lb/дн", GroupName = "Массовый расход", Name = "фунты в день")]
        PoundsPerDay = 83,

        [Display(ShortName = "short ton/мин", GroupName = "Массовый расход", Name = "короткие тонны в минуту")]
        ShortTonsPerMinute = 84,

        [Display(ShortName = "short ton/ч", GroupName = "Массовый расход", Name = "короткие тонны в час")]
        ShortTonsPerHour = 85,

        [Display(ShortName = "short ton/дн", GroupName = "Массовый расход", Name = "короткие тонны в день")]
        ShortTonsPerDay = 86,

        [Display(ShortName = "long ton/ч", GroupName = "Массовый расход", Name = "Длинные тонны в час")]
        LongTonsPerHour = 87,

        [Display(ShortName = "long ton/дн", GroupName = "Массовый расход", Name = "Длинные тонны в день")]
        LongTonsPerDay = 88,

        [Display(ShortName = "даТерм", GroupName = "Энергия (работа)", Name = "Дека Терм")]
        DekaTherm = 89,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "единицы удельного веса")]
        SpecificGravityUnits = 90,

        [Display(ShortName = "г/см³", GroupName = "Масса на объем", Name = "граммы на кубический сантиметр")]
        GramsPerCubicCentimeter = 91,

        [Display(ShortName = "кг/м³", GroupName = "Масса на объем", Name = "килограммы на кубический метр")]
        KilogramsPerCubicMeter = 92,

        [Display(ShortName = "lb/gl", GroupName = "Масса на объем", Name = "фунтов на галлон")]
        PoundsPerGallon = 93,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "фунтов на кубический фут")]
        PoundsPerCubicFoot = 94,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "граммы на миллилитр")]
        GramsPerMilliliter = 95,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "килограммы на литр")]
        KilogramsPerLiter = 96,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "граммы на литр")]
        GramsPerLiter = 97,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "фунты на кубический дюйм")]
        PoundsPerCubicInch = 98,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "короткие тонны на кубический ярд")]
        ShortTonsPerCubicYard = 99,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "градусы твадделла")]
        DegreesTwaddell = 100,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "градусов по шкале Брикса")]
        DegreesBrix = 101,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "градус Боме тяжелый")]
        DegreesBaumeHeavy = 102,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "градус Боме легкий")]
        DegreesBaumeLight = 103,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "градусы API")]
        DegreesApi = 104,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "процент твердых веществ на вес")]
        PercentSolidsPerWeight = 105,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "процент твердых веществ на объем")]
        PercentSolidsPerVolume = 106,

        [Display(ShortName = "", GroupName = "Объем на массу", Name = "Степень баллинг")]
        DegreesBalling = 107,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "Пруф на объем")]
        ProofPerVolume = 108,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "Пруф на массу")]
        ProofPerMass = 109,

        [Display(ShortName = "", GroupName = "Объем", Name = "бушели")]
        Bushels = 110,

        [Display(ShortName = "", GroupName = "Объем", Name = "Кубические ярды")]
        CubicYards = 111,

        [Display(ShortName = "", GroupName = "Объем", Name = "кубический фут")]
        CubicFeet = 112,

        [Display(ShortName = "", GroupName = "Объем", Name = "Кубические дюймы")]
        CubicInches = 113,

        [Display(ShortName = "", GroupName = "Скорость", Name = "дюймы в секунду")]
        InchesPerSecond = 114,

        [Display(ShortName = "", GroupName = "Скорость", Name = "дюймы в минуту")]
        InchesPerMinute = 115,

        [Display(ShortName = "", GroupName = "Скорость", Name = "футы в минуту")]
        FeetPerMinute = 116,

        [Display(ShortName = "", GroupName = "Угловая скорость", Name = "градусы в секунду")]
        DegreesPerSecond = 117,

        [Display(ShortName = "", GroupName = "Угловая скорость", Name = "оборотов в секунду")]
        RevolutionsPerSecond = 118,

        [Display(ShortName = "", GroupName = "Угловая скорость", Name = "оборотов в минуту")]
        RevolutionsPerMinute = 119,

        [Display(ShortName = "", GroupName = "Скорость", Name = "метры в час")]
        MetersPerHour = 120,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Нормальный кубический метр в час система MKS")]
        NormalCubicMeterPerHourMksSystem = 121,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Нормальный литр в час система MKS")]
        NormalLiterPerHourMksSystem = 122,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Стандартные Кубические футы в минуту в США система")]
        StandardCubicFeetPerMinuteUsSystem = 123,

        [Display(ShortName = "", GroupName = "Объем", Name = "BBL Liq 1 Жидкая ствола равна 31,5 галлонов США")]
        BblLiq1 = 124,

        [Display(ShortName = "oz", GroupName = "Масса", Name = "унция")]
        Ounce = 125,

        [Display(ShortName = "", GroupName = "Энергия (работа)", Name = "фут-фунт силы")]
        FootPoundForce = 126,

        [Display(ShortName = "", GroupName = "Мощность", Name = "Кило Ватт")]
        KiloWatt = 127,

        [Display(ShortName = "", GroupName = "Энергия (работа)", Name = "Кило -ватт час")]
        KiloWattHour = 128,

        [Display(ShortName = "", GroupName = "Мощность", Name = "Лошадиные силы")]
        Horsepower = 129,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Кубические футы в час")]
        CubicFeetPerHour = 130,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Кубические метры в минуту")]
        CubicMetersPerMinute = 131,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "бочки в секунду 1 баррель равна 42 галлона США")]
        BarrelsPerSecond = 132,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "бочки в минуту 1 баррель равна 42 галлона США")]
        BarrelsPerMinute = 133,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "бочки в час 1 баррель равна 42 галлона США")]
        BarrelsPerHour = 134,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "бочки в день 1 баррель равна 42 галлона США")]
        BarrelsPerDay = 135,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "галлоны в час")]
        GallonsPerHour = 136,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "Имперские галлоны в секунду")]
        ImperialGallonsPerSecond = 137,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "литры в час")]
        LitersPerHour = 138,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "частей на миллион")]
        PartsPerMillion = 139,

        [Display(ShortName = "", GroupName = "Мощность", Name = "мегалория в час 1 калория = 4,184 джоулз")]
        MegaCaloriePerHour = 140,

        [Display(ShortName = "", GroupName = "Мощность", Name = "мега джоул в час")]
        MegaJoulePerHour = 141,

        [Display(ShortName = "Btu/h", GroupName = "Мощность", Name = "Британская тепловая единица в час 1BTU = 0,2519958 ккала энергии")]
        BritishThermalUnitPerHour = 142,

        [Display(ShortName = "", GroupName = "Угол", Name = "градусы")]
        Degrees = 143,

        [Display(ShortName = "", GroupName = "Угол", Name = "радиан")]
        Radian = 144,

        [Display(ShortName = "", GroupName = "Давление", Name = "дюймы воды при 60 градусов по Фа")]
        InchesOfWaterAt60DegreesF = 145,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "Микрограммы на литр")]
        MicrogramsPerLiter = 146,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "микрограммы на кубический метр")]
        MicrogramsPerCubicMeter = 147,

        [Display(ShortName = "", GroupName = "Масса на объем", Name = "процент согласованности")]
        PercentConsistency = 148,

        [Display(ShortName = "", GroupName = "Объем на объем", Name = "Объем процент")]
        VolumePercent = 149,

        [Display(ShortName = "", GroupName = "Аналитические", Name = "Процентное качество пар")]
        PercentSteamQuality = 150,

        [Display(ShortName = "lb⁶⁰", GroupName = "Длина", Name = "Футы в шестидесятых")]
        FeetInSixteeenths = 151,

        [Display(ShortName = "", GroupName = "Объем на массу", Name = "Кубические футы за фунт")]
        CubicFeetPerPound = 152,

        [Display(ShortName = "", GroupName = "Емкость", Name = "Пикофарадс")]
        Picofarads = 153,

        [Display(ShortName = "", GroupName = "Объем на объем", Name = "Прокладка на литр")]
        MililitersPerLiter = 154,

        [Display(ShortName = "", GroupName = "Объем на объем", Name = "Микролитры на литр")]
        MicrolitersPerLiter = 155,

        [Display(ShortName = "", GroupName = "Аналитические", Name = "процент Платон")]
        PercentPlato = 160,

        [Display(ShortName = "", GroupName = "Аналитические", Name = "процент более низкого уровня взрыва")]
        PercentLowerExplosionLevel = 161,

        [Display(ShortName = "", GroupName = "Энергия (работа)", Name = "мегалория")]
        MegaCalorie,

        [Display(ShortName = "", GroupName = "Сопротивление", Name = "Комс")]
        Kohms = 163,

        [Display(ShortName = "", GroupName = "Энергия (работа)", Name = "Мега Джоул")]
        MegaJoule = 164,

        [Display(ShortName = "Btu", GroupName = "Энергия (работа)", Name = "Британская тепловая единица")]
        BritishThermalUnit = 165,

        [Display(ShortName = "", GroupName = "Объем", Name = "система нормального кубического метра MKS")]
        NormalCubicMeterMksSystem = 166,

        [Display(ShortName = "", GroupName = "Объем", Name = "система нормальной литр MKS")]
        NormalLiterMksSystem = 167,

        [Display(ShortName = "", GroupName = "Объем", Name = "Кубический фут (Стандартная система США)")]
        StandardCubicFeetUsSystem = 168,

        [Display(ShortName = "", GroupName = "Концентрация", Name = "части на миллиард")]
        PartsPerBillion = 169,

        [Display(ShortName = "", GroupName = "Давление", Name = "сантиметры воды при 4 °C")]
        CentimetersOfWaterAt4DegreesC = 170,

        [Display(ShortName = "", GroupName = "Давление", Name = "метры воды при 4 °C")]
        MetersOfWaterAt4DegreesC = 171,

        [Display(ShortName = "", GroupName = "Давление", Name = "сантиметры ртути при 0 °C")]
        CentimetersOfMercuryAt0DegreesC = 172,

        [Display(ShortName = "", GroupName = "Давление", Name = "фунты на квадратный фут")]
        PoundsPerSquareFoot = 173,

        [Display(ShortName = "", GroupName = "Давление", Name = "Гектопаскалы")]
        HectoPascals = 174,

        [Display(ShortName = "", GroupName = "Давление", Name = "фунты на квадратный дюйм абсолют")]
        PoundsPerSquareInchAbsolute = 175,

        [Display(ShortName = "", GroupName = "Давление", Name = "килограммы на квадратный метр")]
        KilogramsPerSquareMeter = 176,

        [Display(ShortName = "", GroupName = "Давление", Name = "Ноги вода 4 °C")]
        FeetWater4DegreesC = 177,

        [Display(ShortName = "", GroupName = "Давление", Name = "ноги вода при 60 °F")]
        FeetWaterAt60DegreesF = 178,

        [Display(ShortName = "", GroupName = "Давление", Name = "метры ртути при 0 °C")]
        MetersOfMercuryAt0DegreesC = 179,

        [Display(ShortName = "", GroupName = "Объемный расход", Name = "галлоны в день")]
        GallonsPerDay = 235,

        [Display(ShortName = "", GroupName = "Объем", Name = "Гектолитры")]
        Hectoliters = 236,

        [Display(ShortName = "МПа", GroupName = "Давление", Name = "Мегапаскалы")]
        Megapascals = 237,

        [Display(ShortName = "", GroupName = "Давление", Name = "Дюймы воды при 4 °C")]
        InchesOfWaterAt4DegreesC = 238,

        [Display(ShortName = "", GroupName = "Давление", Name = "Миллиметры воды при 4 °C")]
        MillimetersOfWaterAt4DegreesC = 239,

        [Display(ShortName = "", GroupName = "Общий", Name = "Специализированный производителем")]
        Custom = 240,

        [Display(ShortName = "", GroupName = "Общий", Name = "Не используется")]
        NotUsed = 250,

        [Display(ShortName = "", GroupName = "Общий", Name = "Отсутствует")]
        None = 251,

        [Display(ShortName = "", GroupName = "Общий", Name = "Неизвестный")]
        Unknown = 252,

        [Display(ShortName = "", GroupName = "Общий", Name = "Специальный")]
        Special = 253
    }
}