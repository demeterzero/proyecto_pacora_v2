using UnityEngine;
using System.Collections;

public class ChildColor : MonoBehaviour {

	public Color startColor;
	public GameObject selection;

	// Use this for initialization
	void Start () {
		startColor = GetComponentInChildren<Renderer> ().material.color;
		selection = GameObject.Find ("MainGameLogic");
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponentInParent<TerrainSelect> ().isTouch || GetComponentInParent<TerrainSelect>().lockTouch) {
			GetComponentInChildren<Renderer> ().material.color = Color.yellow;
		} 
		else {
			GetComponentInChildren<Renderer> ().material.color = startColor;
		}
	
	}


}
