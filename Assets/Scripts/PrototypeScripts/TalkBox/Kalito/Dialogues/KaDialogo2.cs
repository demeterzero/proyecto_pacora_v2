using UnityEngine;
using System.Collections;

public class KaDialogo2 : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk;
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().houseCount >= 4 && GetComponentInParent<GameScore>().farmCount >= 3) {
			Instantiate(baseTalk);
			GameObject.Find("KalitoBase(Clone)").GetComponent<KalitoBase>().whichTalk = 2;
			Destroy(this);
		}
	}
}
