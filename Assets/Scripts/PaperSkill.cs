using System.Collections;
using UnityEngine;

public class PaperSkill : MonoBehaviour
{
    public Transform handRef;
    public Transform Paper;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        Paper.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = handRef.transform.position;
    }

    public void Trigger()
    {
        Debug.Log("Trigger");
        Paper.gameObject.SetActive(true);
        particle.Play();
        
    }
    
    public void UnTrigger()
    {
        Debug.Log("Trigger");
        Paper.gameObject.SetActive(false);
        particle.Stop();
    }
}
