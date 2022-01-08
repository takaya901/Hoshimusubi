using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class Maggellan : MonoBehaviour
{
    Transform _tf;
    Vector3 _pos = Vector3.zero;
    float _distance;
    float _theta;
    [SerializeField] float _velocity = 0.1f;
    
    void Start()
    {
        _tf = transform;
        _distance = -_tf.position.magnitude;
    }

    void Update()
    {
        _theta += _velocity * Deg2Rad;
        _tf.position = new Vector3(Cos(_theta), 0f, Sin(_theta)) * _distance;

        //var target = new Vector3(Cos(_theta + PI/6f), 0f, Sin(_theta + PI/6f)) * _distance;
        //_tf.rotation = Quaternion.LookRotation(target - _tf.position, Vector3.right);
        _tf.rotation = Utils.LookRotationY(_tf.position, Vector3.zero);
    }
}
