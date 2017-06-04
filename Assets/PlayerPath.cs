using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public enum Dir
{
    counter,
    clockwards
}
public class PlayerPath : MonoBehaviour
{
    public float distance;
    private Dir dir;
    private float rotationStartTime;
    public int currentTarget;
    public bool[] circlePoints;
    public PathManager path;
    public int pathRotation;
    public float speed;
    public bool loop;
    public bool faceAway;
    public int current;
    public bool goBackwardsOnPath;
    public static bool allowMovement;
    public int roundCount;
    public string tagToSearch;
    public Text text;
    public StatsManager statsManager;
    private List<Transform> targets;

    private void Start()
    {
        targets = path.GetTargetsList();
        rotationStartTime = Time.time;
        roundCount = 0;
        if (goBackwardsOnPath)
            targets.Reverse();
        circlePoints = new bool[targets.Count];
    }


    private void Update()
    {
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
        transform.rotation = Quaternion.LookRotation((Camera.main.transform.position - transform.position) * (faceAway ? 1 : -1));

        if (current != currentTarget && transform.position != targets[current].position)
        {
            //Vector3 pos = Vector3.MoveTowards(transform.position, targets[current].position, speed * Time.deltaTime);

            //GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            int amount = targets.Count;
            //bool clockwards = Mathf.Abs(current - currentTarget) < amount / 2 ^ currentTarget < current;
            if (dir == Dir.clockwards)
                current++;
            else
                current--;
            if (current < 0)
                current += amount;
            else if (current >= amount)
                current -= amount;
        }
    }

    public void Shout(int newTarget)
    {
        //text.text = dir == Dir.clockwards ? "right" : "left";

        int amount = targets.Count;
        Dir newDir = (Mathf.Abs(currentTarget - newTarget) < amount / 2 ^ newTarget < currentTarget) ? Dir.clockwards : Dir.counter;
        if(dir != newDir)
        {
            resetCirclePoints();
            dir = newDir;
        }
        currentTarget = newTarget;
        if (circlePoints[currentTarget])
        {
            if(circlePoints.Count(c => c) >= 0.75f * circlePoints.Length)
            { 
                roundCount++;
                resetCirclePoints();
            }
            text.text = roundCount.ToString();
            if (roundCount >= 20)
                    LoadGameOver(true);
        }
        else
            circlePoints[newTarget] = true;
    }

    private void resetCirclePoints()
    {
        circlePoints = new bool[circlePoints.Length];
    }

    public void LoadGameOver(bool yay)
    {
        //update all records and stats
        statsManager.updateRecordTable(yay ? 1 : -1);
        //print table for check
        statsManager.printRecordTable();

        SceneManager.LoadScene("gameOverScene");

    }

    public Dir GetCurrentDirection()
    {
        return dir;
    }
}
