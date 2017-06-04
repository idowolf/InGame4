using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    public List<Text> texts;
    public List<Challenge> challenges;
    private Challenge currentChallenge;
    private int i;
    // Use this for initialization
    void Start()
    {
        i = 0;
        currentChallenge = challenges[i];
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
                    texts[i].text = "V " + texts[i].text;
                    i++;
                    currentChallenge = challenges[i];
                }
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
            else
            {
                // restart manager
                for(i = 0; i < challenges.Count; i++)
                {
                    challenges[i].resetChallenge();
                    texts[i].text = challenges[i].GetDescription();
                }
                i = 0;
                currentChallenge = challenges[i];
            }
        }
    }
}
