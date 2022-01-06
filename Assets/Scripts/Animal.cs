using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] AudioSource _cry;
    float _timer = 5f;

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f) {
            _timer = 5f;
            _cry.Play();
        }
    }
}
