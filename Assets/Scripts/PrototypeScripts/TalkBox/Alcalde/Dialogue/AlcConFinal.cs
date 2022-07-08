using UnityEngine;
using System.Collections;

public class AlcConFinal : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<Watch> ().currentTurn >= 49) {
			Instantiate(baseTalk);
			//GameObject.Find("AlcaldeFinal(Clone)").GetComponent<AlcaldeBase>().whichTalk = 3;
			Destroy(this);
		}
	}
}
