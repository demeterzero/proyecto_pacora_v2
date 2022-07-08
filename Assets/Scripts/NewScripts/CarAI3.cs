using UnityEngine;
using System.Collections;

public class CarAI3 : MonoBehaviour {

    public bool carMovement = true, isTurning = false;
    public float startCurve, endCurve, currentCurve, LeftSpeed = 90, RightSpeed = 180;
    public int thisTurn = -1;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        //Tell the car to move
        if (carMovement)
            transform.Translate(Vector3.forward * Time.deltaTime / 2);

        //Get current Angle for calculations
        currentCurve = transform.localEulerAngles.y;

        //START LOGIC
        if(isTurning && thisTurn > -1 && carMovement)
        {
            switch (thisTurn)
            {
                case 0:

                    this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * RightSpeed, Space.Self);

                    if (currentCurve + 2 >= endCurve && (endCurve != 0 || endCurve != 360))
                    {

                        FinishTurning();

                        //print("I finished turning to the right!");

                    }
                    else if((endCurve == 0 || endCurve >= 360) && (currentCurve >= 358 || currentCurve <= 2))
                    {
                        FinishTurning();

                       //print("I finished turning to the right! (special)");
                    }

                    break;

                case 1:

                    //Do nothing because it's going straight!

                    //print("I'm an independent Latin Car and I need no curve!");

                    break;

                case 2:

                    this.gameObject.transform.Rotate(Vector3.down * Time.deltaTime * LeftSpeed, Space.Self);

                    if ((endCurve == 0 && (currentCurve <= 2 || currentCurve >= 358)) || (endCurve == 270 && currentCurve <= 272 && currentCurve > 5))
                    {
                        //print("Left 1");
                        FinishTurning();

                       // print("I finished turning to the left! (special)");
                    }

                   else if (currentCurve - 2 <= endCurve && endCurve != 270)
                    {
                        //print("Left 2");
                        FinishTurning();

                        //print("I finished turning to the left!");

                    }
                   /* else if(endCurve == 270 && currentCurve <= 272 && currentCurve > 5)
                    {
                        print("Left 3");
                        FinishTurning();
                    }*/

                    break;
            }
        }

    }

    void OnTriggerEnter (Collider col)
    {
       // print("Collision detected.. its a...");

        //Make sure its these colliders, avoids bus colliders
        if(col.name == "UpLeft" || col.name == "UpRight" || col.name == "DownRight" || col.name == "DownLeft")
        {
            switch (thisTurn)
            {
                case 0:

                    //print("Right!");

                    startCurve = Mathf.Floor(transform.eulerAngles.y);

                    //Fix to avoid negative numbers
                    if (startCurve >= 359)
                        startCurve = 0;

                    //Get the final angle of the car that you're looking for
                    endCurve = startCurve + 90;

                    //If finishing curve is above desired limit, to reposition
                    if (endCurve >= 360 || endCurve <= 0)
                        endCurve = 360;

                   // print("The starting curve is " + startCurve + ", and the desired curve is "+endCurve);

                    break;

                case 1:
                    //print("Straight!");
                    //Do nothing because it's going straight!
                    break;

                case 2:
                    //print("Left!");

                    startCurve = Mathf.Floor(transform.eulerAngles.y);

                    //Fix offset to avoid negative numbers
                    if (startCurve == 0)
                    {
                        startCurve = 360;
                        //currentCurve = 359.9999f;
                    }
                    //Get the final angle of the car that you're looking for
                    endCurve = startCurve - 90;

                    //Fix to avoid bug
                   // if (startCurve >= 359)
                    //    endCurve = 270;

                    break;
            }
        }

        isTurning = true;

    }

    public void FinishTurning()
    {
        transform.localEulerAngles = new Vector3(0, endCurve, 0);
        isTurning = false;
        thisTurn = -1;
        startCurve = 0;
        endCurve = 0;
    }

}
