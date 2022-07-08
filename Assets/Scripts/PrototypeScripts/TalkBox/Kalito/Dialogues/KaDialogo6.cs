using UnityEngine;
using System.Collections;

public class KaDialogo6 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().nature >= 55) {
			Instantiate(baseTalk);
			GameObject.Find("KalitoBase2(Clone)").GetComponent<KalitoBase>().whichTalk = 6;
			Destroy(this);
		}
	}

}