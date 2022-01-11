using UnityEngine;
using static StarZodiacDictionary;

public class Connector : MonoBehaviour
{
    [SerializeField] Material _material;

    void Start()
    {
    }

    void Update()
    {

    }

    /// <summary>
    /// Magicが当たったZodiacSignに呼び出される
    /// </summary>
    public void Connect(ZodiacSigns zodiacSign)
    {
        // 線の両端のリスト
        var connections = Zodiac2Connection[zodiacSign];

        // 一本ずつ線を繋ぐ
        foreach (var (star1, star2) in connections)
        {
            var lr = GetNewRenderer();
            // 両端の星のPositionを取得
            Vector3[] vertices = new Vector3[2]{ID2Pos(star1), ID2Pos(star2)};
            lr.SetPositions(vertices);
        }
    }

    /// <summary>
    /// 星のIDからPositionを返す
    /// </summary>
    Vector3 ID2Pos(int id)
    {
        return GameObject.Find($"star {id}").transform.position;
    }

    LineRenderer GetNewRenderer()
    {
        var renderer = new GameObject().AddComponent<LineRenderer>();
        renderer.material = _material;
        renderer.startWidth = 0.1f;
        renderer.endWidth = 0.1f;
        return renderer;
    }
}