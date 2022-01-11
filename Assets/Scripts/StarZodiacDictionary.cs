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
        {ZodiacSigns.Cancer, new List<(int star1, int star2)>{(16228, 18505), (18505, 22783), (16228, 17959), (17959, 22783), (17959, 25110)}},
        {ZodiacSigns.Pisces, new List<(int star1, int star2)>{(4889, 5742), (4889, 6193), (6193, 5742), (5742, 7097), (7097, 8198), (8198, 9487), (9487, 8833), (8833, 7884), (7884, 7007), (7007, 4906), (4906, 3760), (3760, 1645)}},
        {ZodiacSigns.Taurus, new List<(int star1, int star2)>{(25428, 21881), (21881, 20889), (21421, 26451), (20205, 20455), (20205, 18724), (18724, 15900), (21421, 20889), (21421, 20894), (20894, 20205), (20889, 20648), (20648, 20455), (20455, 17847)}},
        {ZodiacSigns.Libra, new List<(int star1, int star2)>{(77853, 76333), (76333, 74785), (74785, 72622), (72622, 73714), (73714, 76333)}},
        {ZodiacSigns.Scorpio, new List<(int star1, int star2)>{(85927, 86670), (86670, 87073), (86228, 84143), (84143, 82671), (82671, 82514), (82514, 82396), (82396, 81266), (81266, 80763), (80763, 78401), (78265, 78401), (78820, 78401), (85927, 86228)}},
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
    }
}
