using UnityEngine;
using System.Collections;

public class AlcConv1 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<Watch> ().currentTurn >= 13) {
			Instantiate(baseTalk);
			GameObject.Find("AlcaldeBase(Clone)").GetComponent<AlcaldeBase>().whichTalk = 1;
			Destroy(this);
		}
	}
}
