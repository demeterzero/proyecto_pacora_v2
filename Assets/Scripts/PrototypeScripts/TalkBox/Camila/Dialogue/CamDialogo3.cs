using UnityEngine;
using System.Collections;

public class CamDialogo3 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<Watch> ().currentTurn >= 18) {
			Instantiate(baseTalk);
				GameObject.Find("CamilaBase(Clone)").GetComponent<CamilaBase>().whichTalk = 3;			
			Destroy(this);
		}
}
}
