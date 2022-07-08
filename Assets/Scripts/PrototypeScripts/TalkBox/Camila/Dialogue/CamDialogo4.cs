using UnityEngine;
using System.Collections;

public class CamDialogo4 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().greenCount > 0) {
			Instantiate(baseTalk);
			GameObject.Find("CamilaBase(Clone)").GetComponent<CamilaBase>().whichTalk = 4;
			Destroy(this);
		}
	}
}
