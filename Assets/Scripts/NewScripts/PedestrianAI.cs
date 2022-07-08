using UnityEngine;
using System.Collections;

public class PedestrianAI : MonoBehaviour {

    public float speed = 0.3f, turnSpeed = 90, startCurve, endCurve, currentCurve;
    public int decision = 0, myCurve = -1;
    public bool goRight = false, north, south, east, west;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (decision > 0 && myCurve > 0)
        {

            //Get current Angle for calculations
            currentCurve = transform.localEulerAngles.y;

            if (goRight)
            {
                this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.Self);

                if(currentCurve + 2 >= endCurve && (endCurve != 0 || endCurve != 360))
                {
                    //print("I turned to the right!");
                    FinishTurning();
                }
                else if ((endCurve == 0 || endCurve >= 360) && (currentCurve >= 358 || currentCurve <= 2))
                {
                    FinishTurning();
                }
            }
            else
            {
                this.gameObject.transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.Self);

                /*if (currentCurve - 2 <= endCurve)
                {
                    print("I turned to the left!");
                    FinishTurning();
                }*/

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

            }
            
        }

    }

    void OnTriggerEnter(Collider col)
    {

        //Make sure its these colliders
        if (col.tag == "PedestrianBox")
        {

            startCurve = Mathf.Floor(transform.eulerAngles.y);

            ///////////////////TRANSFER/////////////////////

            //Get True and False of Directions from collider + False from the direction the Person is commin
            GetDir(startCurve, col);

            //Set Random Number for path
            decision = Random.Range(1, 5);

            //Detect which path to take Function
            WhatPath();

            //////////////////END//////////////////////////

            //Logic to determin direction is the player comming from right now
            if (startCurve == 0 || startCurve == 360)
            {
                myCurve = 1;
            }
            else if(startCurve == 90)
            {
                myCurve = 2;
            }
            else if (startCurve == 180)
            {
                myCurve = 3;
            }
            else if (startCurve == 270)
            {
                myCurve = 4;
            }

            //print("My decision is " + decision + ", and my curve is " + myCurve);


            //Go Straight Logic
            if (decision == myCurve)
            {
                //DoNothing
                endCurve = startCurve;
                FinishTurning();
            }
            //GoRightLogic
            else if(myCurve < decision && (myCurve != 1 || decision != 4) || (myCurve == 4 && decision == 1))
            {
                endCurve = startCurve + 90;
                goRight = true;
                //print("Registered for right!");
            }
            //GoLeftLogic
            else if (myCurve > decision && (myCurve != 4 || decision != 1) || (myCurve == 1 && decision == 4))
            {

                if (startCurve == 0)
                    startCurve = 360;
                
                endCurve = startCurve - 90;
                goRight = false;
                //print("Registered for left!");
            }

        }
    }
    

    public void FinishTurning()
    {
        transform.localEulerAngles = new Vector3(0, endCurve, 0);
        decision = 0;
        startCurve = 0;
        endCurve = 0;
        myCurve = 0;
        goRight = false;
    }

    ///////////////////////TRANSFERED FUNCTIONS/////////////////////////////

    public void GetDir(float x, Collider c)
    {
        north = c.GetComponent<WalkingBoxAI>().northR;
        south = c.GetComponent<WalkingBoxAI>().southR;
        west = c.GetComponent<WalkingBoxAI>().westR;
        east = c.GetComponent<WalkingBoxAI>().eastR;

        //print("The current y curve in function is: " + x);

        //Going Up
        if (x < 1 || x > 359)
        {
            //Touched UpLeft and UpRight
            south = false;
        }
        //Going Right
        else if (x >= 89 && x <= 91)
        {
            //Touches UpRight and DownRight
            west = false;
        }
        //Going Down
        else if (x > 179 && x < 181)
        {
            //Touches DownLeft and DownRight
            north = false;
        }
        //Going Left
        else if (x > 269 && x < 271)
        {
            //touched UpLeft and DownLeft
            east = false;
        }
        else
        {
            //print("THIS PERSON FAILED TO RETAIN THE RIGHT ROTATION");
        }
    }

    public void WhatPath()
    {
        switch (decision)
        {
            //Up
            case 1:

                if (north)
                {
                    //print("North was decided");
                    decision = 1;
                }
                else if (!north)
                {
                    decision++;
                    WhatPath();
                }

                break;

            //Right
            case 2:

                if (east)
                {
                    //print("East was decided");
                    decision = 2;
                }
                else if (!east)
                {
                    decision++;
                    WhatPath();
                }

                break;

            //Down
            case 3:

                if (south)
                {
                    //print("South was decided");
                    decision = 3;
                }
                else if (!south)
                {
                    decision++;
                    WhatPath();
                }

                break;

            //Left
            case 4:

                if (west)
                {
                    //print("West was decided");
                    decision = 4;
                }
                else if (!west)
                {
                    decision = 1;
                    WhatPath();
                }

                break;
        }
    }

}
