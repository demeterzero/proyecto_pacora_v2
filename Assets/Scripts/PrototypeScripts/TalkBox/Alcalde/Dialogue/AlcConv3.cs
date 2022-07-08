using UnityEngine;
using System.Collections;

public class AlcConv3 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<Watch> ().currentTurn >= 37) {
			Instantiate(baseTalk);
			GameObject.Find("AlcaldeBase(Clone)").GetComponent<AlcaldeBase>().whichTalk = 3;
			Destroy(this);
		}
	}
}
