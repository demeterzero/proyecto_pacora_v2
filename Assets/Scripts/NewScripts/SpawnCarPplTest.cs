using UnityEngine;
using System.Collections;

public class SpawnCarPplTest : MonoBehaviour {

	public GameObject person, car, peopleSpawn, carSpawn;
	public bool doSpawn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!Input.GetKey (KeyCode.Mouse0) && !Input.GetKey (KeyCode.Mouse1)) {

			doSpawn = false;
		}
	
	}

	void OnMouseOver(){

		if (Input.GetKey (KeyCode.Mouse0) && !doSpawn) {
			if (Random.Range (0, 2) > 0) 
				Instantiate (person, peopleSpawn.transform.position, Quaternion.Euler (0, 90, 0));
			else
				Instantiate (person, peopleSpawn.transform.position, Quaternion.Euler (0, 270, 0));
			doSpawn = true;
		}

		if (Input.GetKey (KeyCode.Mouse1) && !doSpawn) {
	
				Instantiate (car, carSpawn.transform.position, Quaternion.Euler (0, 90, 0));

			doSpawn = true;
		}
	}
}
