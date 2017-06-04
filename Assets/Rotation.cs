using UnityEngine;

public class Rotation
{
    private Dir dir;
    private float duration;
    private float startTime;
    public Rotation()
    {
        startTime = Time.time;
    }

    public Dir Dir
    {
        get
        {
            return dir;
        }
    }

    public float Duration
    {
        get
        {
            return duration;
        }
    }

    public void endRotation(Dir dir)
    {
        duration = Time.time - startTime;
        this.dir = dir;
    }
}
