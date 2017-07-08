using UnityEngine;
using System.Collections;

public class AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 0f;

    // Use this for initialization
    void Start()
    {
        if(GetComponent<Animator>())
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.01f + delay);
        else if(GetComponent<ParticleSystem>())
            Destroy(gameObject, this.GetComponent<ParticleSystem>().main.duration - 0.01f + delay);
    }
}