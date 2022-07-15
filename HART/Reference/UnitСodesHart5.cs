namespace HART.Reference
{
    /// <summary>
    /// Коды единиц измерения для HART версии 5 и более ранних версий.
    /// </summary>
    public enum UnitСodesHart5
    {
        /*
         1	inches of water at 68 degrees F	Pressure	
        2	inches of mercury at 0 degrees C	Pressure	
        3	feet of water at 68 degrees F	Pressure	
        4	millimeters of water at 68 degrees F	Pressure	
        5	millimeters of mercury at 0 degrees C	Pressure	
        6	pounds per square inch	Pressure	
        7	bars	Pressure	
        8	millibars	Pressure	
        9	grams per square centimeter	Pressure	
        10	kilograms per square centimeter	Pressure	
        11	pascals	Pressure	
        12	kilopascals	Pressure	
        13	torr	Pressure	
        14	atmospheres	Pressure	
        15	cubic feet per minute	Volumetric Flow	
        16	gallons per minute	Volumetric Flow	
        17	liters per minute	Volumetric Flow	
        18	imperial gallons per minute	Volumetric Flow	
        19	cubic meter per hour	Volumetric Flow	
        20	feet per second	Velocity	
        21	meters per second	Velocity	
        22	gallons per second	Volumetric Flow	
        23	million gallons per day	Volumetric Flow	
        24	liters per second	Volumetric Flow	
        25	million liters per day	Volumetric Flow	
        26	cubic feet per second	Volumetric Flow	
        27	cubic feet per day	Volumetric Flow	
        28	cubic meters per second	Volumetric Flow	
        29	cubic meters per day	Volumetric Flow	
        30	imperial gallons per hour	Volumetric Flow	
        31	imperial gallons per day	Volumetric Flow	
        32	Degrees Celsius	Temperature	
        33	Degrees Fahrenheit	Temperature	
        34	Degrees Rankine	Temperature	
        35	Kelvin	Temperature	
        36	millivolts	Electromagnetic Unit of Electric Potential	
        37	ohms	Electromagnetic Unit of Resistance	
        38	hertz	Miscellaneous	
        39	milliamperes	Electromagnetic Unit of Electric Potential	
        40	gallons	Volume	
        41	liters	Volume	
        42	imperial gallons	Volume	
        43	cubic meters	Volume	
        44	feet	Length	
        45	meters	Length	
        46	barrels 1 barrel equals 42 U.S. gallons	Volume	
        47	inches	Length	
        48	centimeters	Length	
        49	millimeters	Length	
        50	minutes	Time	
        51	seconds	Time	
        52	hours	Time	
        53	days	Time	
        54	centistokes	Viscosity	
        55	centipoise	Viscosity	
        56	microsiemens	Miscellaneous	
        57	percent	Miscellaneous	
        58	volts	Electromagnetic Unit of Electric Potential	
        59	pH	Miscellaneous	
        60	grams	Mass	
        61	kilograms	Mass	
        62	metric tons	Mass	
        63	pounds	Mass	
        64	short tons	Mass	
        65	long tons	Mass	
        66	milli siemens per centimeter	Miscellaneous	
        67	micro siemens per centimeter	Miscellaneous	
        68	newton	Miscellaneous	
        69	newton meter	Energy (includes Work)	
        70	grams per second	Mass Flow	
        71	grams per minute	Mass Flow	
        72	grams per hour	Mass Flow	
        73	kilograms per second	Mass Flow	
        74	kilograms per minute	Mass Flow	
        75	kilograms per hour	Mass Flow	
        76	kilograms per day	Mass Flow	
        77	metric tons per minute	Mass Flow	
        78	metric tons per hour	Mass Flow	
        79	metric tons per day	Mass Flow	
        80	pounds per second	Mass Flow	
        81	pounds per minute	Mass Flow	
        82	pounds per hour	Mass Flow	
        83	pounds per day	Mass Flow	
        84	short tons per minute	Mass Flow	
        85	short tons per hour	Mass Flow	
        86	short tons per day	Mass Flow	
        87	long tons per hour	Mass Flow	
        88	long tons per day	Mass Flow	
        89	deka therm	Energy (includes Work)	
        90	specific gravity units	Mass per Volume	
        91	grams per cubic centimeter	Mass per Volume	
        92	kilograms per cubic meter	Mass per Volume	
        93	pounds per gallon	Mass per Volume	
        94	pounds per cubic foot	Mass per Volume	
        95	grams per milliliter	Mass per Volume	
        96	kilograms per liter	Mass per Volume	
        97	grams per liter	Mass per Volume	
        98	pounds per cubic inch	Mass per Volume	
        99	short tons per cubic yard	Mass per Volume	
        100	degrees twaddell	Mass per Volume	
        101	degrees brix	Miscellaneous	
        102	degrees baume heavy	Mass per Volume	
        103	degrees baume light	Mass per Volume	
        104	degrees API	Mass per Volume	
        105	percent solids per weight	Miscellaneous	
        106	percent solids per volume	Miscellaneous	
        107	degrees balling	Miscellaneous	
        108	proof per volume	Miscellaneous	
        109	proof per mass	Miscellaneous	
        110	bushels	Volume	
        111	cubic yards	Volume	
        112	cubic feet	Volume	
        113	cubic inches	Volume	
        114	inches per second	Velocity	
        115	inches per minute	Velocity	
        116	feet per minute	Velocity	
        117	degrees per second	Radial Velocity	
        118	revolutions per second	Radial Velocity	
        119	revolutions per minute	Radial Velocity	
        120	meters per hour	Velocity	
        121	normal cubic meter per hour MKS System	Volumetric Flow	
        122	normal liter per hour MKS System	Volumetric Flow	
        123	standard cubic feet per minute U.S. System	Volumetric Flow	
        124	bbl liq 1 liquid barrel equals 31.5 U.S. gallons	Volume	
        125	ounce	Mass	
        126	foot pound force	Energy (includes Work)	
        127	kilo watt	Power	
        128	kilo watt hour	Energy (includes Work)	
        129	horsepower	Power	
        130	cubic feet per hour	Volumetric Flow	
        131	cubic meters per minute	Volumetric Flow	
        132	barrels per second 1 barrel equals 42 U.S. gallons	Volumetric Flow	
        133	barrels per minute 1 barrel equals 42 U.S. gallons	Volumetric Flow	
        134	barrels per hour 1 barrel equals 42 U.S. gallons	Volumetric Flow	
        135	barrels per day 1 barrel equals 42 U.S. gallons	Volumetric Flow	
        136	gallons per hour	Volumetric Flow	
        137	imperial gallons per second	Volumetric Flow	
        138	liters per hour	Volumetric Flow	
        139	parts per million	Miscellaneous	
        140	mega calorie per hour 1 calorie = 4.184 Joules	Power	
        141	mega joule per hour	Power	
        142	british thermal unit per hour 1Btu=0.2519958kcal Energy	Power	
        143	degrees	Miscellaneous	
        144	radian	Miscellaneous	
        145	inches of water at 60 degrees F	Pressure	
        146	micrograms per liter	Mass per Volume	
        147	micrograms per cubic meter	Mass per Volume	
        148	percent consistency	Miscellaneous	
        149	volume percent	Miscellaneous	
        150	percent steam quality	Miscellaneous	
        151	feet in sixteeenths See Note 1 Below	Miscellaneous	"There must be 6 digits to the left of the decimal point of the associated numeric value. The
        format of the most significant two of these digits indicate the number of feet . The adjacent
        two lesser significant digits indicate the number of additional sixteenths (i.e., 16 sixteenths =
        1 inch). If the numeric value is in the floating point format, any digits to the right of the
        decimal point are discarded by the host."
        152	cubic feet per pound	Miscellaneous	
        153	picofarads	Miscellaneous	
        154	mililiters per liter	Miscellaneous	
        155	microliters per liter	Miscellaneous	
        160	percent plato	Miscellaneous	
        161	percent lower explosion level	Miscellaneous	
        162	mega calorie 1 calorie = 4.184 Joules	Energy (includes Work)	
        163	kohms	Electromagnetic Unit of Resistance	
        164	mega joule	Energy (includes Work)	
        165	british thermal unit 1Btu=0.2519958kcal Energy	Energy (includes Work)	
        166	normal cubic meter MKS System	Volume	
        167	normal liter MKS System	Volume	
        168	standard cubic feet U.S. System	Volume	
        169	parts per billion	Miscellaneous	
        235	gallons per day	Volumetric Flow	
        236	hectoliters	Volume	
        237	megapascals	Pressure	
        238	inches of water at 4 degrees C	Pressure	
        239	millimeters of water at 4 degrees C	Pressure	
        240	Enumeration may be used for manufacturer specific definitions	Generic	
        250	Not Used	Generic	
        251	None	Generic	
        252	Unknown	Generic	
        253	Special	Generic	
    
         */
    }
}