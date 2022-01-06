using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class ZodiacSign : MonoBehaviour
{
    [SerializeField] ZodiacSigns _zodiacSign;
    [SerializeField] GameObject _model;
    [SerializeField] AudioSource _cry;

    public ZodiacSigns Zodiac => _zodiacSign;
    public GameObject Model => _model;
    public bool IsComplete { get; set; }

    public void Cry()
    {
        _cry.Play();
    }
}
