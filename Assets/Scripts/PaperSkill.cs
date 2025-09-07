using System.Collections;
using Oculus.Interaction;
using UnityEngine;

public class PaperSkill : MonoBehaviour
{
    public GrabInteractable grabPaper;
    public bool enableSkill = false;
    public Transform handRef;
    public Transform Paper;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        Paper.gameObject.SetActive(false);
        particle.Stop();
    }

    void CheckPick(InteractableStateChangeArgs  args)
    {
        // if (grabPaperInteractor.State == InteractorState.Select)
        // {
        //     Debug.Log("成功拿取" + grabPaperInteractor.State);
        //     enableSkill = true;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = handRef.transform.position;
        transform.rotation = handRef.transform.rotation;
    }

    public void EnableSkill()
    {
        enableSkill = true;
    }

    public void Trigger()
    {
        if(!enableSkill) return;
        Debug.Log("Trigger");
        Paper.gameObject.SetActive(true);
        particle.Play();
        
    }
    
    public void UnTrigger()
    {
        if(!enableSkill) return;
        Debug.Log("Trigger");
        Paper.gameObject.SetActive(false);
        particle.Stop();
    }
}
