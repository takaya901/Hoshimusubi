using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetTest
{
    public class Star
    {
        public int Id { get; }
        public Vector3 Pos { get; }
        public Color Color { get; }
        public float Magnitude { get; }

        public Star(int id, Vector3 pos, Color color, float magnitude)
        {
            Id = id;
            Pos = pos;
            Color = color;
            Magnitude = magnitude;
        }
        
        public Star(Star data)
        {
            Id = data.Id;
            Pos = data.Pos;
            Color = data.Color;
            Magnitude = data.Magnitude;
        }
    }
}
