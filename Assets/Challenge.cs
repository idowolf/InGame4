using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Challenge : MonoBehaviour
{
    private bool started, ended, succeeded;
    public float goalTime;
    private float elapsedTime;
    public int goalRotations;
    private List<Rotation> rotations;

    // Use this for initialization
    public virtual void Start()
    {
        resetChallenge();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if ((!started) || ended) return;

        elapsedTime += Time.deltaTime;

        if(elapsedTime > goalTime)
        {
            ended = true;
            if (rotations.Count >= goalRotations)
                succeeded = true;
        }
    }
    
    public void challengeFailure()
    {
        ended = true;
        succeeded = false;
    }

    public virtual bool evalRotation(Rotation r)
    {
        return true;
    }

    public virtual void resetChallenge()
    {
        started = ended = succeeded = false;
        elapsedTime = 0;
    }

    public void addRotation(Rotation r)
    {
        if(evalRotation(r))
            rotations.Add(r);
    }
}
