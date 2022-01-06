using UnityEngine;

public class Flush : MonoBehaviour
{
    Material _material;
    Color _orgColor;
    Color _flushColor;
    float _alphaSin;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _orgColor = _material.color;
    }

    void Update()
    {
        _flushColor = new Color(_orgColor.r, _orgColor.g, _orgColor.b, Mathf.Sin(Time.time * 8f) / 2 + 0.5f);
        _material.color = _flushColor;
    }
}
