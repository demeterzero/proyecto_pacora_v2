using UnityEngine;
using System.Collections;

public class KaDialogo4 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().happy <= 25.0f) {
			Instantiate(baseTalk);
			GameObject.Find("KalitoBase2(Clone)").GetComponent<KalitoBase>().whichTalk = 4;
			Destroy(this);
		}
	}
}
