using UnityEngine;
using System.Collections;

public class AIRay : MonoBehaviour {

    public float length = 10, rayAngle = 15, frontRayLength = 0.25f, sideRayLength = 0.25f;
    public bool colDetec = false;
    public Vector3 rayPos, leftPos, rightPos, leftRayRot, rightRayRot;
    public Ray mainRay, leftRay, rightRay;
    public RaycastHit hitInfo;

	// Use this for initialization
	void Start () {

     }

    // Update is called once per frame
    void Update() {

        //Angles and Directions
        rayPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //leftPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //rightPos = new Vector3(transform.position.x  * -offset, transform.position.y, transform.position.z) ;

        //endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        leftRayRot = Quaternion.AngleAxis(-rayAngle, transform.up) * transform.forward;
        rightRayRot = Quaternion.AngleAxis(rayAngle, transform.up) * transform.forward;

        //Declaration of Rays
        mainRay = new Ray(rayPos, transform.forward);
        leftRay = new Ray(rayPos, leftRayRot);
        rightRay = new Ray(rayPos, rightRayRot);

        /* DEBUG RAYS
        Debug.DrawRay(rayPos, transform.forward);
        Debug.DrawRay(rayPos, leftRayRot, Color.white);
        Debug.DrawRay(rayPos, rightRayRot, Color.white);
        */

        //LOGIC TO SEE IF ANY CARS ARE FOUND WITH ANY OF THE THREE RAYS
        if (Physics.Raycast(mainRay, out hitInfo, frontRayLength, 1 << 8))
        {
            
                colDetec = true;
            
        }

        if (Physics.Raycast(leftRay, out hitInfo, sideRayLength, 1 << 8))
        {
            
                colDetec = true;
            
        }

        if (Physics.Raycast(rightRay, out hitInfo, sideRayLength, 1 << 8))
        {
            
                colDetec = true;
            
        }

        //THE GAMEBREAKER TO STOP AND GO THE CAR GOES HERE
        if (colDetec) { 
        GetComponentInParent<CarAI3>().carMovement = false;
        colDetec = false;
        }
        else
            GetComponentInParent<CarAI3>().carMovement = true;


    }
}
