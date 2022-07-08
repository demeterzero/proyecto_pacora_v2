using UnityEngine;
using System.Collections;

public class CarAI : MonoBehaviour {

    public float turnSpeed = 1;

   public int startRot, desRot;
   public float curRot;
   // public float desRot;

    public bool doRotation = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime/2);

        if (doRotation)
        {
            transform.rotation = Quaternion.Lerp(new Quaternion(0, startRot, 0, 1), new Quaternion(0, desRot, 0, 1), Time.deltaTime * turnSpeed);
            //this.gameObject.transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.Self);

            curRot = transform.localEulerAngles.y;

            if(curRot < desRot)
            {
                doRotation = false;
                this.gameObject.transform.Rotate(new Vector3(0, desRot, 0));
            }

           // print("Y is "+ this.gameObject.transform.localEulerAngles.y + ", looking for " + desRot);
           
            /*
            if(curRot <= desRot || (curRot > desRot+340))
            {
                print("Cap reached!");
                doRotation = false;
                this.gameObject.transform.Rotate(new Vector3(0, desRot, 0));

                /*
                if (transform.localEulerAngles.y > 20 && transform.localEulerAngles.y < 340)
                    this.gameObject.transform.Rotate(0, 0, 0);

                if (transform.localEulerAngles.y > 70 && transform.localEulerAngles.y < 110)
                    this.gameObject.transform.Rotate(0, 90, 0);

                if (transform.localEulerAngles.y > 160 && transform.localEulerAngles.y < 210)
                    this.gameObject.transform.Rotate(0, 180, 0);

                if (transform.localEulerAngles.y > 250 && transform.localEulerAngles.y < 290)
                    this.gameObject.transform.Rotate(0, 270, 0);
                    

                curRot = desRot;
            }
            */
        }
	
	}

    void OnTriggerEnter(Collider col)
    {

        curRot = transform.localRotation.y;

        startRot = (int)Mathf.Floor(curRot);

        switch ((int)Mathf.Floor(curRot))
        {
            case 0:
                desRot = 270;
                break;

            case 90:
                desRot = 0;
                break;

            case 180:
                desRot = 90;
                break;

            case 270:
                desRot = 180;
                break;
        }



        //print(transform.localEulerAngles.y + ", and substracted is: " + float.Parse(transform.localEulerAngles.y) - 90.0f);

        //desRot = transform.localRotation.y - 90.0f;

        //print(transform.localRotation.y - 90f);

        //print(transform.localEulerAngles.y - 90);

        doRotation = true;

    }

}
