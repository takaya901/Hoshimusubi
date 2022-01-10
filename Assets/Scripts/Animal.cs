using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 一定時間ごとに鳴く、移動する
/// </summary>
public class Animal : MonoBehaviour
{
    AudioSource _voice;
    const float CRY_INTERVAL = 5f;
    [SerializeField] float MOVE_INTERVAL = 10f;
    [SerializeField] float _distance = 30f;
    [SerializeField] float _speed = 5f;
    bool _isIdling;
    Transform _tf;

    Vector3 _destination;

    void Start()
    {
        _tf = transform;
        _voice = GetComponent<AudioSource>();
        _tf.LookAt(Vector3.zero);

        _destination = _tf.position;
        StartCoroutine(((Func<IEnumerator>)UpdateDestination).Method.Name);
        StartCoroutine(((Func<IEnumerator>)Cry).Method.Name);
    }

    void Update()
    {
        _tf.LookAt(Vector3.zero);
        _tf.position = Vector3.MoveTowards(_tf.position, _destination, _speed * Time.deltaTime);
    }

    /// <summary>
    /// 一定時間待機してから次の目的地を決定
    /// </summary>
    IEnumerator UpdateDestination()
    {
        while (true) {
            yield return new WaitForSeconds(MOVE_INTERVAL);
            _destination = UnityEngine.Random.onUnitSphere * _distance;
        }
    }

    /// <summary>
    /// 一定時間ごとに鳴く
    /// </summary>
    IEnumerator Cry()
    {
        while (true) {
            yield return new WaitForSeconds(CRY_INTERVAL);
            _voice.Play();
        }
    }
}
