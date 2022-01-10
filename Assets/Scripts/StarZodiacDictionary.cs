using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarZodiacDictionary
{
    /// <summary> 星が属する星座を返す </summary>
    public static Dictionary<int, ZodiacSigns> Star2Zodiac { get; private set; } = new Dictionary<int, ZodiacSigns>();
    /// <summary> 星座を繋ぐ線を返す </summary>
    public static Dictionary<ZodiacSigns, List<(int star1, int star2)>> Zodiac2Connection { get; private set; } = new Dictionary<ZodiacSigns, List<(int star1, int star2)>>()
    {
        {ZodiacSigns.Aries, new List<(int star1, int star2)>{(13209, 9884), (9884, 8903), (8903, 8832)}},
        {ZodiacSigns.Cancer, new List<(int star1, int star2)>{(16228, 18505), (18505, 22783), (16228, 17959), (17959, 22783), (17959, 25110)}}
    };

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

        Star2Zodiac.Add(77853, ZodiacSigns.Libra);
        Star2Zodiac.Add(76333, ZodiacSigns.Libra);
        Star2Zodiac.Add(74785, ZodiacSigns.Libra);
        Star2Zodiac.Add(72622, ZodiacSigns.Libra);
        Star2Zodiac.Add(73714, ZodiacSigns.Libra);

        Star2Zodiac.Add(16228, ZodiacSigns.Cancer);
        Star2Zodiac.Add(18505, ZodiacSigns.Cancer);
        Star2Zodiac.Add(22783, ZodiacSigns.Cancer);
        Star2Zodiac.Add(17959, ZodiacSigns.Cancer);
        Star2Zodiac.Add(25110, ZodiacSigns.Cancer);

        Star2Zodiac.Add(25428, ZodiacSigns.Taurus);
        Star2Zodiac.Add(21881, ZodiacSigns.Taurus);
        Star2Zodiac.Add(20889, ZodiacSigns.Taurus);
        Star2Zodiac.Add(21421, ZodiacSigns.Taurus);
        Star2Zodiac.Add(26451, ZodiacSigns.Taurus);
        Star2Zodiac.Add(20205, ZodiacSigns.Taurus);
        Star2Zodiac.Add(20455, ZodiacSigns.Taurus);
        Star2Zodiac.Add(18724, ZodiacSigns.Taurus);
        Star2Zodiac.Add(15900, ZodiacSigns.Taurus);
        Star2Zodiac.Add(20894, ZodiacSigns.Taurus);
        Star2Zodiac.Add(20648, ZodiacSigns.Taurus);
        Star2Zodiac.Add(17847, ZodiacSigns.Taurus);

        //Zodiac2Connection.Add(ZodiacSigns.Aries, new List<(int star1, int star2)>{(13209, 9884), (9884, 8903), (8903, 8832)});
        //Zodiac2Connection.Add(ZodiacSigns.Cancer, new List<(int star1, int star2)>{(16228, 18505), (18505, 22783), (16228, 17959), (17959, 22783), (17959, 25110)});
    }
}
