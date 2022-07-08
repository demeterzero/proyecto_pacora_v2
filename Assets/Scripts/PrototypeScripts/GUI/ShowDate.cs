using UnityEngine;
using System.Collections;

public class ShowDate : MonoBehaviour {

	public bool showDate = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		if (showDate) {

			GUI.Label (new Rect (830, 80, 80, 20), GetComponentInParent<Watch> ().month);
			GUI.Label (new Rect (900, 80, 40, 20), GetComponentInParent<Watch> ().year.ToString ());

		}

	}
}
