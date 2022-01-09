using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summoner : MonoBehaviour
{
    [SerializeField] SummonEffect _summonEffect;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit)) {
            Summon(hit.collider.transform.parent);
        }
    }

    void Summon(Transform zodiacSign)
    {
        zodiacSign.GetComponent<ZodiacSign>().Summon();
        _summonEffect.Play();
    }
}
