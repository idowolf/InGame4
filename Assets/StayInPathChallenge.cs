using UnityEngine;
using System.Collections;

public class StayInPathChallenge : Challenge
{
    public PathManager path;

    public override void Update()
    {
        base.Update();
        if (Started && !Ended)
            path.drawLine();
        float cameraY = Camera.main.transform.position.y + (Camera.main.transform.forward * 5f).y;
        float pathY = path.GetTargetsList()[0].position.y;
        float pathHalfWidth = path.GetTargetsList()[0].localScale.y;
        if (cameraY > pathY + pathHalfWidth || cameraY < pathY - pathHalfWidth)
            challengeFailure();
    }

    public override string GetDescription()
    {
        return string.Format("Spin {0} times in under {1} seconds\nwhile staying on the line!", goalRotations, goalTime);
    }
}
