using UnityEngine;
using System.Collections;

public class RotateInDirectionChallenge : Challenge
{
    public Dir direction;

    public override bool evalRotation(Rotation r)
    {
        return r.Dir == direction;
    }
}
