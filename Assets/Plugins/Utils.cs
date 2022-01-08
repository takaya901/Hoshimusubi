using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    /// <summary>
    /// ターゲットに向くようにY軸のみ回転
    /// </summary>
    public static Quaternion LookRotationY(Vector3 source, Vector3 target)
    {
        var lookRotation = Quaternion.LookRotation(target - source, Vector3.right);
        //lookRotation.x = 0;
        //lookRotation.z = 0;
        return lookRotation;
    }

    /// <summary>
    /// ターゲットに向くようにY軸のみ回転
    /// </summary>
    public static Quaternion LookRotationX(Vector3 source, Vector3 target)
    {
        var lookRotation = Quaternion.LookRotation(target - source, Vector3.up);
        lookRotation.y = 0;
        lookRotation.z = 0;
        return lookRotation;
    }
}
