using System.Collections;
using System.Collections.Generic;
using System.IO;
using PlanetTest;
using UnityEngine;

public class HipListReader : MonoBehaviour
{
    [SerializeField] GameObject _sphere;
    
    // 読み込むデータ
    [SerializeField] TextAsset _lightFile = null;
    // 読み込んだデータを格納するリスト
    public List<Star> _hipList;
    
    void Start()
    {
        _hipList = CreateHipList(_lightFile);
        foreach (var star in _hipList) {
            Instantiate(_sphere, star.Pos, Quaternion.identity);
        }
    }
    
    void Update()
    {
        if (_hipList != null)
        {
            foreach(var hip in _hipList){
                Debug.DrawLine(Vector3.zero, hip.Pos*500f, Color.white*(1f/hip.Magnitude));
            }
        }
    }
    
    // ファイルからデータを読み込みデータリストに格納する
    List<Star> CreateHipList(TextAsset lightsFile)
    {
        var list = new List<Star>();
        var sr = new StringReader(lightsFile.text);
        while (sr.Peek() > -1)
        {
            string lineStr = sr.ReadLine();
            if (StringToHipData(lineStr, out var data))
            {
                list.Add(data);
            }
        }
        sr.Close();
        return list;
    }
    
    // CSV文字列からデータ型に変換
    bool StringToHipData(string hipStr, out Star data)
    {
        bool ret = true;
        data = null;
        // カンマ区切りのデータを文字列の配列に変換
        var dataArr = hipStr.Split(',');
        
        try
        {
            // 文字列をint,floatに変換する
            int hipId = int.Parse(dataArr[0]);
            float hlH = float.Parse(dataArr[1]);
            float hlM = float.Parse(dataArr[2]);
            float hlS = float.Parse(dataArr[3]);
            int hsSgn = int.Parse(dataArr[4]);
            float hsH = float.Parse(dataArr[5]);
            float hsM = float.Parse(dataArr[6]);
            float hsS = float.Parse(dataArr[7]);
            float mag = float.Parse(dataArr[8]);
            var col = Color.gray;
            float hDeg = (360f / 24f) * (hlH + hlM / 60f + hlS / 3600f);
            float sDeg = (hsH + hsM / 60f + hsS / 3600f) * (hsSgn == 0 ? -1f : 1f);
            var rotL = Quaternion.AngleAxis(hDeg, Vector3.up);
            var rotS = Quaternion.AngleAxis(sDeg, Vector3.right);
            var pos = rotL * rotS * Vector3.forward;
            data = new Star(hipId, pos, Color.white, mag);
        }
        catch
        {
            ret = false;
            Debug.Log("data err");
        }
        return ret;
    }
}
