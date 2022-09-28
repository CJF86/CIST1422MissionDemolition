using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //creates basic follow camera 
    
    static public GameObject POI;

    [Header("Dynamic")]
    public float CamZ;

    private void Awake()
    {
        CamZ = this.transform.position.z;

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(POI == null) return;

        Vector3 destination = POI.transform.position;

        destination.z = CamZ;

        transform.position = destination;

        
    }
}
