using UnityEngine;
using System.Collections;

public class CarAI2 : MonoBehaviour {

    public float startCurve, endCurve;
    public float currentCurve, turnSpeed = 90;
    public bool isTurning = false; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime / 2);
        currentCurve = transform.localEulerAngles.y;

        if (currentCurve == 0)
            currentCurve = 360;

        if (isTurning)
        {
            this.gameObject.transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.Self);
            
            if(endCurve == 0)
            {
                if(currentCurve <= 5 || currentCurve >= 355)
                {
                    transform.localEulerAngles = new Vector3(0, endCurve, 0);
                    isTurning = false;
                    startCurve = 20;
                    endCurve = 20;

                    print("I finished turning (special)");
                }
            }
            else if (currentCurve-10 <= endCurve)
            {
                transform.localEulerAngles = new Vector3(0, endCurve, 0);
                isTurning = false;
                startCurve = 0;
                endCurve = 0;

                print("I finished turning");

            }
        }


    }

    void OnTriggerEnter(Collider col) {

        //if(col.name.Contains("what"))

        print("It started! with "+transform.eulerAngles.y);

        startCurve = Mathf.Floor(transform.eulerAngles.y);

        //Fix to avoid bugs
        if (startCurve == 0)
            startCurve = 360;

        //Get the final angle of the car that you're looking for
        endCurve = startCurve - 90;

        //Fix to avoid bug
        if (endCurve < 0)
            endCurve = 90;

        isTurning = true;

    }

}
