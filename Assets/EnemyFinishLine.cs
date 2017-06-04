using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyFinishLine : MonoBehaviour {
    public int roundCount;
    public string tagToSearch;
    public Text text;
    public StatsManager statsManager;
	// Use this for initialization
	void Start () {
        roundCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagToSearch)
        {
            roundCount++;
            text.text = roundCount.ToString();
            if(roundCount >= 20)
            {
                if (other.tag == "Enemy")
                    LoadGameOver(false);
                else if (other.tag == "Player")
                    LoadGameOver(true);
            }
        }
    }
    public void LoadGameOver(bool yay)
    {
        //update all records and stats
        statsManager.updateRecordTable(yay ? 1 : -1);
        //print table for check
        statsManager.printRecordTable();

        SceneManager.LoadScene("gameOverScene");

    }
}
