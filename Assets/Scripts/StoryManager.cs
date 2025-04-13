using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{



    public Story[] stories;


    private void Start()
    {
        
    }

    public void LoadStory(int index)
    {
        LoadStory(stories[index]);
    }

    /// <summary>
    /// 开始故事
    /// </summary>
    /// <param name="name">故事名</param>
    public void LoadStory(string name)
    {
        foreach (Story story in stories)
        {

            if (story.name == name)
            {
                LoadStory(story);
            }
        }
    }

    private void LoadStory(Story story)
    {
        GameManager.Instance.playableDirector.Play(story.timelineAsset);

    }
}
