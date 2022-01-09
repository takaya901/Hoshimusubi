using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using static UnityEditor.AssetDatabase;
using static UnityEditor.PrefabUtility;

namespace PlanetTest
{
    public class CreatePlanet : EditorWindow
    {
        static readonly string SPHERE_PATH = "Assets/Prefabs/Sphere.prefab";
        static readonly string CSV_PATH = "Assets/StarData/hip_constellation_line_star.csv";
        static readonly string BLOOM_MAT_PATH = "Assets/Materials/Bloom.mat";
        static readonly string BLOOM_RED_MAT_PATH = "Assets/Materials/BloomRed.mat";

        //シーンに星を配置
        [MenuItem("Planet/Create Planet")]
        static void Create()
        {
            var parents = CreateParents();

            var starCsv = LoadAssetAtPath<TextAsset>(CSV_PATH);
            var starList = CreateHipList(starCsv);
            var starPrefab = LoadAssetAtPath<GameObject>(SPHERE_PATH);
            var bloomMat = LoadAssetAtPath<Material>(BLOOM_MAT_PATH);
            var bloomRedMat = LoadAssetAtPath<Material>(BLOOM_RED_MAT_PATH);
            var star2zodiac = new StarZodiacDictionary();
            
            foreach (var star in starList) 
            {
                var sphere = new GameObject();
                
                //設定済みの星座に含まれる星はその子に入れる．未設定の場合otherの子に入れる
                if (star2zodiac.Star2Zodiac.ContainsKey(star.Id)) {
                    sphere = InstantiatePrefab(starPrefab, parents[(int)star2zodiac.Star2Zodiac[star.Id]].transform) as GameObject;
                    sphere.GetComponent<Renderer>().material = bloomRedMat;
                }
                else {
                    sphere = InstantiatePrefab(starPrefab, parents[(int)ZodiacSigns.Other].transform) as GameObject;
                    sphere.GetComponent<Renderer>().material = bloomMat;
                }
                
                sphere.name = $"star {star.Id}";
                sphere.transform.position = star.Pos;
                sphere.transform.localScale *= star.Magnitude * star.Magnitude / 5f;

                Undo.RegisterCreatedObjectUndo(sphere, "Create " + sphere.name);
            }
        }

        /// <summary> 各星座の親となる空オブジェクトを生成 </summary>
        static GameObject[] CreateParents()
        {
            var parents = new GameObject[Enum.GetNames(typeof(ZodiacSigns)).Length];

            foreach (var zodiac in Enum.GetValues(typeof(ZodiacSigns))) {
                parents[(int)zodiac] = new GameObject(zodiac.ToString());
                Undo.RegisterCreatedObjectUndo(parents[(int)zodiac], "Create " + parents[(int)zodiac].name);
            }

            return parents;
        }
        
        // ファイルからデータを読み込みデータリストに格納する
        static List<Star> CreateHipList(TextAsset lightsFile)
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
        static bool StringToHipData(string hipStr, out Star data)
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
                var pos = rotL * rotS * Vector3.forward * 20f;
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
}

