﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinScript : MonoBehaviour {
    public GameObject coinSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gazeAtSilverCoin()
    {
        CoinController.AmountOfCoins++;
        GameObject.Instantiate(coinSound);
        Destroy(gameObject);
    }
}
