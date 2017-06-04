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

    public bool Started
    {
        get
        {
            return started;
        }
    }

    public bool Ended
    {
        get
        {
            return ended;
        }
    }

    public bool Succeeded
    {
        get
        {
            return succeeded;
        }
    }

    public void StartChallenge()
    {
        started = true;
    }
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
        rotations = new List<Rotation>();
    }

    public void addRotation(Rotation r)
    {
        if(evalRotation(r))
            rotations.Add(r);
    }

    public virtual string GetDescription()
    {
        return string.Format("Spin {0} times in under {1} seconds!",goalRotations,goalTime);
    }
}
