using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogObj : MonoBehaviour
{
    public TMP_Text tmpTxt;
    public float fadeOutTime = 1;
    CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndDialog()
    {
        tmpTxt.text = "";
        Debug.Log("EndDialog");

        StartCoroutine(FadeOut());
    }
 

    IEnumerator FadeOut()
    {
        Debug.Log("EndDialog" + fadeOutTime);
        float start = fadeOutTime;
        while (fadeOutTime > 0)
        {
            canvasGroup.alpha = start / fadeOutTime;

            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
