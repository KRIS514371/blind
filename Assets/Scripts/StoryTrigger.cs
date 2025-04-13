using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public bool hasDone = false;
    public string name;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && !hasDone)
        {
            Debug.Log("´¥·¢Story" + gameObject.name);
            GameManager.Instance.storyManager.LoadStory(name);

            hasDone = true; 
        }
    }
}
