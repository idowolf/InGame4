using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration - 0.05f);
    }

}