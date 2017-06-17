using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public PowerupName item;
    public int price;
    public float gazeTime = 1f;
    private float timer;
    private bool gazedAt;
    private LifeBar lifeBar;
    StoreManager storeManager;
    // Use this for initialization
    void Start()
    {
        lifeBar = GameObject.Find("LifeBar").GetComponent<LifeBar>();
        storeManager = GameObject.Find("StoreText").GetComponent<StoreManager>();
        if (StoreManager.ItemsSold[(int)item])
        {
            GetComponentInChildren<Text>().text = item.ToString() + " SOLD";

        }
        else
        {
            GetComponentInChildren<Text>().text = "BUY " + item.ToString() + ": " + price;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
                //GetComponent<Collider>.enabled = false;
            }
        }
    }
    public void PointerEnter()
    {
        lifeBar.duration = gazeTime;
        lifeBar.setActivated = true;
        gazedAt = true;
    }
    public void PointerExit()
    {
        lifeBar.deactivate();
        timer = 0;
        gazedAt = false;
    }
    public void PointerDown()
    {
        if (!StoreManager.ItemsSold[(int)item])
        {
            if(CoinController.AmountOfCoins >= price)
            { 
                storeManager.BuyItem(item, price);
                GetComponentInChildren<Text>().text = item.ToString() + " SOLD";
            }
            else
            {
                GetComponentInChildren<Text>().text = "NO COINS!";
            }
        }
    }
    public void PointerDownExit()
    {
        //Application.Quit();
    }
}
