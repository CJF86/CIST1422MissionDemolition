using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject ProjectilePrefab;
    public float VelocityMult = 10f;
    [Header("Dynamic")]
    public GameObject LaunchPoint;
    public Vector3 LaunchPosition;
    public GameObject Projectile;
    public bool AimingMode;


    private void Awake()
    {
        Transform LaunchPointTrans = GameObject.Find("LaunchPoint").transform;
        LaunchPoint = LaunchPointTrans.gameObject;
        LaunchPoint.SetActive(false);
        LaunchPosition = LaunchPointTrans.position;

    }
    private void OnMouseEnter()
    {
        print("Slingshot:OnMouseEnter()");
        LaunchPoint.SetActive(true);

    }

    private void OnMouseExit()
    {
        print("Slingshot:OnMouseExit()");
        LaunchPoint.SetActive(false);

    }

    private void OnMouseDown()
    {
        //player has pressed mouse over slingshot
        AimingMode = true;

        //instantiate projectile
        Projectile = Instantiate(ProjectilePrefab) as GameObject;

        //set created prefab at launch point

        Projectile.transform.position = LaunchPosition;

        Projectile.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void Update()
    {
        if(!AimingMode) return;

        //gets current mouse position

        Vector3 MousePosition2D = Input.mousePosition;
        MousePosition2D.z = -Camera.main.transform.position.z;

        Vector3 MousePosition3D = Camera.main.ScreenToWorldPoint(MousePosition2D);

        Vector3 MouseDelta = MousePosition3D - LaunchPosition;

        float MaxMagnitude = this.GetComponent<SphereCollider>().radius;

        if(MouseDelta.magnitude > MaxMagnitude)
        {
            MouseDelta.Normalize();
            MouseDelta *= MaxMagnitude;

        } 

        Vector3 ProjectilePosition = LaunchPosition + MouseDelta;
        Projectile.transform.position = ProjectilePosition;

        if(Input.GetMouseButtonUp(0))
        {
            AimingMode = false;
            Rigidbody ProjectileBody = Projectile.GetComponent<Rigidbody>();
            ProjectileBody.isKinematic = false;
            ProjectileBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            ProjectileBody.velocity = -MouseDelta * VelocityMult;
            FollowCam.POI = Projectile;
            Projectile = null;
        }

    }
    
}
