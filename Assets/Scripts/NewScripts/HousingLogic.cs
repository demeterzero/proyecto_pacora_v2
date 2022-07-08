using UnityEngine;
using System.Collections;

public class HousingLogic : MonoBehaviour {

	public int maxCap, curCap = 0, whichHouse = 0, spawnCount = 0;

	// Use this for initialization
	void Start () {
	
		//DYNAMIC LOGIC TO FIGURE WHICH TYPE OF HOUSE WAS BUILT

		if (transform.name.Contains ("Casa")) {
			whichHouse = 1;
			maxCap = 100;
		} else if (transform.name.Contains ("Mansion")) {
			whichHouse = 2;
			maxCap = 50;
		} else if (transform.name.Contains ("Apartamento")) {
			whichHouse = 3;
			maxCap = 200;
		}

		GameObject.FindWithTag ("Main").gameObject.GetComponent<GameList> ().house.Add (this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {

		//Spawn Car and Pedestrian Logic
		if (curCap / maxCap >= 0.5f && spawnCount == 0) {
			//DO SPAWN LOGIC
			spawnCount++;
		} else if (curCap / maxCap == 1 && spawnCount == 1) {
			//DO SPAWN LOGIC AGAIN
			spawnCount++;
		}
	


	}
}
