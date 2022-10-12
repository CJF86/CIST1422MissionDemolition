using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class RigidBodySleep : MonoBehaviour
{
    private int sleepCountDown = 4;

    

    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();


    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(sleepCountDown > 0)
        {
            rigid.Sleep();
            sleepCountDown--;


        }
        
    }
}
