using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    [HideInInspector]
    public StoryManager storyManager;
    public PlayableDirector playableDirector;   
    // Start is called before the first frame update
    void Start()
    {
        storyManager= gameObject.GetComponent<StoryManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);   
    }

    public void UnloadScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
}
