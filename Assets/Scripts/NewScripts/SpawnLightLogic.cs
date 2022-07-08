using UnityEngine;
using System.Collections;

public class SpawnLightLogic : MonoBehaviour {

    public float offsetX, offsetY, offsetZ;
    public int sideCount = 0;
    public GameObject trafficLight, thisLight;

	// Update is called once per frame
	void Update () {
	
        //If we get all 3 counts, we must spawn the lighting system
        if(sideCount == 3)
        {
            //Add offset for centering
            thisLight = Instantiate(trafficLight, new Vector3 (this.gameObject.transform.position.x + offsetX, this.gameObject.transform.position.y + offsetY, this.gameObject.transform.position.z + offsetZ), this.gameObject.transform.rotation) as GameObject;
            thisLight.transform.parent = this.gameObject.transform;
            Destroy(this);
        }

	}

    void OnTriggerEnter(Collider col)
    {
        //If collision is detected, count goes up and destroys other gameobject
        if (col.transform.tag == "TrafficLight")
        {
            sideCount++;
            Destroy(col.gameObject);
        }
    }
}
