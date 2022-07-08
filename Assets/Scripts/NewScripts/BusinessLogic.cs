using UnityEngine;
using System.Collections;

public class BusinessLogic : MonoBehaviour {

	public int maxCap, curCap = 0, whichWork = 0;

	// Use this for initialization
	void Start () {

		//DYNAMIC LOGIC TO FIGURE WHICH TYPE OF HOUSE WAS BUILT

		if (transform.name.Contains ("Granja")) {
			whichWork = 1;
			maxCap = 150;
		} else if (transform.name.Contains ("Restaurante")) {
			whichWork = 2;
			maxCap = 100;
		} else if (transform.name.Contains ("Super")) {
			whichWork = 3;
			maxCap = 150;
		} else if (transform.name.Contains ("Polic")) {
			whichWork = 4;
			maxCap = 100;
		} else if (transform.name.Contains ("Bombero")) {
			whichWork = 5;
			maxCap = 100;
		} else if (transform.name.Contains ("Hospital")) {
			whichWork = 6;
			maxCap = 200;
		} else if (transform.name.Contains ("Centro Com")) {
			whichWork = 7;
			maxCap = 400;
		} else if (transform.name.Contains ("Parque")) {
			whichWork = 8;
			maxCap = 0;
		} else if (transform.name.Contains ("Cine")) {
			whichWork = 9;
			maxCap = 100;
		} else if (transform.name.Contains ("Basura")) {
			whichWork = 10;
			maxCap = 100;
		} else if (transform.name.Contains ("Puerto")) {
			whichWork = 11;
			maxCap = 400;
		}

		GameObject.FindWithTag ("Main").gameObject.GetComponent<GameList> ().work.Add (this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
