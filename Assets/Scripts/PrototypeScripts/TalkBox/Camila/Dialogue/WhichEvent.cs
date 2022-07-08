using UnityEngine;
using System.Collections;

public class WhichEvent : MonoBehaviour {

	//public int thisTalk, theEvents;
	public GameObject baseTalk;

	// Update is called once per frame
	void Update () {

		if (GetComponentInParent<GameScore> ().houseCount >= 2) {
			Instantiate(baseTalk);
				GameObject.Find("CamilaBase(Clone)").GetComponent<CamilaBase>().whichTalk = 1;
			Destroy(this);
		}
	
	}
}
