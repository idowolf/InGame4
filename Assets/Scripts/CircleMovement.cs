using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{

    public float RotateSpeed = 5f;
    public float Radius = 3;

    private Vector3 _centre;
    private float _angle;
    public Transform pivot;
    private void Start()
    {
        if(false)
            _centre = pivot.localPosition;
        else
        {
            _centre = transform.position;
        }
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle)) * Radius;
        transform.localPosition = _centre + offset;
        transform.forward = offset;
    }



}
