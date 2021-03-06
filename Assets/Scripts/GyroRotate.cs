﻿#if UNITY_EDITOR
using UnityEngine;
 using System.Collections;
 public class GyroRotate : MonoBehaviour {
 
     private Gyroscope gyro;
 
     void Start () 
     {
         if (SystemInfo.supportsGyroscope)
         {
             gyro = Input.gyro;
             gyro.enabled = true;
         }
         else
         {
         }
     }
 
     void Update () 
     {
         GameObject player = GameObject.FindGameObjectWithTag ("Player");
        if(gyro != null)
            player.transform.Rotate (-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0);
     }
 
     void OnGUI()
     {
        if(gyro != null)
            GUILayout.Label ("Gyroscope attitude : " + gyro.attitude);
    }
}
#endif