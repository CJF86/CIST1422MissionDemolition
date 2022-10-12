using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    const int LOOKBACK_Count =10;
    [SerializeField]

    private bool Is_Awake = true;
    // Start is called before the first frame update

    public bool awake
    {
        get{return Is_Awake;}
        private set {Is_Awake = value;}

    }

    private Vector3 prevPos;

    private List<float> deltas = new List<float>();

    private Rigidbody rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        awake = true;

        prevPos = new Vector3(1000,1000,0);

        deltas.Add(1000);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rigid.isKinematic || !awake) return;

        Vector3 deltaV3 = transform.position - prevPos;

        deltas.Add(deltaV3.magnitude);

        prevPos = transform.position;

        while(deltas.Count > LOOKBACK_Count)
        {
            deltas.RemoveAt(0);

        }

        float Max_Delta = 0;

        foreach(float f in deltas)
        {
            if(f > Max_Delta) Max_Delta = f;

            if(Max_Delta <= Physics.sleepThreshold)
            {
                awake = false;
                rigid.Sleep();
            }
        }
        
    }
}
