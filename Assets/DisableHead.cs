using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableHead : MonoBehaviour {
    
    void Start()
    {
        StartCoroutine(DestroyHeadTracking());
    }

    IEnumerator DestroyHeadTracking()
    {
        yield return new WaitForSeconds(0.01f);
        Camera.main.gameObject.GetComponent<GvrHead>().trackRotation = false;
        Camera.main.transform.rotation = Quaternion.identity;
    }
}
