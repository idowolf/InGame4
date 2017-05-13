using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour {
    private List<StatsManager.StatsNode> stats;
    public int statSelector;
	// Use this for initialization
	void Start () {
        string s = "";
        switch (statSelector)
        {
            case (0):
                s += "Fastest Spins:";
                stats = StatsManager.fastRotList;
                break;
            case (1):
                s += "Best Combos:";
                stats = StatsManager.maxComboList;
                break;
            case (2):
                s += "Best Times:";
                stats = StatsManager.maxSpeedList;
                break;
        }
        s += Environment.NewLine;
        foreach (StatsManager.StatsNode sn in stats)
        {
            s += sn.ToString();
            s += Environment.NewLine;
        }
        GetComponent<Text>().text = s;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
