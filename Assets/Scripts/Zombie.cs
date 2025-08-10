using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float waitTime = 3f;
    NavMeshAgent  agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        StartCoroutine(DoPratrol());
    }

    public Transform[] pos;

    private int index = 0;
    IEnumerator DoPratrol()
    {
        while (true)
        {
            agent.SetDestination(pos[index].position);
        
            while (agent.remainingDistance > agent.stoppingDistance || agent.pathPending)
            {
                //Debug.Log("remainingDistance: " + agent.remainingDistance);
                yield return null;
            }

            Debug.Log("Reached point: " + index);
            index = (index + 1) % pos.Length;
            yield return new WaitForSeconds(waitTime); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
