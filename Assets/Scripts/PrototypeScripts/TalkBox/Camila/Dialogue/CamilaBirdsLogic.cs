using UnityEngine;
using System.Collections;

public class CamilaBirdsLogic : MonoBehaviour {

	// Use this for initialization
	public GameObject baseTalk, bird;
	public AudioClip birdSounds;
	public bool isTalking=false, noMoreBirds = false;
	public float timer = 0, totalTimer = 0;

	// Update is called once per frame
	void Update () {
		
		if (GetComponentInParent<GameScore> ().nature >= 75 && !isTalking) {
			Instantiate(baseTalk);
			GameObject.Find("CamilaBase(Clone)").GetComponent<CamilaBase>().whichTalk = 5;
			GetComponent<AudioSource>().PlayOneShot(birdSounds);
			isTalking = true;
		}

		if (isTalking) {
			timer += Time.deltaTime;
			totalTimer += Time.deltaTime;
		}

		if (timer > 4 && !noMoreBirds) {

			Instantiate(bird,new Vector3(-22, 0.9f, Random.Range(-15.0f, -9.0f)), Quaternion.Euler(0,90,0));
			timer = 0;
		}

		if (totalTimer >= 31) {
			noMoreBirds = true;
		}

		if (totalTimer >= 59) {
			Destroy(this);
		}
	}
}
