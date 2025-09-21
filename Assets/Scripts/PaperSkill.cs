using System.Collections;
using Oculus.Interaction;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class PaperSkill : MonoBehaviour
{
    public GameObject grabPaperItem;
    public HandGrabInteractable grabPaper;
    public bool enableSkill = false;
    public Transform handRef;
    public Transform Paper;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        Paper.gameObject.SetActive(false);
        particle.Stop();
        grabPaper.WhenStateChanged += StateChanged;
        
    }

    void StateChanged(InteractableStateChangeArgs arg)
    {
        Debug.Log("grabPaper NewState:" +arg.NewState);
        if (arg.NewState == InteractableState.Select)
        {
            enableSkill = true;
        }

        if ( arg.PreviousState == InteractableState.Select &&  arg.NewState == InteractableState.Normal)
        {
            //Todo:触发消散
            grabPaperItem.SetActive(false);
        }
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
