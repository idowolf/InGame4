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
        bool lerped = false;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        if (sceneArray.Contains(sceneName) == false){
            lifeBar = GameObject.Find("Slider");
            if (lifeBar)
            {
                if (lifeBar.GetComponent<Slider>().value < 50 )
                {
                    if (!lerped)
                    {
                        this.GetComponent<AudioSource>().volume = Mathf.Lerp(0.175f, 0.475f,Time.deltaTime * 35);
                        lerped = true;
                    }
                }  else
                {
                    this.GetComponent<AudioSource>().volume = 0.175f;
                    
                    lerped = false;
                }                     
            }
            else
            {
                
                this.GetComponent<AudioSource>().volume = .175f;
                
            }
        } else
        {
            this.GetComponent<AudioSource>().volume = 0.175f;
            
        }
    }
}
