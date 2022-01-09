using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacSign : MonoBehaviour
{
    [SerializeField] ZodiacSigns _zodiacSign;
    [SerializeField] GameObject _model;

    public ZodiacSigns Zodiac => _zodiacSign;
    public GameObject Model => _model;
    public bool IsComplete { get; set; }

    public void Summon()
    {
        _model.SetActive(true);
    }
}

public enum ZodiacSigns
{
    Aries,
    Taurus,
    Gemini,
    Cancer,
    Leo,
    Virgo,
    Libra,
    Scorpio,
    Sagittarius,
    Capricorn,
    Aquarius,
    Pisces,
    Other
}
