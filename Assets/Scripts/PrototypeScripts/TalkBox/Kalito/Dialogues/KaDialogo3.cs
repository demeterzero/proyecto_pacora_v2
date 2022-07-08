using UnityEngine;
using System.Collections;

public class KaDialogo3 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<Watch> ().currentTurn >= 20) {
			Instantiate(baseTalk);
			GameObject.Find("KalitoBase(Clone)").GetComponent<KalitoBase>().whichTalk = 3;
			Destroy(this);
		}
	}
}
