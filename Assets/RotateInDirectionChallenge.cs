using UnityEngine;
using System.Collections;

public class RotateInDirectionChallenge : Challenge
{
    public Dir direction;

    public override bool evalRotation(Rotation r)
    {
        return r.Dir == direction;
    }
    public override string GetDescription()
    {
        return string.Format("Spin {0} times to the {1} in under {2} seconds!", 
            goalRotations, 
            direction==Dir.clockwards ? "right" : "left",
            goalTime);
    }
}
