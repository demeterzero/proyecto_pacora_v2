using UnityEngine;
using System.Collections;

public class DonConv4 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().houseBigCount <= 4 && GetComponentInParent<Watch>().currentTurn >= 26) {
			Instantiate (baseTalk);
			GameObject.Find ("DonDineroBase(Clone)").GetComponent<StartGameBox> ().whichTalk = 4;
			Destroy (this);
		}
	}
}
