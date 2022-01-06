using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarZodiacDictionary
{
    public Dictionary<int, ZodiacSigns> Star2Zodiac { get; set; } = new Dictionary<int, ZodiacSigns>();
//    Dictionary<int, ZodiacSigns> Star2Zodiac = new Dictionary<int, ZodiacSigns>();

    public StarZodiacDictionary()
    {
        Star2Zodiac.Add(8832, ZodiacSigns.Aries);
        Star2Zodiac.Add(8903, ZodiacSigns.Aries);
        Star2Zodiac.Add(9884, ZodiacSigns.Aries);
        Star2Zodiac.Add(13209, ZodiacSigns.Aries);
        
        Star2Zodiac.Add(1645, ZodiacSigns.Pisces);
        Star2Zodiac.Add(3760, ZodiacSigns.Pisces);
        Star2Zodiac.Add(4906, ZodiacSigns.Pisces);
        Star2Zodiac.Add(7007, ZodiacSigns.Pisces);
        Star2Zodiac.Add(7884, ZodiacSigns.Pisces);
        Star2Zodiac.Add(8833, ZodiacSigns.Pisces);
        Star2Zodiac.Add(9487, ZodiacSigns.Pisces);
        Star2Zodiac.Add(8198, ZodiacSigns.Pisces);
        Star2Zodiac.Add(7097, ZodiacSigns.Pisces);
        Star2Zodiac.Add(5742, ZodiacSigns.Pisces);
        Star2Zodiac.Add(6193, ZodiacSigns.Pisces);
        Star2Zodiac.Add(4889, ZodiacSigns.Pisces);
        
        Star2Zodiac.Add(85927, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(86670, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(87073, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(86228, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(84143, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(82671, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(82514, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(82936, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(81266, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(80763, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(78401, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(78820, ZodiacSigns.Scorpio);
        Star2Zodiac.Add(78265, ZodiacSigns.Scorpio);
    }
}
