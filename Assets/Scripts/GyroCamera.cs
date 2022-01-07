using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    private bool gyroBool;
    private Gyroscope gyro;
    private Quaternion rotFix;
    private Vector3 initial = new Vector3(90, 0, 0);

    // Use this for initialization
    void Start()
    {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;

        gyroBool = SystemInfo.supportsGyroscope;

        Debug.Log("gyro bool = " + gyroBool.ToString());

        if (gyroBool) {
            gyro = Input.gyro;
            gyro.enabled = true;

            rotFix = new Quaternion(0, 0, 0.7071f, 0.7071f);
        }
        else {
            Debug.Log("No Gyro Support");
        }
    }

    void Update()
    {
        if (gyroBool) {
            var camRot = R2L(gyro.attitude);      //クォータニオンを右手系から左手系へ変換
            //transform.eulerAngles = initial;      //カメラの向きを端末の始状態に合わせる
            //transform.localRotation = camRot * transform.localRotation;      //カメラを回転
            //transform.rotation = Quaternion.Euler(0, 0, -180) * Quaternion.Euler(-90, 0, 0) * Input.gyro.attitude * Quaternion.Euler(0, 0, 180);
            // https://rightcode.co.jp/blog/information-technology/unity-google-sdk-standards-speed-up-gyro-acquisition-drawing-speed-vr
            transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.right) * Input.gyro.attitude * Quaternion.AngleAxis(180.0f, Vector3.forward);
        }
    }

    private static Quaternion R2L(Quaternion q)
    {      //クォータニオンを右手系から左手系へ変換する関数
        //return new Quaternion(-q.y, q.z, q.x, -q.w);
        return new Quaternion(-q.x, -q.y, q.z, q.w);
    }
}
