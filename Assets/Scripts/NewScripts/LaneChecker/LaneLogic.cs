using UnityEngine;
using System.Collections;

public class LaneLogic : MonoBehaviour {

    public bool left = false, straight = false;
    public int whatSide = 0, choiceGiven = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Check for current possibilities
        if (left && straight)
            whatSide = 2;
        else if ((left && !straight) || (!left && straight))
            whatSide = 1;
	
	}

    public void OnTriggerEnter(Collider thisCar)
    {
        if (thisCar.tag == "Car")
        {
            //Switch to know which side to pick and throw a random number for it
            switch (whatSide)
            {
                //Right side only
                case 0:
                    //GETCOMPONENT for CarAI
                    //print("Right was decided!");
                    choiceGiven = 0;
                    thisCar.GetComponent<CarAI3>().thisTurn = 0;
                    break;

                //Left OR Straight is available
                case 1:
                    choiceGiven = Random.Range(0, 2);

                    if (choiceGiven == 1 && left)
                    {
                        //go Left
                        //print("Left was decided from CASE 1!");
                        thisCar.GetComponent<CarAI3>().thisTurn = 2;
                    }
                    else if (choiceGiven == 1 && straight)
                    {
                        //go Straight
                        //print("Straight was decided from CASE 1!");
                        thisCar.GetComponent<CarAI3>().thisTurn = 1;
                    }
                    else if (choiceGiven == 0)
                    {
                        //go Right
                        thisCar.GetComponent<CarAI3>().thisTurn = 0;
                       // print("Right was decided from CASE 1!");

                    }

                    break;

                //Left AND Straight is available
                case 2:
                    //print("Multiple choice!");
                    choiceGiven = Random.Range(0, 3);
                    thisCar.GetComponent<CarAI3>().thisTurn = choiceGiven;
                    break;
            }

            //Resets choice
            choiceGiven = -1;
        }
    }
}
