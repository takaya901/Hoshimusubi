using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面をタッチしたら魔法を飛ばす、星座に当たったらモデルを召喚
/// </summary>
public class Summoner : MonoBehaviour
{
    [SerializeField] Magic _magic;
    [SerializeField] SummonEffect _summonEffect;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        // 画面をタッチした場所に向かって魔法を飛ばす
        _magic.gameObject.SetActive(true);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _magic.Direction = ray.direction;
        //if (Physics.Raycast(ray, out var hit)) {
        //    Summon(hit.collider.transform.parent);
        //}
    }

    void Summon(Transform zodiacSign)
    {
        zodiacSign.GetComponent<ZodiacSign>().Summon();
        _summonEffect.Play();
    }
}
