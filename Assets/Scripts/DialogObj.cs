using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogObj : MonoBehaviour
{
    public TMP_Text tmpTxt;
    public float fadeOutTime = 2;
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
        StartCoroutine(FadeOut());
    }
 

    IEnumerator FadeOut()
    {
        Debug.Log("EndDialog" + fadeOutTime);
        float timer = fadeOutTime;
        while (timer > 0)
        {
            yield return new WaitForEndOfFrame();
            timer -= Time.deltaTime;
            canvasGroup.alpha = timer / fadeOutTime;
           //tmpTxt.text = canvasGroup.alpha.ToString();
        }
        Destroy(gameObject);
    }
}
