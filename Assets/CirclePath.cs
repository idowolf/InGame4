using UnityEngine;
using System.Collections;

public class CirclePath : MonoBehaviour
{

    public int numObjects = 10;
    public int pointsToIgnore;
    public bool inverseDirection;
    public GameObject prefab;
    public float radius;
    //public void OnDrawGizmos()
    //{
    //    Start();
    //}
    void Start()
    {
        prefab = new GameObject();
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects - pointsToIgnore; i++)
        {
            Vector3 pos = RandomCircle(center, radius, (360 / numObjects) * (i + 1));
            //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, Quaternion.identity,transform);

        }
    }

    private Quaternion AbsVector3(Quaternion v)
    {
        return new Quaternion(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z),Mathf.Abs(v.w));
    }

    Vector3 RandomCircle(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        ang = inverseDirection ? 360 - ang : ang;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
