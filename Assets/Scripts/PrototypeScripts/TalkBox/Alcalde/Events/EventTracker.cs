using UnityEngine;
using System.Collections;

public class EventTracker : MonoBehaviour {

	public int CurrEvent, FinEvent, person;
	public string dialogue;

	// Use this for initialization
	void Start () {
		person = 4;
		CurrEvent = 0;
		FinEvent = 3;
	
	}

	/// <summary>
	/// PERSONS:
	/// 1 - CAMILA
	/// 2 - KALITO
	/// 3 - DON DINERO
	/// 4 - ALCALDE
	/// </summary>

	// Update is called once per frame
	void Update () {

		//At the end of the turn, are there any new events? If so, needs to do check here

		if (CurrEvent < FinEvent) {

		}

		if (CurrEvent == FinEvent) {

			CurrEvent = 0;
			FinEvent = 0;

			//LOGIC FOR STARTING OF TURN GOES HERE


		}
	
	}
}
