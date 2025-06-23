using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SubtitleManager : MonoBehaviour
{
    public static SubtitleManager instance;
    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    [Header("UIroot")]
    public Transform tragetTransform;
    [Header("Prefab")]
    public GameObject TextUI;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in tragetTransform)
        {
            Destroy(item.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    DialogObj dialogObj;
    public void ShowSubtitle(string content)
    {
        if(dialogObj != null) Destroy (dialogObj.gameObject);
        dialogObj = Instantiate(TextUI, tragetTransform).GetComponent<DialogObj>();
        dialogObj.tmpTxt.text = content;  
    }

    public void EndSubtite()
    { 
        if(dialogObj !=null) dialogObj.EndDialog(); 
    }
}
