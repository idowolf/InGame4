using UnityEngine;

public class Rotation
{
    private Dir dir;
    private float duration;
    public Rotation(float duration, Dir dir)
    {
        this.duration = duration;
        this.dir = dir;

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
}
