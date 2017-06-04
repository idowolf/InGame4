using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    public GameObject explosion;
    public List<Text> texts;
    public List<Challenge> challenges;
    private Challenge currentChallenge;
    public string nextScene;
    private int i;
    // Use this for initialization
    void Start()
    {
        i = 0;
        currentChallenge = challenges[i];
        resetManager();

    }

    // Update is called once per frame
    void Update()
    {
        if (!currentChallenge.Started)
            currentChallenge.StartChallenge();
        if (currentChallenge.Ended)
        {
            if (currentChallenge.Succeeded)
            {
                if (i < challenges.Count - 1)
                {
                    // go to next challenge
                    GameObject.Instantiate(explosion, Camera.main.transform.position, Quaternion.identity);
                    texts[i].text = "V " + texts[i].text;
                    i++;
                    currentChallenge = challenges[i];
                }
                else
                {
                    if (nextScene != "")
                        SceneManager.LoadScene(nextScene);
                    else
                    {

                        // succeeded all challenges
                        foreach (Text text in texts)
                        {
                            text.text = "";
                        }
                        texts[0].text = "Great job!";
                    }
                }
            }
            else
            {
                resetManager();
            }
        }
    }

    private void resetManager()
    {
        // restart manager
        for (i = 0; i < challenges.Count; i++)
        {
            challenges[i].resetChallenge();
            texts[i].text = (i+1) + ". " + challenges[i].GetDescription();

        }
        i = 0;
        currentChallenge = challenges[i];
    }

    public void AddToCurrentChallenge(Rotation r)
    {
        currentChallenge.addRotation(r);
    }
}
