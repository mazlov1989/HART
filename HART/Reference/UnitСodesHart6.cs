namespace HART.Reference
{
    /// <summary>
    /// Коды единиц измерения для HART версии 6 и более поздних версий.
    /// </summary>
    public enum UnitСodesHart6
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
    36	millivolts	EMF
    37	ohms	Resistance
    38	hertz	Frequency
    39	milliamperes	Current
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
    56	microsiemens	Conductance
    57	percent	Analytical
    58	volts	EMF
    59	pH	Analytical
    60	grams	Mass
    61	kilograms	Mass
    62	metric tons	Mass
    63	pounds	Mass
    64	short tons	Mass
    65	long tons	Mass
    66	milli siemens per centimeter	Conductance
    67	micro siemens per centimeter	Conductance
    68	newton	Force
    69	newton meter	Energy (Work)
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
    89	deka therm	Energy (Work)
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
    101	degrees brix	Concentration
    102	degrees baume heavy	Mass per Volume
    103	degrees baume light	Mass per Volume
    104	degrees API	Mass per Volume
    105	percent solids per weight	Concentration
    106	percent solids per volume	Concentration
    107	degrees balling	Volume per Mass
    108	proof per volume	Concentration
    109	proof per mass	Concentration
    110	bushels	Volume
    111	cubic yards	Volume
    112	cubic feet	Volume
    113	cubic inches	Volume
    114	inches per second	Velocity
    115	inches per minute	Velocity
    116	feet per minute	Velocity
    117	degrees per second	Angular Velocity
    118	revolutions per second	Angular Velocity
    119	revolutions per minute	Angular Velocity
    120	meters per hour	Velocity
    121	normal cubic meter per hour MKS System	Volumetric Flow
    122	normal liter per hour MKS System	Volumetric Flow
    123	standard cubic feet per minute U.S. System	Volumetric Flow
    124	bbl liq 1 liquid barrel equals 31.5 U.S. gallons	Volume
    125	ounce	Mass
    126	foot pound force	Energy (Work)
    127	kilo watt	Power
    128	kilo watt hour	Energy (Work)
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
    139	parts per million	Concentration
    140	mega calorie per hour 1 calorie = 4.184 Joules	Power
    141	mega joule per hour	Power
    142	british thermal unit per hour 1Btu=0.2519958kcal Energy	Power
    143	degrees	Angle
    144	radian	Angle
    145	inches of water at 60 degrees F	Pressure
    146	micrograms per liter	Mass per Volume
    147	micrograms per cubic meter	Mass per Volume
    148	percent consistency	Mass per Volume
    149	volume percent	Volume per Volume
    150	percent steam quality	Analytical
    151	feet in sixteeenths	Length
    152	cubic feet per pound	Volume per Mass
    153	picofarads	Capacitance
    154	mililiters per liter	Volume per Volume
    155	microliters per liter	Volume per Volume
    160	percent plato	Analytical
    161	percent lower explosion level	Analytical
    162	mega calorie 1 calorie = 4.184 Joules	Energy (Work)
    163	kohms	Resistance
    164	mega joule	Energy (Work)
    165	british thermal unit 1Btu=0.2519958kcal Energy	Energy (Work)
    166	normal cubic meter MKS System	Volume
    167	normal liter MKS System	Volume
    168	standard cubic feet U.S. System	Volume
    169	parts per billion	Concentration
    170	centimeters of water at 4 degrees C	Pressure
    171	meters of water at 4 degrees C	Pressure
    172	centimeters of mercury at 0 degrees C	Pressure
    173	pounds per square foot	Pressure
    174	hectoPascals	Pressure
    175	pounds per square inch absolute	Pressure
    176	kilograms per square meter	Pressure
    177	feet water 4 degrees C	Pressure
    178	feet water at 60 degrees F	Pressure
    179	meters of mercury at 0 degrees C	Pressure
    235	gallons per day	Volumetric Flow
    236	hectoliters	Volume
    237	megapascals	Pressure
    238	inches of water at 4 degrees C	Pressure
    239	millimeters of water at 4 degrees C	Pressure

         */
    }
}