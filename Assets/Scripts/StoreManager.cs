using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
    public static bool[] ItemsSold = new bool[System.Enum.GetNames(typeof(PowerupName)).Length];
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Coins: " + CoinController.AmountOfCoins;
    }

    // Update is called once per frame
    void Update () {
	}

    public void BuyItem(PowerupName item, int price)
    {

        CoinController.AmountOfCoins -= price;
        ItemsSold[(int)item] = true;
        GetComponent<Text>().text = "Coins: " + CoinController.AmountOfCoins;
    }
}
