using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

	public float speedModifier = 1.0f;

	// Use this for initialization
	void Start () {
	
		transform.localEulerAngles = new Vector3 (0, 90, 0);

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.right * (Time.deltaTime * speedModifier), Space.World);

		if (this.gameObject.transform.position.x >= 18) {
			Destroy(this.gameObject);
		}
	
	}
}
