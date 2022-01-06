//using System;
//using UnityEngine;
//using UnityEngine.UI;
//using static OVRInput;
//using static UnityEngine.Physics;

//namespace MyScripts
//{
//    public class LaserPointer : MonoBehaviour
//    {
//        [SerializeField] Transform _rightHandAnchor;
//        [SerializeField] Transform _leftHandAnchor;
//        [SerializeField] LineRenderer _laserPointerRenderer;
//        static readonly float MAX_DISTANCE = 30.0f;

//        Transform Controller
//        {
//            get{
//                //現在アクティブなコントローラを取得
//                var controller = GetActiveController();
//                switch (controller) 
//                {
//                    case OVRInput.Controller.RTrackedRemote:
//                        return _rightHandAnchor;
//                    case OVRInput.Controller.LTrackedRemote:
//                        return _leftHandAnchor;
//                    default:
//                        return _rightHandAnchor;
//                }
//            }
//        }

//        void Update()
//        {
//            var pointerRay = new Ray(Controller.position, Controller.forward);
//            RenderRay(pointerRay);
//        }

//        /// <summary>
//        /// コントローラの位置からRayを飛ばす
//        /// </summary>
//        /// <param name="pointerRay"></param>
//        //https://qiita.com/MuAuan/items/5ca130f2095cc5e896fa
//        void RenderRay(Ray pointerRay)
//        {
//            if (!Controller || !_laserPointerRenderer) return;
        
//            //レーザーの起点
//            _laserPointerRenderer.SetPosition(0, pointerRay.origin);

//            // Rayがヒットしたらそこまで，ヒットしなかったら向いている方向にMaxDistance伸ばす
//            if (Raycast(pointerRay, out var hitInfo, MAX_DISTANCE)){
//                _laserPointerRenderer.SetPosition(1, hitInfo.point);
//            }else{
//                _laserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * MAX_DISTANCE);
//            }
//        }
//    }

//}
