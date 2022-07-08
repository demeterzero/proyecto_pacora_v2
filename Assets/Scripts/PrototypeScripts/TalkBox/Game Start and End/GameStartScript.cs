using UnityEngine;
using System.Collections;

public class GameStartScript : MonoBehaviour {

	public Texture wallpaper, portrait;
	public GameObject nextmessage;
	public ScriptableObject script;
	public GUIStyle name, message, button;
	public GameObject mainLog;
	private string messagecontent = "Bienvenido a Nueva Pacora\n\nTu, el Inversionista, ha s sido escogido para llevar el futuro de esta ciudad. Tu objetivo es construir y desarrollar los edificios necesarios para suplir las necesidades de la comunidad. Es importante traer felicidad hacia los residentes y proteger el ambiente. \n\nDicho esto,  ¿cómo planeas construir esta ciudad?";

	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		
		GUI.BeginGroup (new Rect (Screen.width*0.075f, Screen.height*0.075f, Screen.width * 7/8, Screen.height * 7/8));
		
		//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
		GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper
		
		//GUI.DrawTexture (new Rect (100, 35, 400, 200), portrait, ScaleMode.StretchToFill, true, 1.0f); //Portrait of the character
		
		GUI.Label (new Rect (35, 60, 160, 80), "Como será tu ciudad?", name);

		GUI.Label (new Rect (40, 150, 775, 300), messagecontent, message);
		
		if (GUI.Button (new Rect (450, 450, 90, 40), "Jugar!", button)) {
			
			//Logic starts here

			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			Instantiate(nextmessage);

			Destroy(this.gameObject);
			
		}
		
		GUI.EndGroup ();
		
	}
	
}

