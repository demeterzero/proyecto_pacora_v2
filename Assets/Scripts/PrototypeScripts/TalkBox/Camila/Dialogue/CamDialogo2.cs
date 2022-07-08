using UnityEngine;
using System.Collections;

public class CamDialogo2 : MonoBehaviour {

	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().houseCount >= 4) {
			Instantiate(baseTalk);
				GameObject.Find("CamilaBase2(Clone)").GetComponent<CamilaBase>().whichTalk = 2;
			Destroy(this);
		}
}
}
