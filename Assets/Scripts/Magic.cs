using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] SummonEffect _summonEffect;
    [SerializeField] float _speed = 5f;
    public Vector3 Direction { get; set; }
    const float RANGE = 35f;
    Transform _tf;

    void OnEnable()
    {
        _tf = transform;
        _tf.position = Vector3.zero;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        _tf.position += Direction * _speed * Time.deltaTime;
        if (_tf.position.magnitude > RANGE) {
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
