using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuAudio : MonoBehaviour
{
    public GameObject musicPlayer;
    public GameObject lifeBar;
    public Scene currentScene;
    public string[] sceneArray;
    string sceneName;


    void Awake()
    {
        
        musicPlayer = GameObject.Find("MUSIC");
        if (musicPlayer == null)
        {
            musicPlayer = this.gameObject;
            
            musicPlayer.name = "MUSIC";

            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if (this.gameObject.name != "MUSIC")
            {
                
                Destroy(this.gameObject);
            }
        }
    }
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        if (sceneArray.Contains(sceneName) == false){
            lifeBar = GameObject.Find("Slider");
            if (lifeBar)
            {
                Debug.Log("SLIDEEERRRRR!! WOOHOO");
                this.GetComponent<AudioSource>().pitch = (lifeBar.GetComponent<Slider>().value <= 30) ?
                     1 + (lifeBar.GetComponent<Slider>().value / 500) :
                     1;
                this.GetComponent<AudioSource>().volume = (lifeBar.GetComponent<Slider>().value <= 50) ?
                    0.175f + (lifeBar.GetComponent<Slider>().value / 100) :
                    0.175f;


            }
            else
            {
                this.GetComponent<AudioSource>().pitch = 1;
                this.GetComponent<AudioSource>().volume = .175f;
            }
        }
    }
}
