using UnityEngine;
using System.Collections;

public class DonConv1 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().farmCount >= 3) {
			Instantiate (baseTalk);
			GameObject.Find ("DonDineroBase(Clone)").GetComponent<StartGameBox>().whichTalk = 1;
			Destroy (this);
		}
	}
}
