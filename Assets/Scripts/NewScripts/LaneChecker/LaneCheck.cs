using UnityEngine;
using System.Collections;

public class LaneCheck : MonoBehaviour {

    public GameObject laneRef, walkRefOne, walkRefTwo;

    void OnTriggerEnter(Collider col)
    {

        //print("Something came in!");

        if(col.tag == "Building")
        {
            if(this.gameObject.name == "NorthWestCheck" || this.gameObject.name == "NorthEastCheck" || this.gameObject.name == "SouthEastCheck" || this.gameObject.name == "SouthWestCheck")
            {
                //Enable left turn
                //print("left has been enabled! at "+this.gameObject.name+" from object "+ transform.parent.name);
                laneRef.GetComponent<LaneLogic>().left = true;
                
            }
            else if(this.gameObject.name == "NorthCheck" || this.gameObject.name == "SouthCheck" || this.gameObject.name == "EastCheck" || this.gameObject.name == "WestCheck")
            {
                //Enable going straight
                //print("straight has been enabled! at " + this.gameObject.name + " from object " + transform.parent.name);
                laneRef.GetComponent<LaneLogic>().straight = true;

                //WalkingCheck
                if (walkRefOne != null && walkRefTwo != null)
                    CardinalCheck();
            }

            //Destroy Logic
            Destroy(this.gameObject);
        }
    }

    void CardinalCheck()
    {
        if(this.gameObject.name == "NorthCheck")
        {
            walkRefOne.GetComponent<WalkingBoxAI>().northR = true;
            walkRefTwo.GetComponent<WalkingBoxAI>().northR = true;
        }
        else if (this.gameObject.name == "EastCheck")
        {
            walkRefOne.GetComponent<WalkingBoxAI>().eastR = true;
            walkRefTwo.GetComponent<WalkingBoxAI>().eastR = true;
        }
        else if (this.gameObject.name == "SouthCheck")
        {
            walkRefOne.GetComponent<WalkingBoxAI>().southR = true;
            walkRefTwo.GetComponent<WalkingBoxAI>().southR = true;
        }
        else if (this.gameObject.name == "WestCheck")
        {
            walkRefOne.GetComponent<WalkingBoxAI>().westR = true;
            walkRefTwo.GetComponent<WalkingBoxAI>().westR = true;
        }
    }
    

}
