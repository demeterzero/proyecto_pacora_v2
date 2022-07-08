using UnityEngine;
using System.Collections;

public class SetReferenceConstr : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//This is used to set the reference of the center of the building plane

		GetComponentInParent<BuildLogic> ().refPoint = this.gameObject;
		Destroy (this);
	
	}

}
