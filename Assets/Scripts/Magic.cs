using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] SummonEffect _summonEffect;
    [SerializeField] float _speed = 0.1f;
    public Vector3 Direction { get; set; }
    Transform _tf;

    void OnEnable()
    {
        _tf = transform;
        _tf.position = Vector3.zero;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        _tf.position += Direction * _speed;
        if (_tf.position.magnitude > 30f) {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 星座に当たったらモデルを召喚
    /// </summary>
    void OnTriggerEnter(Collider collider)
    {
        gameObject.SetActive(false);
        collider.transform.parent.GetComponent<ZodiacSign>().Summon();
        collider.GetComponent<Collider>().enabled = false;  //一度召喚したら星座のColliderを無効化
        _summonEffect.Play();
    }
}
