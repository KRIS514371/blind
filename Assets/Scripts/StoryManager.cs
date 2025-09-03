
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class StoryManager : MonoBehaviour
{
    public Story[] stories;
    private Story _current;

    private void Start()
    {
        
    }

    public void LoadStory(int index)
    {
        if (index < 0 || index >= stories.Length) return;
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
                return;
            }
        }
    }

    public UnityEvent OnStoryEnd;

    private void LoadStory(Story story)
    {
        _current = story;
        var dir = GameManager.Instance?.playableDirector;
        if (dir != null && story.timelineAsset != null)
        {
            // 确保自然结束能回调 stopped
            dir.extrapolationMode = DirectorWrapMode.None;
            dir.Play(story.timelineAsset);
        }
     
        
        _current.OnStoryStart?.Invoke();
    }
    
    public void InvokeCurrentStoryEnd()
    {
        _current?.OnStoryEnd?.Invoke();
    }
}
