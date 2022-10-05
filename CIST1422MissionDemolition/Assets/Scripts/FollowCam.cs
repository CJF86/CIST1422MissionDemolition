using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //creates basic follow camera 
    
    static public GameObject POI;

   [Header("Inscribed")]
   public float Easing = 0.05f; 
   public Vector2 Min_XY = Vector2.zero;

    [Header("Dynamic")]
    public float CamZ;

    private void Awake()
    {
        CamZ = this.transform.position.z;

    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(POI == null) return;

        Vector3 destination = Vector3.zero;

        if(POI != null)
        {
            Rigidbody POI_Rigid = POI.GetComponent<Rigidbody>();
            print("POI trigger");

            if((POI_Rigid != null) && (POI_Rigid.IsSleeping()))
            {
                POI = null;
                print("nested if trigger");

            }

        }

        if(POI != null)
        {
            destination = POI.transform.position;
            print("last if trigger");

        }
        
        destination.x = Mathf.Max(Min_XY.x,destination.x);
        destination.y = Mathf.Max(Min_XY.y,destination.y);

        //lerp stands for linear interpolation
        destination = Vector3.Lerp(transform.position,destination,Easing);

        destination.z = CamZ;

        transform.position = destination;

        //sets orthographic size of the camera to keep the ground in view

        //Camera.main.orthographic.size = destination.y + 10;

        
    }
}
