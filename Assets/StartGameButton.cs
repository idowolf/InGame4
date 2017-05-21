using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void GazedAt()
    {
        SceneManager.LoadScene("level1");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
