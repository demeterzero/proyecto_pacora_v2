using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingTooltip : MonoBehaviour {

	public Canvas ToolTipCanvas;
	public GameObject baseImage, mc;
	public Text name, total, bonuses;
	public bool thisUI = false;

	private Vector3 offset = new Vector3 (125, 50, 0);

	// Use this for initialization
	void Start () {
	
		ToolTipCanvas.enabled = false;
		mc = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

		if (ToolTipCanvas.enabled && thisUI) {
			name.text = transform.name;
			total.text = GetComponent<HousingLogic> ().curCap + " / " + GetComponent<HousingLogic> ().maxCap;
			bonuses.text = "To be worked on";
			baseImage.GetComponent<RectTransform> ().localPosition = (Input.mousePosition - ToolTipCanvas.GetComponent<RectTransform>().localPosition + offset);
		}
	
	}

	void OnMouseEnter(){
		//print ("Mouse entered!!");

		//Check to make sure other UIs do not appear and bother the player
		if(mc.GetComponent<CameraMovement>().isSelect == false && !thisUI)
			ActiveOnHover ();
	}

	void OnMouseExit(){
		//print ("Mouse left!!");
		if(thisUI)
			DisableWhenAway ();
	}

	public void ActiveOnHover(){
		ToolTipCanvas.enabled = true;
		thisUI = true;
		mc.GetComponent<CameraMovement> ().isSelect = true;
	}

	public void DisableWhenAway(){
		ToolTipCanvas.enabled = false;
		thisUI = false;
		mc.GetComponent<CameraMovement> ().isSelect = false;
	}
}
