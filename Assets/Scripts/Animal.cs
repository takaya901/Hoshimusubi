using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一定時間ごとに鳴く、移動する
/// </summary>
public class Animal : MonoBehaviour
{
    AudioSource _voice;
    const float CRY_INTERVAL = 5f;
    Transform _tf;

    void Start()
    {
        _tf = transform;
        _voice = GetComponent<AudioSource>();
        _tf.LookAt(Vector3.zero);
        StartCoroutine("Cry");
    }

    void Update()
    {

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
