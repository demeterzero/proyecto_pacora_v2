using UnityEngine;
using System.Collections;

public class WalkingBoxAI : MonoBehaviour {

    public int whatNum = 0;
    public bool northR, southR, westR, eastR, north = false, south = false, west = false, east = false;
    public float curRot;
	
    /*
	// Update is called once per frame
	void Update () {

        
	
	}

    void OnTriggerEnter(Collider person)
    {

        if(person.tag == "People")
        {
            //Get what side the person is comming from
            curRot = person.transform.localEulerAngles.y;
            //print("The current y curve non-function is: " + curRot);

            GetDir(curRot);

            //Set Random Number for path
            whatNum = Random.Range(1, 5);
            
            //Detect which path to take Function
            WhatPath(person);

        }
    }

    public void WhatPath(Collider per)
    {
        switch (whatNum)
        {
                //Up
            case 1:

                if (north)
                {
                    print("North was decided");
                    per.GetComponent<PedestrianAI>().decision = 1;
                }
                else if(!north)
                {
                    whatNum++;
                    WhatPath(per);
                }

                break;

                //Right
            case 2:

                if (east)
                {
                    print("East was decided");
                    per.GetComponent<PedestrianAI>().decision = 2;
                }
                else if (!east)
                {
                    whatNum++;
                    WhatPath(per);
                }

                break;

                //Down
            case 3:

                if (south)
                {
                    print("South was decided");
                    per.GetComponent<PedestrianAI>().decision = 3;
                }
                else if (!south)
                {
                    whatNum++;
                    WhatPath(per);
                }

                break;

                //Left
            case 4:

                if (west)
                {
                    print("West was decided");
                    per.GetComponent<PedestrianAI>().decision = 4;
                }
                else if (!west)
                {
                    whatNum=1;
                    WhatPath(per);
                }

                break;
        }
    }

    public void GetDir(float x)
    {
        north = northR;
        south = southR;
        west = westR;
        east = eastR;

        print("The current y curve in function is: "+x);

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
            print("THIS PERSON FAILED TO RETAIN THE RIGHT ROTATION");
        }
    }

    */

}
