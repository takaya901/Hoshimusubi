using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class Maggellan : MonoBehaviour
{
    Vector3 _pos = Vector3.zero;
    float _distance;
    float _theta;
    float _velocity = 0.1f;
    
    void Start()
    {
        _distance = transform.position.magnitude;
    }

    void Update()
    {
        _theta += _velocity * Deg2Rad;
        _pos.x = _distance * Cos(_theta);
        _pos.z = _distance * Sin(_theta);
        transform.position = _pos;
        transform.LookAt(Vector3.zero);
    }
}
