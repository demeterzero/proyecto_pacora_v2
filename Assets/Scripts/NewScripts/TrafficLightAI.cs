using UnityEngine;
using System.Collections;

public class TrafficLightAI : MonoBehaviour {

    public GameObject north, south, east, west;
    public float baseTime = 0, reset = 6;
    public int lightDecision = 1;
	
    void Start()
    {
        north.SetActive(false);
        south.SetActive(true);
        east.SetActive(true);
        west.SetActive(true);
    }

	// Update is called once per frame
	void Update () {

        baseTime += Time.deltaTime;

        //LOGIC FOR WHEN TIME IS UP
        if(baseTime >= reset)
        {
            lightDecision++;

            if (lightDecision > 4)
                lightDecision = 1;

            baseTime = 0;

        }

        //for lights to be enabled
        switch (lightDecision)
        {
            //NORTH
            case 1:
                north.SetActive(false);
                south.SetActive(true);
                east.SetActive(true);
                west.SetActive(true);
                break;

            //EAST
            case 2:
                north.SetActive(true);
                south.SetActive(true);
                east.SetActive(false);
                west.SetActive(true);
                break;

            //SOUTH
            case 3:
                north.SetActive(true);
                south.SetActive(false);
                east.SetActive(true);
                west.SetActive(true);
                break;

            //WEST
            case 4:
                north.SetActive(true);
                south.SetActive(true);
                east.SetActive(true);
                west.SetActive(false);
                break;
        }

	}
}
