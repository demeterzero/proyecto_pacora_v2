using UnityEngine;
using System.Collections;

public class AlcConv2 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<Watch> ().currentTurn >= 25) {
			Instantiate(baseTalk);
			GameObject.Find("AlcaldeBase(Clone)").GetComponent<AlcaldeBase>().whichTalk = 2;
			Destroy(this);
		}
	}
}
