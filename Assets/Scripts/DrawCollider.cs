using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCollider : MonoBehaviour
{
    public Shader shader;
    public Color color;
    public float height, width, prevHeight, prevWidth;
    void Start()
    {
        LineRenderer r = new GameObject().AddComponent<LineRenderer>();
        r.transform.SetParent(transform);
        r.material = new Material(shader);
        r.material.color = color;
        r.startWidth = 0.2f;
        r.endWidth = 0.1f;

        List<Vector3> positions = new List<Vector3>();
        //while (true)
        StartCoroutine(draw2(r, positions));
    }

    void Update()
    {

    }

    //IEnumerator draw()
    //{

        //yield return new WaitForSeconds(0);
        //r.useWorldSpace = false;
        //List<Vector2> positions2 = new List<Vector2>();
        //for (int i = 0; i < positions.Count; i++)
        //{
        //    positions2.Add(new Vector2(positions[i].x, positions[i].y));
        //}
        //PolygonCollider2D col = r.gameObject.AddComponent<PolygonCollider2D>();
        //col.gameObject.GetComponent<PolygonCollider2D>().points = positions2.ToArray();
        //col.gameObject.AddComponent<Rigidbody2D>();
        //col.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    //}
    IEnumerator draw2(LineRenderer r, List<Vector3> positions)
    {
        Camera cam = Camera.main;
#if UNITY_EDITOR
        width = Screen.width / 2;
        height = Screen.height / 2;
#else
        width = UnityEngine.VR.VRSettings.eyeTextureWidth / 2;
        height = UnityEngine.VR.VRSettings.eyeTextureHeight / 2;

#endif
        positions.Add(Camera.main.ScreenToWorldPoint(new Vector3(width, height, 8f)));
        r.positionCount = positions.Count;
        r.SetPositions(positions.ToArray());
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(draw2(r, positions));
    }
}
