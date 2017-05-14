using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRecordsManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (StatsManager.playerRecords.Count >= 3)
        {
            string s = "Longest Combo: " + StatsManager.playerRecords[0].ToStringNoTime() + Environment.NewLine;
            s += "Fastest Spin: " + StatsManager.playerRecords[1].ToStringNoTime() + Environment.NewLine;
            s += "Time Left: " + StatsManager.playerRecords[2].ToStringNoTime();
            GetComponent<Text>().text = s;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
