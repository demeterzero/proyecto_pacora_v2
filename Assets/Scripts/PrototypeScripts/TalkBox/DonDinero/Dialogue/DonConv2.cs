using UnityEngine;
using System.Collections;

public class DonConv2 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().shopCount >= 1) {
			Instantiate (baseTalk);
			GameObject.Find ("DonDineroBase(Clone)").GetComponent<StartGameBox> ().whichTalk = 2;
			Destroy (this);
		}
	}
}
