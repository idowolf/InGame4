using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelButton : MonoBehaviour
{
    public float gazeTime = 1f;
    private float timer;
    private bool gazedAt;
    public LifeBar lifeBar;
    public string nextScene = "1-1";
    public string transitionText;
    // Use this for initialization
    void Start()
    {
        EventTrigger trigger = GetComponentInParent<EventTrigger>();
        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerEnter;
        entry1.callback.AddListener((eventData) => { PointerEnter(); });
        trigger.triggers.Add(entry1);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerDown;
        entry2.callback.AddListener((eventData) => { PointerDown(); });
        trigger.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerExit;
        entry3.callback.AddListener((eventData) => { PointerExit(); });
        trigger.triggers.Add(entry3);
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
        Debug.Log(nextScene);
        PracticeDialogManager.SetNameAndLevel(transitionText, nextScene);
        SceneManager.LoadScene("intro");
    }
    public void PointerDownExit()
    {
        //Application.Quit();
    }
}
