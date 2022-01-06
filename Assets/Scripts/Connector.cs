//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;
//using static OVRInput;
//using static UnityEngine.Physics;

//public class Connector : MonoBehaviour
//{
//    [SerializeField] Text _debugText;
//    [SerializeField] Transform _rightHandAnchor;
//    [SerializeField] Transform _leftHandAnchor;
//    [SerializeField] LineRenderer _edge;
//    [SerializeField] SummonEffect _summonEffect;
//    [SerializeField] AudioSource _summonSE;
//    static readonly float MAX_DISTANCE = 30.0f;

//    /// <summary>現在繋いでいる星のリスト</summary>
//    List<GameObject> _connectingStars = new List<GameObject>();
//    /// <summary>現在繋いでいる星のリスト</summary>
//    List<Vector3> _positions = new List<Vector3>();
//    /// <summary>現在繋いでいる星座</summary>
//    ZodiacSigns _currentZodiac;
    
//    //TO DO LaserPointerと共通化
//    Transform Controller
//    {
//        get{
//            var controller = GetActiveController(); //現在アクティブなコントローラを取得
//            switch (controller) 
//            {
//                case OVRInput.Controller.RTrackedRemote:
//                    return _rightHandAnchor;
//                case OVRInput.Controller.LTrackedRemote:
//                    return _leftHandAnchor;
//                default:
//                    return _rightHandAnchor;
//            }
//        }
//    }

//    void Update()
//    {
//        //コントローラの位置と向き取得
//        var pointerRay = new Ray(Controller.position, Controller.forward);

//        try {
//            //星が1つ以上選択されていたら，星とレーザーポインタの先を繋ぐ（選択待ち状態）
//            if (_connectingStars.Count >= 1) {
//                _edge.SetPosition(_edge.positionCount - 1, pointerRay.origin + pointerRay.direction * MAX_DISTANCE);
//            }
            
//            //星が選択されたら接続判定に入る
//            if (!GetDown(OVRInput.Button.SecondaryIndexTrigger) ||
//                !Raycast(pointerRay, out var hitInfo, MAX_DISTANCE)) return;
            
//            StartCoroutine(Haptics(0.3f, 0.5f, 0.1f));
            
//            //選択された星の情報を取得
//            var parent = hitInfo.transform.parent;
//            var zodiac = parent.GetComponent<ZodiacSign>();
            
//            //接続すべき星なら接続処理に入る
//            if (!IsValidConnection(hitInfo, zodiac)) return;

//            Connect(pointerRay, hitInfo, zodiac);
                
//            //星座が完成したらモデルを召喚，接続情報をリセット
//            if (parent.childCount - 1 == _connectingStars.Count){    //モデルを子に入れてるので-1
//                Summon(zodiac);
//            }
//        }
//        catch (Exception e) {
//            _debugText.text = e.Message;
//        }
//    }
    
//    /// <summary>繋ぐべき星が選択されているか</summary>
//    bool IsValidConnection(RaycastHit hitInfo, ZodiacSign zodiac)
//    {
//        var previousStarIndex = _connectingStars.Count == 0 ? 
//            0 : _connectingStars[_connectingStars.Count - 1].transform.GetSiblingIndex();

//        return !_connectingStars.Contains(hitInfo.collider.gameObject) &&          //その星が未接続で，
//               !zodiac.IsComplete &&                                               //その星の属する星座が未完成で，
//               (_connectingStars.Count == 0 || zodiac.Zodiac == _currentZodiac) && //現在その星座を繋ごうとしていて（最初の星以外），
//               hitInfo.transform.GetSiblingIndex() == previousStarIndex + 1;       //次に繋ぐべき星ならtrue
//    }

//    void Connect(Ray pointerRay, RaycastHit hitInfo, ZodiacSign zodiac)
//    {
//        //1つ目の星なら，それが属する星座を保存
//        if (_connectingStars.Count == 0) {
//            _currentZodiac = zodiac.Zodiac;
//            _positions.Add(hitInfo.transform.position);
//        }
//        //2つ目以降は
//        else {
//            _positions[_positions.Count - 1] = hitInfo.transform.position;
//        }
//        //接続済みリストに追加
//        _connectingStars.Add(hitInfo.collider.gameObject);
//        _positions.Add(pointerRay.origin + pointerRay.direction * MAX_DISTANCE); //選択された星とレーザーポインタの先を接続（選択待ち状態）

//        //前の星と選択された星を接続
//        _edge.positionCount = _positions.Count;
//        _edge.SetPositions(_positions.ToArray());
//        _debugText.text = _edge.positionCount.ToString();
//    }

//    void Summon(ZodiacSign zodiac)
//    {
//        zodiac.Cry();
//        _summonSE.Play();
//        _summonEffect.Play();
//        _connectingStars.Clear();
//        _positions.Clear();
//        zodiac.IsComplete = true;
//        _edge = DuplicateComponent.Duplicate(_edge); //次の星座を繋ぐ辺
//        _edge.positionCount = 0;
//        zodiac.Model.SetActive(true);
//        if (_currentZodiac != ZodiacSigns.Pisces) {
//            zodiac.Model.transform.LookAt(Vector3.zero);
//        }
//    }

//    static IEnumerator Haptics(float frequency, float amplitude, float duration)
//    {
//        SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
//        yield return new WaitForSeconds(duration);
//        SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
//    }
//}