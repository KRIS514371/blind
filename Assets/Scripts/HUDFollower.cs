using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFollower : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public float offsetDistance = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.Lerp(transform.position, target.position +  (target.transform.forward *offsetDistance), Time.deltaTime * followSpeed);
        transform.position = pos;   
        
       // Quaternion  rot = Quaternion.Lerp(transform.rotation, , Time.deltaTime * followSpeed);

        transform.rotation = Quaternion.LookRotation(target.transform.forward, Vector3.up);
    }
}
