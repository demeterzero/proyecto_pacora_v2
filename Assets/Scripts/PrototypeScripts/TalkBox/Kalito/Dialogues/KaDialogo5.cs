using UnityEngine;
using System.Collections;

public class KaDialogo5 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().nature <= 25) {
			Instantiate(baseTalk);
			GameObject.Find("KalitoBase2(Clone)").GetComponent<KalitoBase>().whichTalk = 5;
			Destroy(this);
		}
	}
}
