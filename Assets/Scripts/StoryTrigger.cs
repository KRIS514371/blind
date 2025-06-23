using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public bool hasDone = false;
    public string storyName;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && !hasDone)
        {
            Debug.Log("TriggerStory" + gameObject.name + storyName);
            GameManager.Instance.storyManager.LoadStory(storyName);

            hasDone = true; 
        }
    }
}
