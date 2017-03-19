using UnityEngine;
using System.Collections;
public class GyroscopeEnable : MonoBehaviour
{
    private Gyroscope gyro;

    void Start()
    {
            gyro = Input.gyro;
            gyro.enabled = true;
    }
    void OnGUI()
    {
        GUILayout.Label("Gyroscope attitude : " + gyro.attitude);
        GUILayout.Label("Gyroscope gravity : " + gyro.gravity);
        GUILayout.Label("Gyroscope rotationRate : " + gyro.rotationRate);
        GUILayout.Label("Gyroscope rotationRateUnbiased : " + gyro.rotationRateUnbiased);
        GUILayout.Label("Gyroscope updateInterval : " + gyro.updateInterval);
        GUILayout.Label("Gyroscope userAcceleration : " + gyro.userAcceleration);
    }
}
