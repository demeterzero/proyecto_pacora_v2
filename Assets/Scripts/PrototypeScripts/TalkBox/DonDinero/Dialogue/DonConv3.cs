using UnityEngine;
using System.Collections;

public class DonConv3 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().shopCount >= 2 && GetComponentInParent<Watch>().currentTurn >= 12) {
			Instantiate (baseTalk);
			GameObject.Find ("DonDineroBase2(Clone)").GetComponent<StartGameBox> ().whichTalk = 3;
			Destroy (this);
		}
	}
}
